using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Security.Policy;

namespace week5
{
    public partial class Form1 : Form
    {
        private HashSet<string> phoneNumbers = new HashSet<string>();  // 存储去重后的电话号码
        private Dictionary<string, HashSet<string>> phoneNumberUrls = new Dictionary<string, HashSet<string>>();  // 电话号码及其关联的URLs
        private IWebDriver webDriver;
        private List<string> searchURLs;

        public Form1()
        {
            InitializeComponent();
            cmbSearchEngine.SelectedIndex = 0; // 默认选择Baidu

            // 初始化进度条
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            progressBar.Value = 0;  // 初始进度为0
            // 初始化ChromeDriver
            ChromeOptions options = new ChromeOptions();
            //options.AddArgument("--headless"); 
            webDriver = new ChromeDriver(options);
            searchURLs=new List<string>();
        }

        // 异步搜索事件
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtKeyword.Text.Trim();
            string selectedEngine = cmbSearchEngine.SelectedItem.ToString();
            string searchUrl = GetSearchUrl(selectedEngine, keyword);

            if (string.IsNullOrWhiteSpace(keyword))
            {
                MessageBox.Show("请输入搜索关键词");
                return;
            }

            // 清空之前的结果
            phoneNumbers.Clear();
            phoneNumberUrls.Clear();
            dataGridViewPhones.Rows.Clear();

            // 重置进度条
            progressBar.Value = 0;

            // 启动爬虫
            await CrawlAsync(searchUrl);
        }

        // 根据用户选择返回百度或Bing的搜索URL
        private string GetSearchUrl(string engine, string keyword)
        {
            if (engine == "Baidu")
            {
                return $"https://www.baidu.com/s?wd={keyword}";
            }
            else // Bing
            {
                return $"https://www.cn.bing.com/search?q={keyword}";
            }
        }

        // 异步抓取网页内容
        private async Task CrawlAsync(string searchUrl)
        {
            try
            {
                webDriver.Navigate().GoToUrl(searchUrl);  // 使用Selenium加载页面
                var pageSource = webDriver.PageSource;  // 获取页面源代码
                var urls = ExtractUrlsFromSearchPage(pageSource);

                foreach (var targetUrl in urls)
                {
                    CrawlPhoneNumbersFromUrl(targetUrl);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error crawling {url}: {ex.Message}");
            }
        }

        // 爬取特定URL并提取电话号码
        private void CrawlPhoneNumbersFromUrl(string url)
        {
            // 检查是否已经找到100个电话号码
            if (phoneNumbers.Count >= 100) return;

            try
            {
                webDriver.Navigate().GoToUrl(url);  // 使用Selenium加载页面
                var pageSource = webDriver.PageSource;  // 获取页面源代码

                // 提取电话号码
                var phoneNumbersInPage = ExtractPhoneNumbers(pageSource);

                lock (phoneNumbers)
                {
                    foreach (var phoneNumber in phoneNumbersInPage)
                    {
                        if (phoneNumbers.Count >= 100) break; // 如果达到100个号码，停止添加

                        if (!phoneNumbers.Contains(phoneNumber))
                        {
                            phoneNumbers.Add(phoneNumber);
                            phoneNumberUrls[phoneNumber] = new HashSet<string> { url };  // 确保URL不重复

                            // 更新UI中电话号码个数的显示
                            Invoke(new Action(() =>
                            {
                                UpdateProgressBar();
                                UpdateDataGridView();
                            }));
                        }
                        else
                        {
                            if (!phoneNumberUrls[phoneNumber].Contains(url))
                            {
                                phoneNumberUrls[phoneNumber].Add(url);  // 只添加新的URL
                            }
                        }
                    }
                }

                // 如果已经找到100个电话号码，停止进一步的爬取
                if (phoneNumbers.Count >= 100) return;

                // 更新UI显示已爬取的URL
                Invoke(new Action(() =>
                {
                    searchURLs.Add(url);
                }));




            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error crawling {url}: {ex.Message}");
            }
        }



        // 从HTML中提取电话号码
        private List<string> ExtractPhoneNumbers(string html)
        {
            var phoneNumbers = new List<string>();
            var regex = new Regex(@"\b\d{3,4}[-.\s]?\d{7,8}\b");  // 简单的电话号码匹配规则

            var matches = regex.Matches(html);
            foreach (Match match in matches)
            {
                phoneNumbers.Add(match.Value);
            }

            return phoneNumbers;
        }
        // 从搜索页面提取所有结果的URLs
        private List<string> ExtractUrlsFromSearchPage(string html)
        {
            var urls = new HashSet<string>(); // 使用 HashSet 来自动处理重复项
            var regex = new Regex(@"https?://[^\s""<>]+"); // 匹配以 http 或 https 开头的 URL

            // 使用正则表达式查找所有匹配的 URL
            var matches = regex.Matches(html);

            // 将匹配到的 URL 添加到 HashSet 中
            foreach (Match match in matches)
            {
                urls.Add(match.Value);
            }

            return new List<string>(urls); // 将 HashSet 转换回 List 返回
        }

        // 更新DataGridView中的数据
        private void UpdateDataGridView()
        {

            foreach (var phoneNumber in phoneNumbers)
            {
                string _urls = "";

                foreach (var url in phoneNumberUrls[phoneNumber])
                {
                    _urls+= $"{url} ";
                }
                dataGridViewPhones.Rows.Add(phoneNumber, _urls);
            }
        }

        // 更新ProgressBar进度
        private void UpdateProgressBar()
        {
            // 计算当前找到的手机号数量相对于100个的百分比
            int progress = phoneNumbers.Count;

            if (progress <= 100)
            {
                progressBar.Value = progress; // 更新进度条的值
            }
        }

        private void btnShowUrls_Click(object sender, EventArgs e)
        {
            Form2 urlForm = new Form2(searchURLs);
            urlForm.Show();
        }
    }
}

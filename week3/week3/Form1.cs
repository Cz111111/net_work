using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace week3
{
    public partial class Form1 : Form
    {
        private string filePath="";
        private string originalFile = "";
        private string formattedFile = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "C# Files|*.cs",
                Title = "Select a C# Source File"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                //AnalyzeAndFormatFile(filePath);
                MessageBox.Show("文件上传成功！");
            }
        }

        private int CountLines(string content)
        {
            string[] lines = content.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            return lines.Length;
        }

        private int CountWords(string content)
        {
            //string[] words = Regex.Split(content, @"\W+");
            int wordCount = Regex.Matches(content, @"\w+").Count;
            return wordCount;
        }

        private Dictionary<string, int> CountWordFrequencies(string content)
        {
            string[] words = Regex.Split(content, @"\W+");
            Dictionary<string, int> frequencies = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (!string.IsNullOrEmpty(word))
                {
                    if (frequencies.ContainsKey(word))
                    {
                        frequencies[word]++;
                    }
                    else
                    {
                        frequencies[word] = 1;
                    }
                }
            }

            return frequencies;
        }

        private void ShowResults(int originalLineCount, int originalWordCount, int formattedLineCount, int formattedWordCount, Dictionary<string, int> wordCounts)
        {
            MessageBox.Show($"Original Line Count: {originalLineCount}\n" +
                            $"Original Word Count: {originalWordCount}\n" +
                            $"Formatted Line Count: {formattedLineCount}\n" +
                            $"Formatted Word Count: {formattedWordCount}\n" +
                            "Word Frequencies:\n" + string.Join("\n", wordCounts.Select(kvp => $"{kvp.Key}: {kvp.Value}")),
                            "Analysis Results");
        }

        private void btnBefore_Click(object sender, EventArgs e)
        {
            originalFile = File.ReadAllText(filePath, Encoding.UTF8);
            Console.Write(originalFile);
            int originalLineCount = CountLines(originalFile);
            int originalWordCount = CountWords(originalFile);
            richTextBox1.Text = $"原始行数: {originalLineCount}\n"+
                                $"原始单词数: {originalWordCount}\n";
        }

        private void btnFormat_Click(object sender, EventArgs e)
        {
            string withoutComments = Regex.Replace(originalFile, @"//.*", "", RegexOptions.Multiline);
            string withoutEmptyLines = Regex.Replace(withoutComments, @"\s*[\r\n]+\s*", "", RegexOptions.Multiline);

            formattedFile = withoutEmptyLines;
            MessageBox.Show("格式化成功！");
        }

        private void btnAfter_Click(object sender, EventArgs e)
        {
            int formattedLineCount = CountLines(formattedFile);
            int formattedWordCount = CountWords(formattedFile);
            Console.Write(formattedFile);
            richTextBox1.Text = $"格式化后行数: {formattedLineCount}\n" +
                                $"格式化后单词数: {formattedWordCount}\n" +
                                "单词列表:\n" + string.Join("\n", CountWordFrequencies(formattedFile).Select(kvp => $"{kvp.Key}: {kvp.Value}"));
        }
    }
}

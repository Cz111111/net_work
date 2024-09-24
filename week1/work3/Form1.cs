using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace work3
{
    public partial class Form1 : Form
    {
        private Random random = new Random();
        private int num1 = 0;
        private int num2 = 0;
        private int answer = 0;
        private static int num = 1;
        private static int score = 0;
        private bool isTimeUp = false;
        private int totalTime = 10;
        public Form1()
        {
            InitializeComponent();
            initial();
            InitializeTimer();
        }
        private void initial()
        {
            num1 = random.Next(1, 101);
            num2 = random.Next(1, 101);
            char op = random.Next(2) == 0 ? '+' : '-';
            label1.Text = $"一共10道题，这是第{num++}题";
            label2.Text = $"{num1}";
            label3.Text = $"{op}";
            label4.Text = $"{num2}";
            isTimeUp = false;
            totalTime = 10;
            label6.Text = $"本题剩余时间:10s";
        }
        private void InitializeTimer()
        {
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (label3.Text) {
                case "+":
                    answer = num1+ num2;
                    if (answer== int.Parse(textBox1.Text))
                    {

                        MessageBox.Show("回答正确");
                        score += 10;
                        
                    }
                    else
                    {
                        //答错了
                        MessageBox.Show("回答错误");
                    }
                    if (label1.Text.Equals("一共10道题，这是第10题"))
                    {
                        //显示得分
                        MessageBox.Show($"得分{score}");
                        this.Close();
                    }
                    else
                    {
                        initial();
                    }
                    break;
                case "-":
                    answer = num1 - num2;
                    if (answer == int.Parse(textBox1.Text))
                    {

                        MessageBox.Show("回答正确");
                        score += 10;

                    }
                    else
                    {
                        //答错了
                        MessageBox.Show("回答错误");
                    }
                    if (label1.Text.Equals("一共10道题，这是第10题"))
                    {
                        //显示得分
                        MessageBox.Show($"得分{score}");
                        this.Close();
                    }
                    else
                    {
                        initial();
                    }
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!isTimeUp)
            {
                // 检查是否超时
                if (totalTime <= 0)
                {
                    isTimeUp = true;
                    totalTime = 10;// 重置时间
                    MessageBox.Show("时间到！自动跳到下一题");
                    initial();
                }
                else
                {
                    totalTime--;
                    label6.Text = $"本题剩余时间:{totalTime}s";
                }
            }
        }
    }
}

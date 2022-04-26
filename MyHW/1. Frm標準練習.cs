
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmHomeWork : Form
    {
        public FrmHomeWork()
        {
            InitializeComponent();
        }
        int num, k = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            int a = 100;
            int b = 66;
            int c = 77;
            int[] abc = new int[3] {a,b,c};
            int max = abc.Max(); 
            lblResult.Text = "最大值 :" + max;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int cnt1 = 0, cnt2 = 0;
            int[] nums = { 33, 4, 5, 11, 222, 34 };

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] % 2 == 0)
                {
                    cnt2++;
                    //int 偶數 = arr0711.Length;
                }
                else
                {
                    cnt1++;
                    //int 奇數 = arr0711.Length;
                }
                lblResult.Text =  "偶數共" + cnt2 + "\r\n奇數共" + cnt1;
            }

        }

        private void button14_Click(object sender, EventArgs e)
        {
            string[] names = { "aaa", "ksdkfjsdk", "mother張", "emma", "迪克蕭", "J40", "Candy", "Coconut", "Motherfaker" };
            string longest = names.OrderByDescending(s => s.Length).First();
            lblResult.Text = longest;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt奇偶.Text))
            {
                MessageBox.Show("請輸入數字", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            num = Convert.ToInt16(txt奇偶.Text);
            if (num % 2 == 0)
            {
                lblResult.Text = num + "是偶數";
            }
            else
            {
                lblResult.Text = num + "是奇數";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int[] scores = { 2, 3, 46, 33, 22, 100,150, 33,55};

            int max =  scores.Max();
            int min = scores.Min();
            lblResult.Text = "最大值 :" + max+"最小值 :" + min;

            //MessageBox.Show("Max = " + max);

            //Array.Sort(scores);
            //MessageBox.Show("Max =" + scores[scores.Length - 1]);

            //================================

            //Point[] points = new Point[3];
            //points[0].X = 3;
            //points[0].Y = 4;
            ////System.InvalidOperationException: '無法比較陣列中的兩個元素。'

            //Array.Sort(points);

            //=================================


        }

        private void button16_Click(object sender, EventArgs e)
        {
            lblResult.Text = "";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string data = "";
            for (int i = 1; i < 10; i++)
            {
                for (int j = 1; j < 10; j++)
                {
                    data += $" { j} x { i}={i * j}\t";
                }
                data += "\r\n";
            }
            Font myfont = new Font("微軟正黑體", 9f);
            lblResult.Font = myfont;
            lblResult.Text = data;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            int d = 100;
            int r;
            string b = string.Empty;

            while (d > 0)
            {
                r = d % 2;
                d /= 2;
                b = r.ToString() + b;
            }
            lblResult.Text = "100的二進位是: " + b;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int count = 0;
            var names = new string[] { "mother張", "emma", "迪克蕭", "J40", "Candy", "Cindy", "Coconut", "Motherfacker" };
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i].Contains("C"))
                {
                    count++;
                }
                else if (names[i].Contains("c"))
                {
                    count++;
                }
            }
            lblResult.Text = "mother張, emma, 迪克蕭, J40, Candy, Cindy, coconut, motherfaker" + "\r\n加起來總共有:" + count + "個";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            lblResult.Text = "";
            k++;
            {
                //產生六個號碼
                int[] randomBall = new int[6];
                //產生亂數初始值
                Random rnd = new Random();
                for (int i = 0; i < 6; i++)
                {
                    //隨機產生1~49
                    randomBall[i] = rnd.Next(1, 49);

                    for (int j = 0; j < i; j++)
                    {
                        //檢查號碼是否重複
                        while (randomBall[j] == randomBall[i])
                        {
                            j = 0;
                            //重新產生，存回陣列，亂數產生的範圍是1~49
                            randomBall[i] = rnd.Next(1, 49);
                        }
                    }

                }
                lblResult.Text += "第" + k + "組 :" + randomBall[0].ToString() + "   ";
                lblResult.Text += randomBall[1].ToString() + "   ";
                lblResult.Text += randomBall[2].ToString() + "   ";
                lblResult.Text += randomBall[3].ToString() + "   ";
                lblResult.Text += randomBall[4].ToString() + "   ";
                lblResult.Text += randomBall[5].ToString() + "\r\n";


            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtStart.Text))
            {
                MessageBox.Show("請輸入數字", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtEND.Text))
            {
                MessageBox.Show("請輸入數字", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtStep.Text))
            {
                MessageBox.Show("請輸入數字", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int start, end, step = 0;
            int sum = 0;
            int i = 0;
            start = Convert.ToInt32(txtStart.Text);
            end = Convert.ToInt32(txtEND.Text);
            step = Convert.ToInt32(txtStep.Text);
            i = start;
            while (i <= end)
            {
                sum += i;
                i += step;

                lblResult.Text = start + "到" + end + "相隔" + (step - 1) + "\r\n加總為:" + sum;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtStart.Text))
            {
                MessageBox.Show("請輸入數字", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtEND.Text))
            {
                MessageBox.Show("請輸入數字", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtStep.Text))
            {
                MessageBox.Show("請輸入數字", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int F = int.Parse(txtStart.Text);
            int T = int.Parse(txtEND.Text);
            int S = int.Parse(txtStep.Text);
            int[] arr = new int[1];
            int j = 0;
            for (int i = F; i <= T; i += S)
            {
                Array.Resize(ref arr, j + 1);
                arr[j] = i;
                j++;
            }
            lblResult.Text = F.ToString() + "到" + T + "相隔" + (S - 1) + "\n加總為 " + arr.Sum().ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtStart.Text))
            {
                MessageBox.Show("請輸入數字", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtEND.Text))
            {
                MessageBox.Show("請輸入數字", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtStep.Text))
            {
                MessageBox.Show("請輸入數字", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int start, end, step = 0;
            int sum = 0;
            int i = 0;
            start = Convert.ToInt32(txtStart.Text);
            end = Convert.ToInt32(txtEND.Text);
            step = Convert.ToInt32(txtStep.Text);
            i = start;
            do
            {
                sum += i;
                i += step;
            } while (i <= end);

            lblResult.Text = start + "到" + end + "相隔" + (step - 1) + "\r\n加總為:" + sum;
        }

        int MyMinScore(int[] nums)
        {
            return 10;
        }
    }
}

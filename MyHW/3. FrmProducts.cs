using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyHomeWork
{
    public partial class FrmProducts : Form
    {
        public FrmProducts()
        {
            InitializeComponent();
            this.productsTableAdapter1.Fill(this.myDataSet1.Products);
            this.bindingSource1.DataSource = myDataSet1.Products;
            this.dataGridView1.DataSource = bindingSource1;
            this.bindingNavigator1.BindingSource = this.bindingSource1;

                    }

        private void button13_Click(object sender, EventArgs e)
        {
            this.bindingSource1.MovePrevious();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.bindingSource1.MoveLast();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.bindingSource1.MoveFirst();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.bindingSource1.MoveLast();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("請輸入數字", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("請輸入數字", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            decimal start = Convert.ToInt32(textBox1.Text);
            decimal end = Convert.ToInt32(textBox2.Text);
            this.productsTableAdapter1.FillByUnitPrice(this.myDataSet1.Products, start, end);
            lblResult.Text = $"{start}到{end}總共有{this.bindingSource1.Count}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("請輸入正確文字", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string name = textBox3.Text;
            this.productsTableAdapter1.FillByName(this.myDataSet1.Products, '%' + name + '%');
            lblResult.Text = $"{name}總共有{this.bindingSource1.Count}";
        }

        private void label2_BindingContextChanged(object sender, EventArgs e)
        {
            this.label2.Text = $"{this.bindingSource1.Position+ 1}/{this.bindingSource1.Count}";
        }


    }
}

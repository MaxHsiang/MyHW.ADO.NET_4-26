using MyHomeWork;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace MyHW
{
    public partial class FrmTable : Form
    {
        public FrmTable()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2.Controls.Clear();
            FrmCategoryProducts CategoryProducts = new FrmCategoryProducts();
            CategoryProducts.MdiParent = this;
            splitContainer2.Panel2.Controls.Add(CategoryProducts);
            CategoryProducts.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2.Controls.Clear();
            FrmProducts Products = new FrmProducts();
            Products.MdiParent = this;
            splitContainer2.Panel2.Controls.Add(Products);
            Products.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2.Controls.Clear();
            FrmDataSet_結構 DataSet_結構 = new FrmDataSet_結構();
            DataSet_結構.MdiParent = this;
            splitContainer2.Panel2.Controls.Add(DataSet_結構);
            DataSet_結構.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2.Controls.Clear();
            FrmAdventureWorks AdventureWorks = new FrmAdventureWorks();
            AdventureWorks.MdiParent = this;
            splitContainer2.Panel2.Controls.Add(AdventureWorks);
            AdventureWorks.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2.Controls.Clear();
            FrmCustomers Customers = new FrmCustomers();
            Customers.MdiParent = this;
            splitContainer2.Panel2.Controls.Add(Customers);
            Customers.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            splitContainer2.Panel2.Controls.Clear();
            FrmHomeWork HomeWork = new FrmHomeWork();
            HomeWork.MdiParent = this;
            splitContainer2.Panel2.Controls.Add(HomeWork);
            HomeWork.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            splitContainer2.Panel2.Controls.Clear();
            FrmTreeView TreeView = new FrmTreeView();
            TreeView.MdiParent = this;
            splitContainer2.Panel2.Controls.Add(TreeView);
            TreeView.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2.Controls.Clear();
            FrmMyAlbum_V1 MyAlbum = new FrmMyAlbum_V1();
            MyAlbum.MdiParent = this;
            splitContainer2.Panel2.Controls.Add(MyAlbum);
            MyAlbum.Show();
        }
    }
}

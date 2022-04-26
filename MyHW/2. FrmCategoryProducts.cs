using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyHomeWork
{
    public partial class FrmCategoryProducts : Form
    {
        public FrmCategoryProducts()
        {
            
            InitializeComponent();
            SqlConnection conn = null;
            conn = new SqlConnection("Data Source=.;Initial Catalog=Northwind;Integrated Security=True");
            conn.Open();
            SqlCommand command = new SqlCommand("Select CategoryName from Categories", conn);
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                comboBox1.Items.Add(dataReader["CategoryName"]);
                //$ = string.Format
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
            SqlConnection conn = null;
            try
            {
                string s = (comboBox1.SelectedIndex + 1).ToString();
                conn = new SqlConnection("Data Source=.;Initial Catalog=Northwind;Integrated Security=True");
                conn.Open();
                SqlCommand command = new SqlCommand("Select * from products as P join Categories as C on P.CategoryID = C.CategoryID where P.CategoryID ="+s, conn);
                SqlDataReader dataReader = command.ExecuteReader();
             
                while (dataReader.Read())
                {
                   s = $"{dataReader["ProductName"],-40} - {dataReader["UnitPrice"]:c2}";
                    this.listBox1.Items.Add(s);
                }
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
    }
    
}

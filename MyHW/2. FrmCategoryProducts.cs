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
            using (conn = new SqlConnection("Data Source=.;Initial Catalog=Northwind;Integrated Security=True"))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("select CategoryName from Categories", conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    this.comboBox2.Items.Add(ds.Tables[0].Rows[i]["CategoryName"]);
                }
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = null;

            //Disconnected - DataAdapter
            using (conn = new SqlConnection("Data Source=.;Initial Catalog=Northwind;Integrated Security=True"))
            {
                conn.Open();
                string cmdText = $"select ProductName from Products as p join Categories as c on p.CategoryID=c.CategoryID where CategoryName='{comboBox2.Text}'";
                SqlDataAdapter adapter = new SqlDataAdapter(cmdText, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                listBox2.DataSource = ds.Tables[0];
            }
        }
    }
    
}

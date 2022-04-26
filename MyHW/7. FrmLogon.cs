using MyHW;
using MyHW.Properties;
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
    public partial class FrmLogon : Form
    {
        public FrmLogon()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string UserName = UsernameTextBox.Text;
                string Password = PasswordTextBox.Text;
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = $"Insert into MyMember (UserName , Password) values ('{UserName}','{Password}')";
                    command.Connection = conn;
                    conn.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("創建成功");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            try
            {
                string UserName = UsernameTextBox.Text;
                string Password = PasswordTextBox.Text;
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = $"select * from  MyMember  where UserName='{UserName}' and Password='{Password}'";
                    command.Connection = conn;
                    MessageBox.Show(command.CommandText);

                    conn.Open();
                    SqlDataReader dataReader = command.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        MessageBox.Show("會員登入成功"); 
                        FrmTable f = new FrmTable();
                        f.Show();
                        this.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("會員登入失敗");
                    }


                } // Auto conn.Close()
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

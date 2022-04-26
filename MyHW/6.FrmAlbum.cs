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

namespace MyHW
{
    public partial class FrmAlbum : Form
    {
        public FrmAlbum()
        {
            InitializeComponent();


            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.MyAlbumConnectionString))
                {

                    SqlCommand command = new SqlCommand();
                    command.CommandText = "select  distinct(City) from MyAlbum";
                    command.Connection = conn; 
                    conn.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    this.listBox1.Items.Clear();
                    this.listBox2.Items.Clear();

                    while (dataReader.Read())
                    {
                        this.listBox1.Items.Add(dataReader["City"]);
                    

                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            FormBBB f = new FormBBB();
            f.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Id = (int)this.listBox2.Items[this.listBox1.SelectedIndex];
            //轉型成(int),顯示listbox3的Index選項
            ShowImage(Id);
        }

        private void ShowImage(int iD)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.DatabaseAAAConnectionString))
                {

                    SqlCommand command = new SqlCommand();
                    command.CommandText = $"select * from TableAAA where Id = {iD} ";
                    command.Connection = conn;
                    conn.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    //if (dataReader.HasRows)
                    //{
                    dataReader.Read();
                    byte[] bytes = (byte[])dataReader["Photo"];//(byte[]):小括號強制轉換屬性
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
                    this.pictureBox1.Image = Image.FromStream(ms);
                    //}

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //this.pictureBox2.Image = this.pictureBox2.ErrorImage;
            }
        }
    }
}

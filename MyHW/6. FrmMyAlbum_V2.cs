using MyHW.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyHW
{
    public partial class FrmMyAlbum_V1 : Form
    {
        public FrmMyAlbum_V1()
        {
            InitializeComponent();
            this.flowLayoutPanel3.AllowDrop = true;
            this.flowLayoutPanel3.DragEnter += FlowlayoutPanel3_DragEnter;
            this.flowLayoutPanel3.DragDrop += FlowLayoutPanel3_DragDrop;
            LoadCountryToComboBox();
            
            this.myPhotoTableAdapter.FillByCity(this.myAlbumDataSet.MyPhoto);
            for (int i = 0; i < myAlbumDataSet.MyPhoto.Rows.Count; i++)
            {
                Button n = new Button();
                n.Text = myAlbumDataSet.MyPhoto[i].City;
                n.Left = 10;
                n.Top = 40 * i;
                n.Tag = myAlbumDataSet.MyPhoto[i].City;
                n.Click += N_Click;
                flowLayoutPanel2.Controls.Add(n);

            }


        }

        private void FlowlayoutPanel3_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void N_Click(object sender, EventArgs e)
        {
            Button n = sender as Button;
            ShowImage((string)n.Tag);
        }

        private void ShowImage(string n)
        {
            flowLayoutPanel1.Controls.Clear();
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.MyAlbumConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = $"select Photo from MyPhoto where City='{n}'";
                    command.Connection = conn;
                    conn.Open();
                    SqlDataReader dataReader = command.ExecuteReader();

         
                      while( dataReader.Read())
                    { 
                        byte[] bytes = (byte[])dataReader["Photo"];
                        System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
                        PictureBox p = new PictureBox();
                        p.Image = Image.FromStream(ms);
                        p.SizeMode = PictureBoxSizeMode.StretchImage;
                        this.flowLayoutPanel1.Controls.Add(p);
                        p.Click += Pic_Click;
                        //=======================
                    }

                } // Auto conn.Close()
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
               
            }
        }

        private void LoadCountryToComboBox()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.MyAlbumConnectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("select distinct City from MyPhoto", conn);

                    SqlDataReader dataReader = command.ExecuteReader();

                    this.comboBox1.Items.Clear();
                    while (dataReader.Read())
                    {
                        this.comboBox1.Items.Add(dataReader["City"]);
                    }
                    this.comboBox1.SelectedIndex = 0;

                } // Auto conn.Close()
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FlowLayoutPanel3_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            for (int i = 0; i <= files.Length - 1; i++)
            {
                PictureBox pic = new PictureBox();
                pic.Image = Image.FromFile(files[i]);
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.Width = 240;
                pic.Height = 160;

                pic.Click += Pic_Click;
                this.flowLayoutPanel3.Controls.Add(pic);
            }
        }

        private void Pic_Click(object sender, EventArgs e)
        {
            Form f = new Form();
            f.BackgroundImage = ((PictureBox)sender).Image;
            f.BackgroundImageLayout = ImageLayout.Stretch;
            f.Show();
        }

        private void FlowLayoutPanel3_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void myPhotoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.myPhotoBindingSource.EndEdit();
            SqlCommandBuilder a = new SqlCommandBuilder(this.myPhotoTableAdapter.Adapter);
            this.myPhotoTableAdapter.Adapter.UpdateCommand = a.GetUpdateCommand();
            this.tableAdapterManager.UpdateAll(this.myAlbumDataSet);

        }

        private void FrmMyAlbum_V1_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'myAlbumDataSet.MyPhoto' 資料表。您可以視需要進行移動或移除。
            this.myPhotoTableAdapter.Fill(this.myAlbumDataSet.MyPhoto);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = this.openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                MessageBox.Show("OK " + this.openFileDialog1.FileName);

                this.photoPictureBox.Image = Image.FromFile(this.openFileDialog1.FileName);
            }
            else
            {
                MessageBox.Show("Cancel");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string folder = folderBrowserDialog1.SelectedPath;

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            flowLayoutPanel3.Controls.Clear();
            try
            {
   
                using (SqlConnection conn = new SqlConnection(Settings.Default.MyAlbumConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = $"select Photo from MyPhoto where City='{this.comboBox1.Text}'";
                    cmd.Connection = conn;
                    conn.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        byte[] bytes = (byte[])dataReader["Photo"];
                        MemoryStream ms = new MemoryStream(bytes);

                        for (int i = 0; i <= dataReader.FieldCount - 1; i++)
                        {
                            PictureBox pic = new PictureBox();
                            pic.Image = Image.FromStream(ms);
                            pic.Width = 240;
                            pic.Height = 160;
                            pic.SizeMode = PictureBoxSizeMode.StretchImage;
                            flowLayoutPanel3.Controls.Add(pic);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}


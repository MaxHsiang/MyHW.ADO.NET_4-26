using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyHW
{
    public partial class FormBBB : Form
    {
        public FormBBB()
        {
            InitializeComponent();
        }

        private void tableAAABindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tableAAABindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.databaseAAADataSet);

        }

        private void FormBBB_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'databaseAAADataSet.TableAAA' 資料表。您可以視需要進行移動或移除。
            this.myPhotoTableAdapter1.Fill(this.myAlbumDataSet1.MyPhoto);

        }

        private void button1_Click(object sender, EventArgs e)
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
    }
}

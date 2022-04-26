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
    public partial class FormTool : Form
    {
        public FormTool()
        {
            InitializeComponent();
        }

        private void photoTableBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.photoTableBindingSource.EndEdit();
            try 
            {
                this.tableAdapterManager.UpdateAll(this.photobaseDataSet);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }



        }

        private void FormTool_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'photobaseDataSet.PhotoTable' 資料表。您可以視需要進行移動或移除。
            this.photoTableTableAdapter.Fill(this.photobaseDataSet.PhotoTable);

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

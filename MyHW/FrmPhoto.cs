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
    public partial class FrmPhoto : Form
    {
        public FrmPhoto()
        {
            InitializeComponent();
        }

        private void photoTableBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.photoTableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.photobaseDataSet);

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

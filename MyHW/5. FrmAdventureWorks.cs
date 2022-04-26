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
    public partial class FrmAdventureWorks : Form
    {
        public FrmAdventureWorks()
        {
            InitializeComponent();
            this.pictureBox1.DataBindings.Add("Image", this.productPhotoBindingSource, "LargePhoto", true);
            aDDataSet1.EnforceConstraints = false;
            this.productPhotoTableAdapter.FillByYear(this.aDDataSet1.ProductPhoto);
            for(int i = 0; i <= aDDataSet1.ProductPhoto.Rows.Count - 1; i++)
            {
                comboBox1.Items.Add(aDDataSet1.ProductPhoto.Rows[i]["Year"]);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.productPhotoBindingSource.MovePrevious();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.productPhotoBindingSource.MoveNext();
        }

        private void button13_Click(object sender, EventArgs e)
        {

            this.productPhotoBindingSource.MoveFirst();

        }

        private void button16_Click(object sender, EventArgs e)
        {
            this.productPhotoBindingSource.MoveLast();
        }

        private void productPhotoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productPhotoBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.aDDataSet1);

        }

        private void FrmAdventureWorks_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'aDDataSet1.ProductPhoto' 資料表。您可以視需要進行移動或移除。
            this.productPhotoTableAdapter.Fill(this.aDDataSet1.ProductPhoto);

        }

        private void productPhotoBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            this.label4.Text = $"{this.productPhotoBindingSource.Position + 1} / {this.productPhotoBindingSource.Count}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime start = dateTimePicker1.Value;
            DateTime end = dateTimePicker2.Value;
            this.productPhotoTableAdapter.FillByDate(this.aDDataSet1.ProductPhoto, start, end);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.productPhotoTableAdapter.dataFillByYear(this.aDDataSet1.ProductPhoto,decimal.Parse( comboBox1.Text));
            productPhotoDataGridView.DataSource = productPhotoBindingSource;
            this.productPhotoBindingSource.DataSource = aDDataSet1.ProductPhoto;
            this.productPhotoBindingNavigator.BindingSource = this.productPhotoBindingSource;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.productPhotoTableAdapter.FillByOrderBy(this.aDDataSet1.ProductPhoto);
            productPhotoDataGridView.DataSource = aDDataSet1.ProductPhoto;
        }
    }
}

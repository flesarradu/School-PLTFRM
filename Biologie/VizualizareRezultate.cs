using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biologie
{
    public partial class VizualizareRezultate : Form
    {
        public VizualizareRezultate()
        {
            InitializeComponent();

        }

        private void VizualizareRezultate_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dB_A36E0C_flesarraduDataSet.rezultate' table. You can move, or remove it, as needed.
            this.rezultateTableAdapter1.Fill(this.dB_A36E0C_flesarraduDataSet.rezultate);
            // TODO: This line of code loads data into the '_Database_EFBioDataSet.rezultate' table. You can move, or remove it, as needed.
            this.rezultateTableAdapter.Fill(this._Database_EFBioDataSet.rezultate);
            // TODO: This line of code loads data into the '_Database_EFBioDataSet.teste' table. You can move, or remove it, as needed.
            this.testeTableAdapter.Fill(this._Database_EFBioDataSet.teste);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

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
    public partial class AdaugareElev : Form
    {
        public AdaugareElev()
        {
            InitializeComponent();
            comboBox1.Items.Add("10i");
            comboBox1.Items.Add("10e");
            comboBox1.Items.Add("10g");
            comboBox1.Items.Add("11i");
            comboBox1.Items.Add("12i");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text, parola = textBox2.Text;
            int admin = 0;
            if (checkBox1.Checked)
                admin = 1;
            string clasa = comboBox1.SelectedItem.ToString();
            FunctiiPublice login = new FunctiiPublice();
            login.adaugaCont(username, parola, admin, clasa);
            Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

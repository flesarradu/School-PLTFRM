using Biologie.EntityFramework;
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
    public partial class Exersare : Form
    {
        private string user = "";
        public Exersare(string str)
        {
            InitializeComponent();
            user = str;
            using (var db = new MapProjectDatabaseEntities())
            {
               foreach(var x in db.Tests)
                {
                    if(x.Exersare == 1)
                        comboBox1.Items.Add(x.Name);
                }
            }
        }

        private void Label4_Click(object sender, EventArgs e) => Close();

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var visa = new Testare(user, comboBox1.SelectedItem.ToString(), true);
            Hide();
            visa.Show();
            visa.Closed += (s,args) => Close();
        }
    }
}

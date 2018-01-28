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
    public partial class AdminTeste : Form
    {
        public AdminTeste()
        {
            InitializeComponent();
            FunctiiPublice x = new FunctiiPublice();
            using (var db = new EntityFBio())
            {
                var query = from x in db.teste select x;
                foreach (var x in query)
                {
                    comboBox1.Items.Add(x.nume);
                }
            }
            
            comboBox2.Items.Add("10i");
            comboBox2.Items.Add("10e");
            comboBox2.Items.Add("10g");
            comboBox2.Items.Add("11i");
            comboBox2.Items.Add("12i");
           
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            using (var db = new EntityFBio())
            {
                var query = db.teste.Where(x => x.nume == comboBox1.SelectedItem.ToString());
                foreach(var x in query)
                    x.clasa = comboBox2.SelectedItem.ToString();
                db.SaveChanges();
                MessageBox.Show("Testul a fost adaugat cu succes.");
                
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}

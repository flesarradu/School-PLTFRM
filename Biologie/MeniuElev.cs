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
    public partial class MeniuElev : Form
    {
        string user;
        FunctiiPublice functii = new FunctiiPublice();
        public MeniuElev(string u)
        {
           InitializeComponent();
            user = u;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (var db = new EntityFBio())
            {
                string test, clasa;
                clasa = functii.getClasa(user);
                test = functii.getTest(clasa);
                Testare visa = new Testare(user, test);
                Hide();
                visa.Closed += (s, args) => Close();
                visa.Show();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SchimbaParola visa = new SchimbaParola(user);
            Hide();
            visa.Closed += (s, args) => Close();
            visa.Show();
        }

        
    }
}

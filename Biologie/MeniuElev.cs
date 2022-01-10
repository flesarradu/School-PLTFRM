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
            using (var db = new MapProjectDatabaseEntities())
            {
                string test, clasa;
                clasa = functii.getClasa(user);
                test = functii.GetTest(clasa);
                Testare visa = new Testare(user, test,false);
                Hide();
                visa.Closed += (s, args) => Close();
                visa.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SchimbaParola visa = new SchimbaParola(user);
            Hide();
            visa.Closed += (s, args) => Show();
            visa.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Exersare visa = new Exersare(user);
            Hide();
            visa.Closed += (s, args) => Show();
            visa.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }
    }
}

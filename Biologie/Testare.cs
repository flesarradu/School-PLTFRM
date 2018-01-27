using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
namespace Biologie
{
    public partial class Testare : Form
    {
        string test="";
        string u = "";
        int corecte = 0;
        int numarEnunturi = 0;
        int numarRaspunse = 0;
       // Label cerinta = new Label();
        List<enunturi> Enunturi = new List<enunturi>();
        public Testare(string user, string tes)
        {
            InitializeComponent();
            test = tes;
            u = user;
            // WindowState = FormWindowState.Normal;
            // FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            // Bounds = Screen.PrimaryScreen.Bounds;
            //Activate();
            List<Test> enunturiTest = new List<Test>();
            using (var db = new EntityFBio())
            {
                string enunturi = "";
                var query = from y in db.teste select y;
                foreach (var y in query)
                {
                    if (y.nume == tes)
                        enunturi = y.enunturi;
                }
                char[] delimiterChar = { ',', ' ' };
                string[] words = enunturi.Split(delimiterChar);
                foreach (string s in words)
                {
                    if (s != "")
                        enunturiTest.Add(new Test() { enuntID = int.Parse(s) });
                }

                foreach (var x in enunturiTest)
                {
                    var q = from y in db.enunturi where y.id.Equals(x.enuntID) select y;
                    foreach (var z in q)
                    {
                        Enunturi.Add(z);
                        numarEnunturi++;
                    }
                }
            }
            afiseazaEnunt(Enunturi[numarRaspunse++].id);
                
            
        }

        private void Testare_Load(object sender, EventArgs e)
        {

        }
        private void afiseazaEnunt(int id)
        {
            foreach(var x in Enunturi)
            {
                if(x.id == id)
                {
                    if (x.tip == 1)
                        afiseazaEnunt1(x.enunt, x.raspuns);
                }
            }
        }
        
        private void afiseazaEnunt1(string enunt, string raspuns)
        {
            
            labelCerinta.Text = enunt;
            
            //Camp de Raspuns
            TextBox campRaspuns = new TextBox();
            campRaspuns.Parent = this;
            campRaspuns.Text = "";
            campRaspuns.Location = new Point(25, 400);
            campRaspuns.Size = new Size(470, 61);
            campRaspuns.Update();
            campRaspuns.Show();

            //Buton raspuns
            Button butonRaspuns = new Button();
            butonRaspuns.Parent = this;
            butonRaspuns.Location = new Point(1463, 801);
            butonRaspuns.Size = new Size(250, 65);
            butonRaspuns.Text = "Raspunde";
            butonRaspuns.Update();
            butonRaspuns.Show();
            butonRaspuns.Click += (s, args) =>
            {
                if (campRaspuns.Text.ToLower() == Enunturi[numarRaspunse-1].raspuns.ToLower())
                {
                    corecte++;
                    
                }
                campRaspuns.Text = "";
                if (numarRaspunse < numarEnunturi)
                {
                    afiseazaEnunt(Enunturi[numarRaspunse++].id); 
                }

                else
                {
                    DialogResult rez = MessageBox.Show("Doriti sa incheiati testul?", "Confirm", MessageBoxButtons.YesNoCancel);
                    if (rez == DialogResult.Yes)
                    {
                        MessageBox.Show(100 * corecte / numarEnunturi + "%");
                        //adauga rezultatul in baza de date
                        using (var db = new EntityFBio())
                        {
                            db.rezultate.Add(new rezultate { user = u, test = test, rezultat = (corecte / numarEnunturi).ToString() });
                            db.rezultate.
                            MessageBox.Show("Rezultatul a fost adaugat in baza de date");
                        }
                            Close();
                    }
                }
            };
        }

    }
}

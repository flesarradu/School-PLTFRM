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
        int[] raspunse = new int[100];
        int lastID = 0;
       // Label cerinta = new Label();
        List<enunturi> Enunturi = new List<enunturi>();
        CheckBox[] labels = new CheckBox[4];
        TextBox campRaspuns = new TextBox();
        Button butonRaspuns = new Button();
        Button butonRaspuns1 = new Button();
       
        public Testare(string user, string tes)
        {
            InitializeComponent();
            test = tes;
            u = user;
            for (int i = 0; i < 100; i++)
            {
                raspunse[i] = 0;
                
            }
            //BUTOANE
            int yx = 70, xy = 350;
            butonRaspuns1.Parent = this;
            butonRaspuns1.Location = new Point(1463, 801);
            butonRaspuns1.Size = new Size(250, 65);
            butonRaspuns1.Text = "Raspunde";
            butonRaspuns1.Update();
            campRaspuns.Parent = this;
            campRaspuns.Text = "";
            campRaspuns.Location = new Point(25, 400);
            campRaspuns.Size = new Size(470, 61);
            campRaspuns.Update();
            butonRaspuns.Parent = this;
            butonRaspuns.Location = new Point(1463, 801);
            butonRaspuns.Size = new Size(250, 65);
            butonRaspuns.Text = "Raspunde";
            butonRaspuns.Update();
            for(int i=0;i<4;i++)
            {
                labels[i] = new CheckBox();
                labels[i].Parent = this;
                labels[i].Size = new Size(1650, 55);
                labels[i].Location = new Point(yx, xy += 70);
                labels[i].Update();
            }

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
                        Enunturi[numarEnunturi++].raspunsa=0;
                    }                
                }
            }
            butonRaspuns.Click += (s, args) => {
                
                for (int i = 0; i < 4; i++)
                {
                    if (labels[i].Checked)
                    {
                        if (labels[i].Text.ToLower() == Enunturi[lastID].raspuns.ToLower())
                        {
                            corecte++;
                            
                        }
                        labels[i].CheckState = CheckState.Unchecked;
                        numarRaspunse++;
                        Enunturi[lastID].raspunsa = 1;
                        if (numarRaspunse < numarEnunturi)
                        {   
                            // afiseazaEnunt(Enunturi[numarRaspunse++].id);
                            afiseazaEnunt(getID());
                        }
                        else
                        {
                            DialogResult rez = MessageBox.Show("Doriti sa incheiati testul?", "Confirm", MessageBoxButtons.YesNoCancel);
                            if (rez == DialogResult.Yes)
                            {
                                finalizareTest();
                                Close();
                            }
                        }

                    }
                }

            };
            butonRaspuns1.Click += (s, args) =>
            { 
                butonRaspuns.Hide();
                campRaspuns.Hide();
                if (campRaspuns.Text.ToLower() == Enunturi[lastID].raspuns.ToLower())
                {
                    corecte++;
                }
                campRaspuns.Text = "";
                numarRaspunse++;
                Enunturi[lastID].raspunsa = 1;
                if (numarRaspunse < numarEnunturi)
                {
                    
                    // afiseazaEnunt(Enunturi[numarRaspunse++].id);
                    afiseazaEnunt(getID());
                }

                else
                {
                    DialogResult rez = MessageBox.Show("Doriti sa incheiati testul?", "Confirm", MessageBoxButtons.YesNoCancel);
                    if (rez == DialogResult.Yes)
                    {
                        finalizareTest();
                        Close();
                    }
                }
            };
            // afiseazaEnunt(Enunturi[numarRaspunse++].id);
            afiseazaEnunt(getID());
            
            
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
                    else if (x.tip == 0)
                        afiseazaEnunt0(x.enunt, x.raspuns, x.varianta1, x.varianta2, x.varianta3, x.varianta4);
                }
            }
        }
        
        private void afiseazaEnunt1(string enunt, string raspuns)
        {
            butonRaspuns.Hide();
            for (int i=0;i<4;i++)
            {
                labels[i].Hide();
            }
            labelCerinta.Text = enunt;
            
            //Camp de Raspuns
 
       
            campRaspuns.Show();

            //Buton raspuns

            butonRaspuns1.Show();
            
        }
        private void finalizareTest()
        {
            using (var db = new EntityFBio())
            {
                var query = from x in db.rezultate select x;
                int ID = query.Max(x => x.id);
                db.rezultate.Add(new rezultate { id = ID + 1, user = u, test = test, rezultat = (corecte * 10 + 10).ToString() });
                db.SaveChanges();
                MessageBox.Show("Rezultat: " + (corecte*10+10) + " puncte");
            }
        }
        private void afiseazaEnunt0(string enunt, string raspuns, string v1, string v2, string v3, string v4)
        {

            campRaspuns.Hide();
            butonRaspuns1.Hide();
            
            labelCerinta.Text = enunt;
            butonRaspuns.Show();
            //Checkbox Variante           
            for (int i = 0; i < 4; i++)
            { 
                labels[i].Show();
            }
            labels[0].Text = v1;
            labels[1].Text = v2;
            labels[2].Text = v3;
            labels[3].Text = v4;          
        }
        private int getID()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            int n=0;
            
            int[] vct = new int[100];
            for(int i=0; i<numarEnunturi;i++)
                if(Enunturi[i].raspunsa==0)
                {
                    vct[n++] = i;
                }
            int idNumber = 0;
            if (n > 1)
                idNumber = rand.Next(0, n - 1);
         
            lastID = vct[idNumber];
            return Enunturi[vct[idNumber]].id;
        }
    }
}

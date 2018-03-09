using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Forms;

namespace Biologie
{
   public class FunctiiPublice
    {
        public bool verificaCont(string user, string password)
        {

            using (var db = new EntityFBio())
            {
                
                if (db.accounts.Any(s => (s.password == password) && (s.user == user)))
                        return true;
                    else
                        return false;       
            }
        }
        public bool verificaUser(string user)
        {
            using (var db = new EntityFBio())
            {
                if (db.accounts.Any(s => (s.user == user)))
                    return true;
                else
                    return false;
            }
        }
        public int returneazaID(string user)
        {
            using (var db = new EntityFBio())
            {
                var query = from x in db.accounts where x.user == user select x;
                foreach(var x in query)
                {
                    return x.id;
                }
                return 0;
            }
        }
        public bool isAdmin(string user)
        {
            using (var db = new EntityFBio())
            {
                if (db.accounts.Any(s => (s.user == user) && (s.admin == 1)))
                    return true;
                return false;
            }
        }
        public void adaugaCont(string user, string password, int admin, string clasa)
        {
            if (user != "" && password != "" && !verificaUser(user))
            {
                try
                {
                    using (var db = new EntityFBio())
                    {
                        int lastID = 0;
                        var query = from y in db.accounts select y;
                        lastID = query.Max(item => item.id);
                        accounts cont = new accounts();
                        cont.id = lastID+1;
                        cont.user = user;
                        cont.password = password;
                        cont.admin = admin;
                        cont.clasa = clasa;
                        db.accounts.Add(cont);
                        db.SaveChanges();
                        MessageBox.Show("Cont creeat cu succes(user= " + user + ")");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A aparut o eroare la baza de date, contactati developerul cat mai rapid.");
                }
            }
            else
            {
                MessageBox.Show("User/Parola prea scurte sau User existent");
            }
        }

         public void adaugaTest(string nume, string enunt = "")
        {
            if(nume != "" && !verificaTest(nume))
            {
                try
                {
                    using (var db = new EntityFBio())
                    {
                        int lastID = 1;
                        var query = from y in db.teste select y;
                        lastID = query.Max(item => item.id) + 1;
                        teste test = new teste();
                        test.id = lastID;
                        test.nume = nume;
                        test.enunturi = enunt;
                        db.teste.Add(test);
                        db.SaveChanges();
                        MessageBox.Show("Testul cu numele " + nume +", id "+ lastID +" care contine enunturile cu id:" + enunt +" a fost creeat si introdus cu succes in baza de date");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A aparut o eroare la baza de date, contactati developerul cat mai rapid.");
                }
            }
            else
            {
                MessageBox.Show("Testul cu numele "+nume+" exista deja in baza de date.");
            }
        }

        public void adaugaEnunt(int dificultate, string cerinta, int tip, string raspuns, string var1, string var2, string var3, string var4)
        {
            using (var db = new EntityFBio())
            {
                enunturi enunt = new enunturi();
                int lastID = 1;
                var query = from y in db.enunturi select y;
                lastID = query.Max(item => item.id) + 1;
                if (tip == 0)
                {
                    enunt.id = lastID;
                    enunt.dificultate = dificultate;
                    enunt.enunt = cerinta;
                    enunt.tip = tip;
                    enunt.raspuns = raspuns;
                    enunt.varianta1 = var1;
                    enunt.varianta2 = var2;
                    enunt.varianta3 = var3;
                    enunt.varianta4 = var4;
                    
                }
                else if(tip==1)
                {
                  enunt.id = lastID;
                  enunt.dificultate = dificultate;
                  enunt.enunt = cerinta;
                  enunt.tip = tip;
                  enunt.raspuns = raspuns;
                }
                db.enunturi.Add(enunt);
                db.SaveChanges();
                if(tip == 0)
                    MessageBox.Show("Item-ul cu enuntul: " + cerinta + ", raspunsul " + raspuns + " si cu variantele de raspuns: \n-" + var1 + "\n-" + var2 + "\n-" + var3 + "\n-" + var4 + "\n a fost adaugat in baza de date");
                else
                    MessageBox.Show("Item-ul cu enuntul:" + cerinta + ", raspunsul " + raspuns + "\n a fost adaugat in baza de date");
            }
        }

        public bool verificaTest(string nume)
        {
            using (var db = new EntityFBio())
            {
                if (db.teste.Any(s => (s.nume == nume)))
                    return true;
                else
                    return false;
            }
        }
                
        public void schimbaParola(string user, string password)
        {
            using (var db = new EntityFBio())
            {
                var query = db.accounts.Where(item => (item.user == user));
                foreach(var x in query)
                    x.password = password;
                db.SaveChanges();
            }
        }
        public string getClasa(string user)
        {
            using (var db = new EntityFBio())
            {
                var u = db.accounts.Where(x => x.user == user);
                foreach (var x in u)
                    return x.clasa;
                return null;
            }
        }
        public string getTest(string clasa)
        {
            using (var db = new EntityFBio())
            {
                var u = db.teste.Where(x => x.clasa == clasa);
                foreach (var x in u)
                    return x.nume;
                return null;
            }
        }
    }
}

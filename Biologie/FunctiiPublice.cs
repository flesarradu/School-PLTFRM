using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Forms;
using Biologie.EntityFramework;

namespace Biologie
{
   public class FunctiiPublice
    {
        public bool verificaCont(string user, string password)
        {

            using (var db = new EntityFBio())
            {

                var cont = db.Accounts.Where(s => s.User == user).Select(s => s).FirstOrDefault();
                return (cont.Password == password) ? true : false;
                                    
            }
            return false;
        }
        public bool verificaUser(string user)
        {
            using (var db = new EntityFBio())
            {
                if (db.Accounts.Any(s => (s.User == user)))
                    return true;
                else
                    return false;
            }
        }
        public int returneazaID(string user)
        {
            using (var db = new EntityFBio())
            {
               int id = db.Accounts.Where(s => s.User == user).Select(s => s.Id).FirstOrDefault();
               return id;
            }
        }
        public bool isAdmin(string user)
        {
            using (var db = new EntityFBio())
            {
                return (db.Accounts.Where(s => s.User==user).Select(s=>s.Class.ClassName).FirstOrDefault() == "Admin") ? true : false;
            }
        }
        public void adaugaCont(string user, string password, int clasa)
        {
            if (user != "" && password != "" && !verificaUser(user))
            {
                try
                {
                    using (var db = new EntityFBio())
                    {
                        Account account = new Account();
                        account.User = user;
                        account.Password = password;
                        account.ClassId = clasa;
                        db.Accounts.Add(account);
                        if(db.SaveChanges()!=0)
                             MessageBox.Show("Cont creat cu succes(user= " + user + ")");
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

         public void adaugaTest(string nume, List<Question> enunturi)
        {
            if(nume != "" && !verificaTest(nume))
            {
                try
                {
                    using (var db = new EntityFBio())
                    {
                        Test test = new Test();
                        test.Name = nume;
                        db.Tests.Add(test);
                        db.SaveChanges();
                        string enunt="";
                        foreach (var x in enunturi)
                        {
                            enunt += x.Id + ", ";
                            db.QuestionTests.Add(new QuestionTest { QuestionId = x.Id, TestId = test.Id });
                        }
                        db.SaveChanges();
                        MessageBox.Show("Testul cu numele " + nume +", id "+ test.Id +" care contine enunturile cu id:" + enunt +" a fost creeat si introdus cu succes in baza de date");
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
        public void adaugaTest(string nume)
        {
            if (nume != "" && !verificaTest(nume))
            {
                try
                {
                    using (var db = new EntityFBio())
                    {
                        Test test = new Test();
                        test.Name = nume;                       
                        db.Tests.Add(test);                       
                        db.SaveChanges();
                        MessageBox.Show("Testul cu numele " + nume + ", id " + test.Id + " a fost adaugat in baza de date");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A aparut o eroare la baza de date, contactati developerul cat mai rapid.");
                }
            }
            else
            {
                MessageBox.Show("Testul cu numele " + nume + " exista deja in baza de date.");
            }
        }
        public void adaugaEnunt(int dificultate, string cerinta, int tip, string raspuns, string var1, string var2, string var3, string var4)
        {
            using (var db = new EntityFBio())
            {
                Question intrebare = new Question();
                if (tip == 0)
                {
                    intrebare.Type = 0;
                    intrebare.QuestionText = cerinta;
                    intrebare.Answer = raspuns;
                    intrebare.choice1 = var1;
                    intrebare.choice2 = var2;
                    intrebare.choice3 = var3;
                    intrebare.choice4 = var4;
                }
                else if(tip==1)
                {
                    intrebare.Type = 1;
                    intrebare.QuestionText = cerinta;
                    intrebare.Answer = raspuns;
                }
                else if(tip==2)
                {
                    intrebare.Type = 2;
                    intrebare.QuestionText = cerinta;
                    intrebare.Answer = raspuns;
                    intrebare.choice1 = var1;
                    intrebare.choice2 = var2;
                    intrebare.choice3 = var3;
                    intrebare.choice4 = var4;
                }
                intrebare.Level = dificultate;
                db.Questions.Add(intrebare);
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
                if (db.Tests.Any(s => (s.Name == nume)))
                    return true;
                else
                    return false;
            }
        }
                
        public void schimbaParola(string user, string password)
        {
            using (var db = new EntityFBio())
            {
                var x = db.Accounts.FirstOrDefault(s => s.User == user);
                x.Password = password;
                db.SaveChanges();
            }
        }
        public string getClasa(string user)
        {
            using (var db = new EntityFBio())
            {
                var x = db.Accounts.FirstOrDefault(s => s.User == user);
                return x.Class.ClassName;
            }
        }
        public string GetTest(string clasa)
        {
            using (var db = new EntityFBio())
            {
                //var x = db.Classes.FirstOrDefault(s => s.ClassName == clasa);
                //return db.Tests.Where(s => s.ClassId == x.Id).Select(s => s.Name).FirstOrDefault();
                return db.Classes.Where(x => x.ClassName == clasa).Select(x => x.Test.Name).FirstOrDefault();
            }
        }
        public List<Question> getQuestions(Test test)
        {
            List<Question> Questions = new List<Question>();
            using (EntityFBio db = new EntityFBio())
            {
                var QuestionsTests = db.QuestionTests.Where(s => s.TestId == test.Id).Select(s => s);
                foreach (var x in QuestionsTests)
                {
                    Questions.Add(db.Questions.FirstOrDefault(s => s.Id == x.QuestionId));
                }
            }
            return Questions;
        }
    }
}

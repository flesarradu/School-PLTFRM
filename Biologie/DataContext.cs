using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Linq;
using Biologie.DataContracts.SqlModels;

namespace Biologie
{
    public class DataContext : DbContext
    {
        public DbSet<Test> Teste;
        public DbSet<Raspuns> Raspunsuri;
        public DbSet<Intrebare> Intrebari;
        public DbSet<Nota> Rezultate;
        public DbSet<Clasa> Clase;
        public DbSet<User> Utilizatori;
    }
}

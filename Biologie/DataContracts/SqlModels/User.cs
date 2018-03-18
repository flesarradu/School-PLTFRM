using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biologie.DataContracts.SqlModels
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Parola { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public List<Nota> Note { get; set; }
        public Clasa Clasa { get; set; }
        public bool EProfesor() => Note == null || Note.Count == 0;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biologie.DataContracts.SqlModels
{
    public class Clasa
    {   
        public Clasa()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string NumeClasa { get; set; }
        public User Profesor { get; set; }
        public List<User> Elevi { get; set; }
    }
}

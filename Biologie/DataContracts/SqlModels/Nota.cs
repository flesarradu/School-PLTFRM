using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biologie.DataContracts.SqlModels
{
   public class Nota
    {
        public Guid Id { get; set; }
        public double Val { get; set; }
        public Clasa Clasa { get; set; }
        public User Elev { get; set; }
    }
}

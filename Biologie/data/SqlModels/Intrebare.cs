using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biologie.DataContracts.SqlModels
{
   public class Intrebare
    {
        public Intrebare()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public Test Test { get; set; }
        public string Enunt { get; set; }
        public List<Raspuns> Raspunsuri { get; set; }
        
    }
}

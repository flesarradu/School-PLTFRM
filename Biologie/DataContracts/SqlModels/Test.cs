using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biologie.DataContracts.SqlModels
{
    public class Test
    {
        public Guid Id { get; set; }
        public Clasa Clasa { get; set; }
        public List<Intrebare> Intrebari { get; set; }
    }
}

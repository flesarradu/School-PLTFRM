using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biologie.DataContracts.SqlModels
{
   public class Raspuns
    {
        public Raspuns()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OefeningenCsharpAdvancedEB
{
    public class Bankrekening
    {
        public decimal Rekeningstand { get; set; }

        public Bankrekening(decimal stand)
        {
            Rekeningstand = stand;
        }
        public void Opname(decimal bedrag)
        {
            Rekeningstand -= bedrag;
        }
        public void Storting(decimal bedrag)
        {
            Rekeningstand += bedrag;
        }
    }
}

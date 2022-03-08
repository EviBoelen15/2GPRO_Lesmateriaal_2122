using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Oefening_07
{
    public class Bankrekening
    {
        // Property
        public decimal HuidigSaldo { get; set; }

        // Constructor 
        public Bankrekening()
        {
            HuidigSaldo = 0M;
        }

        // Method Opname() of BedragVerlagen(), kies zelf maar de naam
        public void Opname(decimal bedrag)
        {
            if (HuidigSaldo - bedrag >= 0M)
                
            {
                HuidigSaldo -= bedrag;
            }
            else
            {
                throw new ArithmeticException();
            }
        }

        // Method Storting() of BedragVerhogen(), kies zelf maar de naam
        public void Storting(decimal bedrag)
        {
            HuidigSaldo += bedrag;
        }
    }
}

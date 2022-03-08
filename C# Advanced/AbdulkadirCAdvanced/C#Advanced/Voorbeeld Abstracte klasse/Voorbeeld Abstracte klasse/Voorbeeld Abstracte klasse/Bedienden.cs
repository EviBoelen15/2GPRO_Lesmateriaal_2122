using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voorbeeld_Abstracte_klasse
{
    public class Bedienden : Medewerker
    {

        private double belastbaar, bruto, bv;

        //Roept klasse Werknemer op.
        public Bedienden(string firstName, string familyName, double salary) : base(firstName, familyName, salary)
        {
            bruto = Bruto();
        }

        // De functies moeten overschreven worden.

        public override double RSZ() => bruto * 0.1307f;

        public override double BV()
        {
            belastbaar = bruto - RSZ();
            // Belastingsschijven If-structuur
            if (belastbaar <= 45000)
            {
                bv = belastbaar * 0.45f;
            }
            else
            {
                bv = (bruto - 50000) * 0.5f + (50000 * 0.45f);
            }
            return bv;
        }

        public override double Netto() => belastbaar - bv;


    }
}

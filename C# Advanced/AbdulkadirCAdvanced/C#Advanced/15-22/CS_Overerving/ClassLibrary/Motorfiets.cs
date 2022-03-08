using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Motorfiets : Voertuig
    {

        public Motorfiets()
        {
            Merk = "Honda";
            Prijs = 1000.0;
            AantalPassagiers = 1;
        }

        public override string WieBenIk()
        {
            return "Motorfiets";
        }
    }
}

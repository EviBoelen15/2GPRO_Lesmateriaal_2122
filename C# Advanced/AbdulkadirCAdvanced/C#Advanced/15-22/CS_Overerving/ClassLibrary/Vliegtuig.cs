using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Vliegtuig : Voertuig
    {

        public Vliegtuig()
        {
            Merk = "Boeing";
            Prijs = 1000000.0;
            AantalPassagiers = 200;
        }

        public override string WieBenIk()
        {
            return "Vliegtuig";
        }
    }
}

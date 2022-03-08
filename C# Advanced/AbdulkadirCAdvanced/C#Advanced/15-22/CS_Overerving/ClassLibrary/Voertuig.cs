using System;

namespace ClassLibrary
{
    public abstract class Voertuig
    {
        public string Merk { get; set; }
        public double Prijs { get; set; }
        public int AantalPassagiers { get; set; }

        public Voertuig()
        {
            Merk = "";
            Prijs = 0.0;
            AantalPassagiers = 1;
        }

        public virtual string Geluid()
        {
            return "";
        }

        public abstract string WieBenIk();
    }
}

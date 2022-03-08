using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Oefening_20
{
    public class Persoon : IOuderdom
    {
        // Member variabelen
        private int geboortejaar;
        private string naam;
        private string voornaam;

        // Constructor
        public Persoon(string voornaam, string naam, int geboortejaar)
        {
            this.voornaam = voornaam;
            this.naam = naam;
            this.geboortejaar = geboortejaar;
        }

        // Read-only property Ouderdom -implementatie van interface
        public float Ouderdom => (DateTime.Now.Year - geboortejaar);

        // Read-only property Naam -implementatie van interface
        public string Naam => $"{voornaam} {naam}";
    }
}

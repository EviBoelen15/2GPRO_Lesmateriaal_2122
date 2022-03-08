using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Oefening_20
{
    public class Hond : IOuderdom
    {
        // Member variabelen
        private int geboortejaar;
        private string grootte;
        private string naam;
        private string ras;

        // Extra member variabele die ik zelf heb toegevoegd: gaat veel code versimpelen
        private float leeftijdsFactor;

        // Constructor
        public Hond(string ras, string grootte, string naam, int geboortejaar, float leeftijdsFactor)
        {
            this.ras = ras;
            this.grootte = grootte;
            this.naam = naam;
            this.geboortejaar = geboortejaar;
            this.leeftijdsFactor = leeftijdsFactor;
            // this.geboortejaar is de membervariabele geboortejaar
            // geboortejaar is de parameter bovenaan van de constructor
        }

        // Read-only property Ouderdom - implementatie van interface
        public float Ouderdom => (DateTime.Now.Year - geboortejaar) * leeftijdsFactor;

        // Read-only property Naam - implementatie van interface
        public string Naam => $"{ras} ({grootte}): {naam}";
    }
}

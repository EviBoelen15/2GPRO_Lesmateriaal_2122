using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Oefening_20
{
    public class Boom : IOuderdom
    {
        // Instantie variabelen
        private int ringen;
        private string soort;

        // Constructor
        public Boom(string soort, int plantjaar)
        {
            this.soort = soort;
            ringen = DateTime.Now.Year - plantjaar;
        }

        // Read-only property Ouderdom - implementatie van interface
        public float Ouderdom => ringen;

        // Read-only property Naam - implementatie van interface
        public string Naam => $"Boom: {soort}";
    }
}

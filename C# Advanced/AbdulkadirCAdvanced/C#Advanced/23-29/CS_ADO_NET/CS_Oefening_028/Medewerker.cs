using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Oefening_028
{
    public class Medewerker
    {
        public int Afdeling { get; set; }
        public int Chef { get; set; }
        public float Comm { get; set; }
        public string Functie { get; set; }
        public DateTime GebDatum { get; set; }
        public float Maandsalaris { get; set; }
        public int MnrID { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }

        public Medewerker()
        {
        }
    }
}

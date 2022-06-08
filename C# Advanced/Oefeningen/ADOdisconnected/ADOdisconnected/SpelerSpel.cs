using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOdisconnected
{
    class SpelerSpel
    {
        int SpelerId { get; set; }
        int SpelId { get; set; }
        string Naam { get; set; }
        string Wachtwoord { get; set; }
        bool IsMol { get; set; }
        int LeeftijdDeelname { get; set; }
        string Beroep { get; set; }
        int Jaar { get; set; }
        string Locatie { get; set; }

        public SpelerSpel()
        {

        }
    }
}

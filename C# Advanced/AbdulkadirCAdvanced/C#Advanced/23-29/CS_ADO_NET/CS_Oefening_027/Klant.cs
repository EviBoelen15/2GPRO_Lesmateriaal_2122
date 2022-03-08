using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Oefening_027
{
    public class Klant
    {
        public int ID { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public string Woonplaats { get; set; }
        public DateTime Geboortedatum { get; set; }
        public string Gebruikersnaam { get; set; }
        public string Wachtwoord { get; set; }

        public override string ToString() => $"{Voornaam} {Naam} ({ID}) {Woonplaats}";
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Oefening_026
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

        public override string ToString() => $"{Naam} {Voornaam} ({ID}) {Woonplaats}";


        public static int StringNaarID(string toStringGegevens)
        {
            int idStartIndex = toStringGegevens.IndexOf('(') + 1;
            int idEindIndex = toStringGegevens.IndexOf(')');

            string result = toStringGegevens.Substring(idStartIndex, idEindIndex - idStartIndex);
            return int.Parse(result);
        }
    }
}

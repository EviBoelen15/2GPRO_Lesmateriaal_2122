using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Oefening_18
{
    // De klasse Werknemer is een abstracte klasse.
    // Hier kunnen we dus geen instanties van maken.
    // Afgeleide classes moeten de abstracte methods gaan overriden met hun eigen implementatie!
    public abstract class Werknemer
    {
        public string Voornaam { get; set; }
        public string Familienaam { get; set; }
        public char Type { get; set; }

        // Constructor
        public Werknemer(string firstName, string familyName, char type)
        {
            Voornaam = firstName;
            Familienaam = familyName;
            Type = type;
        }

        // Abstracte methods
        // Afgeleide classes moeten de abstracte methods gaan overriden met hun eigen implementatie!
        public abstract decimal Wedde();
        public abstract string Info();
    }
}

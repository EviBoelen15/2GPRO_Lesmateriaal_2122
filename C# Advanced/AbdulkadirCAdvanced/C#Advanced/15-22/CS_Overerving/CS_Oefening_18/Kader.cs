using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Oefening_18
{
    public class Kader : Werknemer
    {
        // Constructor
        // Roept constructor van abstracte base class Werknemer op.
        // Daarna stelt hij Salaris in.
        public Kader(string firstName, string familyName, char type, decimal salaris) 
            : base(firstName, familyName, type)
        { 
            Salaris = salaris; 
        }

        public decimal Salaris { get; set; }

        // De afgeleide class Bediende moet de abstract methods van Werknemer overriden met eigen implementatie!
        public override decimal Wedde() => Salaris;
        public override string Info()
        {
            string naam = $"{Voornaam} {Familienaam}"; 
            return $"{Type} | {naam, -25} wedde: {Salaris:c}"; 
        }
    }
}

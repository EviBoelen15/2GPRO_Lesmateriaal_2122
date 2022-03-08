using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Oefening_18
{
    public class Bediende : Werknemer
    {
        // Constructor
        // Roept constructor van abstracte base class Werknemer op.
        // Daarna stelt hij het Uurloon en UrenGewerkt in.
        public Bediende(string firstName, string familyName, char type, decimal uurloon, decimal aantalUren) 
            : base(firstName, familyName, type)
        {
            Uurloon = uurloon;
            UrenGewerkt = aantalUren;
        }
        
        public decimal Uurloon { get; set; }
        public decimal UrenGewerkt { get; set; }

        // De afgeleide class Bediende moet de abstract methods van Werknemer overriden met eigen implementatie!
        public override decimal Wedde() => Uurloon * UrenGewerkt;
        public override string Info()
        {
            string naam = $"{Voornaam} {Familienaam}";
            return $"{Type} | {naam, -25} wedde: {Uurloon:c} x {UrenGewerkt} = {Wedde():c}";
        }
    }
}

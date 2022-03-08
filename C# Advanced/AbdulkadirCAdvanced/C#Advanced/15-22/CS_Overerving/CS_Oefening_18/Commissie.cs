using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Oefening_18
{
    public class Commissie : Werknemer
    {
        private decimal comm;
        // Constructor
        // Roept constructor van abstracte base class Werknemer op.
        // Daarna stelt hij Omzet, CommissiePerc,... in.
        public Commissie(string firstName, string familyName, char type, decimal salaris, decimal commissiePerc, decimal omzet) 
            : base(firstName, familyName, type)
        {
            Omzet = omzet;
            CommissiePerc = commissiePerc;
            comm = omzet * commissiePerc / 100;
            Salaris = salaris;
        }

        public decimal Salaris { get; set; }
        public decimal CommissiePerc { get; set; }
        public decimal Omzet { get; set; }

        // De afgeleide class Bediende moet de abstract methods van Werknemer overriden met eigen implementatie!
        public override decimal Wedde() => Salaris + comm;
        public override string Info()
        {
            string naam = $"{Voornaam} {Familienaam}";
            return $"{Type} | {naam, -15} wedde (incl. comm.): {Salaris:c} + {comm:c} = {Wedde():c}";
        }
    }
}

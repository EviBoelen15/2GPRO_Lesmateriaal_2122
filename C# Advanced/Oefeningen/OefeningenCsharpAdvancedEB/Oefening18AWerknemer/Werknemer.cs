using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefening18AWerknemer
{
    public abstract class Werknemer
    {
        public string Familienaam { get; set; }
        public string Type { get; set; }
        public string Voornaam { get; set; }

        public Werknemer(string fn, string type, string n)
        {
            Familienaam = fn;
            Type = type;
            Voornaam = n;
        }

        public abstract string Info();
        public abstract double Wedde();
    }
}

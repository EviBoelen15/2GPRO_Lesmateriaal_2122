using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefening18AWerknemer
{
    class Bedienden : Werknemer
    {
        public float UrenGewerkt { get; set; }
        public float UurLoon { get; set; }
        public Bedienden(string vn, string type, string n, float uurLoon, float urenGewerkt) : base(vn, type, n)
        {
            Voornaam = vn;
            Familienaam = n;
            Type = type;
            UurLoon = uurLoon;
            UrenGewerkt = urenGewerkt;
        }
        public override string Info()
        {
            string info = $"{Type}  |  {Voornaam} {Familienaam}            Wedde: ${UurLoon} * {UrenGewerkt} = {Wedde()}";
            return info;
        }
        public override double Wedde()
        {
            double dbl = UurLoon * UrenGewerkt;
            return dbl;
        }
    }
}

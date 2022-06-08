using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefening18AWerknemer
{
    class Kader : Werknemer
    {
        public float Salaris { get; set; }
        public Kader(string vn, string type, string n, float salaris) : base(vn, type, n)
        {
            Voornaam = vn;
            Type = type;
            Familienaam = n;
            Salaris = salaris;
        }
        public override string Info()
        {
            string info = $"{Type}  |  {this.Voornaam} {this.Familienaam}            Wedde: ${this.Wedde()}";
            return info;
        }
        public override double Wedde()
        {
            double dbl = Salaris;
            return dbl;
        }

    }
}

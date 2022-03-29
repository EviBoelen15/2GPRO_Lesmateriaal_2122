using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefening18AWerknemer
{
    class Commissie : Werknemer
    {
        //Var
        double comm;

        //Properties
        public float CommissiePerc { get; set; } 
        public float Omzet { get; set; }
        public float Salaris { get; set; }


        //Constructor
        public Commissie(string vn, string type, string n, float commissiePerc, float omzet, float salaris) : base(vn, type, n)
        {
            Voornaam = vn;
            Familienaam = n;
            Type = type;
            CommissiePerc = commissiePerc;
            Omzet = omzet;
            Salaris = salaris;
            comm = Salaris * CommissiePerc;
        }

        //Override methods
        public override string Info()
        {
            string info = $"{Type}  |  {Voornaam} {Familienaam}            Wedde: (incl. commissie):  ${Salaris} + {comm} = {Wedde()}";
            return info;
        }
        public override double Wedde()
        {
            double dbl = Salaris + comm;
            return dbl;
        }
    }
}

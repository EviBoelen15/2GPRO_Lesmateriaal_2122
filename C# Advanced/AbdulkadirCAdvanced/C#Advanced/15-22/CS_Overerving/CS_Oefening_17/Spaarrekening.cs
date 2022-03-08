using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Oefening_17
{
    public class Spaarrekening : Bankrekening
    {
        public Spaarrekening(double opening, string name, string address) : base(opening, name, address)
        {
        }

        // Verplichte implementatie van de abstracte method BerekenRente() van abstracte class Bankrekening.
        // Om een eigen implementatie hiervan te doen, gebruiken we het keyword "override".
        // 50% => * 0.5
        // 10% => * 0.1
        // 1% => * 0.01
        // 1,5% => * 0.015
        // Rente wordt jaarlijks berekend: dus 100 euro aftrekken
        public override double BerekenRente() => (saldo * 0.015) - 100;
    }
}

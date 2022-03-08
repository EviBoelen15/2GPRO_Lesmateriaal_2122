using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Oefening_17
{
    public class Zichtrekening : Bankrekening
    {
        public Zichtrekening(double opening, string name, string address) : base(opening, name, address)
        {
        }

        public override void CreditSaldo(double waarde)
        {
            // Als het saldo onder 0 zou gaan, gooi dan een BankException
            // (BankException is een eigen class die overerft van ApplicationException)
            if ((saldo - waarde) < 0)
            {
                throw new BankException("Zichtrekening: saldo ontoereikend!");
            }
            // Ik roep de CreditSaldo() method op van de base class (dus van Bankrekening)
            base.CreditSaldo(waarde);
        }

        // Verplichte implementatie van de abstracte method BerekenRente() van abstracte class Bankrekening.
        // Om een eigen implementatie hiervan te doen, gebruiken we het keyword "override".
        public override double BerekenRente() => saldo * 0.005;
        /*
        public override double BerekenRente()
        {
            return saldo * 0.005;
        }
        */
    }
}

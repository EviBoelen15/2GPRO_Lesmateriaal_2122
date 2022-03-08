using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Oefening_17
{
    public abstract class Bankrekening
    {
        // protected is binnen de klasse en afgeleide klasse beschikbaar
        // maar niet erbuiten!
        protected double saldo;

        // Contructor
        public Bankrekening(double opening, string name, string address)
        {
            saldo = opening;
            Naam = name;
            Adres = address;
        }

        // Expression-bodied read-only property (enkel get)
        public double HuidigSaldo => saldo; 


        // Auto-implemented properties
        public string Naam { get; set; }
        public string Adres { get; set; }


        // Methods
        public void DebetSaldo(double waarde)
        {
            saldo += waarde;
        }

        // Deze virtual method kan in een afgeleide class override worden
        // met een eigen implementatie.
        public virtual void CreditSaldo(double waarde)
        {
            saldo -= waarde;
        }

        // Abstracte method: deze heeft geen implementatie.
        // De implementatie MOET aanwezig zijn in een afgeleide class.
        // In een afgeleide class gebruik je dan het keyword
        // "override" om een eigen implementatie te geven.
        public abstract double BerekenRente();
    }
}

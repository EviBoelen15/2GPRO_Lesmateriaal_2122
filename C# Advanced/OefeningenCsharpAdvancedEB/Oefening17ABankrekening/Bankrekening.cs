using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefening17ABankrekening
{
    public abstract class Bankrekening
    {
        // protected is binnen de klasse en afgeleide klasse beschikbaar
        // maar niet erbuiten!
        protected double saldo;

        //Constructor
        public Bankrekening(double opening, string name, string address)
        {
            saldo = opening;
            Naam = name;
            Adress = address;
        }

        //Properties 
        // Expression-bodied read-only property (enkel get)
        public double huidigSaldo => saldo;
        public string Adress { get; set; }
        public string Naam { get; set; }

        //Methodes 
        public virtual void CreditSaldo(double waarde)
        {
            saldo += waarde;
        }
        public void DebitSaldo(double waarde)
        {
            saldo -= waarde;
        }

        //Overwrite methodes

        public abstract double BerekenRente();
    }
}

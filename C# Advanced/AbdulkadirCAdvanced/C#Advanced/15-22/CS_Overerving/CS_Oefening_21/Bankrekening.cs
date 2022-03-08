using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Oefening_21
{
    public class Bankrekening : IBankrekening
    {
        private string naam;

        public Bankrekening(string nummer, string naam)
        {
            Saldo = 0; // kunnen we toch nog instellen dankzij private set; (zie hieronder)
            Rekeningnummer = nummer; // kunnen we toch nog instellen dankzij private set; (zie hieronder)
            this.naam = naam;
        }

        public string Naam { get; set; }
        public double Saldo { get; private set; }
        public string Rekeningnummer { get; private set; }

        public void Opname(double bedrag)
        {
            if (Saldo - bedrag < 0.0)
                throw new BankException($"{naam}\r\n\r\nJe saldo is ontoereikend!\r\nHuidig saldo: {Saldo:c}");
            else
                Saldo -= bedrag;
        }

        public void Storting(double bedrag)
        {
            if (Saldo + bedrag > 2500.0)
                throw new BankException($"{naam}\r\n\r\nStorting op {Rekeningnummer}\r\nKan maximaal 2500 bedragen!");
            else
                Saldo += bedrag;
        }
    }
}

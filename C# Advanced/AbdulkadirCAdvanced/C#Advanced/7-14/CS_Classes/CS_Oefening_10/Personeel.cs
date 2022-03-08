using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Oefening_010
{
    public class Personeel
    {
        private int cijfer;
        
        // Properties
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public string Geslacht { get; set; }
        public int Beoordelingscijfer
        {
            get { return cijfer; }
            set
            {
                if (value < 0)
                    cijfer = 0;
                else if (value > 10)
                    cijfer = 10;
                else
                    cijfer = value;
            }
        }
        public int Startjaar { get; set; }

        // Read-only properties
        public int Aantaldienstjaren => (DateTime.Now.Year - Startjaar); // Expression-bodied property
        public string Geslachttekst => (Geslacht.Equals("M")) ? "Mannelijk" : "Vrouwelijk";

        public decimal Premie
        {
            get 
            {
                decimal bedrag = (500 + Aantaldienstjaren * 20);
                if (cijfer < 5)
                    bedrag /= 2; // bedrag = bedrag / 2;
                else if (cijfer == 7 || cijfer == 8)
                    bedrag *= 1.5M; // bedrag = bedrag * 1.5M;
                else if (cijfer > 8)
                    bedrag *= 2;
                
                return bedrag;
            }
        }

        public Personeel() : this("", "", "M", 0, 2000)
        {
        }

        public Personeel(string naam, string voornaam, string geslacht, int cijfer, int startjaar)
        {
            Naam = naam;
            Voornaam = voornaam;
            Geslacht = geslacht;
            Beoordelingscijfer = cijfer;
            Startjaar = startjaar;
        }

        public void VerhoogBeoordeling()
        {
            Beoordelingscijfer++;
        }

        public void VerlaagBeoordeling()
        {
            Beoordelingscijfer--;
        }

        public string InformatieVolledig() => $"Personeelslid  {Voornaam} {Naam}\r\n\r\n" +
            $"Geslacht : {Geslachttekst}\r\nAantal dienstjaren : {Aantaldienstjaren}\r\n" + 
            $"Beoordelingscijfer : {Beoordelingscijfer}\r\nPremie: {Premie:c}";
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefening10KlassePersoneel
{
    public class Personeel
    {
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public string Geslacht { get; set; }
        public int Beoordelingscijfer { get; set; }
        public int Startjaar { get; set; }


        public int Aantaldienstjaren { get; }
        public string Geslachtstekst { get; }
        public decimal Premie { get; set; }


        public Personeel()
        {
            Naam = "";
            Voornaam = "";
            Geslacht = "M";
            Beoordelingscijfer = 0;
            Startjaar = 2000;
            Aantaldienstjaren = 0;
            Premie = BerekenPremie(0, 0);
        }
        public Personeel(string naam, string voornaam, string geslacht, int beoordelingscijver, int startjaar)
        {
            Naam = naam;
            Voornaam = voornaam;
            Geslacht = (geslacht == "M") ? "Mannelijk" : "Vrouwelijk";
            Beoordelingscijfer = beoordelingscijver;
            Startjaar = startjaar;
            Aantaldienstjaren = DateTime.Now.Year - startjaar;
            Premie = BerekenPremie(Beoordelingscijfer, Aantaldienstjaren);
        }

        private decimal BerekenPremie(int beoordelingscijfer, int dienstjaren)
        {
            decimal premie;
            decimal startbedrag = 500;
            decimal maandPremie = 20;

            if(beoordelingscijfer < 5)
            {
                startbedrag = startbedrag / 2;
            } 
            else if (beoordelingscijfer == 7 || beoordelingscijfer == 8)
            {
                startbedrag = startbedrag + (startbedrag * 2);
            }
            else
            {
                startbedrag = startbedrag * 2;
            }

            premie = startbedrag + (dienstjaren * maandPremie);
            return premie;
        }
        public void VerhoogBeoordeling()
        {
            Beoordelingscijfer++;
            Premie = BerekenPremie(Beoordelingscijfer, Aantaldienstjaren);
        }
        public void VerlaaggBeoordeling()
        {
            Beoordelingscijfer--;
            Premie = BerekenPremie(Beoordelingscijfer, Aantaldienstjaren);
        }
        public string InformatieVolledig()
        {
            string resultaat = $"Personeelslid {Naam} {Voornaam} \nGeslacht : {Geslacht} \n" +
                $"Aantal dienstjaren : {Aantaldienstjaren} \n" +
                $"Beoordelingscijfer : {Beoordelingscijfer} \n" +
                $"Premie : {Premie}";
            return resultaat;
        }
    }
}

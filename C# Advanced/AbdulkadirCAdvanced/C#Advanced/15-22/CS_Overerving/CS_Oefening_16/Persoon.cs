using System;

namespace CS_Oefening_16
{

    public class Persoon
    {
        public string Voornaam { get; set; }
        public string Naam { get; set; }
        public string Straat { get; set; }
        public string Postcode { get; set; }
        public DateTime Geboortedatum { get; set; }
        public string Email { get; set; }

        protected virtual string InfoHeader => "Uw persoonlijke gegevens:\r\n\r\n";

        public Persoon()
        {
            Voornaam = "Tom";
            Naam = "Quareme";
            Straat = "Elfde­Liniestraat 26";
            Postcode = "3500";
            Geboortedatum = new DateTime(1992, 1, 12);
        }

        // Read­-only property
        public virtual string Gegevens => $"{VolledigeNaam()}\r\nGeboortedatum:{Geboortedatum.ToLongDateString()}";

        public string Info()
            => $"{InfoHeader}Naam: {Voornaam} {Naam}\r\n" +
            $"Adres: {Straat} {Postcode}\r\nGeboortedatum: {Geboortedatum.ToLongDateString()}\r\nE-mail: {Email}";
        
        public string VolledigeNaam() => $"{Voornaam} {Naam}";
    }
}


using System;
using System.Windows;

namespace VoorbeeldenOverervingPolymorfismeWPF
{
	public class Persoon
	{
		
        // Eigenschappen
        public string Voornaam {get; set;}
		public string Naam {get; set;}
		public DateTime Geboortedatum {get; set;}

        // Read-only eigenschappen
        public virtual string Gegevens => $"{Voornaam} {Naam}\r\nGeboortedatum: {Geboortedatum.ToLongDateString()}";

       
        // Methods
        public virtual string VolledigeNaam() => Voornaam + " " + Naam;
        public virtual void Info(string tekst)
        {
            string info = "Uw persoonlijke gegevens:  ";
            MessageBox.Show(info + tekst, "Info Klasse Persoon", MessageBoxButton.OK, MessageBoxImage.Information);
        }


        // public virtual string VolledigeNaam()
        //{
        //	return Voornaam + " " + Naam;
        //}

        // Virtual geeft aan dat de eigenschap in de afgeleide klasse overschreven kan worden.
        //public virtual string Gegevens
        //{
        //	get
        //	{
        //		return Voornaam + " " + Naam + "\r\n" + "Geboortedatum: " + Geboortedatum.ToLongDateString();
        //	}
        //}



    }
	
}

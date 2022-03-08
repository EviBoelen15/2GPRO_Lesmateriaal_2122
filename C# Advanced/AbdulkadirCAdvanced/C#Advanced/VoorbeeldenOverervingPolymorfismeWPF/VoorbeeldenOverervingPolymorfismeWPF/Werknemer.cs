
using System;
using System.Windows;

namespace VoorbeeldenOverervingPolymorfismeWPF
{
    public class Werknemer : Persoon
    {
        public DateTime DatumInDienst { get; set; }
        private string functie = "Lector";

        public string Functie
        {
            get { return functie; }
            set { functie = value; }
        }

        public override void Info(string tekst)
        {
            // Infotekst is gewijzigd.
            string info = "Gegevens van de werknemer:   ";
            MessageBox.Show(info + tekst, "Info Klasse Werknemer", MessageBoxButton.OK
                , MessageBoxImage.Information);
        }

        public override string Gegevens => $"{base.Gegevens} - {Functie}";


        //public override string Gegevens
        //{
        //    get { return base.Gegevens + " - " + Functie; }
        //    // Base verwijst naar basisklasse.
        //}


    }
	
}

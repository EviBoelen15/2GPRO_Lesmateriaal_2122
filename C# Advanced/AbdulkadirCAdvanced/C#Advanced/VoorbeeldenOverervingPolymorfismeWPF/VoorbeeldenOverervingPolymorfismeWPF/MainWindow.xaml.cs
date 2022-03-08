using System;
using System.Windows;

namespace VoorbeeldenOverervingPolymorfismeWPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		Werknemer wrkn = new Werknemer();
		Persoon prsn = new Persoon();

		private void BtnBasisklasse_Click(object sender, RoutedEventArgs e)
		{
			// Initialiseren van klasse.
			prsn.Voornaam = "Patricia";
			prsn.Naam = "Briers";
			prsn.Geboortedatum = DateTime.Parse("27/11/1979");

			MessageBox.Show(prsn.VolledigeNaam(), " Volledige naam", MessageBoxButton.OK, MessageBoxImage.Information);
			MessageBox.Show(prsn.Gegevens, "Persoonlijke gegevens", MessageBoxButton.OK, MessageBoxImage.Information);
		}

		

		private void BtnOvererving_Click(object sender, RoutedEventArgs e)
		{
			// Je kan de method VolledigeNaam() gebruiken uit de klasse Persoon. 
			wrkn.Voornaam = "Leona";
			wrkn.Naam = "Bertels";
			wrkn.Geboortedatum = DateTime.Parse("27/11/1984");
			wrkn.DatumInDienst = DateTime.Parse("2/9/2011");

			string bericht = wrkn.VolledigeNaam() + "\r\n" + "is in dienst sinds " + wrkn.DatumInDienst.ToLongDateString();
			MessageBox.Show(bericht, " Persoonsgegevens", MessageBoxButton.OK, MessageBoxImage.Information);
		}

		

		private void BtnPolymorfisme_Click(object sender, RoutedEventArgs e)
		{
			Persoon persoon = new Persoon();
			persoon.Info("Maarten Clijsters" + " geboren in Hasselt");

			Werknemer werknemer = new Werknemer();
			werknemer.Info("Patricia  Briers" + " in dienst sinds 02-09-1991");

			// of de eigenschappen Gegevens uit beide klassen.
			persoon.Geboortedatum = DateTime.Parse("14-05-1980");
			werknemer.Geboortedatum = DateTime.Parse("14-05-1990");
			MessageBox.Show("Gegevens uit basisklasse: " + persoon.Gegevens, "Base");
			MessageBox.Show("Gegevens uit afgeleide klasse: " + werknemer.Gegevens, "This");
		}

		private void BtnConverteren_Click(object sender, RoutedEventArgs e)
		{
			prsn.Geboortedatum = DateTime.Parse("14-05-1980");
			wrkn.Geboortedatum = DateTime.Parse("14-05-1990");

			MessageBox.Show($"{BerekenLeeftijd(prsn)} jaar", "Geboortedatum van klasse persoon");

			// De functie BerekenLeeftijd accepteert enkel een argument van het type Persoon!
			prsn = (Persoon)wrkn;

			MessageBox.Show($"{BerekenLeeftijd(prsn)} jaar", "Geboortedatum van klasse werknemer");
		}

		public int BerekenLeeftijd(Persoon prsn)
		{
			DateTime vandaag = DateTime.Today;
			int leeftijd = vandaag.Year - this.prsn.Geboortedatum.Year;
			if (this.prsn.Geboortedatum > vandaag.AddYears(-leeftijd)) leeftijd--;
			return leeftijd;
		}


	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CS_Oefening_029
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

        private void LeegMaken()
        {
            TxtMnr.Clear();
            TxtVoornaam.Clear();
            TxtNaam.Clear();
            TxtFunctie.Clear();
            TxtChef.Clear();
            TxtGeboortedatum.Clear();
            TxtMaandsal.Clear();
            TxtComm.Clear();
            TxtAfdeling.Clear();

            TxtMnr.Focus();
        }

        private void BtnZoekMedewerker_Click(object sender, RoutedEventArgs e)
        {
            int mnrID;
            bool isGetal = int.TryParse(TxtMnr.Text, out mnrID);
            if (!isGetal)
            {
                MessageBox.Show("Geef een correct medewerkersnummer op!",
                    "Fout",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                LeegMaken();
                return;
            }

            try
            {
                Medewerker medewerker = DBMedewerker.ZoekMedewerker(mnrID);

                TxtVoornaam.Text = medewerker.Voornaam;
                TxtNaam.Text = medewerker.Naam;
                TxtFunctie.Text = medewerker.Functie;
                TxtChef.Text = medewerker.Chef.ToString();
                TxtGeboortedatum.Text = medewerker.GebDatum.ToString();
                TxtMaandsal.Text = medewerker.Maandsalaris.ToString();
                TxtComm.Text = medewerker.Comm.ToString();
                TxtAfdeling.Text = medewerker.Afdeling.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Medewerker niet gevonden", MessageBoxButton.OK, MessageBoxImage.Warning);
                LeegMaken();
            }
        }

        private void BtnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            ToevoegenWindow w = new ToevoegenWindow();
            if (w.ShowDialog() == true)
            {
                MessageBox.Show("Nieuwe medewerker is succesvol toegevoegd!", 
                    "Medewerker toegevoegd", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Information);
            }
        }

        private void BtnWijzigen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Medewerker medewerker = new Medewerker();
                medewerker.MnrID = int.Parse(TxtMnr.Text);
                medewerker.Naam = TxtNaam.Text;
                medewerker.Voornaam = TxtVoornaam.Text;
                medewerker.Functie = TxtFunctie.Text;
                medewerker.Chef = int.Parse(TxtChef.Text);

                medewerker.GebDatum = DateTime.Parse(TxtGeboortedatum.Text.Split(' ')[0]); // laat het tijdstip weg
                medewerker.Maandsalaris = float.Parse(TxtMaandsal.Text);
                medewerker.Comm = float.Parse(TxtComm.Text);
                medewerker.Afdeling = int.Parse(TxtComm.Text);

                DBMedewerker.UpdateMedewerker(medewerker);
            }
            catch (FormatException)
            {
                MessageBox.Show("Voer correcte waardes in!", "Fout!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            catch (Exception)
            {
                MessageBox.Show("Medewerker niet kunnen updaten!", "Fout!", MessageBoxButton.OK, MessageBoxImage.Warning);
                LeegMaken();
                return;
            }

            MessageBox.Show("Medewerker is succesvol gewijzigd!",
                    "Medewerker gewijzigd",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
        }

        private void BtnVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            int mnrID = int.Parse(TxtMnr.Text);
            string naam = DBMedewerker.IDNaarNaam(mnrID);

            MessageBoxResult resultaat = MessageBox.Show($"Medewerker {naam.ToUpper()} verwijderen?",
                "Verwijdering bevestigen.",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (resultaat == MessageBoxResult.Yes)
            {
                try
                {
                    DBMedewerker.VerwijderMedewerker(mnrID);
                    LeegMaken();
                }
                catch (Exception)
                {
                    MessageBox.Show("Kan medewerker niet verwijderen!", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnAfsluiten_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
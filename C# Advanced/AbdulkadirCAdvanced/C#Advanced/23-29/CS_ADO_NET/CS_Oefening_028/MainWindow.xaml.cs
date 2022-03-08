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

namespace CS_Oefening_028
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

            TxtMnr.SelectAll();
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
    }
}

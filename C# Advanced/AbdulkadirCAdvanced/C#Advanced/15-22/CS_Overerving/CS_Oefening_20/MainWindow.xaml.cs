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

using System.IO;

namespace CS_Oefening_20
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<HondDBItem> hondenlijst;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Inladen van bestand Hondenras
            try
            {
                hondenlijst = HondDB.LeesHondenBestand(@"..\..\Bestanden\Hondenras.txt");
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                Close();
                return;
            }

            // Toevoegen aan combobox
            foreach (var h in hondenlijst)
            {
                CboHond.Items.Add(h.Ras);
            }
        }

        private void BtnOuderdomPersoon_Click(object sender, RoutedEventArgs e)
        {
            int geboortejaar;
            bool isGelukt = int.TryParse(TxtPersoonGeboortejaar.Text, out geboortejaar);
            if (!isGelukt)
            {
                TxtPersoonGeboortejaar.Clear();
                return;
            }

            // We  instantiëren een object van de klasse Persoon
            Persoon persoon = new Persoon(TxtPersoonVoornaam.Text, TxtPersoonFamilienaam.Text, geboortejaar);
            MessageBox.Show($"Ouderdom: {persoon.Ouderdom}", persoon.Naam, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BtnOuderdomBoom_Click(object sender, RoutedEventArgs e)
        {
            Boom boom = new Boom(TxtBoomSoort.Text, int.Parse(TxtBoomPlantjaar.Text));
            MessageBox.Show($"Ouderdom: {boom.Ouderdom}", boom.Naam, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BtnOuderdomHond_Click(object sender, RoutedEventArgs e)
        {
            int index = CboHond.SelectedIndex;
            if (index != -1) // er is iets geselecteerd
            {
                Hond hond = new Hond(
                    CboHond.Text, 
                    TxtHondGrootte.Text, 
                    TxtHondNaam.Text, 
                    int.Parse(TxtHondGeboortejaar.Text), 
                    hondenlijst[index].LeeftijdsFactor);
                MessageBox.Show($"Ouderdom: {hond.Ouderdom}", hond.Naam, MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Kies eerst het ras van de hond!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CboHond_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = CboHond.SelectedIndex;
            if (index == -1) // niets geselecteerd
            {
                TxtHondGrootte.Clear();
                return;
            }
            // toch iets geselecteerd
            TxtHondGrootte.Text = hondenlijst[index].Grootte;
            TxtHondGrootte.Focus();  // focus verzetten anders blijft ComboBox geselecteerd
        }
    }
}

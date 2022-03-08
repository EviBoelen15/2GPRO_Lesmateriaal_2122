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

namespace CS_Oefening_010
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // bool bijhouden, want anders wordt SelectionChanged al getriggerd wanneer WPF componenten nog niet bestaan
        private bool loaded = false;
        
        private Personeel personeel = new Personeel();

        public MainWindow()
        {
            InitializeComponent();

            MessageBoxResult mr = MessageBox.Show(
                "Starten met ingevulde waarden?",
                "Start",
                MessageBoxButton.YesNo);

            personeel = (mr == MessageBoxResult.No)
                ? new Personeel()
                : new Personeel("Dox", "Paul", "M", 9, 1983);

            loaded = true;
            TxtVoornaam.Text = personeel.Voornaam;
            TxtNaam.Text = personeel.Naam;
            TxtStartjaar.Text = personeel.Startjaar.ToString();
            ToonResultaat();
        }

        private void ToonResultaat()
        {
            TxtRes.Text = personeel.InformatieVolledig();
        }

        private void TxtVoornaam_LostFocus(object sender, RoutedEventArgs e)
        {
            personeel.Voornaam = TxtVoornaam.Text;
            ToonResultaat();
        }

        private void TxtNaam_LostFocus(object sender, RoutedEventArgs e)
        {
            personeel.Naam = TxtNaam.Text;
            ToonResultaat();
        }

        private void TxtStartjaar_LostFocus(object sender, RoutedEventArgs e)
        {
            int sj;
            bool isGelukt = int.TryParse(TxtStartjaar.Text, out sj);
            if (!isGelukt)
            {
                MessageBox.Show("Geef een correct startjaar in!", 
                    "Foute invoer", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Error);
                return;
            }
            personeel.Startjaar = sj;
            ToonResultaat();
        }

        private void CboGeslacht_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!loaded)
                return;
            personeel.Geslacht = ((ComboBoxItem)CboGeslacht.SelectedItem).Content.ToString();
            ToonResultaat();
        }

        private void BtnVerhoogBeoordeling_Click(object sender, RoutedEventArgs e)
        {
            personeel.VerhoogBeoordeling();
            ToonResultaat();
        }

        private void BtnVerlaagBeoordeling_Click(object sender, RoutedEventArgs e)
        {
            personeel.VerlaagBeoordeling();
            ToonResultaat();
        }
    }
}

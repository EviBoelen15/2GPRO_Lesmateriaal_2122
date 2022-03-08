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

using System.Data.SqlClient;

namespace CS_Oefening_026
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Klant> klanten;
        private string connectionString = Properties.Settings.Default.CNstr;

        public MainWindow()
        {
            InitializeComponent();

            try
            {
                RefreshLbxKlanten();
            }
            catch (SqlException)
            {
                MessageBox.Show("Voer een geldige datum in!", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RefreshLbxKlanten()
        {
            LbxKlanten.Items.Clear();
            klanten = KlantDB.LaadKlanten(connectionString);
            foreach (var klant in klanten)
            {
                LbxKlanten.Items.Add(klant.ToString());
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            DateTime geboortedatum;
            bool isDatum = DateTime.TryParse(TxtGeboortedatum.Text, out geboortedatum);
            if (!isDatum)
            {
                MessageBox.Show("Voer een geldige datum in!", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Klant klant = new Klant();
            klant.Voornaam = TxtVoornaam.Text;
            klant.Naam = TxtNaam.Text;
            klant.Geboortedatum = geboortedatum;
            klant.Woonplaats = TxtWoonplaats.Text;
            klant.Gebruikersnaam = TxtGebruikersnaam.Text;
            klant.Wachtwoord = PwbWachtwoord.Password;

            try
            {
                KlantDB.AddKlant(klant, connectionString);
                RefreshLbxKlanten();
            }
            catch (SqlException)
            {
                MessageBox.Show("Respecteer de juiste datatypes en constraints!", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int index = LbxKlanten.SelectedIndex;
            if (index == -1)
            {
                return;
            }

            bool isDatum = DateTime.TryParse(TxtGeboortedatum.Text, out DateTime geboortedatum);
            if (!isDatum)
            {
                MessageBox.Show("Voer een geldige datum in!", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int id = Klant.StringNaarID((string)LbxKlanten.Items[index]);

            Klant klant = new Klant()
            {
                ID = id,
                Voornaam = TxtVoornaam.Text,
                Naam = TxtNaam.Text,
                Geboortedatum = geboortedatum,
                Woonplaats = TxtWoonplaats.Text,
                Gebruikersnaam = TxtGebruikersnaam.Text,
                Wachtwoord = PwbWachtwoord.Password
            };

            try
            {
                KlantDB.UpdateKlant(klant, connectionString);
                RefreshLbxKlanten();
            }
            catch (SqlException)
            {
                MessageBox.Show("Respecteer de juiste datatypes en constraints!", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            int index = LbxKlanten.SelectedIndex;
            if (index == -1)
            {
                return;
            }
            int id = Klant.StringNaarID((string)LbxKlanten.Items[index]);

            try
            {
                KlantDB.DeleteKlant(id, connectionString);
                RefreshLbxKlanten();
            }
            catch (SqlException)
            {
                MessageBox.Show("Respecteer de juiste datatypes en constraints!", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

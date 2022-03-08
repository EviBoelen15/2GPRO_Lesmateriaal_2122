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
using System.Windows.Shapes;

namespace CS_Oefening_029
{
    /// <summary>
    /// Interaction logic for ToevoegenWindow.xaml
    /// </summary>
    public partial class ToevoegenWindow : Window
    {
        public ToevoegenWindow()
        {
            InitializeComponent();
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Medewerker medewerker = new Medewerker();
                medewerker.MnrID = int.Parse(TxtMnr.Text);
                medewerker.Naam = TxtNaam.Text;
                medewerker.Voornaam = TxtVoornaam.Text;
                medewerker.Functie = TxtFunctie.Text;
                medewerker.Chef = int.Parse(TxtChef.Text);
                medewerker.GebDatum = DateTime.Parse(TxtGeboortedatum.Text);
                medewerker.Maandsalaris = float.Parse(TxtMaandsal.Text);
                medewerker.Comm = float.Parse(TxtComm.Text);
                medewerker.Afdeling = int.Parse(TxtComm.Text);

                DBMedewerker.ToevoegenMedewerker(medewerker);
                DialogResult = true;
            }
            catch (FormatException)
            {
                MessageBox.Show("Vul alle velden correct in!", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                DialogResult = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Kan medewerker niet toevoegen!", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                DialogResult = false;
            }
        }

        private void BtnAnnuleren_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}

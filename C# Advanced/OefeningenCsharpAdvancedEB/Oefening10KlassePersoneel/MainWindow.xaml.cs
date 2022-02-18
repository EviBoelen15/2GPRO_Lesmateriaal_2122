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

namespace Oefening10KlassePersoneel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Personeel personeel; 
        MessageBoxResult result;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            result = MessageBox.Show("Wil je een lege of nieuwe gebruiker toevoegen", "Personeel", MessageBoxButton.YesNo);
            if(result.Equals(MessageBoxResult.Yes))
            {
                personeel = new Personeel();
                VulNieuwePersoneel(personeel);
            }   
        }

        private void VulNieuwePersoneel(Personeel personeel)
        {
            txtNaam.Text = personeel.Naam;
            txtVoornaam.Text = personeel.Voornaam;
            txtStartjaar.Text = personeel.Startjaar.ToString();
            cbGeslacht.SelectedItem = personeel.Geslacht;
            txtResultaat.Text = personeel.InformatieVolledig();
        }

        private void btnVerhoog_Click(object sender, RoutedEventArgs e)
        {
            if(personeel.Beoordelingscijfer <= 10)
            {
                personeel.VerhoogBeoordeling();
                txtResultaat.Text = personeel.InformatieVolledig();
            }
            else
            {
                MessageBox.Show("Max beoordeling bereikt");
            }
            
        }

        private void btnVerlaag_Click(object sender, RoutedEventArgs e)
        {
            if (personeel.Beoordelingscijfer > 0)
            {
                personeel.VerlaaggBeoordeling();
                txtResultaat.Text = personeel.InformatieVolledig();
            }
            else
            {
                MessageBox.Show("Min beoordeling bereikt");
            }
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            personeel = new Personeel(txtNaam.Text, txtVoornaam.Text, cbGeslacht.SelectedItem.ToString(), 0, int.Parse(txtStartjaar.Text));
        }


    }
}

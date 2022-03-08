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

namespace CS_Oefening_16
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

        private void BtnStudent_Click(object sender, RoutedEventArgs e)
        {
            LbxInfo.Items.Clear();
            try
            {
                List<Student> studenten = Student.LeesStudenten(@"..\..\Bestanden\Studenten.csv");
                foreach (var student in studenten)
                    LbxInfo.Items.Add(student.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("Kan bestand Studenten.csv niet lezen!", 
                    "Fout", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Error);
            }   
        }

        private void BtnLector_Click(object sender, RoutedEventArgs e)
        {
            Persoon p = new Persoon();
            p.Naam = "Janssen";
            LbxInfo.Items.Clear();
            try
            {
                List<Lector> lectoren = Lector.LeesLectoren(@"..\..\Bestanden\Lectoren.csv");
                foreach (var lector in lectoren)
                    LbxInfo.Items.Add(lector.Gegevens);
            }
            catch (Exception)
            {
                MessageBox.Show("Kan bestand Lectoren.csv niet lezen!", 
                    "Fout", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Error);
            }
        }

        private void BtnPersoon_Click(object sender, RoutedEventArgs e)
        {
            Persoon persoon = new Persoon();
            // Alle gegevens van de persoon zitten in de constructor maar 
            // enkel het e­mailadres moet uit het tekstvak opgehaald worden.
            // Controle
            if (Validator.IsPresent(TxtEmail.Text) && Validator.IsValidEmail(TxtEmail.Text))
            {
                persoon.Email = TxtEmail.Text;
                // Afdruk van gegevens.
                MessageBox.Show(persoon.Info(), 
                    "Info Klasse Persoon", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Information);
            }
        }

        private void TxtEmail_GotFocus(object sender, RoutedEventArgs e)
        {
            TxtEmail.Text = string.Empty;
        }
    }
}

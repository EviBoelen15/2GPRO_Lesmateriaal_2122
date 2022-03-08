using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Threading;

namespace CS_Oefening_12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Metingen metingen = new Metingen();
        private Random rnd = new Random();
        private int vorigeKleur = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private string Seizoen(int maand, int dag)
        {
            switch (maand)
            {
                case 3:
                    return (dag >= 21) ? "lente.jpg" : "winter.jpg";
                case 4:
                case 5:
                    return "lente.jpg";
                case 6:
                    return (dag >= 21) ? "zomer.jpg" : "lente.jpg";
                case 7:
                case 8:
                    return "zomer.jpg";
                case 9:
                    return (dag >= 21) ? "herst.jpg" : "zomer.jpg";
                case 10:
                case 11:
                    return "herfst.jpg";
                case 12:
                    return (dag >= 21) ? "winter.jpg" : "herfst.jpg";
            }
            return "winter.jpg";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // TIMER

            // Tijd instellen al bij het inladen van het Window
            // Anders verschijnt de tijd pas na het interval (1 seconde)
            DispatcherTimer_Tick(sender, e);

            DispatcherTimer timer = new DispatcherTimer();
            // Timer laten aflopen om de seconde.
            timer.Tick += DispatcherTimer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1); // uren, minuten, seconden

            // Timer laten starten 
            timer.Start();

            // AFBEELDING SEIZOEN 
            string seizoensAfb = Seizoen(DateTime.Now.Month, DateTime.Now.Day);
            string bestand = System.IO.Path.Combine(@"..\..\Bestanden", seizoensAfb);
            if (File.Exists(bestand))
            {
                // Zie slides Tom Quareme C# Essentials (Hoofdstuk 9: Besturingselementen en layouts)
                ImgSeizoen.Source = new BitmapImage(
                    new Uri(AppDomain.CurrentDomain.BaseDirectory + bestand, UriKind.RelativeOrAbsolute));
            }
            else
            {
                MessageBox.Show("Kan afbeelding niet inladen!",
                    "Ongeldig bestand",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            TextBlockDateTime.Text = $"{DateTime.Now.ToLongDateString()} {DateTime.Now.ToLongTimeString()}";
        }

        private void MnuDetails_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TxtResultaat.Text = metingen.LeesAlles(@"..\..\Bestanden\Zonnepanelen.txt");
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show($"Geef nieuwe naam!\r\n\r\n{ex.Message}",
                    "Foutmelding",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("Kan bestand niet vinden.",
                    "Onverwachte fout.",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }

        private void MnuSamenvatting_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                metingen.LeesEnVerwerk(@"..\..\Bestanden\Zonnepanelen.txt");
                TxtResultaat.Text = metingen.ToonResultaten();
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show($"Geef nieuwe naam!\r\n\r\n{ex.Message}",
                    "Foutmelding",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("Kan bestand niet vinden.",
                    "Onverwachte fout.",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }

        private void MnuDatum_Click(object sender, RoutedEventArgs e)
        {
            TextBlockDateTime.Visibility =
                (MnuDatum.IsChecked) ? Visibility.Visible : Visibility.Hidden;
        }

        private void MnuAchtergrond_Click(object sender, RoutedEventArgs e)
        {
            // Kleur instellen.
            int kleur = rnd.Next(1, 6); // van 1 tot en met 5 (6 is exclusief dus)
            //Voorkomen dat dezelfde kleur opnieuw gekozen wordt.
            while (kleur == vorigeKleur)
            {
                kleur = rnd.Next(1, 6);
            }
            vorigeKleur = kleur;

            switch (kleur)
            {
                case 1:
                    Background = Brushes.Gold;
                    break;
                case 2:
                    Background = Brushes.BlueViolet;
                    break;
                case 3:
                    Background = Brushes.LightGreen;
                    break;
                case 4:
                    Background = Brushes.Silver;
                    break;
                default:
                    Background = Brushes.MediumVioletRed;
                    break;
            }
        }
    }
}

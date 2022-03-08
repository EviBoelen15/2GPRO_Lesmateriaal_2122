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
using Microsoft.Win32;
using System.Windows.Threading;

namespace CS_Oefening_09
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Dialoogvenster op voorhand aanmaken (gebruiken we in meerdere event procedures)
        private OpenFileDialog ofd = new OpenFileDialog()
        {
            Filter = "Csv bestanden (*.csv) |*.csv|Tekstbestanden (*.txt) |*.txt|Alle bestanden (*.*)|*.*",
            InitialDirectory = System.IO.Path.GetFullPath(@"..\..\Bestanden"),
            Title = "Bestand openen",
            FileName = "Punten.csv",
            AddExtension = true,
            DefaultExt = "csv"
        };

        private List<PuntenAdmin> pntAdmin = new List<PuntenAdmin>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Toon op voorhand al de tijd, anders verschijnt die pas na 1 seconde.
            DispatcherTimer_Tick(sender, e);

            DispatcherTimer wekker = new DispatcherTimer();
            wekker.Tick += DispatcherTimer_Tick;
            // Timer laten aflopen om de seconde.
            wekker.Interval = new TimeSpan(0, 0, 1); // uren, minuten, seconden
            // Timer laten starten
            wekker.Start();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            TextBlockDateTime.Text = $"{DateTime.Now.ToLongDateString()} {DateTime.Now.ToLongTimeString()}";
        }

        private void BtnInlezen_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            if (ofd.ShowDialog() != true)
            {
                MessageBox.Show("File does not exist",
                        "Error message",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                return;
            }

            string fileName = ofd.FileName;
            FileInfo fi = new FileInfo(fileName);
            if (!fi.Exists)
            {
                return;
            }

            using (StreamReader sr = fi.OpenText())
            {
                while (!sr.EndOfStream)
                {
                    PuntenAdmin ad = new PuntenAdmin();
                    string[] lijnen = sr.ReadLine().Split(';'); // CSV-file
                    string[] name = lijnen[0].Trim().Split(' ');
                    ad.Familyname = name[0].Trim();
                    ad.Firstname = name[1].Trim();
                    ad.Email = lijnen[1].Trim();
                    ad.Gender = lijnen[2].Trim();
                    
                    string punten1 = lijnen[3].Substring(0, 3).Trim();
                    string punten2 = lijnen[3].Substring(3, 3).Trim();
                    ad.Score = int.Parse(punten1);
                    ad.TotalScore = int.Parse(punten2);
                    
                    sb.Append($"{(ad.Firstname + ' ' + ad.Familyname), -21}{ad.Email, -21}");
                    sb.Append($"{ad.Gender, -5}{ad.Score}/{ad.TotalScore}".Replace("\"", "")); // laat dubbele quotes weg
                    sb.AppendLine();
                    
                    pntAdmin.Add(ad);
                }
            }
            BtnVerwerken.IsEnabled = true;
            TxtResultaat.Text = sb.ToString();
        }

        public void BtnNalezen_Click(object sender, RoutedEventArgs e)
        {
            // Openen van bestaand dialoogvenster
            ofd.ShowDialog();
            string fileName = ofd.FileName;
            
            FileInfo fi = new FileInfo(fileName);
            if (!fi.Exists)
            {
                TxtResultaat.Clear();
                MessageBox.Show($"Bestand {System.IO.Path.GetFileName(fileName)} bestaat niet",
                    "Foutmelding",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;  
            }

            using (StreamReader sr = fi.OpenText())
            {
                TxtResultaat.Text = sr.ReadToEnd();
            }
        }

        private void BtnVerwerken_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Alle bestanden (*.*)|*.*| CSV bestanden (*.csv)|*.csv| Tekstbestanden (*.txt)|*.txt",
                FilterIndex = 2,
                InitialDirectory = System.IO.Path.GetFullPath(@"..\..\Bestanden"),
                Title = "Geef een bestandsnaam op",
                FileName = "PuntenVerwerkt.csv",
                // Bevestiging vragen bij overschrijven van een bestand
                OverwritePrompt = true
            };

            if (sfd.ShowDialog() != true)
            {
                MessageBox.Show("De resultaten zijn niet verwerkt.", 
                    "Resultaten", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Information);
                return;
            }

            // Bestand opslaan
            string fileName = sfd.FileName;
            using (StreamWriter sw = File.CreateText(fileName))
            {
                // Gegevens wegschrijven
                foreach (var item in pntAdmin)
                {
                    sw.WriteLine($"{item.Familyname + ' '+ item.Firstname};{item.Percent():p};{item.Grade()}");
                }
            }

            MessageBox.Show($"De resultaten zijn verwerkt. Je kan de resultaten nalezen in het bestand {fileName}",
                "Resultaten", 
                MessageBoxButton.OK, 
                MessageBoxImage.Information);
            BtnNalezen.IsEnabled = true;
        }

        private void BtnSluiten_Click(object sender, RoutedEventArgs e)
        {
            Close(); 
        }
    }
}

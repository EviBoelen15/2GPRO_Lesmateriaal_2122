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

namespace CS_Oefening_03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<string, float> puntenlijst = new Dictionary<string, float>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnInlezen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Alle bestanden (*.*)|*.*|Tekstbestanden (*.txt) |*.txt",
                FilterIndex = 2,
                InitialDirectory = Environment.CurrentDirectory, // onder bin\Debug
                Title = "Bestand openen",
                AddExtension = true,
                DefaultExt = "txt",
                FileName = "Punten.txt"
            };

            if (ofd.ShowDialog() == false)
            {
                return; // Indien we niet op Openen klikken
            }

            StringBuilder sb = new StringBuilder();
            using (StreamReader sr = new StreamReader(ofd.FileName))
            {
                while (!sr.EndOfStream)
                {
                    string lijn = sr.ReadLine();
                    string naam = lijn.Substring(0, 18).Trim();
                    string mail = lijn.Substring(19, 20).Trim();
                    string geslacht = lijn.Substring(40, 1); // Geen Trim() nodig, want 1 karakter maar
                    string puntenNotatie = lijn.Substring(48, 6).Trim();
                    sb.AppendLine($"{naam, -21}{mail, -21}{geslacht, -5}{puntenNotatie, -9}");

                    float punt = float.Parse(puntenNotatie.Substring(0, 3)); // eerste 3 cijfers
                    float max = float.Parse(puntenNotatie.Substring(3, 3)); // laatste 3 cijfers
                    float punten = punt / max; // kommagetal van 0 tot 1
                    puntenlijst[naam] = punten; // puntenlijst.Add(naam, punten);
                }
            }
            // De TextBox TxtResultaat gaat enkel en alleen mooie uitgelijnde kolommen hebben
            // wanneer we de FontFamily instellen op een monospaced lettertype!!! vb/ Consolas
            // (FontFamily="Consolas")
            TxtResultaat.Text = sb.ToString();
            BtnVerwerken.IsEnabled = true;
        }

        private void BtnVerwerken_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Alle bestanden (*.*)|*.*|Tekstbestanden (*.txt)|*.txt", // keuze uit deze bestandstypes
                FilterIndex = 2, // kies het 2de (tekstbestanden) uit bovenstaande filter standaard aangeduid
                Title = "Geef een bestandsnaam op", // titel
                OverwritePrompt = true,  // bevestiging vragen bij overschrijven van bestand 
                AddExtension = true, // extensie wordt toegevoegd aan bestand
                DefaultExt = "txt", // standaardextensie die wordt toegevoegd is txt
                FileName = "PuntenVerwerkt.txt", // bestandsnaam van bestand dat je wil opslaan
                InitialDirectory = Environment.CurrentDirectory // onder bin\Debug
            };

            if (sfd.ShowDialog() == false)
            {
                return; // Indien we niet op Opslaan klikken
            }

            using (StreamWriter sw = new StreamWriter(sfd.FileName))
            {
                foreach (var paar in puntenlijst)
                {
                    string naam = paar.Key;
                    float punten = paar.Value;
                    string graad = (punten >= 0.85f) ? "Geslaagd" : "Niet Geslaagd";
                    /*
                    if (punten >= 0.85f)
                    {
                        graad = "Geslaagd";
                    }
                    else
                    {
                        graad = "Niet Geslaagd";
                    }
                    */

                    // :P zet kommagetal tussen 0 en 1 om naar percentage met 2 cijfers achter de komma
                    sw.WriteLine($"{naam, -24}{punten, -10:P}{graad, -20}");
                }
            }
            BtnNalezen.IsEnabled = true;

            MessageBox.Show($"De resultaten zijn verwerkt. Je kan de resultaten nalezen in het bestand {sfd.FileName}",
                "Resultaten",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        private void BtnNalezen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Alle bestanden (*.*)|*.*|Tekstbestanden (*.txt)|*.txt",
                FilterIndex = 2,
                InitialDirectory = Environment.CurrentDirectory,
                Title = "Bestand openen",
                AddExtension = true,
                DefaultExt = "txt",
                FileName = "PuntenVerwerkt.txt"
            };

            TxtResultaat.Clear();
            if (ofd.ShowDialog() == false)
            {
                return; // Indien we niet op Openen klikken
            }

            FileInfo fi = new FileInfo(ofd.FileName);
            if (fi.Exists)
            {
                string tekst;
                using (StreamReader sr = fi.OpenText())
                {
                    tekst = sr.ReadToEnd();
                }
                TxtResultaat.Text = tekst;
            }
            else
            {
                MessageBox.Show($"Bestand {System.IO.Path.GetFileName(ofd.FileName)} bestaat niet", 
                    "Foutmelding", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Information);
            }
        }

        private void BtnSluiten_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

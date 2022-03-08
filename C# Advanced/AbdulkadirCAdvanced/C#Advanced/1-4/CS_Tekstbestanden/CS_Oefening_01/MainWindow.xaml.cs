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

namespace CS_Oefening_01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<string, string> dicGeg = new Dictionary<string, string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private string InlezenBestand(string bestandsnaam)
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                using (StreamReader sr = new StreamReader(bestandsnaam))
                {
                    int regelNummer = 1;
                    while (!sr.EndOfStream) // lees het bestand regel per regel in
                    {
                        // Splits de ingelezen regel tekst volgens scheidingsteken ','.
                        string[] velden = sr.ReadLine().Split(',');

                        if (velden.Length != 2) // lege regel, geen ',' tussen velden of 1 veld ontbreekt.
                        {
                            MessageBox.Show($"Onvolledige gegevens bij lijn {regelNummer}");
                        }
                        else
                        {
                            // Verwijder alle " dubbele quotes
                            string naam = velden[0].Replace("\"", "");
                            string mail = velden[1].Replace("\"", "");

                            sb.AppendLine($"{naam} : {mail}");
                        }
                        regelNummer++;
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("Geef nieuwe naam!\r\n\r\n" + ex.Message, 
                    "Foutmelding", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("Probleem met het inlezen van het bestand.", 
                    "Foutmelding", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Warning);
            }

            return sb.ToString();
        }

        private void BtnInlezen_Click(object sender, RoutedEventArgs e)
        {
            string inhoud = InlezenBestand("Email.txt");
            // Als het bestand gevonden is, dan is de inhoud niet leeg
            if (inhoud.Length != 0)
            {
                TxtResultaat.Text = inhoud;
            }
        }

        private void BtnInlezenDialog_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Alle bestanden (*.*)|*.*|Tekstbestanden (*.txt) |*.txt",
                FilterIndex = 2,
                FileName = "Email.txt",
                InitialDirectory = Environment.CurrentDirectory // onder bin\Debug   
            };

            if (ofd.ShowDialog() == true) // bestand geopend en op knop Openen geklikt.
            {
                string inhoud = InlezenBestand(ofd.FileName);
                // Als het bestand gevonden is, dan is de inhoud niet leeg
                if (inhoud.Length != 0)
                {
                    TxtResultaat.Text = inhoud;
                }
            }
        }

        // Toevoegen van elementen aan dictionary bestaande uit de Key en Value.
        private void BtnInlezenDictionary_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (StreamReader sr = new StreamReader("Email.txt"))
                {
                    int regelNummer = 1;
                    while (!sr.EndOfStream)
                    {
                        //Scheidingsteken opgeven.
                        string[] velden = sr.ReadLine().Split(',');

                        if (velden.Length != 2)
                        {
                            MessageBox.Show($"Onvolledige gegevens bij lijn {regelNummer}");
                        }
                        else
                        {
                            string naam = velden[0].Replace("\"", "");
                            string mail = velden[1].Replace("\"", "");
                            dicGeg.Add(naam, mail);
                        }
                        regelNummer++;
                    }
                }

                foreach (var paar in dicGeg)
                {
                    TxtResultaat.AppendText($"{paar.Key} : {paar.Value}\r\n");
                }
                BtnWegschrijven.IsEnabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Kan bestand niet wegschrijven.", 
                    "Foutmelding", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Warning);
            }
        }


        private void BtnWegschrijven_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //File.CreateText(pad) creëert en overschrijft een tekstbestand.
                using (StreamWriter sw = File.CreateText("Adressen.txt"))
                {
                    // Schrijf elke Value van elk key-value paar van de Dictionary weg naar bestand
                    foreach (var paar in dicGeg)
                    {
                        sw.WriteLine(paar.Value);
                    }

                }
                MessageBox.Show(@"E-mailadressen weggeschreven in Adressen.txt.", 
                    "Info", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Kan bestand niet wegschrijven.", 
                    "Foutmelding", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Warning);
            }
        }

        private void BtnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            // Dialoogvenster voor opslaan van bestanden aanmaken en openen
            SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Alle bestanden (*.*)|*.*|Tekstbestanden (*.txt)|*.txt",
                FilterIndex = 2,
                Title = "Geef een bestandsnaam op",
                OverwritePrompt = true,  // bevestiging vragen bij overschrijven van een bestand 
                AddExtension = true, // extensie wordt toegevoegd.
                DefaultExt = "txt", // standaardextensie is txt
                FileName = "Email.txt",
                InitialDirectory = Environment.CurrentDirectory // onder bin\Debug
            };
            if (sfd.ShowDialog() == true)
            {
                // Regel toevoegen (appenden) aan bestand vb/ "Doe John","doj@gmail.com"
                // We escapen de dubbele quotes (speciaal karakter) zo: \"
                string regel = $"\"{TxtNaam.Text}\",\"{TxtEmailadres.Text}\"";
                using (StreamWriter sw = new StreamWriter(sfd.FileName, true))  // Optie true: append, false: overschrijven
                {
                    sw.WriteLine(regel);
                }
                // Kan ook zo:
                /*
                using (FileStream fs = new FileStream(sfd.FileName, FileMode.Append, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(regel);
                }
                */
            }
        }
    }
}

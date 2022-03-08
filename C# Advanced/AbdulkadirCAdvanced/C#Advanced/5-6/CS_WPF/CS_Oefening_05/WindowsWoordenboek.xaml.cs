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

namespace CS_Oefening_05
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WindowsWoordenboek : Window
    {
        private bool wijzigingen = false;

        public WindowsWoordenboek()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string bestand = @"..\..\Teksten\ICTWoordenboek.txt";
            FileInfo fi = new FileInfo(bestand);
            if (fi.Exists) 
            { 
                using (StreamReader sr = fi.OpenText()) 
                { 
                    while (!sr.EndOfStream) 
                    {
                        string[] velden = sr.ReadLine().Split('|'); 
                        Wachtwoorden.Engels.Add(velden[0]); 
                        Wachtwoorden.Nederlands.Add(velden[1]); 
                        LbxTermen.Items.Add($"{velden[0]} - {velden[1]}"); 
                    } 
                } 
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string bestand = @"..\..\Teksten\ICTwoordenboek.txt";
            FileInfo fi = new FileInfo(bestand);
            // Enkel als het bestand bestaat en er iets gewijzigd is pas wegschrijven.
            if (fi.Exists && wijzigingen == true)
            {
                using (StreamWriter sw = fi.CreateText())
                {
                    for (int i = 0; i < Wachtwoorden.Engels.Count; i++)
                    {
                        sw.WriteLine($"{Wachtwoorden.Engels[i]}|{Wachtwoorden.Nederlands[i]}");
                    }
                }
                MessageBox.Show("Bestand werd bijgewerkt!", 
                    "Info afsluiten", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Information);
            }
            // App volledig afsluiten, ook alle andere windows.
            Environment.Exit(0);
        }

        private void BtnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            string engels = TxtEngels.Text;
            string nederlands = TxtNederlands.Text;
            // Controleer of beide TextBoxes zijn ingevuld.
            if (engels.Length == 0 || nederlands.Length == 0)
            {
                MessageBox.Show("Voer zowel een Engels als Nederlands woord in om toe te voegen.");
                return;
            }

            // We voegen de vertaling toe aan beide List's en gecombineerd aan de ListBox.
            Wachtwoorden.Engels.Add(engels);
            Wachtwoorden.Nederlands.Add(nederlands); 
            LbxTermen.Items.Add($"{engels} - {nederlands}");
            // We houden bij of er wijzigingen zijn gebeurd.
            wijzigingen = true;
            
            // Maak de TextBoxes leeg en zet de focus op TxtEngels.
            TxtEngels.Clear(); 
            TxtNederlands.Clear(); 
            TxtEngels.Focus();
        }

        private void BtnVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            // Als er geen item geselecteerd is, kan je het niet verwijderen.
            if (LbxTermen.SelectedIndex == -1)
            {
                MessageBox.Show("Selecteer een item om te verwijderen.");
                return;
            }
            // Er is een item geselecteerd. 
            // We verwijderen dit uit beide List's en uit de ListBox.
           // Wachtwoorden.Engels.R
            Wachtwoorden.Engels.RemoveAt(LbxTermen.SelectedIndex); 
            Wachtwoorden.Nederlands.RemoveAt(LbxTermen.SelectedIndex);
            LbxTermen.Items.Remove(LbxTermen.SelectedItem);
            // We houden bij of er wijzigingen zijn gebeurd.
            wijzigingen = true;
        }

        private void MnuZoekvenster_Click(object sender, RoutedEventArgs e)
        {
            // Woordenboekvenster eventueel verbergen.
            Hide();

            // Zoekvenser oproepen en tonen als een dialog.
            WindowsZoeken zoekvenster = new WindowsZoeken();
            zoekvenster.ShowDialog();
            // indien we DialogResult = true hebben gedaan in het zoekvenster
            if (zoekvenster.DialogResult == true)
            {
                Show(); // toon het woordenboekvenster terug
            }
        }

        private void MnuAfsluiten_Click(object sender, RoutedEventArgs e)
        {
            // De hele applicatie volledig afsluiten (geen Windows_Closing mogelijk)
            // Environment.Exit(0);
            // Toepassing afsluiten (Windows_Closing mogelijk)
            // Application.Current.Shutdown();
            // Alternatief:
            Close();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            WindowsInfo info = new WindowsInfo(); 
            info.ShowDialog();
        }
    }
}

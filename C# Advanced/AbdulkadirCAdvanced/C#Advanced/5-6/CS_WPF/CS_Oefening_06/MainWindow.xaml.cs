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
using System.Windows.Threading;

namespace CS_Oefening_06
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool wijzigingen = false;
        private Random rnd = new Random();
        private int randomIndex = -1;

        private List<string> ictEngels = new List<string>(); 
        private List<string> ictNederlands = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TabZoeken.IsEnabled = false;
            TextBlockUser.Text += Data.User;

            string bestand = @"..\..\Teksten\ICTTermen.txt";
            FileInfo fi = new FileInfo(bestand);
            if (fi.Exists)
            {
                using (StreamReader sr = fi.OpenText())
                {
                    while (!sr.EndOfStream)
                    {
                        string[] velden = sr.ReadLine().Split('|');
                        ictEngels.Add(velden[0]);
                        ictNederlands.Add(velden[1]);
                        LbxTermen.Items.Add($"{velden[0]} - {velden[1]}");
                    }
                }
            }

            // ==== TIMER INSTALLEREN ===== 
            // Tijd al tonen op voorhand en niet pas na 1 seconde.
            DispatcherTimer_Tick(sender, e);

            // Installeren van timer dmv de klasse aan te spreken.
            DispatcherTimer wekker = new DispatcherTimer();
            // Timer laten aflopen om de seconde.
            wekker.Tick += DispatcherTimer_Tick;
            wekker.Interval = new TimeSpan(0, 0, 1); //uren, minuten, seconden
            // Timer laten starten
            wekker.Start();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string bestand = @"..\..\Teksten\ICTTermen.txt";
            FileInfo fi = new FileInfo(bestand);
            // Enkel als het bestand bestaat en er iets gewijzigd is pas wegschrijven.
            if (fi.Exists && wijzigingen == true)
            {
                using (StreamWriter sw = fi.CreateText())
                {
                    for (int i = 0; i < ictEngels.Count; i++)
                    {
                        sw.WriteLine($"{ictEngels[i]}|{ictNederlands[i]}");
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

        private void DispatcherTimer_Tick(object sender, EventArgs e) 
        { 
            TextBlockDatumTijd.Text = $"{DateTime.Now.ToLongDateString()} {DateTime.Now.ToLongTimeString()}"; 
        }

        private void BtnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            string engels = TxtEngels1.Text;
            string nederlands = TxtNederlands1.Text;
            // Controleer of beide TextBoxes zijn ingevuld.
            if (engels.Length == 0 || nederlands.Length == 0)
            {
                MessageBox.Show("Voer zowel een Engels als Nederlands woord in om toe te voegen.");
                return;
            }

            // We voegen de vertaling toe aan beide List's en gecombineerd aan de ListBox.
            ictEngels.Add(engels);
            ictNederlands.Add(nederlands);
            LbxTermen.Items.Add($"{engels} - {nederlands}");
            // We houden bij of er wijzigingen zijn gebeurd.
            wijzigingen = true;

            // Maak de TextBoxes leeg en zet de focus op TxtEngels.
            TxtEngels1.Clear();
            TxtNederlands1.Clear();
            TxtEngels1.Focus();
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
            ictEngels.RemoveAt(LbxTermen.SelectedIndex);
            ictNederlands.RemoveAt(LbxTermen.SelectedIndex);
            LbxTermen.Items.Remove(LbxTermen.SelectedItem);
            // We houden bij of er wijzigingen zijn gebeurd.
            wijzigingen = true;
        }

        private void BtnZoeken_Click(object sender, RoutedEventArgs e)
        {
            int bovengrensExclusief = ictEngels.Count;
            if (bovengrensExclusief == 0)
            {
                MessageBox.Show("Er staan geen woorden in de woordenlijst!");
                return;
            }
            randomIndex = rnd.Next(bovengrensExclusief);

            TxtEngels2.Text = ictEngels[randomIndex];
        }

        private void BtnControle_Click(object sender, RoutedEventArgs e)
        {
            if (ictEngels.Count == 0)
            {
                MessageBox.Show("Er staan geen woorden in de woordenlijst!");
                return;
            }
            // We verwaarlozen hoofdlettergevoeligheid (ToLower()) en witruimtes (Trim())
            string ingegeven = TxtNederlands2.Text.ToLower().Trim();
            string verwacht = ictNederlands[randomIndex].ToLower().Trim();
            if (ingegeven.Equals(verwacht))
            {
                MessageBox.Show("De vertaling is goed", "Prima vertaling");
            }
            else
            {
                MessageBox.Show($"De vertaling is verkeerd.\r\nHet juiste antwoord was {verwacht.ToUpper()}",
                    "Fout",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }

        private void MnuToevoegen_Click(object sender, RoutedEventArgs e)
        {
            TabZoeken.IsEnabled = true;
        }

        private void MnuSluiten_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MnuOver_Click(object sender, RoutedEventArgs e)
        {
            InfoWindow info = new InfoWindow();
            info.ShowDialog();
        }
    }
}

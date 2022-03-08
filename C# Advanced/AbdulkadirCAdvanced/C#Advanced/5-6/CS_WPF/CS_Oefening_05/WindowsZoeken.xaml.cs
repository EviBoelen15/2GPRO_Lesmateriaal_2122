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

namespace CS_Oefening_05
{
    /// <summary>
    /// Interaction logic for WindowsZoeken.xaml
    /// </summary>
    public partial class WindowsZoeken : Window
    {
        private Random rnd = new Random();
        private int randomIndex = -1;

        public WindowsZoeken()
        {
            InitializeComponent();
        }

        private void BtnZoeken_Click(object sender, RoutedEventArgs e)
        {
            int bovengrensExclusief = Wachtwoorden.Engels.Count;
            if (bovengrensExclusief == 0)
            {
                MessageBox.Show("Er staan geen woorden in de woordenlijst!");
                return;
            }
            randomIndex = rnd.Next(bovengrensExclusief);

            TxtEngels.Text = Wachtwoorden.Engels[randomIndex]; 
        }

        private void BtnControle_Click(object sender, RoutedEventArgs e)
        {
            if (Wachtwoorden.Engels.Count == 0)
            {
                MessageBox.Show("Er staan geen woorden in de woordenlijst!");
                return;
            }
            // We verwaarlozen hoofdlettergevoeligheid (ToLower()) en witruimtes (Trim())
            string ingegeven = TxtNederlands.Text.ToLower().Trim();
            string verwacht = Wachtwoorden.Nederlands[randomIndex].ToLower().Trim();
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

        private void MnuZoeken_Click(object sender, RoutedEventArgs e)
        {
            BtnZoeken_Click(sender, e);
        }

        private void MnuSluiten_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void MnuInfo_Click(object sender, RoutedEventArgs e)
        {
            WindowsInfo info = new WindowsInfo();
            info.ShowDialog();
        }
    }
}

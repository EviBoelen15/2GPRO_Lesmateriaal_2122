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

namespace CS_Oefening_17
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Polymorfisme: behandel de zichtrekening en spaarrekening alsof het een abstracte Bankrekening is
        // Van Bankrekening kan ik geen constructor oproepen, want dat is een abstracte class.
        // Van Zichtrekening en Spaarrekening kan ik wel een constructor oproepen.
        private Bankrekening zichtRekening;
        private Bankrekening spaarRekening;

        public MainWindow()
        {
            InitializeComponent();

            // Zichtrekening initialiseren (Polymorfisme)
            zichtRekening = new Zichtrekening(2000.0, "PXL Digital | Campus PXL Hasselt", "Elfde­Liniestraat 26, 3500 Hasselt");
            LblZichtrekening.Content = $"{zichtRekening.Naam}, {zichtRekening.Adres}";
            LblSaldoZichtrekening.Content = $"{zichtRekening.HuidigSaldo:c}";
            LblRenteZichtrekening.Content = $"{zichtRekening.BerekenRente():c}";

            // Spaarrekening initialiseren.
            spaarRekening = new Spaarrekening(9500.0, zichtRekening.Naam, zichtRekening.Adres);
            LblSpaarrekening.Content = $"{spaarRekening.Naam}, {spaarRekening.Adres}";
            LblSaldoSpaarrekening.Content = $"{spaarRekening.HuidigSaldo:c}";
            LblRenteSpaarrekening.Content = $"{spaarRekening.BerekenRente():c}";
        }

        private void BtnSaldo_Click(object sender, RoutedEventArgs e)
        {
            double bedrag;
            bool isGetal = double.TryParse(TxtBedrag.Text, out bedrag);
            if (!isGetal)
            {
                MessageBox.Show("Geef een correct getal in!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }


            if (bedrag < 0)
            {
                // bijvoorbeeld -(-500) wordt 500
                spaarRekening.CreditSaldo(-bedrag);
                try
                {
                    zichtRekening.CreditSaldo(-bedrag);
                }
                catch (BankException ex)  // Foutmelding bij saldo < 0
                {
                    MessageBox.Show(ex.Message, "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Stop);
                }
            }
            else
            {
                spaarRekening.DebetSaldo(bedrag);
                zichtRekening.DebetSaldo(bedrag);
            }

            LblSaldoZichtrekening.Content = $"{zichtRekening.HuidigSaldo:c}";
            LblSaldoSpaarrekening.Content = $"{spaarRekening.HuidigSaldo:c}";
        }

        private void BtnRente_Click(object sender, RoutedEventArgs e)
        {
            LblRenteZichtrekening.Content = $"{zichtRekening.BerekenRente():c}";
            LblRenteSpaarrekening.Content = $"{spaarRekening.BerekenRente():c}";
        }

        private void BtnAfsluiten_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

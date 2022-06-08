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

namespace Oefening17ABankrekening
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Bankrekening zichtrekening;
        Bankrekening spaarrekening;
        public MainWindow()
        {
            InitializeComponent();
            zichtrekening = new Zichtrekening(2000.0, "PXL Digital | Campus PXL Hasselt", "Elfde­Liniestraat 26, 3500 Hasselt");
            spaarrekening = new Spaarrekening(9500.0, zichtrekening.Naam, zichtrekening.Adress);
        }

        private void TxtBedrag_TextChanged(object sender, TextChangedEventArgs e)
        {
            int bedrag = int.Parse(TxtBedrag.Text);
            if(bedrag > 0)
            {
                zichtrekening.CreditSaldo(bedrag);
                spaarrekening.CreditSaldo(bedrag);
            } else
            {
                zichtrekening.DebitSaldo(bedrag);
                spaarrekening.DebitSaldo(bedrag);
            }
        }

        private void BtnSaldo_Click(object sender, RoutedEventArgs e)
        {
            LblSaldoZichtrekening.Content = zichtrekening.huidigSaldo;
            LblSaldoSpaarrekening.Content = spaarrekening.huidigSaldo;
        }

        private void BtnRente_Click(object sender, RoutedEventArgs e)
        {
            LblRenteZichtrekening.Content = zichtrekening.BerekenRente();
            LblRenteSpaarrekening.Content = spaarrekening.BerekenRente();
        }

        private void BtnAfsluiten_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}

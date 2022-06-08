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

namespace Oefening8KlasseTeller
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Teller teller = new Teller();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGeefWaarde_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"De waarde van de teller is nu: {teller.Counter}");
        }

        private void btnVerhoog_Click(object sender, RoutedEventArgs e)
        {
            teller.VerhoogTeller();
        }

        private void btnVerlaag_Click(object sender, RoutedEventArgs e)
        {
            teller.VerminderTeller();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            teller.ResetTeller();
        }

        private void btnVerhoogMet_Click(object sender, RoutedEventArgs e)
        {
            teller.Waarde(int.Parse(txtVerhoogGetal.Text));
        }
    }
}

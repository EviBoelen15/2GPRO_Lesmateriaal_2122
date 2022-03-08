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

namespace CS_Oefening
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Teller teller = new Teller();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnLees_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(teller.Counter.ToString());
            // Of korter indien de Teller class een ToString() method heeft
            MessageBox.Show(teller.ToString());
        }

        private void BtnVerhoog_Click(object sender, RoutedEventArgs e)
        {
            teller.VerhoogTeller();
        }

        private void BtnVerminder_Click(object sender, RoutedEventArgs e)
        {
            teller.VerminderTeller();
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            teller.ResetTeller();
        }

        private void BtnWaarde_Click(object sender, RoutedEventArgs e)
        {
            int waarde; 
            bool isGelukt = int.TryParse(TxtWaarde.Text, out waarde);
            if (!isGelukt)
            {
                MessageBox.Show("Geef een geheel getal in!",
                    "Fout",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                TxtWaarde.Text = "0";
            }
            else
            {
                teller.Waarde(waarde);
            }
        }

        private void BtnEinde_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

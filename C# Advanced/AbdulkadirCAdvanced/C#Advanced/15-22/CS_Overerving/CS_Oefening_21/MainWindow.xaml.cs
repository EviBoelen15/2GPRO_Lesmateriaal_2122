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

namespace CS_Oefening_21
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Bankrekening bankrekening;
        
        public MainWindow()
        {
            InitializeComponent();
            bankrekening = new Bankrekening(TxtRekeningnummer.Text, TxtNaam.Text);
            TxtSaldo.Text = bankrekening.Saldo.ToString();
        }

        private void BtnBerekenSaldo_Click(object sender, RoutedEventArgs e)
        { 
            double bedrag = double.Parse(TxtBedrag.Text); 
            try 
            {
                if (bedrag < 0)
                {
                    bankrekening.Opname(-bedrag);
                }
                else
                {
                    bankrekening.Storting(bedrag);
                }
                TxtSaldo.Text = Convert.ToString(bankrekening.Saldo); 
            } 
            catch (BankException ex) 
            { 
                MessageBox.Show(ex.Message, "Fout", MessageBoxButton.OK, MessageBoxImage.Error); 
            } 
        }
    }
}

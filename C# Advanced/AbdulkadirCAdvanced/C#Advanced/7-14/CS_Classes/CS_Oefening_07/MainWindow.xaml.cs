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

namespace CS_Oefening_07
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Bankrekening rekening = new Bankrekening();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            rekening.HuidigSaldo = 500M;
            TxtStandRekening.Text = rekening.HuidigSaldo.ToString();

            TxtBedrag.SelectAll(); 
            TxtBedrag.Focus(); 
        }

        private void TxtBedrag_KeyDown(object sender, KeyEventArgs e)
        {
            
            if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) || // cijfers 0 tot 9
                (e.Key >= Key.D0 && e.Key <= Key.D9) ||
                e.Key == Key.Subtract || e.Key == Key.Add ||  //  '­-' of '+'
                e.Key == Key.OemComma || // ','
                e.Key == Key.LeftShift || e.Key == Key.RightShift)
            {
                // Als we geldige tekens invoeren: event nog niet afhandelen
                e.Handled = false;
            }
            else if (e.Key == Key.Return)
            {
                // Als we op enter drukken (return toets): event afhandelen
                e.Handled = true;
                decimal bedrag;
                bool isGelukt = decimal.TryParse(TxtBedrag.Text, out bedrag);
                if (!isGelukt)
                {
                    MessageBox.Show("Geef correct getal",
                    "Bedrag niet numeriek",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                    return;
                }

                
                if (bedrag >= 0M)
                {
                    // indien bedrag positief dan verhogen.
                    rekening.Storting(bedrag);
                }
                else
                {
                    try
                    {
                        // indien bedrag negatief dan verminderen.
                        rekening.Opname(-bedrag); // negatief bedrag positief maken, want in method gaan we aftrekken

                    }
                    catch (ArithmeticException)
                    {
                        MessageBox.Show($"Bedrag ontoereikend.\r\n\r\nHuidig saldo is {rekening.HuidigSaldo:c}",
                            "Invoer fout!");
                    }
                }
                
                // Stand van de rekening weergeven
                TxtStandRekening.Text = rekening.HuidigSaldo.ToString();
                TxtBedrag.Focus();
                TxtBedrag.Clear();
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Geef correct getal", 
                    "Bedrag niet numeriek", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Error);
                TxtBedrag.Focus();
                TxtBedrag.SelectAll();
            }        
        }
    }
}

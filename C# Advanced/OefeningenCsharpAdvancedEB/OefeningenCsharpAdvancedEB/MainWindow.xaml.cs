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

namespace OefeningenCsharpAdvancedEB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Bankrekening bankrekening = new Bankrekening(1000);

        public MainWindow()
        {
            InitializeComponent();
            txtRekeningstand.Text = bankrekening.Rekeningstand.ToString();
        }

        private void txtVerrichting_KeyDown(object sender, KeyEventArgs e)
        {
            string content = txtVerrichting.Text.ToString();

            if(e.Key == Key.Return)
            {
                if(content.StartsWith("-"))
                {
                    bankrekening.Opname(Convert.ToDecimal(content));
                    MessageBox.Show("Dit is een opname");
                }
                else if (content.StartsWith("+"))
                {
                    bankrekening.Storting(Convert.ToDecimal(content));
                    MessageBox.Show("Dit is een storting");
                }
                else
                {
                    MessageBox.Show("Geef een + of - in voor het bedrag.");
                }
            }
            txtRekeningstand.Text = bankrekening.Rekeningstand.ToString();
        }
    }
}

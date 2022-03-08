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

namespace Voorbeeld_Abstracte_klasse
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnBediende_Click(object sender, RoutedEventArgs e)
        {
            Bedienden med = new Bedienden(TxtVoornaamBediende.Text, TxtNaamBediende.Text, double.Parse(TxtBrutoBediende .Text));
            TxtSalaris.Text = $"{med.Voornaam}  {med.Naam}\r\n\r\nBruto: {med.Bruto():c}\r\nRSZ: {med.RSZ():c}\r\nBedrijfsvoorheffing: {med.BV():c}\r\nNetto: {med.Netto():c}";
        }

        private void BtnArbeiders_Click(object sender, RoutedEventArgs e)
        {
            Arbeiders med = new Arbeiders(TxtVoornaamArbeider.Text, TxtNaamArbeider.Text, double.Parse(TxtUurloonArbeider.Text), double.Parse(TxtAantalUrenArbeider.Text));
            TxtLoon.Text = $"{med.Voornaam}  {med.Naam}\r\n\r\nBruto: {med.Bruto():c}\r\nRSZ: {med.RSZ():c}\r\nBedrijfsvoorheffing: {med.BV():c}\r\nNetto: {med.Netto():c}";
        }

       

       
    }
}

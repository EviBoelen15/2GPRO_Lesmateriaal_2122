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

namespace VoorbeeldInterfaceBoomPersoon
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

        public void BerekenOuderdom(IOuderdom pb)
        {
            MessageBox.Show("Ouderdom: " + pb.Ouderdom, pb.Naam, MessageBoxButton.OK, MessageBoxImage.Information);
        }

     
        private void BtnOuderdom_Click(object sender, RoutedEventArgs e)
        {
            Boom boom = new Boom(TxtSoort.Text, int.Parse(TxtPlantjaar.Text));
            BerekenOuderdom(boom);
        }

        private void BtnLeeftijd_Click(object sender, RoutedEventArgs e)
        {
            // We  instantiëren een object van de klasse Persoon.
            Persoon persoon = new Persoon(TxtVoornaam.Text, TxtFamilienaam.Text, int.Parse(TxtGeboortejaar.Text));
            BerekenOuderdom(persoon);
        }
    }
}

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

using System.IO;

namespace CS_Oefening_13
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SportkampLeden : Window
    {
        private List<Lid> leden;
        
        public SportkampLeden()
        {
            InitializeComponent();

            try
            {
                leden = Lid.LeesLeden(@"..\..\Bestanden\LedenSportkampen.txt");
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Kan bestand LedenSportkampen.txt niet vinden!", 
                    "Fout", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Error);
                return;
            }

            TxtDetails.Text = Lid.ToonLeden(leden);
            TxtOverzichtWeek.Text = Lid.ToonWeekOverzicht();
            TxtOverzichtSporttak.Text = Lid.ToonSporttakOverzicht();
        }
    }
}

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
using System.Windows.Shapes;

namespace ADOdisconnected
{
    /// <summary>
    /// Interaction logic for Profiel.xaml
    /// </summary>
    public partial class Profiel : Window
    {
        string naam, wachtwoord, beroep, locatieSpel, spelerId, spelId, leeftijdTijdensDeelname, jaarSpel;
        bool isMol; 

        public Profiel(string[] gebruiker)
        {
            InitializeComponent();
            spelerId = gebruiker[0];
            spelId = gebruiker[1];
            naam = gebruiker[2];
            wachtwoord = gebruiker[3];
            isMol = bool.Parse(gebruiker[4]);
            leeftijdTijdensDeelname = gebruiker[5];
            beroep = gebruiker[6];
            jaarSpel = gebruiker[7];
            locatieSpel = gebruiker[8];
            vulGegevensIn();
        }

        private void vulGegevensIn()
        {
            if(isMol)
            {
                NaamTextBlock.Foreground = Brushes.Red;
            }
            NaamTextBlock.Text = naam;
            LeeftijdTextBlock.Text = leeftijdTijdensDeelname;
            BeroepTextBlock.Text = beroep;
            LocatieSpelTextBlock.Text = locatieSpel;
            JaarTextBlock.Text = jaarSpel;
        }
    }
}

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

namespace CS_Oefening_18
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Werknemer> werknemers = new List<Werknemer>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnWerknemer_Click(object sender, RoutedEventArgs e)
        {
            FileInfo fi = new FileInfo(@"..\..\Bestanden\Werknemers.txt");
            if (!fi.Exists)
            {
                return;
            }

            using (StreamReader sr = fi.OpenText())
            {
                // Lees regel per regel deze fixed-width text file
                while (!sr.EndOfStream) // zolang als er regels te lezen zijn
                {
                    string lijn = sr.ReadLine();
                    string veld1 = lijn.Substring(0, 15).Trim();
                    string veld2 = lijn.Substring(15, 20).Trim();
                    char veld3 = Convert.ToChar(lijn.Substring(35, 2).Trim());

                    // Type werknemer
                    switch (veld3)
                    {
                        case 'K':
                            decimal veld4k = Convert.ToDecimal(lijn.Substring(37, 9).Trim());
                            werknemers.Add(new Kader(veld1, veld2, veld3, Convert.ToDecimal(veld4k)));
                            break;
                        case 'B':
                            decimal veld5b = Convert.ToDecimal(lijn.Substring(46, 7).Trim());
                            decimal veld6b = Convert.ToDecimal(lijn.Substring(54, 7).Trim());
                            werknemers.Add(new Bediende(veld1, veld2, veld3, veld5b, veld6b));
                            break;
                        case 'C':
                            decimal veld4c = Convert.ToDecimal(lijn.Substring(37, 9).Trim());
                            decimal veld7c = Convert.ToDecimal(lijn.Substring(62, 6).Trim());
                            decimal veld8c = Convert.ToDecimal(lijn.Substring(68, 9).Trim());
                            werknemers.Add(new Commissie(veld1, veld2, veld3, veld4c, veld7c, veld8c));
                            break;
                    }
                }
            }

            LbxLoon.Items.Clear();
            foreach (var item in werknemers)
            {
                LbxLoon.Items.Add($"{item.Voornaam} {item.Familienaam} - {item.Wedde():c}");
            }

            BtnWerknemer.IsEnabled = false;
            BtnBediende.IsEnabled = true;
            BtnCommissie.IsEnabled = true;
            BtnKader.IsEnabled = true;
        }

        private void BtnBediende_Click(object sender, RoutedEventArgs e)
        {
            LbxLoon.Items.Clear();
            foreach (var item in werknemers)
            {
                if (item.Type == 'B')
                    LbxLoon.Items.Add($"{item.Info()}");
            }
        }

        private void BtnKader_Click(object sender, RoutedEventArgs e)
        {
            LbxLoon.Items.Clear();
            foreach (var item in werknemers)
            {
                if (item.Type == 'K')
                    LbxLoon.Items.Add($"{item.Info()}");
            }
        }

        private void BtnCommissie_Click(object sender, RoutedEventArgs e)
        {
            LbxLoon.Items.Clear();
            foreach (var item in werknemers)
            {
                if (item.Type == 'C')
                    LbxLoon.Items.Add($"{item.Info()}");
            }
        }
    }
}

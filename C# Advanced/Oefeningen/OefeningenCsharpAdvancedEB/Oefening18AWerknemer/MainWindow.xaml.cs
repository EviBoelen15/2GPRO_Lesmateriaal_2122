using System;
using System.Collections.Generic;
using System.IO;
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

namespace Oefening18AWerknemer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Werknemer> werknemers = new List<Werknemer>();
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
                    var lijn = sr.ReadLine();
                    var vak1 = lijn.Substring(0, 15).Trim();
                    var vak2 = lijn.Substring(15, 20).Trim();
                    var vak3 = lijn.Substring(35, 2).Trim();

                    switch (vak3)
                    {
                        case "K":
                            float vak4 = float.Parse(lijn.Substring(37, 9).Trim());
                            Werknemer kader = new Kader(vak1, vak3, vak2, vak4);
                            werknemers.Add(kader);
                            break;

                        case "B":
                            float vak5 = float.Parse(lijn.Substring(46, 7).Trim());
                            float vak6 = float.Parse(lijn.Substring(54, 7).Trim());
                            Werknemer bediende = new Bedienden(vak1, vak3, vak2, vak5, vak6);
                            werknemers.Add(bediende);
                            break;

                        case "C":
                            float vak4a = float.Parse(lijn.Substring(37, 9).Trim());
                            float vak7 = float.Parse(lijn.Substring(62, 6).Trim());
                            float vak8 = float.Parse(lijn.Substring(68, 9).Trim());
                            Werknemer comissie = new Commissie(vak1, vak3, vak2, vak7, vak8, vak4a);
                            werknemers.Add(comissie);
                            break;
                    }
                }
            }
            foreach(Werknemer wn in werknemers)
            {
                LbxLoon.Items.Add(wn.Info());
            }
            BtnWerknemer.IsEnabled = false;
            BtnBediende.IsEnabled = true;
            BtnCommissie.IsEnabled = true;
            BtnKader.IsEnabled = true;
        }

        private void BtnBediende_Click(object sender, RoutedEventArgs e)
        {
            ZoekJuisteWerknemer("B");
        }

        private void BtnKader_Click(object sender, RoutedEventArgs e)
        {
            ZoekJuisteWerknemer("K");
        }

        private void BtnCommissie_Click(object sender, RoutedEventArgs e)
        {
            ZoekJuisteWerknemer("C");
        }

        public void ZoekJuisteWerknemer(string s)
        {
            LbxLoon.Items.Clear();
            foreach (Werknemer wn in werknemers)
            {
                if (wn.Type == s)
                {
                    LbxLoon.Items.Add(wn.Info());
                }
            }
        }
    }
}

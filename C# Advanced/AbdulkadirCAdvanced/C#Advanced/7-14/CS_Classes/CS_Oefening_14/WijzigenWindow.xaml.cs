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

using System.IO;

namespace CS_Oefening_14
{
    /// <summary>
    /// Interaction logic for WijzigenWindow.xaml
    /// </summary>
    public partial class WijzigenWindow : Window
    {
        private List<Sport> sporten;

        public WijzigenWindow()
        {
            InitializeComponent();

            try
            {
                sporten = LeesSportTabel(@"..\..\Bestanden\Sporten.txt");
            }
            catch (Exception)
            {
                DialogResult = false;
                return;
            }

            TxtNaam.Text = SharedData.Lid.Naam;
            TxtVoornaam.Text = SharedData.Lid.Voornaam;
            TxtWeeknr.Text = SharedData.Lid.Weeknr.ToString();
            TxtKampvolgnr.Text = SharedData.Lid.KampVolgnr.ToString();
            LbxSportkampen.SelectedIndex = 0;
        }

        public List<Sport> LeesSportTabel(string bestand)
        {
            List<Sport> tabel = new List<Sport>();
            FileInfo fi = new FileInfo(bestand);
            if (!fi.Exists)
            {
                throw new FileNotFoundException();
            }
            using (StreamReader sr = fi.OpenText())
            {
                while (!sr.EndOfStream)
                {
                    string[] velden = sr.ReadLine().Split(';');
                    Sport sport = new Sport()
                    {
                        Code = velden[0].Replace("\"", ""),
                        Omschrijving = velden[1].Replace("\"", ""),
                        Prijs = double.Parse(velden[2])
                    };
                    tabel.Add(sport);
                }
            }
            return tabel;
        }

        private void BtnBewaren_Click(object sender, RoutedEventArgs e)
        {
            SharedData.Lid.Naam = TxtNaam.Text;
            SharedData.Lid.Voornaam = TxtVoornaam.Text;
            SharedData.Lid.Weeknr = int.Parse(TxtWeeknr.Text); // geen check gevraagd of cijfer 1 t.e.m 9
            SharedData.Lid.KampVolgnr = int.Parse(TxtKampvolgnr.Text); // ook geen check gevraagd

            int sportIndex = LbxSportkampen.SelectedIndex;
            if (sportIndex != -1)
            {
                SharedData.Lid.Sportcode = ((ListBoxItem)LbxSportkampen.Items[sportIndex])
                    .Content.ToString().Substring(0, 3);
            }

            DialogResult = true;
        }

        private void BtnAnnuleren_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}

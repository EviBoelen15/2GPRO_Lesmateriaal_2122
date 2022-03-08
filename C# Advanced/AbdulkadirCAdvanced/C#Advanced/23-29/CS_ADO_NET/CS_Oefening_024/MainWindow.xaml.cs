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

using System.Data;

namespace CS_Oefening_024
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataSet ds = new DataSet();
        private DataTable dtVerkoper = new DataTable("Verkoper");
        private DataTable dtArtikel = new DataTable("Artikel");

        public MainWindow()
        {
            InitializeComponent();

            MaakTabellen();
            VulTabellen();
        }

        private void MaakTabellen()
        {
            DataColumn dcVerkoperId = new DataColumn("VerkoperId", typeof(int)); // Primary key
            DataColumn dcVerkoperNaam = new DataColumn("Naam", typeof(string));
            DataColumn dcVerkoperStraat = new DataColumn("Straat", typeof(string));
            DataColumn dcVerkoperNr = new DataColumn("Nr", typeof(string));
            DataColumn dcVerkoperPostcode = new DataColumn("Postcode", typeof(string));
            DataColumn dcVerkoperWoonplaats = new DataColumn("Woonplaats", typeof(string));
            DataColumn dcVerkoperLand = new DataColumn("Land", typeof(string));

            dtVerkoper.Columns.Add(dcVerkoperId);
            dtVerkoper.Columns.Add(dcVerkoperNaam);
            dtVerkoper.Columns.Add(dcVerkoperStraat);
            dtVerkoper.Columns.Add(dcVerkoperNr);
            dtVerkoper.Columns.Add(dcVerkoperPostcode);
            dtVerkoper.Columns.Add(dcVerkoperWoonplaats);
            dtVerkoper.Columns.Add(dcVerkoperLand);

            DataColumn[] pkVerkoper = { dcVerkoperId }; // kunnen meerdere kolommen zijn, dus array
            dtVerkoper.PrimaryKey = pkVerkoper;

            DataColumn dcArtikelArtId = new DataColumn("ArtId", typeof(int)); // Primary key
            DataColumn dcArtikelVerkoperId = new DataColumn("VerkoperId", typeof(int));
            DataColumn dcArtikelCode = new DataColumn("Code", typeof(string));
            DataColumn dcArtikelBeschrijving = new DataColumn("Beschrijving", typeof(string));
            DataColumn dcArtikelAankoopprijs = new DataColumn("Aankoopprijs", typeof(decimal));
            DataColumn dcArtikelVerkoopprijs = new DataColumn("Verkoopprijs", typeof(decimal));

            dtArtikel.Columns.Add(dcArtikelArtId);
            dtArtikel.Columns.Add(dcArtikelVerkoperId);
            dtArtikel.Columns.Add(dcArtikelCode);
            dtArtikel.Columns.Add(dcArtikelBeschrijving);
            dtArtikel.Columns.Add(dcArtikelAankoopprijs);
            dtArtikel.Columns.Add(dcArtikelVerkoopprijs);


            DataColumn[] pkArtikel = { dcArtikelArtId }; // kunnen meerdere kolommen zijn, dus array
            dtArtikel.PrimaryKey = pkArtikel;

            ds.Tables.Add(dtVerkoper);
            ds.Tables.Add(dtArtikel);

            DgVerkoper.ItemsSource = dtVerkoper.DefaultView;
            DgArtikel.ItemsSource = dtArtikel.DefaultView;
        }

        private void VulTabellen()
        {
            dtVerkoper.Rows.Add(10, "Elon Musk", "Herkenrodesingel", "77", "3500", "Hasselt", "Belgie");
            dtVerkoper.Rows.Add(20, "Clotilde Delbos", "Gouverneur Roppesingel", "2", "3500", "Hasselt", "Belgie");

            dtArtikel.Rows.Add(1, 10, "Tesla", "Tesla Model S", 65000M, 75500M);
            dtArtikel.Rows.Add(2, 10, "Tesla", "Tesla Model S 85kWh (Dual Motor)", 88400M, 96250M);
            dtArtikel.Rows.Add(3, 20, "Renault", "Renault Kadjar", 14000M, 18650M);
        }

        private void BtnListing_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder stb = new StringBuilder();

            stb.AppendLine("LIJST VAN VERKOPERS");
            var queryVerkopers = from row in dtVerkoper.AsEnumerable()
                                 let naam = (string)row["Naam"]
                                 select naam;

            foreach (var naam in queryVerkopers)
            {
                stb.AppendLine(naam);
            }

            stb.AppendLine("\r\nLIJST VAN AUTO'S");
            var queryArtikels = from row in dtArtikel.AsEnumerable()
                                 let beschrijving = (string)row["Beschrijving"]
                                 select beschrijving;

            foreach (var beschrijving in queryArtikels)
            {
                stb.AppendLine(beschrijving);
            }

            TxtListing.Text = stb.ToString();
        }

        private string ArtikelQuery(string codeFilter)
        {
            var query = from row in dtArtikel.AsEnumerable() // AsEnumerable(), want een DataTable is standaard niet Enumerable
                        let code = (string)row["Code"]
                        let beschrijving = (string)row["Beschrijving"]
                        let verkoopprijs = (decimal)(row["Verkoopprijs"])
                        where code.Equals(codeFilter)
                        select (code, beschrijving, verkoopprijs);

            StringBuilder stb = new StringBuilder();
            foreach (var item in query)
            {
                stb.AppendLine($"{item.code,-15} {item.beschrijving,-40} VP: {item.verkoopprijs,-15:c}");
            }

            return stb.ToString();
        }


        private void RadTesla_Checked(object sender, RoutedEventArgs e)
        {
            TxtResultaat.Text = ArtikelQuery("Tesla");
          
        }

        private void RadRenault_Checked(object sender, RoutedEventArgs e)
        {
            TxtResultaat.Text = ArtikelQuery("Renault");
        }
    }
}

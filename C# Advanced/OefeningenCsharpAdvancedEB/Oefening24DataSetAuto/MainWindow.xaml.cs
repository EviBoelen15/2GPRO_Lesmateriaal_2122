using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace Oefening24DataSetAuto
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
            VulDataSet();
        }

        private void MaakTabellen()
        {
            //Data table verkoper aanmaken
            DataColumn dcVerkoperId = new DataColumn("VerkoperId", typeof(int)); // Primary key
            dcVerkoperId.AllowDBNull = false;

            DataColumn dcNaam = new DataColumn("Naam", typeof(string)); // Primary key
            dcNaam.AllowDBNull = false;

            DataColumn dcStraat = new DataColumn("Straat", typeof(string)); // Primary key
            dcStraat.AllowDBNull = false;

            DataColumn dcNR = new DataColumn("Nr", typeof(string)); // Primary key
            dcNR.AllowDBNull = false;

            DataColumn dcChef = new DataColumn("Chef", typeof(string)); // Primary key
            dcChef.AllowDBNull = false;

            DataColumn dcPostcode = new DataColumn("Postcode", typeof(string)); // Primary key
            dcPostcode.AllowDBNull = false;

            DataColumn dcWoonplaats = new DataColumn("Woonplaats", typeof(string)); // Primary key
            dcWoonplaats.AllowDBNull = false;

            DataColumn dcLand = new DataColumn("Land", typeof(string)); // Primary key
            dcLand.AllowDBNull = false;

            DataColumn dcAfd = new DataColumn("Afd", typeof(string)); // Primary key
            dcAfd.AllowDBNull = false;

            dtVerkoper.Columns.Add(dcVerkoperId);
            dtVerkoper.Columns.Add(dcNaam);
            dtVerkoper.Columns.Add(dcStraat);
            dtVerkoper.Columns.Add(dcNR);
            dtVerkoper.Columns.Add(dcChef);
            dtVerkoper.Columns.Add(dcPostcode);
            dtVerkoper.Columns.Add(dcWoonplaats);
            dtVerkoper.Columns.Add(dcLand);
            dtVerkoper.Columns.Add(dcAfd);

            DataColumn[] vPk = { dcVerkoperId }; // kunnen meerdere kolommen zijn, dus array
            dtVerkoper.PrimaryKey = vPk;

            ds.Tables.Add(dtVerkoper);

            //Zorgt voor een gefilterde, of georganiseerde tabel (hoe deze default is)
            DataView dvVerkoper = dtVerkoper.DefaultView;
            DgVerkoper.ItemsSource = dvVerkoper;

            //Data table artikel aanmaken
            DataColumn dcArtId = new DataColumn("ArtikelId", typeof(int)); // Primary key
            dcArtId.AllowDBNull = false;

            DataColumn dcVerkoperIdFK = new DataColumn("VerkoperId", typeof(int)); // Primary key
            dcVerkoperIdFK.AllowDBNull = false;

            DataColumn dcCode = new DataColumn("Code", typeof(string)); // Primary key
            dcCode.AllowDBNull = false;

            DataColumn dcBeschrijving = new DataColumn("Beschrijving", typeof(string)); // Primary key
            dcBeschrijving.AllowDBNull = false;

            DataColumn dcArtikelChef = new DataColumn("Chef", typeof(string)); // Primary key
            dcChef.AllowDBNull = false;

            DataColumn dcAankoopP = new DataColumn("Aankoopprijs", typeof(decimal)); // Primary key
            dcAankoopP.AllowDBNull = false;

            DataColumn dcVerkoopP = new DataColumn("Verkoopprijs", typeof(decimal)); // Primary key
            dcVerkoopP.AllowDBNull = false;

            dtArtikel.Columns.Add(dcArtId);
            dtArtikel.Columns.Add(dcVerkoperIdFK);
            dtArtikel.Columns.Add(dcCode);
            dtArtikel.Columns.Add(dcBeschrijving);
            dtArtikel.Columns.Add(dcArtikelChef);
            dtArtikel.Columns.Add(dcAankoopP);
            dtArtikel.Columns.Add(dcVerkoopP);

            DataColumn[] aPk = { dcArtId, dcVerkoperIdFK }; // kunnen meerdere kolommen zijn, dus array
            dtArtikel.PrimaryKey = aPk;

            ds.Tables.Add(dtArtikel);

            //Zorgt voor een gefilterde, of georganiseerde tabel (hoe deze default is)
            DataView dvArtikel = dtArtikel.DefaultView;
            DgArtikel.ItemsSource = dvArtikel;
        }
        public void VulDataSet()
        {
            dtVerkoper.Rows.Add(10, "Elon Musk", "Herkenrodesingel", "77", "NULL", "3500", "Hasselt", "Belgie", "AFD");
            dtVerkoper.Rows.Add(20, "Clotilde belbos", "Stiemerbeekstraat", "2", "NULL", "3500", "Hasselt", "Belgie", "AFD");
            dtArtikel.Rows.Add(1, 10, "Tesla", "Model S","NULL", "65000", "75500");
            dtArtikel.Rows.Add(2, 10, "Tesla", "Model S 4000", "NULL", "65510", "754015");
            dtArtikel.Rows.Add(3, 20, "Renault", "Kadjar", "NULL", "85000", "75500");
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

        public string CheckProductCode(string ControleCode)
        {
            var query = from artikel in dtArtikel.AsEnumerable()
                        let code = (string)artikel["Code"]
                        let beschrijving = (string)artikel["Beschrijving"]
                        let verkoop = (decimal)artikel["VerkoopPrijs"]
                        where code.Equals(ControleCode)
                        select (code, beschrijving, verkoop);

            StringBuilder sb = new StringBuilder();
            foreach(var item in query)
            {
                sb.AppendLine($"{item.code,-15} {item.beschrijving,-40}  {item.verkoop,-25}");
            }

            return sb.ToString();
        }
        private void RadRenault_Checked(object sender, RoutedEventArgs e)
        {
            TxtResultaat.Text = CheckProductCode("Renault");
        }

        private void RadTesla_Checked(object sender, RoutedEventArgs e)
        {
            TxtResultaat.Text = CheckProductCode("Tesla");
        }
    }
}

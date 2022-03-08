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
using System.IO;


namespace CS_Oefening_023
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable("Medewerkers");

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MaakTabellen()
        {
            DataColumn dcMnr = new DataColumn("Mnr", typeof(int)); // Primary key
            dcMnr.AllowDBNull = false;
            DataColumn dcNaam = new DataColumn("Naam", typeof(string));
            dcNaam.AllowDBNull = false;
            DataColumn dcVoorn = new DataColumn("Voorn", typeof(string));
            dcVoorn.AllowDBNull = false;
            DataColumn dcFunctie = new DataColumn("Functie", typeof(string));
            dcFunctie.AllowDBNull = false;
            DataColumn dcChef = new DataColumn("Chef", typeof(int));
            dcChef.AllowDBNull = true; // Kan null-waarde hebben 
            DataColumn dcGbdatum = new DataColumn("Gbdatum", typeof(DateTime));
            dcGbdatum.AllowDBNull = false;
            DataColumn dcMaandsal = new DataColumn("Maandsal", typeof(float));
            dcMaandsal.AllowDBNull = false;
            DataColumn dcComm = new DataColumn("Comm", typeof(float));
            dcComm.AllowDBNull = true; // Kan null-waarde hebben 
            DataColumn dcAfd = new DataColumn("Afd", typeof(int));
            dcAfd.AllowDBNull = false;

            dt.Columns.Add(dcMnr); 
            dt.Columns.Add(dcNaam);
            dt.Columns.Add(dcVoorn);
            dt.Columns.Add(dcFunctie);
            dt.Columns.Add(dcChef);
            dt.Columns.Add(dcGbdatum);
            dt.Columns.Add(dcMaandsal);
            dt.Columns.Add(dcComm);
            dt.Columns.Add(dcAfd);

            DataColumn[] pk = { dcMnr }; // kunnen meerdere kolommen zijn, dus array
            dt.PrimaryKey = pk;

            ds.Tables.Add(dt);
            
            DataView dv = dt.DefaultView;
            DgMedewerkers.ItemsSource = dv;
        }

        private void VulTabellen()
        {
            dt.Rows.Add(1, "PALMAERS", "KRISTOF", "TRAINER", 5, new DateTime(1985, 12, 17), 2800.0f, null, 20);
            dt.Rows.Add(2, "DOX", "PAUL", "TRAINER", 5, new DateTime(1972, 11, 17), 3500.0f, null, 20);
            dt.Rows.Add(3, "VOS", "FRANCIS", "DEPARTEMENTSHOOFD", null, new DateTime(1989, 12, 3), 5800.55f, null, 10);
            dt.Rows.Add(4, "BRIERS", "PATRICIA", "TRAINER", 5, new DateTime(1972, 2, 22), 2250.0f, 3000.99f, 20);
            dt.Rows.Add(5, "BRUGGEN", "NATACHA", "COORDINATOR", 3, new DateTime(1984, 5, 16), 2250.0f, 2950.0f, 30);
            dt.Rows.Add(6, "AKSU", "KADIR", "STUDENT", 6, new DateTime(1998, 8, 8), 0, 2950.0f, 28);
        }

        private void BtnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            MaakTabellen();
            VulTabellen();
        }

        private void BtnMedTabel_Click(object sender, RoutedEventArgs e)
        {
            FileInfo fi = new FileInfo(@"..\..\Bestanden\DatMedewerkers.txt");
            using (StreamReader sr = fi.OpenText())
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] values = line.Split(';');

                    int? chef = null;
                    if (values[4].Length != 0)
                        chef = int.Parse(values[4].Trim());

                    float? comm = null;
                    if (values[7].Length != 0)
                        comm = float.Parse(values[7].Trim());

                    dt.Rows.Add(int.Parse(values[0].Trim()),
                        values[1].Trim(),
                        values[2].Trim(),
                        values[3].Trim(),
                        chef,
                        DateTime.Parse(values[5].Trim()),
                        float.Parse(values[6].Trim()),
                        comm,
                        int.Parse(values[8].Trim()));
                }
            }
            DataView dv = dt.DefaultView;
            DgMedewerkers.ItemsSource = dv;
        }
    }
}

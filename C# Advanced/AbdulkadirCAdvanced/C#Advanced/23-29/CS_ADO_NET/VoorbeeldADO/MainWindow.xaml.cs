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

using System.Data.SqlClient;
using System.Data;

namespace VoorbeeldADO
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

        private void BtnConnectieTest_Click(object sender, RoutedEventArgs e)
        {
            // Haal de connectiestring uit de settings
            string cn = Properties.Settings.Default.CNstr.ToString();

            SqlConnection sqlcn = new SqlConnection(cn);
            sqlcn.Open();

            if (sqlcn.State == System.Data.ConnectionState.Open)
            {
                MessageBox.Show("De connection is open.");
            }
            else
            {
                MessageBox.Show("De connection is NIET open.");
            }
        }

        private void BtnSqlCommand_Click(object sender, RoutedEventArgs e)
        {
            // === Langste manier ===
            /*
            SqlConnection sqlcn = new SqlConnection(" Integrated Security = SSPI; " + 
                "Persist Security Info = False; Initial Catalog = Medewerkers; " +
                @"Data Source = localhost\SQLEXPRESS");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcn;
            string query = "select * from medewerkers";
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            TxtResultaat.Text = cmd.CommandText;  // Geeft: select * from medewerkers
            */
            // === Kortere manier ===
            /*
            SqlConnection sqlcn = new SqlConnection(" Integrated Security = SSPI; " +
                "Persist Security Info = False; Initial Catalog = Medewerkers; " +
                @"Data Source = localhost\SQLEXPRESS");
            string query = "select * from medewerkers";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Connection = sqlcn;
            TxtResultaat.Text = cmd.CommandText;  // Geeft: select * from medewerkers
            */
            // === Kortste manier ===
            /*
            string cn = Properties.Settings.Default.CNstr.ToString();
            SqlConnection sqlcn = new SqlConnection(cn);
            string query = "select * from medewerkers";
            SqlCommand cmd = new SqlCommand(query, sqlcn);
            TxtResultaat.Text = cmd.CommandText;  // Geeft: select * from medewerkers
            */

            // === 1 waarde opvragen ===
            /*
            string cn = Properties.Settings.Default.CNstr.ToString();
            SqlConnection sqlcn = new SqlConnection(cn);
            sqlcn.Open();
            string query = "select max(mnr) from medewerkers";
            SqlCommand cmd = new SqlCommand(query, sqlcn);
            short maxMed = (short)cmd.ExecuteScalar(); // short (16 bit) van C# komt overeen met smallint in SQL Server
            TxtResultaat.Text = $"{maxMed}";  // Geeft grootste medewerkersnummer
            sqlcn.Close();
            */

            // === 1 waarde opvragen ===
            /*
            string cn = Properties.Settings.Default.CNstr.ToString();
            SqlConnection sqlcn = new SqlConnection(cn);
            sqlcn.Open();
            string query = "select count(mnr) from medewerkers";
            SqlCommand cmd = new SqlCommand(query, sqlcn);
            int aantal = (int)cmd.ExecuteScalar(); // int van C# komt overeen met int in SQL Server
            TxtResultaat.Text = $"{aantal}";  // Geeft aantal rijen van tabel
            sqlcn.Close();
            */

            // === Data (meerdere rijen en/of kolommen) opvragen ===
            /*
            string cn = Properties.Settings.Default.CNstr.ToString();
            // using zorgt voor automatische Close(), maar we moeten wel nog zelf Open() doen!!!
            using (SqlConnection sqlcn = new SqlConnection(cn))
            {
                sqlcn.Open();
                string query = "select * from medewerkers";
                SqlCommand cmd = new SqlCommand(query, sqlcn);
                SqlDataReader reader = cmd.ExecuteReader(); // geeft opgebouwde SqlDataReader terug.
                // SqlDataReader gebruiken we om elke rij (record) te inspecteren
            }
            */

            // === Insert: rij(en) toevoegen ===
            /*
            string cn = Properties.Settings.Default.CNstr.ToString();
            using (SqlConnection sqlcn = new SqlConnection(cn))
            {
                sqlcn.Open();
                string insertString = @"insert into medewerkers(mnr, naam, voorn, gbdatum, maandsal, functie)
                    values (7001, 'QUAREME', 'TOM', '1992-01-12', 2500, 'TRAINER')";
                SqlCommand cmd = new SqlCommand(insertString, sqlcn);
                cmd.ExecuteNonQuery(); // geen query maar commando => cmd.ExecuteNonQuery();
            }
            */
            // === Update: bestaande rij(en) aanpassen ===
            /*
            string cn = Properties.Settings.Default.CNstr.ToString();
            using (SqlConnection sqlcn = new SqlConnection(cn))
            {
                sqlcn.Open();
                string updateString = @"update medewerkers 
                set naam = 'TESLA', voorn = 'NIKOLA' 
                where mnr = 7001";
                SqlCommand cmd = new SqlCommand(updateString, sqlcn);
                cmd.ExecuteNonQuery(); // geen query maar commando => cmd.ExecuteNonQuery();
            }
            */
            // === Delete: rij(en) verwijderen ===
            /*
            string cn = Properties.Settings.Default.CNstr.ToString();
            using (SqlConnection sqlcn = new SqlConnection(cn))
            {
                sqlcn.Open();
                string deleteString = @"delete from medewerkers where mnr = 7001";
                SqlCommand cmd = new SqlCommand(deleteString, sqlcn);
                cmd.ExecuteNonQuery(); // geen query maar commando => cmd.ExecuteNonQuery();
            }
            */

            /*
            string cn = Properties.Settings.Default.CNstr.ToString(); // ConnectionString uitlezen
            // using zorgt voor automatische Close(), maar we moeten wel nog zelf Open() doen!!!
            using (SqlConnection sqlcn = new SqlConnection(cn))
            {
                sqlcn.Open();
                string queryString = "select * from medewerkers";
                SqlCommand cmd = new SqlCommand(queryString, sqlcn);
                // Dankzij using wordt de SqlDataReader automatisch gesloten!
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // SqlDataReader gebruiken we om elke rij (record) te inspecteren
                    while (reader.Read())
                    {
                        // Snelst, let op dat je de juiste types neemt die overeenkomen met SQL server:
                        TxtResultaat.AppendText($"{reader.GetInt16(0)} {reader.GetString(1)}\r\n");
                        // Of trager:
                        TxtResultaat.AppendText($"{reader[0]} {reader[1]}\r\n");
                    }
                }
            }
            */
            /*
            string cn = Properties.Settings.Default.CNstr.ToString();
            using (SqlConnection sqlcn = new SqlConnection(cn))
            {
                sqlcn.Open();
                string query = @"select voorn, naam, maandsal from medewerkers where maandsal >= @salaris";
                // Parameter instellen.
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@salaris";
                param.Value = "3500";
                SqlCommand cmd = new SqlCommand(query, sqlcn);
                cmd.Parameters.Add(param);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Let op dat je de juiste types neemt die overeenkomen met SQL server:
                        TxtResultaat.AppendText($"{reader.GetString(0)} {reader.GetString(1)} {reader.GetDouble(2)}\r\n");
                    }
                }
            }
            */

            // ZELF DATASET OPSTELLEN
            /*
            // 1) Maak DataSet aan
            DataSet ds = new DataSet();
            // 2) Maak DataTable aan
            DataTable dt = new DataTable();
            dt.TableName = "Stud";

            // 3) Kolommen gaan declareren voor deze DataTable
            DataColumn dcStudId = new DataColumn("StudId", typeof(int));
            DataColumn dcNaam = new DataColumn("Naam", typeof(string));
            DataColumn dcOpleiding = new DataColumn("Opleiding", typeof(string));
            DataColumn dcGbDatum = new DataColumn("GbDatum", typeof(DateTime));
            DataColumn dcTel = new DataColumn();
            dcTel.ColumnName = "Telefoon";
            dcTel.DataType = typeof(string);
            dcTel.Unique = true;
            dcTel.ReadOnly = false;

            // Kolommen toevoegen aan DataTable
            dt.Columns.Add(dcStudId);
            dt.Columns.Add(dcNaam);
            dt.Columns.Add(dcOpleiding);
            dt.Columns.Add(dcGbDatum);
            dt.Columns.Add(dcTel);

            // 4) Primary keys toevoegen aan DataTable
            DataColumn[] pk = { dcStudId }; // array omdat je ook samengestelde keys kan hebben
            dt.PrimaryKey = pk;

            // 5) Constraints toevoegen aan DataTable
            UniqueConstraint uniek = new UniqueConstraint(dcNaam);
            dt.Constraints.Add(uniek);


            // 6) Vul de DataTable met rijen
            dt.Rows.Add(new object[] { 1, "Tom Quareme", "Graduaat Programmeren", new DateTime(1992, 1, 12), "011111111"});
            dt.Rows.Add(2, "Paul Dox", "Graduaat Digitale vormgeving", new DateTime(1972, 3, 17), "011775101");
            dt.Rows.Add(3, "Patricia Briers", "Graduaat Systemen en netwerken", new DateTime(1971, 10, 17), "011775102");

            DataRow rij = dt.NewRow();
            rij[dcStudId] = 4;
            rij[dcNaam] = "Ann Das";
            rij[dcOpleiding] = "Graduaat Ssystemen en netwerken";
            rij[dcGbDatum] = new DateTime(1990, 12, 15);
            rij[dcTel] = "011775103";
            dt.Rows.Add(rij);

            // 7) DataTable toevoegen aan DataSet
            ds.Tables.Add(dt);

            // 8) DataTable afdrukken in DataGrid
            DataView dv = ds.Tables["Stud"].DefaultView;
            DgStud.ItemsSource = dv;


            // 9) DataTable dt wegschrijven naar een XML-bestand
            dt.WriteXml(@"..\..\stud.xml");
            */


            // DATASET VULLEN MET DATA DIE UIT SQL SERVER DATABASE (Medewerkers) KOMT
            // string cn = Properties.Settings.Default.CNstr.ToString();
            string cn = @"Integrated Security=SSPI;Persist Security Info=False;
                Initial Catalog=Medewerkers;Data Source=localhost\SQLEXPRESS;";

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.TableName = "Medewerkers";
            ds.Tables.Add(dt);

            using (SqlConnection sqlcn = new SqlConnection(cn))
            {
                sqlcn.Open();

                SqlCommand cmd = new SqlCommand("select * from medewerkers", sqlcn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Medewerkers");
            }

            // DataTable afdrukken in DataGrid
            DataView dv = ds.Tables["Medewerkers"].DefaultView;
            
            DgStud.ItemsSource = dv;

            // DataTable afdrukken in ListBox
            DataView dv2 = ds.Tables["Medewerkers"].DefaultView;
            dv2.RowFilter = "naam like '%E%'";
            dv2.Sort = "naam asc";
            LbxFuncties.ItemsSource = dv2;
            LbxFuncties.DisplayMemberPath = "naam";
        }
    }
}

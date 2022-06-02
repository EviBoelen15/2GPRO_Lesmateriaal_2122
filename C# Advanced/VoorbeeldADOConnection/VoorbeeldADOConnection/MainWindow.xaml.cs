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
using System.Data.SqlClient;

namespace VoorbeeldADOConnection
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
            // Haal de ConnectionString uit de settings file
            string cn = Properties.Settings.Default.CNstr.ToString();
            SqlConnection sqlcn = new SqlConnection(cn);

            sqlcn.Open();

            if (sqlcn.State == ConnectionState.Open)
            {
                MessageBox.Show("De connection is open.");
            }
            else
            {
                MessageBox.Show("De connection is NIET open.");
            }
        }

        private void BtnSqlCommandText_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlcn = new SqlConnection(@" Integrated Security = SSPI; Persist Security Info = False; Initial Catalog = Medewerkers; Data Source = localhost\SQLEXPRESS");
            string query = "select * from medewerkers";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcn; // connectiondoorgeven aan commando
            cmd.CommandType = CommandType.Text; // we zeggen: commando staat in tekstformaat
            cmd.CommandText = query; // commando tekst is de query
            TxtResultaat.Text = cmd.CommandText; // Geeft: select * frommedewerkers
        }
        private void BtnSqlCommandResult_Click(object sender, RoutedEventArgs e)
        {
            string cn = Properties.Settings.Default.CNstr.ToString(); // ConnectionStringuitlezen
                                                                      // usingzorgt voor automatische Close(), maar we moeten wel nog zelf Open() doen!!!
            using (SqlConnection sqlcn = new SqlConnection(cn))
            {
                sqlcn.Open();
                string queryString = "select * from medewerkers";
                SqlCommand cmd = new SqlCommand(queryString, sqlcn);
                // Dankzij usingwordt de SqlDataReaderautomatisch gesloten!
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // SqlDataReadergebruiken we om elke teruggegeven rij (record) te inspecteren
                    while (reader.Read())
                    {
                        TxtResultaat.Clear();
                        // Snelst, let op dat je de juiste types neemt die overeenkomen met SQL server:
                        TxtResultaat.AppendText($"{reader.GetInt16(0)} {reader.GetString(1)}\r\n");
                        // Of trager:
                        TxtResultaat.AppendText($"{reader[0]} {reader[1]}\r\n");
                    }
                }
            }
        }
        private void BtnSqlCommandResult1_Click(object sender, RoutedEventArgs e)
        {
            string cn = Properties.Settings.Default.CNstr.ToString();
            using (SqlConnection sqlcn = new SqlConnection(cn))
            {
                sqlcn.Open();
                string query = "select max(mnr) from medewerkers";
                SqlCommand cmd = new SqlCommand(query, sqlcn);
                // short van C# komt overeen met smallintin SQL Server
                short maxMed = (short)cmd.ExecuteScalar();
                TxtResultaat.Text = $"{maxMed}"; // Geeft grootste medewerkersnummer
            }
        }

        private void BtnSqlInsert_Click(object sender, RoutedEventArgs e)
        {
            string cn = Properties.Settings.Default.CNstr.ToString();
            using (SqlConnection sqlcn = new SqlConnection(cn))
            {
                sqlcn.Open();
                string updateString = @"insert into medewerkers(mnr, naam, voorn, gbdatum, maandsal, functie, comm)
                values (7001, 'QUAREME', 'TOM', '1992-01-12', 2500, 'TRAINER', NULL)";
                SqlCommand cmd = new SqlCommand(updateString, sqlcn);
                cmd.ExecuteNonQuery(); // geen query maar commando
                MessageBox.Show("Employee inserted");
            }
        }

        private void BtnSqlUpdate_Click(object sender, RoutedEventArgs e)
        {
            string cn = Properties.Settings.Default.CNstr.ToString();
            using (SqlConnection sqlcn = new SqlConnection(cn))
            {
                sqlcn.Open();
                string updateString = @"update medewerkers set naam = 'TESLA', voorn = 'NIKOLA' where mnr= 7001";
                SqlCommand cmd = new SqlCommand(updateString, sqlcn);
                cmd.ExecuteNonQuery(); // geen query maar commando
                MessageBox.Show("Employee updated");
            }
        }

        private void BtnSqlDelete_Click(object sender, RoutedEventArgs e)
        {
            string cn = Properties.Settings.Default.CNstr.ToString();
            using (SqlConnection sqlcn = new SqlConnection(cn))
            {
                sqlcn.Open();
                string deleteString = @"delete from medewerkers where mnr= 7001";
                SqlCommand cmd = new SqlCommand(deleteString, sqlcn);
                cmd.ExecuteNonQuery(); // geen query maar commando
                MessageBox.Show("Employee deleted");
            }
        }

        private void BtnDataTable_Click(object sender, RoutedEventArgs e)
        {
            string cn = Properties.Settings.Default.CNstr.ToString();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.TableName = "Medewerkers";
            ds.Tables.Add(dt); // voeg DataTabledttoe aan DataSetds(indien nog niet gedaan)
            using (SqlConnection sqlcn = new SqlConnection(cn))
            {
                sqlcn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlcn;
                cmd.CommandText = "select * from medewerkers";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt); // vul DataTable dt met de resultaten in de SqlDataAdapter da
            }


            DataView dv = new DataView(dt, "functie='MANAGER'", "functie", DataViewRowState.Unchanged);
            lbxResult.ItemsSource = dv;
            lbxResult.DisplayMemberPath = "naam"; // toon enkel de kolom “naam” in de ListBox.
                                                    // Of wanneer we rijen van DataViewnog wat verder willen filteren (wat willen we tonen?)
                                                    // dan gaat dat ook, maar ik doe dat eigenlijk veel liever in de SQL query zelf...
                                                    // Bijvoorbeeld: toon enkel namen met de letter E in.
                                                    // En sorteer ook op naam.
            /*
            dv = new DataView(dt);
            dv.RowFilter = "naam like '%E%'"; // toon enkel namen met de letter E in
            dv.Sort = "naam asc"; // sorteer ook op naam (asc: van klein naar groot, desc: omgekeerd)*/
        }
        /*
        private void BtnSqlParam(object sender, RoutedEventArgs e)
        {
           string cn = Properties.Settings.Default.CNstr.ToString();
           using (SqlConnection sqlcn = new SqlConnection(cn))
           {
               sqlcn.Open();
               string query = @"select voorn, naam, maandsalfrommedewerkers wheremaandsal>= @salaris";
               // Parameter instellen.
               SqlParameter param = new SqlParameter();
               param.ParameterName = "@salaris";
               param.Value = 3500.0f;
               SqlCommand cmd = new SqlCommand(query, sqlcn);
               cmd.Parameters.Add(param);
               using (SqlDataReader reader = cmd.ExecuteReader())
               {
                   while (reader.Read())
                   {
                       // We gebruiken GetDouble() omdat GetFloat() een InvalidCastExceptionheeft...
                       // floatin SQL server is dus double in C# !!!
                       TxtResultaat.AppendText($"{reader.GetString(0)} {reader.GetString(1)} {reader.GetDouble(2)}\r\n");
                   }
               }
           }
        }
        private void BtnSqlParam2(object sender, RoutedEventArgs e)
        {
           string cn = Properties.Settings.Default.CNstr.ToString();
           using (SqlConnection sqlcn = new SqlConnection(cn))
           {
               sqlcn.Open();
               string query = @"select voorn, naam, maandsalfrommedewerkers wheremaandsal>= @salaris";
               // Parameter instellen.
               SqlParameter param = new SqlParameter();
               param.ParameterName = "@salaris";
               param.Value = 3500.0f;
               SqlCommand cmd = new SqlCommand(query, sqlcn);
               cmd.Parameters.Add(param);
               using (SqlDataReader reader = cmd.ExecuteReader())
               {
                   while (reader.Read())
                   {
                       // We gebruiken GetDouble() omdat GetFloat() een InvalidCastExceptionheeft...
                       // floatin SQL server is dus double in C# !!!
                       TxtResultaat.AppendText($"{reader.GetString(0)} {reader.GetString(1)} {reader.GetDouble(2)}\r\n");
                   }
               }
           }
        }
        */

    }
}

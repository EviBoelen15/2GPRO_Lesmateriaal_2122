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

namespace MolConnected
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

        private void Aanmelden_Click(object sender, RoutedEventArgs e)
        {
            string naam = TextBoxNaam.Text;
            string wachtwoord = TextBoxWachtWoord.Text;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("SpelerInfo");
            //string[] ingelogdeGebruiker = new string[9];

            ds.Tables.Add(dt);

            string cn = Properties.Settings.Default.CNstr.ToString();

            using (SqlConnection sqlcn = new SqlConnection(cn))
            {
                sqlcn.Open();
                string query = "select spelers.spelerid, spelers.spel_id, spelers.naam, spelers.wachtwoord, spelers.is_mol, spelers.leeftijd_tijdens_deelname, " +
                                "spelers.beroep, spellen.jaar, spellen.locatie " +
                                "from spelers inner join spellen on spelers.spel_id = spellen.spel_id" +
                                $" where spelers.naam = '{naam}' and spelers.wachtwoord = '{wachtwoord}'";

                SqlCommand cmd = new SqlCommand(query, sqlcn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                if(dt.Rows.Count > 0)
                {
                    Profiel profiel = new Profiel(dt);
                    this.Close();
                    profiel.Show();
                }
                else
                {
                    MessageBox.Show("Geef de juiste gevens in");
                }
                /*
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ingelogdeGebruiker[0] = reader[0].ToString();
                        ingelogdeGebruiker[1] = reader[1].ToString();
                        ingelogdeGebruiker[2] = reader[2].ToString();
                        ingelogdeGebruiker[3] = reader[3].ToString();
                        ingelogdeGebruiker[4] = reader[4].ToString();
                        ingelogdeGebruiker[5] = reader[5].ToString();
                        ingelogdeGebruiker[6] = reader[6].ToString();
                        ingelogdeGebruiker[7] = reader[7].ToString();
                        ingelogdeGebruiker[8] = reader[8].ToString();
                    }
                }*/
                
            }
        }

        private void CheckBoxSQL_Checked(object sender, RoutedEventArgs e)
        {
            //injectionIsChecked = true;
        }
    }
}

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

namespace DeMol
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
            string cn = Properties.Settings.Default.CNstr.ToString();

            string naam = TextBoxNaam.Text;
            string wachtwoord = TextBoxWachtWoord.Text;

            using (SqlConnection sqlcn = new SqlConnection(cn))
            {
                sqlcn.Open();

                string query = "select * from spelers where naam = @naam and wachtwoord = @wachtwoord";

                // Parameter instellen.
                SqlParameter paramNaam = new SqlParameter();
                paramNaam.ParameterName = "@naam";
                paramNaam.Value = naam;
                SqlParameter paramWachtwoord = new SqlParameter();
                paramWachtwoord.ParameterName = "@wachtwoord";
                paramWachtwoord.Value = wachtwoord;

                SqlCommand cmd = new SqlCommand(query, sqlcn);

                cmd.Parameters.Add(paramNaam);
                cmd.Parameters.Add(paramWachtwoord);

                // Dankzij usingwordt de SqlDataReaderautomatisch gesloten!
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (cmd.)
                        new Account().Show();
                    else
                        MessageBox.Show("Deze gebruiker bestaat niet.");
                    // SqlDataReadergebruiken we om elke teruggegeven rij (record) te inspecteren
                }
            }
        }
    }
}

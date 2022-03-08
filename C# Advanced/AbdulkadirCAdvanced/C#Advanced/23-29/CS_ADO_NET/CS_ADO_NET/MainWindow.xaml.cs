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

namespace CS_ADO_NET
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
    }
}

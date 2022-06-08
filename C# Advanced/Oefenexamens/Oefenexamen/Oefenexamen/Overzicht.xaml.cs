using System;
using System.Collections.Generic;
using System.Data;
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

namespace Oefenexamen
{
    /// <summary>
    /// Interaction logic for Overzicht.xaml
    /// </summary>
    public partial class Overzicht : Window
    {
        DataTable dtStudent, dtVak;
        public Overzicht(DataTable dtStudent, DataTable dtVak)
        {
            InitializeComponent();
            DataView dv1 = dtVak.DefaultView;
            dgStudent.ItemsSource = dv1;
            this.dtStudent = dtStudent;

            DataView dv2 = dtVak.DefaultView;
            dgVak.ItemsSource = dv2;
            this.dtVak = dtVak;
        }

        private void btnNaam_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var row in dtStudent.AsEnumerable())
            {
                if (row.Field<string>("Voornaam").StartsWith("P"))
                {
                    string outputString = $"{row.Field<string>("Voornaam").ToUpper()} {row.Field<string>("Achternaam").ToUpper()} - {row.Field<string>("VakCode")} studeert Programmeren";
                    sb.AppendLine(outputString);
                }
            }
            dgStudent.ItemsSource = sb.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var row in dtStudent.AsEnumerable())
            {
                if(row.Field<string>("VakCode").Equals("PRO"))
                {
                    string outputString = $"{row.Field<string>("Voornaam").ToUpper()} {row.Field<string>("Achternaam").ToUpper()} - {row.Field<string>("VakCode")} studeert Programmeren";
                    sb.AppendLine(outputString);
                }
            }
            dgStudent.ItemsSource = sb.ToString();
        }
    }
}

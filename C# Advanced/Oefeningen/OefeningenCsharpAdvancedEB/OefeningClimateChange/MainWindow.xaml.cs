using OefeningClimateChange.ClassLibraryClimateChange;
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

namespace OefeningClimateChange
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataBewerking.InitializeDataSet();
            DataGridCountries.ItemsSource = DataBewerking.GetCountriesDataView();
            DataGridTempChange.ItemsSource = DataBewerking.GetTempChangesDataView();
            foreach(Country country in DataBewerking.GetCountries())
            {
                ComboBoxCountries.Items.Add(country.CountryCode);
            }
            ListBoxWorstYears.ItemsSource = DataBewerking.GetWorstYearAfter2000();
        }

        private void ComboBoxCountries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string country = ComboBoxCountries.SelectedItem.ToString();
            List<Country> lstCountries = DataBewerking.GetCountries();

            string url = string.Empty;
            string name = string.Empty;
            string code = string.Empty;
            string region = string.Empty;
            string subregion = string.Empty;

            foreach (Country varCountry in lstCountries)
            {
                if (varCountry.Equals(country))
                {
                    url = varCountry.CountryName;
                    name = varCountry.CountryCode;
                    code = varCountry.ImageFilePath;
                    region = varCountry.Region;
                    subregion = varCountry.SubRegion;
                }
            }
            TextBlockCountryName.Text = name;
            TextBlockCountryRegion.Text = region;
            TextBlockCountrySubRegion.Text = subregion;
        }
    }
}

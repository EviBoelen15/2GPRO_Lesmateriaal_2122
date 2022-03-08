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

// Zie bestand ArtikelUitCategorie.sql voor de Stored Procedure
//-- === STORED PROCEDURE in SQL Server===
//CREATE OR ALTER PROCEDURE[dbo].[ArtikelUitCategorie]
//@CatID smallint
//AS
//SELECT artikel, omschrijving, verkoopprijs
//FROM artikel
//WHERE cat_id = @CatID
//ORDER BY artikel;

namespace CS_Oefening_027
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Categorie> categories;
        private List<Klant> klanten;
        private DataSet ds = new DataSet("Spionshop");

        public MainWindow()
        {
            InitializeComponent();

            ds.Tables.Add(new DataTable("Artikel"));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                categories = DBCategorie.SelecteerAlleCategories();
                LbxCategorie.ItemsSource = categories;

                // Algemeen als categorie automatisch selecteren
                for (int i = 0; i < LbxCategorie.Items.Count; i++)
                {
                    if (LbxCategorie.Items[i].ToString().Equals("Algemeen"))
                    {
                        LbxCategorie.SelectedIndex = i;
                        break;
                    }
                }

                VulKlanten();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void VulDgArtikel()
        {
            // Geselecteerd catid uitlezen uit listbox LbxCategorie
            short catid = ((Categorie)LbxCategorie.SelectedItem).CatID;
            if (catid == -1)
                return;

            try
            {
                DBArtikel.ArtikelUitCategorie(ds, catid);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            DgArtikel.ItemsSource = ds.Tables["Artikel"].DefaultView;
        }

        private void VulKlanten()
        {
            string woonplaats = TxtWoonplaats.Text;
            if (woonplaats.Equals("Woonplaats"))
                woonplaats = "";
            try
            {
                klanten = DBKlant.SelecteerKlanten(woonplaats);
                LbxWoonplaats.ItemsSource = klanten;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LbxCategorie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LbxCategorie.SelectedIndex == -1)
                return;

            VulDgArtikel();
        }

        private void TxtWoonplaats_KeyUp(object sender, KeyEventArgs e)
        {
            // Enkel wanneer ik op Enter of Return toets op toetsenbord heb gedrukt ga ik verder...
            if (e.Key != Key.Enter && e.Key != Key.Return)
                return;

            VulKlanten();
        }
    }
}

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
using System.IO;
using Microsoft.Win32;
using System.Data;

namespace Oefenexamen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string richting;
        string opslaMapStudentData;


        public DataSet dsStudent = new DataSet();
        DataTable dtVak = new DataTable("Vak");
        DataTable dtStudent = new DataTable("Student");

        public MainWindow()
        {
            InitializeComponent();
            MaakEnVulDataTables();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Alle bestanden (*.*)|*.*|Tekstbestanden (*.txt) |*.txt",
                FilterIndex = 2,
                FileName = "punten.txt",
                Multiselect = true,
                InitialDirectory = Environment.CurrentDirectory // onder onze \Debug map
                                                                // == OF ==
                                                                // InitialDirectory = System.IO.Path.GetFullPath(@"..\..\Bestanden"), // volledig pad
                                                                // == OF ==
                                                                // InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) // start in My Documents
            };
            opslaMapStudentData = ofd.FileName;

            if (ofd.ShowDialog() == true) // als de OpenFileDialog getoond kan worden
            {
                StreamReader sr = new StreamReader(ofd.FileName);
                while (!sr.EndOfStream)
                {
                    string lijn = sr.ReadLine(); // lees nieuwe regel
                    var infoLijn = lijn.Split(';');

                    switch(infoLijn[2].ToString())
                    {
                        case "DVG":
                            richting = "Digitale vormgeving";
                            break;
                        case "PRO":
                            richting = "Programmeren";
                            break;
                        case "IOT":
                            richting = "Internet Of Things";
                            break;
                        case "SNE":
                            richting = "Systeem en netwerken";
                            break;
                        default:
                            richting = "Ongeldige studie ingaven";
                            break;

                    }
                    lbxStudenten.Items.Add($"{infoLijn[1].Substring(0, 1).ToUpper()}{infoLijn[1].Substring(1).ToLower()} {infoLijn[0].ToUpper()} - ({richting})");
                    dtStudent.Rows.Add(infoLijn[1], infoLijn[0], infoLijn[2]);
                }
                sr.Close();
            }
            
        }

        private void lbxStudenten_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string contentStudent = lbxStudenten.SelectedItem.ToString();
            var scStudent = contentStudent.Split('-');
            string outputString = $"{scStudent[0].Substring(0, 1)}. {scStudent[0].Substring(0, 1).ToUpper()}{scStudent[1].Substring(1).ToLower()} studeert {richting.ToUpper()}";
            MessageBox.Show(outputString);
        }
        private void MaakEnVulDataTables()
        {
            dtVak.Columns.Add("Code");
            dtVak.Columns.Add("Omschrijving");

            dtVak.Rows.Add("PRO", "Programmeren");
            dtVak.Rows.Add("SNE", "Systemen en netwerken");
            dtVak.Rows.Add("DVG", "Digitale vormgeving");
            dtVak.Rows.Add("IOT", " Internet of things");

            dtStudent.Columns.Add("Voornaam");
            dtStudent.Columns.Add("Achternaam");
            dtStudent.Columns.Add("VakCode");
        }

        private void ExitItem_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        private void CSVItem_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Alle bestanden (*.*)|*.*|Tekstbestanden (*.txt)|*.txt",
                FilterIndex = 2,
                Title = "Geef een bestandsnaam op",
                OverwritePrompt = true, // bevestiging vragen bij overschrijven van eenbestand
                AddExtension = true, // extensie wordt toegevoegd
                DefaultExt = "csv", // standaard extensie
                FileName = "Studenten.csv",
                InitialDirectory = Environment.CurrentDirectory // onder onze \Debug map
            };
            if (sfd.ShowDialog() == true) // als de SaveFileDialog getoond kan worden
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName))
                {
                    foreach (var item in dtStudent.AsEnumerable())
                    {
                        var achternaam = item.Field<string>("Achternaam");
                        var naam = item.Field<string>("Voornaam");
                        var vakAfk = item.Field<string>("VakCode");
                        string vakNaam = "";

                        foreach (var i in dtVak.AsEnumerable())
                        {
                            if (i.Field<string>("Code").Equals(vakAfk))
                            {
                                vakNaam = i.Field<string>("Code");
                            }
                        }
                        sw.WriteLine($"{naam};{achternaam};{vakNaam}");
                    }
                }
            }
        }
        private void DataBestand_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(opslaMapStudentData))
            {
                foreach (var item in dtStudent.AsEnumerable())
                {
                    var achternaam = item.Field<string>("Achternaam");
                    var naam = item.Field<string>("Voornaam");
                    var vakAfk = item.Field<string>("VakCode");
                    string vakNaam = "";

                    foreach (var i in dtVak.AsEnumerable())
                    {
                        if (i.Field<string>("Code").Equals(vakAfk))
                        {
                            vakNaam = i.Field<string>("Code");
                        }
                    }
                    sw.WriteLine($"{naam};{achternaam};{vakNaam}");
                }
            }
        }
        private void Overzicht_Click(object sender, RoutedEventArgs e)
        {
            Overzicht overzicht = new Overzicht(dtStudent, dtStudent);
            overzicht.Show();
        }

    }
}

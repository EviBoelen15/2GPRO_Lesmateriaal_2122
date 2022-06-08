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
using Microsoft.Win32;
using System.IO;

namespace OefenexamenCONNECTED
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataSet dsStudent = new DataSet();
        DataTable dtStudent = new DataTable("Student");
        DataTable dtVak = new DataTable("Vak");

        string openStudentFilePath;
        public MainWindow()
        {
            InitializeComponent();
            string cn = Properties.Settings.Default.CNstr.ToString();
            SqlConnection sqlcn = new SqlConnection(cn);

            sqlcn.Open();
            if (sqlcn.State == System.Data.ConnectionState.Open)
            {
                MessageBox.Show("Connection established");
            }
            else
            {
                MessageBox.Show("Connection nog open");
            }
            
            //OpenStudentFile();
        }

        public void OpenStudentFile()
        {
            /*
            */

            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Alle bestanden (*.*)|*.*|Tekstbestanden (*.txt) |*.txt",
                FilterIndex = 2, // index start vanaf 1, niet 0 hier! 2 wil zeggen hier filteren op.txt
                FileName = "punten.txt",
                Multiselect = true, // je kan meerdere bestanden selecteren (true, anders false
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) // star in My Documents
                                    // == OF ==
                                    // InitialDirectory = System.IO.Path.GetFullPath(@"..\..\Bestanden"), // volledig pad
                                    // == OF ==
                                    // InitialDirectory = Environment.CurrentDirectory // onder onze \Debug map
            };

            if (ofd.ShowDialog() == true) // als de OpenFileDialog getoond kan worden
            {
                //Pad opvragen voor data file later op te slaan.
                openStudentFilePath = System.IO.Path.GetDirectoryName(ofd.FileName);

                using(StreamReader sr = new StreamReader(ofd.FileName))
                {
                    while (!sr.EndOfStream)
                    {
                        string fileLine = sr.ReadLine(); // lees nieuwe regel
                        Console.WriteLine(fileLine); // print hem af
                        string[] studentInfo = fileLine.Split(';');
                        string naam = studentInfo[0];
                        string achternaam = studentInfo[1];
                        string richtingAFK = studentInfo[2];
                    }
                }
            }
        }

        private void CSVItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DataBestand_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Overzicht_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void ExitItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lbxStudenten_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

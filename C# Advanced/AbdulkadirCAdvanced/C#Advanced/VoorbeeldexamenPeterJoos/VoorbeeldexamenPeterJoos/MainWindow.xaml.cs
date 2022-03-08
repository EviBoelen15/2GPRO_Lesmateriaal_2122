using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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

namespace VoorbeeldexamenPeterJoos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            Vak v = new Vak();
            Student s;

            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Alle bestanden (*.*)|*.*|Tekstbestanden (*.csv) |*.csv",
                FileName = "bediende.csv",
                InitialDirectory = System.IO.Path.GetFullPath(@"..\..\Bestand")
            };
            if (ofd.ShowDialog() == true)
            {
                Bestand.bestandnaam = System.IO.Path.GetDirectoryName(ofd.FileName);
                string[] kolomm;
                using (StreamReader sr = new StreamReader(ofd.FileName))
                {
                    while (!sr.EndOfStream)
                    {
                        kolomm = sr.ReadLine().Split(';');
                        s = new Student(kolomm);
                        Bestand.Data.Add(s);
                    }
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LstData.ItemsSource = Bestand.Data;
        }

        private void LstData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = LstData.SelectedIndex;
            switch (Bestand.Data[index].VakCode)
            {
                case "PRO":
                    MessageBox.Show($"{Bestand.Data[index].Voornaam.Substring(0, 1)}.{Bestand.Data[index].Naam} volgt les in de afdeling PROGRAMMEREN");
                    break;
                case "SNE":
                    MessageBox.Show($"{Bestand.Data[index].Voornaam.Substring(0, 1)}.{Bestand.Data[index].Naam} volgt les in de afdeling SYSTEMEN EN NETWERKEN");
                    break;
                case "DVG":
                    MessageBox.Show($"{Bestand.Data[index].Voornaam.Substring(0, 1)}.{Bestand.Data[index].Naam} volgt les in de afdeling DIGITALE VORMGEVING");
                    break;
                case "IOT":
                    MessageBox.Show($"{Bestand.Data[index].Voornaam.Substring(0, 1)}.{Bestand.Data[index].Naam} volgt les in de afdeling INTERNET OF THINGS");
                    break;
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Alle bestanden (*.*)|*.*|Tekstbestanden (*.csv) |*.csv",
                Title = "Data.csv",
                InitialDirectory = System.IO.Path.GetFullPath(@"..\..\Bestand")
            };
            if (sfd.ShowDialog() == true)
            {
               using (StreamWriter sw = new StreamWriter("text.txt"))
                {
                  foreach (Student s in Bestand.Data)
                    {
                        switch (s.VakCode)
                        {
                            case "PRO":
                                sw.WriteLine(s.Naam + ";" + s.Voornaam + ";programmeren");
                                break;
                            case "SNE":
                                sw.WriteLine(s.Naam + ";" + s.Voornaam + ";systemen en netwerken"); break;
                            case "DVG":
                                sw.WriteLine(s.Naam + ";" + s.Voornaam + ";digitale vormgeving"); break;
                            case "IOT":
                                sw.WriteLine(s.Naam + ";" + s.Voornaam + ";internet of things"); break;
                        }
                    }
                }
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            if (Bestand.bestandnaam != string.Empty)
            {
                string dataBestand = $"{Bestand.bestandnaam}\\data.xml";
                Bestand.dsStudent.WriteXml(dataBestand);
            }
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            WPFData window = new WPFData();
            window.Show();
        }
    }
}

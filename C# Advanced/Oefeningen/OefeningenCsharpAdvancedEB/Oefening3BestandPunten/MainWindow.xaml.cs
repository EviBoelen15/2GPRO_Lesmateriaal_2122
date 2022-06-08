using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

namespace Oefening3BestandPunten
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

        private void BtnInlezen_Click(object sender, RoutedEventArgs e)
        {
            StreamReader sr = new StreamReader("Punten.txt");

            while (!sr.EndOfStream)
            {
                TxtResultaat.Text += sr.ReadLine() + "\n";
            }

        }

        private void BtnVerwerken_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Alle bestanden (*.*)|*.*|Tekstbestanden (*.txt)|*.txt",
                FilterIndex = 2,
                Title = "Geef een bestandsnaam op",
                OverwritePrompt = true, //Bevestiging wordt gevraagd bij overschrijven van een bestand.
                AddExtension = true, // Extensie wordt toegevoegd.
                DefaultExt = "txt",
                FileName = "VerwerktePunten.txt",
                InitialDirectory = Environment.CurrentDirectory// onder ..\Debug
            };
            sfd.ShowDialog();

            //vul nieuw bestand
            FileStream fs = new FileStream("VerwerktePunten.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            for (int i = 0; i < 10; i++)
            sw.Write(i + " ");
            sw.WriteLine(); // Lege regel toevoegen.
                            // Sluiten van bestanden.
            sw.Close();
            fs.Close();


            //Slaat nieuw bestand op.


            

            // SCHRIJVEN
            
        }

        private void BtnNalezen_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSluiten_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}

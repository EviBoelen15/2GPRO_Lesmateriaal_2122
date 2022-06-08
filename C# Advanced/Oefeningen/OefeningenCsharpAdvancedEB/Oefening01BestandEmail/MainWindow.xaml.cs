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

namespace Oefening01BestandEmail
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, string> dct = new Dictionary<string, string>();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void BtnInlezen_Click(object sender, RoutedEventArgs e)
        {
            TxtResultaat.Text = ReadFile("Email.txt").ToString();
        }
        private void BtnInlezenDialog_Click(object sender, RoutedEventArgs e)
        {
            TxtResultaat.Text = ReadFile().ToString();
        }
        private void BtnInlezenDictionary_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            string[] velden; 
            int j = 0;
            // LEZEN
            StreamReader sr = new StreamReader("Email.txt");
            // Inlezen van bestand per record. while (! sr.EndOfStream) { Console.WriteLine(sr.ReadLine()); }

            while (!sr.EndOfStream)
            {
                velden = sr.ReadLine().Split(',');
                dct.Add(velden[0], velden[1]);
                j++;
            }
            // Sluiten van bestand.
            sr.Close();

            foreach (KeyValuePair<string, string> item in dct)
            {
                TxtResultaat.Text += $"{item.Key}     : {item.Value} \n";
            }
            
        }
        private void BtnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            string naam = TxtNaam.Text;
            string email = TxtEmailadres.Text;

            SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Alle bestanden (*.*)|*.*|Tekstbestanden (*.txt)|*.txt",
                FilterIndex = 2,
                Title = "Email.txt",
                OverwritePrompt = true, //Bevestiging wordt gevraagd bij overschrijven van een bestand.
                AddExtension = true, // Extensie wordt toegevoegd.
                DefaultExt = "txt",
                FileName = "Email.txt",
                //InitialDirectory = @"C:\SCHOOL\CSharp 2\Voorbeelden2", // Fysieke map
                InitialDirectory = Environment.CurrentDirectory// onder ..\Debug
            };
            sfd.ShowDialog();

            FileStream fs = new FileStream(sfd.FileName, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine($"\n{naam}     : {email}");

            sw.WriteLine(); // lege regel wegschrijven
                            // Sluiten van bestand.
            sw.Close();

        }
        private void BtnWegschrijven_Click(object sender, RoutedEventArgs e)
        {
            // SCHRIJVEN
            // Tekstbestand creëren en openen (automatisch in standaardirectory van je project \bin\Debug).
            StreamWriter sw = new StreamWriter("Adressen.Txt");
            foreach (KeyValuePair<string, string> item in dct)
            {
                sw.WriteLine($"{item.Key}     : {item.Value} \n");
            }
            sw.WriteLine(); // lege regel wegschrijven

            sw.Close();
        }
        public StringBuilder ReadFile(string file)
        {
            StringBuilder sb = new StringBuilder();
            int j = 0;

            // LEZEN
            StreamReader sr = new StreamReader(file);
            // Inlezen van bestand per record. while (! sr.EndOfStream) { Console.WriteLine(sr.ReadLine()); }

            while (!sr.EndOfStream)
            {
                sb.AppendLine(sr.ReadLine());
                j++;
            }
            // Sluiten van bestand.
            sr.Close();
            return sb;

            // Volledig bestand inlezen.
            // Console.WriteLine(sr.ReadToEnd());
        }
        public StringBuilder ReadFile()
        {
            StringBuilder sb = new StringBuilder();
            int j = 0;

            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Alle bestanden (*.*)|*.*|Tekstbestanden (*.txt) |*.txt",
                FilterIndex = 2,
                FileName = "Email.txt",
                Multiselect = false,
                //InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                // == OF ==
                //InitialDirectory = System.IO.Path.GetFullPath(@"..\..\Bestanden"), // volledig pad
                // == OF ==
                InitialDirectory = Environment.CurrentDirectory // onder ..\Debug
            };
            if (ofd.ShowDialog() == true)
            {
                StreamReader sr = new StreamReader(ofd.FileName);

                while (!sr.EndOfStream)
                {
                    sb.AppendLine(sr.ReadLine());
                    j++;
                }
                // Sluiten van bestand.
                sr.Close();
                return sb;
                /*
                //TxtFile.Text = $"PAD & FILE: {ofd.FileName}\r\n"; //volledig pad en bestandsnaam
                //TxtFile.Text += $"PAD: {System.IO.Path.GetDirectoryName(ofd.FileName)}\r\n"; // enkel pad
                //TxtFile.Text += $"FILE: {System.IO.Path.GetFileName(ofd.FileName)}\r\n\r\n"; // enkel bestandsnaam
                string pad = System.IO.Path.GetDirectoryName(ofd.FileName);
                string[] bestanden = System.IO.Directory.GetFiles(pad); //Lijst van bestanden.
                int i = 0;
                for (; i < bestanden.Length; i++)
                {
                    TxtFile.Text += $"{bestanden[i]}\r\n"; // pad + bestandsnaam
                    StringBuilder sb = new StringBuilder();
                    return sb;
                }*/
            }
            else
            {
                sb.Append("please select a valid format and try again");
                return sb;
            }
        }
    }
}
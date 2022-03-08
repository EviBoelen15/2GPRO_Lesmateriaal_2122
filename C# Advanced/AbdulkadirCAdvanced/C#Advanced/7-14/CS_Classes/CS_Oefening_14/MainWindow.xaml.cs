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

namespace CS_Oefening_14
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Lid> leden;
        private const string LedenBestand = @"..\..\Bestanden\LedenSportkampen.txt";

        public MainWindow()
        {
            InitializeComponent();

            try
            {
                leden = Lid.LeesLeden(LedenBestand);
            }
            catch (Exception)
            {
                MessageBox.Show("Kan bestand LedenSportkampen.txt niet vinden!",
                    "Fout",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            // Toon alle leden in de ListBox
            LbxLeden.Items.Clear();
            foreach (var lid in leden)
            {
                LbxLeden.Items.Add(lid.InformatieVolledig());
            }
        }

        private void LbxLeden_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int index = LbxLeden.SelectedIndex;
            if (index == -1)
                return; // Indien niets geselecteerd

            // Zet het geselecteerde Lid als gedeelde data
            SharedData.Lid = leden[index];
            
            WijzigenWindow w = new WijzigenWindow();
            w.ShowDialog();
            if (w.DialogResult != true)
                return; // Indien op annuleren gedrukt
            
            // Update het aangepaste lid (zowel in List als ListBox)
            leden[index] = SharedData.Lid;
            (LbxLeden.Items[index]) = SharedData.Lid.InformatieVolledig();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult mr = MessageBox.Show(
                $"Wil je het bestand {System.IO.Path.GetFullPath(LedenBestand)} overschrijven?", 
                "Waarschuwing!", 
                MessageBoxButton.YesNo, 
                MessageBoxImage.Warning);

            if (mr == MessageBoxResult.No)
                return;
            
            FileInfo fi = new FileInfo(LedenBestand);
            if (!fi.Exists)
                return;

            using (StreamWriter sw = fi.CreateText())
            {
                foreach (var lid in leden)
                    sw.WriteLine(lid.RecordVorm());
            }
        }
    }
}

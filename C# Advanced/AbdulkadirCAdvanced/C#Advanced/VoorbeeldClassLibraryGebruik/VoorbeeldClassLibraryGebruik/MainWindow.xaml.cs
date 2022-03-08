using System;
using System.Linq;
using System.Windows;
using ClassLibraryBewerking;


namespace VoorbeeldClassLibraryGebruik
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

     
        private void BtnVerschil_Click(object sender, RoutedEventArgs e)
        {
            Bewerking bw = new Bewerking();
            try
            {
                TxtResultaat.Text = $"{bw.Min(float.Parse(TxtGetal1.Text), float.Parse(TxtGetal2.Text))}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnVermenigvuldiging_Click(object sender, RoutedEventArgs e)
        {

            Bewerking bw = new Bewerking();
            try
            {
                TxtResultaat.Text = $"{bw.Maal(float.Parse(TxtGetal1.Text), float.Parse(TxtGetal2.Text))}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       
        private void BtnSom_Click(object sender, RoutedEventArgs e)
        {
            Bewerking bw = new Bewerking();
            try
            {
                TxtResultaat.Text = $"{bw.Som(float.Parse(TxtGetal1.Text), float.Parse(TxtGetal2.Text))}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

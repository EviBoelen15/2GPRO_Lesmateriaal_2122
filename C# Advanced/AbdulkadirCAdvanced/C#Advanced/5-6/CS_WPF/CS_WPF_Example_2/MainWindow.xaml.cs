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

namespace CS_WPF_Example_2
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

        private void BtnWijzigen_Click(object sender, RoutedEventArgs e)
        {
            KeuzeWindow keuzeWindow = new KeuzeWindow(TxtResultaat);
            // Modaal venster oproepen
            keuzeWindow.ShowDialog();
            // Opvangen op welke knop bij het keuzevenster geklikt is.
            if (keuzeWindow.DialogResult.HasValue && keuzeWindow.DialogResult.Value)
            {
                MessageBox.Show("Knop Ok gedrukt.");
            }
            else
            {
                MessageBox.Show("Knop Cancel/Sluiten gedrukt.");
            }
        }
    }
}

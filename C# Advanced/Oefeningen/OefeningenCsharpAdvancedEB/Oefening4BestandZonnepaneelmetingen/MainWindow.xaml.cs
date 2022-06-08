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

namespace Oefening4BestandZonnepaneelmetingen
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

        private void MnuDetails_Click(object sender, RoutedEventArgs e)
        {
            StreamReader sr = new StreamReader("../../Bestanden/Zonnepanelen.txt");

            while (!sr.EndOfStream)
            {
                TxtResultaat.Text += sr.ReadLine() + "\n";
            }
        }
        private void MnuSamenvatting_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

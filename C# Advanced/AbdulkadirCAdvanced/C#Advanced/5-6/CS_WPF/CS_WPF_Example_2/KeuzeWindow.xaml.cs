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
using System.Windows.Shapes;

namespace CS_WPF_Example_2
{
    /// <summary>
    /// Interaction logic for KeuzeWindow.xaml
    /// </summary>
    public partial class KeuzeWindow : Window
    {
        private TextBox tb;
        public KeuzeWindow(TextBox txt)
        {
            InitializeComponent();
            // De 2 objecten worden aan elkaar gekoppeld.
            // Doe dit onder InitializeComponent(); !
            tb = txt;
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            if (RadUpper.IsChecked == true)
                tb.Text = tb.Text.ToUpper();
            else
                tb.Text = tb.Text.ToLower(); 
            // Doorgeven op OK geklikt.
            DialogResult = true;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            // Doorgeven op CANCEL geklikt.
            DialogResult = false;
        }
    }
}

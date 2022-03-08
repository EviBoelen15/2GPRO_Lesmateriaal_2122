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

namespace CS_WPF_Example_3
{
    /// <summary>
    /// Interaction logic for KeuzeWindow.xaml
    /// </summary>
    public partial class KeuzeWindow : Window
    {
        public KeuzeWindow()
        {
            InitializeComponent();
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            if (RadUpper.IsChecked == true)
                Data.Tekst = Data.Tekst.ToUpper();
            else
                Data.Tekst = Data.Tekst.ToLower();

            // KeuzeWindow verbergen zodat MainWindow terug actief wordt (Window_Activated).
            Hide();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

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

namespace CS_WPF
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void BtnShowHide_Click(object sender, RoutedEventArgs e)
        {
            // Verberg huidig venster
            Hide();
            // Terug tonen via Show();
            // Sluit huidig venster
            Close();
        }

        private void BtnShowDialogHide_Click(object sender, RoutedEventArgs e)
        {
            // Verberg huidig venster
            Hide();
            // Terug tonen via ShowDialog();
            // Sluit huidig venster
            Close();
        }
    }
}

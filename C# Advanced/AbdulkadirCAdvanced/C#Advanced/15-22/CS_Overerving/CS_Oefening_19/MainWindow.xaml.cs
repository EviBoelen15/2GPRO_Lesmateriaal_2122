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

namespace CS_Oefening_19
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ListModules listModules;

        public MainWindow()
        {
            InitializeComponent();
            listModules = new ListModules(LbxModules);
        }

        private void BtnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            string module = TxtModule.Text.Trim();
            listModules.Add(module);
        }

        private void BtnZoeken_Click(object sender, RoutedEventArgs e)
        {
            string module = TxtModule.Text.Trim();
            int index = listModules.IndexOf(module);
            if (index == -1)
                MessageBox.Show($"Kan de module {module} niet vinden!", $"De module {module} staat...", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show($"Positie: {index}", $"De module {module} staat...", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BtnVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            string module = TxtModule.Text.Trim();
            listModules.Remove(module);
        }
    }
}

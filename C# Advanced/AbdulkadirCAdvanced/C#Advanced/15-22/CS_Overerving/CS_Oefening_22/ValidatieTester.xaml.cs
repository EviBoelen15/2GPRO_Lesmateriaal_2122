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

// Type project: WPF Application
// Target Framework: .NET Core 3.1 of .NET 5.0 (Current)
// Ik heb hier voor .NET Core gekozen, want ik gebruik toch geen oude InputBox component.

using ValidatieLib; // gebruik onze class library! Let op: target framework moet overeenkomen!!!

namespace CS_Oefening_22
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ValidatieTester : Window
    {
        public ValidatieTester()
        {
            InitializeComponent();
        }
        
        private void BtnTest_Click(object sender, RoutedEventArgs e) 
        { 
            TblResultaat.Text = string.Empty; 

            if (Validatie.IsAanwezig(TxtIntGetal) && 
                Validatie.IsAanwezig(TxtDecGetal) && 
                Validatie.IsInteger(TxtIntGetal) && 
                Validatie.IsDecimal(TxtDecGetal)) 
            { 
                TblResultaat.Text = "Tekstvakken zijn correct ingevuld."; 
            } 
            else 
            { 
                TblResultaat.Text = "Tekstvakken zijn niet correct ingevuld."; 
            } 
        }

        private void TxtIntGetal_GotFocus(object sender, RoutedEventArgs e)
        {
            TxtIntGetal.Text = string.Empty;
            TblResultaat.Text = string.Empty;
        }

        private void TxtDecGetal_GotFocus(object sender, RoutedEventArgs e)
        {
            TxtDecGetal.Text = string.Empty;
            TblResultaat.Text = string.Empty;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
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

namespace MolConnected
{
    /// <summary>
    /// Interaction logic for Profiel.xaml
    /// </summary>
    public partial class Profiel : Window
    {

        public Profiel(DataTable dt)
        {
            InitializeComponent();
            NaamTextBlock.Text = dt.Rows[0][2].ToString();
            LeeftijdTextBlock.Text = dt.Rows[0][5].ToString();
            BeroepTextBlock.Text = dt.Rows[0][6].ToString();
            JaarTextBlock.Text = dt.Rows[0][7].ToString();
            LocatieSpelTextBlock.Text = dt.Rows[0][8].ToString();
            if (dt.Rows[0][4].ToString() == "1")
            {
                NaamTextBlock.Foreground = Brushes.Red;
                LeeftijdTextBlock.Foreground = Brushes.Red;
                BeroepTextBlock.Foreground = Brushes.Red;
                JaarTextBlock.Foreground = Brushes.Red;
                LocatieSpelTextBlock.Foreground = Brushes.Red;
            }
            else
            {
                NaamTextBlock.Foreground = Brushes.Green;
                LeeftijdTextBlock.Foreground = Brushes.Green;
                BeroepTextBlock.Foreground = Brushes.Green;
                JaarTextBlock.Foreground = Brushes.Green;
                LocatieSpelTextBlock.Foreground = Brushes.Green;
            }
        }
    }
}

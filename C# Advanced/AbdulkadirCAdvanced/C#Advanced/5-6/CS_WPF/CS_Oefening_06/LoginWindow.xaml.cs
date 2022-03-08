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

namespace CS_Oefening_06
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private int resterendePogingen = 3;

        public LoginWindow()
        {
            InitializeComponent();
            TxtUser.Focus();
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            string username = TxtUser.Text;
            string wachtwoord = PwbWachtwoord.Password;
            int userIndex = -1;

            // Loopen hadden we kunnen vermijden als we met een Dictionary gewerkt hadden...
            for (int i = 0; i < Data.Wachtwoorden.GetLength(0); i++)
            {
                if (username.Equals(Data.Wachtwoorden[i, 0]))
                {
                    userIndex = i;
                    break; // ontsnap uit de lus als we een geregistreerde gebruiker gevonden hebben
                }
            }
            
            if (userIndex == -1)
            {
                MessageBox.Show("Voer een geregistreerde gebruikersnaam in!",
                    "Foutmelding",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            string correcteWachtwoord = Data.Wachtwoorden[userIndex, 1];
            if (wachtwoord.Equals(correcteWachtwoord))
            {
                Hide();
                Data.User = username;
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }
            else
            {
                resterendePogingen--;
                if (resterendePogingen <= 0)
                {
                    MessageBox.Show("Je aantal pogingen zijn op!",
                        "Foutmelding",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    Close();
                    return;
                }
                MessageBox.Show($"Je wachtwoord is verkeerd\r\nJe krijgt nog {resterendePogingen} poging(en)", 
                    "Foutmelding", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Exclamation);
            }
        }
    }
}

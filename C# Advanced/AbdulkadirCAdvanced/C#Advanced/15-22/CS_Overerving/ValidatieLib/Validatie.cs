using System;

using System.Windows; // Om MessageBox te kunnen gebruiken
using System.Windows.Controls; // Om TextBox te kunnen gebruiken

// Type project: WPF Class Library
// Target Framework: .NET Core 3.1 of .NET 5.0 (Current)
// Ik heb hier voor .NET Core gekozen.

namespace ValidatieLib
{
    public static class Validatie
    {
        private static string titel = "Foutmelding";

        public static string Titel
        {
            get { return titel; }
            set { titel = value; }
        }

        public static bool IsAanwezig(TextBox txt)
        {
            if (txt.Text.Length == 0)
            {
                // Tip: Kijk in de XAML file, we hebben daar een Tag property aan TxtIntGetal en TxtDecGetal gegeven
                MessageBox.Show(txt.Tag + " is een vereist gegeven.", Titel);
                return false;
            }
            return true;
        }

        public static bool IsInteger(TextBox txt)
        {
            bool isGelukt = int.TryParse(txt.Text, out int getal);
            if (!isGelukt)
            {
                MessageBox.Show(txt.Tag + " moet een geheel getal zijn.", Titel);
                return false;
            }
            return true;
        }

        public static bool IsDecimal(TextBox txt)
        {
            bool isGelukt = decimal.TryParse(txt.Text, out decimal getal);
            if (!isGelukt)
            {
                MessageBox.Show(txt.Tag + " moet een decimaal getal zijn.", Titel);
                return false;
            }
            return true;
        }
    }
}


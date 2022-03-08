using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Oefening_16
{
    public static class Validator
    {
        // Eigenschap wordt onmiddellijk gedeclareerd.
        public static string Title { get; set; } = "Foutmelding";

        public static bool IsPresent(string text) => (text != string.Empty);

        public static bool IsValidEmail(string text) => (text.IndexOf("@") != -1 && text.IndexOf(".") != -1);
    }
}

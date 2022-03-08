using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Oefening_06
{
    public static class Data
    {
        public static string User = null;
        // Eigenlijk gebruik je beter een Dictionary<string, string>, dit is hier sneller.
        // Dan kan je een gebruiker (key) opzoeken en dan controleren of
        // het ingegeven wachtwoord overeenkomt met wachtwoord in de dictionary (value).
        public static string[,] Wachtwoorden = new string[4, 2]
        { 
            {"Tom Quareme","1234" },
            {"Crash Bandicoot", "8765"},
            {"Pepsi Man","5678"},
            {"Alberto Vermicelli", "4321"} 
        };
    }
}

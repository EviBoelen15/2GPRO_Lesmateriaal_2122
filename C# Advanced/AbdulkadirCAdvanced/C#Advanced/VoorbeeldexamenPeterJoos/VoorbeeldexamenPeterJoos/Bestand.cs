using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoorbeeldexamenPeterJoos
{
   public class Bestand
    {
        public static string bestandnaam = "";
        public static string[] Header;

        public static DataSet dsStudent = new DataSet("StudentDb");

        public static List<Student> Data = new List<Student>();

        public Boolean OpenBestand(string titel)
        {
            return true;
        }
    }
}

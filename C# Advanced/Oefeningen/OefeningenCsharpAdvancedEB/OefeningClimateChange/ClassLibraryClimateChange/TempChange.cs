using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OefeningClimateChange.ClassLibraryClimateChange
{
    public class TempChange
    {
        public double? Change { get; set; }
        public string CountryCode { get; set;  }
        public string CountryName { get; set; }
        public int Id { get; set; }
        public int Year { get; set; }

        public TempChange(double? change, string countryCode, string countryName, int id, int year)
        {
            Change = change;
            CountryCode = countryCode;
            CountryName = countryName;
            Id = id;
            Year = year;
        }
    }
}

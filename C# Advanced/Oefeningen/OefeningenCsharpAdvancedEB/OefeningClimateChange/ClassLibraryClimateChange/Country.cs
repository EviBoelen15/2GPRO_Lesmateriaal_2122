using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OefeningClimateChange.ClassLibraryClimateChange
{
    public class Country
    {
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string ImageFilePath { get; set; }
        public string Region { get; set; }
        public string SubRegion { get; set; }

        public Country(string countryCode, string countryName, string imageFilePath, string region, string subRegion)
        {
            CountryCode = countryCode;
            CountryName = countryName;
            ImageFilePath = imageFilePath;
            Region = region;
            SubRegion = subRegion;
        }
        public override string ToString()
        {
            string str = "";
            return str;
        }
    }
}

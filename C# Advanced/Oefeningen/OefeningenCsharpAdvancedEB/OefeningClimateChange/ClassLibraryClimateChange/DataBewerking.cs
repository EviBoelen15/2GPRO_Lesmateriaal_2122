using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OefeningClimateChange.ClassLibraryClimateChange
{
    public static class DataBewerking
    {
        static DataSet climateChangeDataSet = new DataSet();
        static string COUNTRIES_FILE_NAME, COUNTRIES_TABLE_NAME, TEMP_CHANGE_FILE_NAME, TEMP_CHANGE_TABLE_NAME;

        public static void AddRowsToDataTableFromFile(DataTable dt, string fileName)
        {

        }
        public static void AddRowsToDataTableFromFile(DataTable dt, string fileName, bool isSkippingFirstLine)
        {

        }

        public static List<Country> GetCountries()
        {
            List<Country> countries = new List<Country>();
            foreach(var row in climateChangeDataSet.Tables["Country"].AsEnumerable())
            {
                string countryCode = row.Field<string>("CountryCode");
                string countryName = row.Field<string>("CountryName");
                string filePath = row.Field<string>("ImageFilePath");
                string region = row.Field<string>("Region");
                string subRegion = row.Field<string>("SubRegion");
                Country validCountry = new Country(countryCode, countryName, filePath, region, subRegion);
                countries.Add(validCountry);
            }
            return countries;
        }
        public static DataView GetCountriesDataView()
        {
            DataView dvCountries;
            if (climateChangeDataSet.Tables.Contains("Country"))
            {
                dvCountries = new DataView(climateChangeDataSet.Tables["Country"]);
                return dvCountries;
            } 
            else
            {
                return dvCountries = new DataView();
            }
        }
        public static DataView GetTempChangesDataView()
        {
            DataView cvTempChanges;
            if (climateChangeDataSet.Tables.Contains("TempChange"))
            {
                cvTempChanges = new DataView(climateChangeDataSet.Tables["TempChange"]);
                return cvTempChanges;
            }
            else
            {
                return cvTempChanges = new DataView();
            }
        }
        public static List<TempChange> GetTempChangesByCountryName(string countryName)
        {
            List<TempChange> tempChanges = new List<TempChange>();
            var query = from row in climateChangeDataSet.Tables["TempChange"].AsEnumerable()
                        let name = row.Field<string>("CountryName")
                        where name.Equals(countryName)
                        select row;

            foreach(var row in query)
            {
                string code = row.Field<string>("CountryCode");
                string naam = row.Field<string>("CountryName");
                int year = row.Field<int>("Year");
                double change = row.Field<int>("Change");
                TempChange validTempchange = new TempChange(change, code, naam, 0, year);
                tempChanges.Add(validTempchange);
            }

            return tempChanges;
        }

        public static List<TempChange> GetWorstYearAfter2000()
        {
            List<TempChange> tempChanges = new List<TempChange>();

            var query = from row in climateChangeDataSet.Tables["TempChange"].AsEnumerable()
                        let year = row.Field<int>("Year")
                        let change = row.Field<double>("Change")
                        where year > 2000 && change > 1.2f
                        select row;

            foreach(var row in query)
            {
                TempChange validTempChange = new TempChange(row.Field<double>("Change"), row.Field<string>("CountryCode"), row.Field<string>("CountryName"), row.Field<int>("Id"), row.Field<int>("Year"));
                tempChanges.Add(validTempChange);
            }

            return tempChanges;
        }
        public static DataTable InitializeCountriesDataTable()
        {
            //csv lezen
            DataTable dtCountries = new DataTable("Country");
            dtCountries.Columns.Add("CountryCode");
            dtCountries.Columns.Add("CountryName");
            dtCountries.Columns.Add("ImageFilePath");
            dtCountries.Columns.Add("Region");
            dtCountries.Columns.Add("SubRegion");

            using (StreamReader sr = new StreamReader("../../csv/Country_codes_and_flags.csv"))
            {
                while(!sr.EndOfStream)
                {
                    string readLine = sr.ReadLine();
                    string[] countryInfo = readLine.Split(',');
                    string countryCode = countryInfo[2];
                    string countryName = countryInfo[0];
                    string imageFilePath = countryInfo[1];
                    string region = countryInfo[3];
                    string subRegion = countryInfo[4];
                    dtCountries.Rows.Add(countryCode, countryName, imageFilePath, region, subRegion);
                }  
            }
            climateChangeDataSet.Tables.Add(dtCountries);
            return dtCountries;
        }
        public static DataTable InitializeTempChangeDataTable()
        {
            //csv lezen
            DataTable dtTempChanges = new DataTable("TempChange");
            dtTempChanges.Columns.Add("CountryCode");
            dtTempChanges.Columns.Add("CountryName");
            dtTempChanges.Columns.Add(new DataColumn("Year", typeof(int)));
            dtTempChanges.Columns.Add(new DataColumn("Change", typeof(double)));


            using (StreamReader sr = new StreamReader("../../csv/Temperature_change.csv"))
            {
                while(!sr.EndOfStream)
                {
                    string readLine = sr.ReadLine();
                    string[] tempInfo = readLine.Split(',');
                    string change = tempInfo[3];
                    string countryCode = tempInfo[0];
                    string countryName = tempInfo[1];
                    string year = tempInfo[2];
                    dtTempChanges.Rows.Add(countryCode, countryName, year, change);
                }
            }
            climateChangeDataSet.Tables.Add(dtTempChanges);
            return dtTempChanges;
        }
        public static void InitializeDataSet()
        {
            InitializeCountriesDataTable();
            InitializeTempChangeDataTable();
        }
    }
}

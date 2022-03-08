using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace CS_Oefening_14
{
    public partial class Lid
    {
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public string Sportcode { get; set; }
        public int Weeknr { get; set; }
        public int KampVolgnr { get; set; }

        public string NaamVolledig => $"{Naam} {Voornaam}";
        public string SportNaam => sportTabel[Sportcode].Omschrijving;
        public double KampPrijs => sportTabel[Sportcode].Prijs;
        public double TeBetalen
        {
            get
            {
                double prijs = KampPrijs;
                double percentage = 1.0;
                if (KampVolgnr >= 5)
                    percentage = 0.9; // 10% korting, dus maar 90% betalen
                else if (KampVolgnr >= 2)
                    percentage = 0.95; // 5% korting, dus maar 95% betalen

                return prijs * percentage;
            }
        }

        public string InformatieVolledig() 
            => $"{NaamVolledig,-35}{SportNaam,-15}{KampPrijs:c} - {KampVolgnr} - {TeBetalen:c}";

        public string RecordVorm() => $"{Naam, -30}{Voornaam, -30}{Weeknr}{Sportcode}{KampVolgnr}";
    }

    public partial class Lid
    {
        // Elk Lid hoeft niet apart een sportTabel of weekOverzicht in zich te hebben.
        // Eentje is genoeg, dus daarom maken we die static.
        // Namelijk 1 voor deze class Lid en niet per Lid object.
        private static Dictionary<string, Sport> sportTabel = LeesSportTabel(@"..\..\Bestanden\Sporten.txt");

        public static Dictionary<string, Sport> LeesSportTabel(string bestand)
        {
            Dictionary<string, Sport> tabel = new Dictionary<string, Sport>();
            FileInfo fi = new FileInfo(bestand);
            if (!fi.Exists)
            {
                throw new FileNotFoundException();
            }
            using (StreamReader sr = fi.OpenText())
            {
                while (!sr.EndOfStream)
                {
                    string[] velden = sr.ReadLine().Split(';');
                    Sport sport = new Sport()
                    {
                        Code = velden[0].Replace("\"", ""),
                        Omschrijving = velden[1].Replace("\"", ""),
                        Prijs = double.Parse(velden[2])
                    };
                    tabel[sport.Code] = sport;
                }
            }
            return tabel;
        }

        public static List<Lid> LeesLeden(string bestand)
        {
            FileInfo fi = new FileInfo(bestand);
            if (!fi.Exists)
            {
                throw new FileNotFoundException();
            }
            List<Lid> leden = new List<Lid>();
            using (StreamReader sr = fi.OpenText())
            {
                while (!sr.EndOfStream)
                {
                    string lijn = sr.ReadLine();
                    string volledigeCode = lijn.Substring(60, 5);
                    Lid lid = new Lid()
                    {
                        Naam = lijn.Substring(0, 30).Trim(),
                        Voornaam = lijn.Substring(30, 30).Trim(),
                        Weeknr = (int)char.GetNumericValue(volledigeCode[0]),
                        Sportcode = volledigeCode.Substring(1, 3),
                        KampVolgnr = (int)char.GetNumericValue(volledigeCode[4])
                    };
                    leden.Add(lid);
                }
            }
            return leden;
        }
    }
}

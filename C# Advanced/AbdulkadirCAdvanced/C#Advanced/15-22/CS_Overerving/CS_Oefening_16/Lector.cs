using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace CS_Oefening_16
{
    public class Lector : Persoon
    {
        public DateTime Indienst { get; set; }
        public string Statuut { get; set; }
        private string afdeling;
        public string Afdeling
        {
            get { return afdeling; }
            set { afdeling = Afdelingsnaam(value); }
        }

        private string Afdelingsnaam(string afd)
        {
            switch (afd)
            {
                case "SNE":
                    return "Systemen en netwerken";
                case "PRO":
                    return "Programmeren";
                case "IOT":
                    return "Internet of things";
                case "DVG":
                    return "Digitale vormgeving";
            }
            return "Onbekende afdeling";
        }

        protected override string InfoHeader => "Gegevens van de lector:\r\n\r\n";
        public override string Gegevens => $"{VolledigeNaam()} - {Statuut} - {Afdeling}";

        public Lector() : base()
        {
        }

        public string AfdrukIndienst() => $"{VolledigeNaam()} is in dienst sinds: {Indienst.ToShortDateString()}";
        public string AfdrukAdres() => $"{VolledigeNaam()}  {Straat} {Postcode}";

        // Eigen ToString method
        public override string ToString() 
            => (Statuut.Equals("DT")) ? "Lector is deeltijds actief" : "Lector is voltijds actief";

        public static List<Lector> LeesLectoren(string bestand)
        {
            FileInfo fi = new FileInfo(bestand);
            if (!fi.Exists)
                throw new FileNotFoundException();

            List<Lector> lectoren = new List<Lector>();
            using (StreamReader sr = fi.OpenText())
            {
                while (!sr.EndOfStream)
                {
                    string[] velden = sr.ReadLine().Split(';');
                    Lector lect = new Lector()
                    {
                        Naam = velden[0],
                        Voornaam = velden[1],
                        Geboortedatum = DateTime.Parse(velden[2]),
                        Straat = velden[3],
                        Postcode = velden[4],
                        Statuut = velden[5],
                        Afdeling = velden[6],
                        Indienst = DateTime.Parse(velden[7])
                    };
                    lectoren.Add(lect);
                }
            }
            return lectoren;
        }
    }
}

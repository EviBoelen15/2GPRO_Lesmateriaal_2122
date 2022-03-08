using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace CS_Oefening_20
{
    // Voor kleine classes is een struct efficiënter en sneller qua geheugen.
    // struct is een value type en geen reference type => moet niet gegarbagecollect worden.
    // Maar je mag ook class van mij gebruiken in plaats van struct. ;-)
    public struct HondDBItem
    {
        public string Ras { get; set; }
        public string Grootte { get; set; }
        public float LeeftijdsFactor { get; set; }
    }

    public static class HondDB
    {
        /// <summary>
        /// Leest een List<HondDBItem> uit een tekstbestand in csv-formaat.
        /// </summary>
        /// <param name="pad">Bestandspad</param>
        /// <returns>Lijst van HondDBItems</returns>
        /// <throws>FileNotFoundException</throws>
        public static List<HondDBItem> LeesHondenBestand(string pad)
        {
            FileInfo fi = new FileInfo(pad);
            if (!fi.Exists)
            {
                throw new FileNotFoundException($"Kan het bestand {pad} niet vinden.");
            }

            // List aanmaken
            List<HondDBItem> hondenlijst = new List<HondDBItem>();
            
            // Inlezen
            using (StreamReader sr = fi.OpenText())
            {
                // Bestand lezen regel per regel en toevoegen aan list
                while (!sr.EndOfStream)
                {
                    HondDBItem hond = new HondDBItem();
                    string lijn = sr.ReadLine();
                    string[] velden = lijn.Split(';'); // splits elk veld op door ;
                    hond.Ras = velden[0].Trim();
                    hond.Grootte = velden[1].Trim();
                    hond.LeeftijdsFactor = float.Parse(velden[2].Trim());

                    hondenlijst.Add(hond);
                }
            }

            return hondenlijst;
        }
    }
}

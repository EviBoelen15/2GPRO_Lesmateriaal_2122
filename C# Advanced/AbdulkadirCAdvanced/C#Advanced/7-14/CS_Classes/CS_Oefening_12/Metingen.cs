using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace CS_Oefening_12
{
    // Metingen metingen = new Meting();
    // metingen.LeesAlles(@"..\..\Bestanden\Zonnepanelen.txt");
    // metingen.LeesEnVerwerk(@"..\..\Bestanden\Zonnepanelen.txt");
    // TxtResultaat.Text = metingen.ToonResultaten();

    public class Metingen
    {
        private static readonly string[] maanden =
        {
            "Januari", "Februari", "Maart", "April", "Mei", "Juni",
            "Juli", "Augustus", "September", "Oktober", "November", "December"
        };

        private float[,] metingen;
        private float[] gemiddeldeProductiePerDag;

        public int TotaleAantalMetingen { get; private set; }
        public float GemiddeldeProductiePerDagAlgemeen { get; private set; }
        public float GemiddeldeProductiePerDagVoorMaand(int maand) => gemiddeldeProductiePerDag[maand - 1];

        public Metingen()
        {
            metingen = new float[12, 2]; // rij: maand en kolom: aantalmetingen, waarde 
            TotaleAantalMetingen = 0;
            GemiddeldeProductiePerDagAlgemeen = 0.0f;
            gemiddeldeProductiePerDag = new float[12];
        }

        public string LeesAlles(string bestand)
        {
            string resultaat;
            using (StreamReader sr = File.OpenText(bestand))
            {
                resultaat = sr.ReadToEnd();
            }
            return resultaat;
        }

        public void LeesEnVerwerk(string bestand)
        {
            using (StreamReader sr = File.OpenText(bestand))
            {
                while (!sr.EndOfStream)
                {
                    // Scheidingsteken opgeven
                    string[] velden = sr.ReadLine().Split('-');
                    // Verwerken van bestand
                    int maandIndex = int.Parse(velden[0].Substring(3, 2)) - 1; // januari = index 0
                    metingen[maandIndex, 0]++; // aantal metingen
                    metingen[maandIndex, 1] += float.Parse(velden[1]);
                    TotaleAantalMetingen++;
                }
            }

            for (int i = 0; i < metingen.GetUpperBound(0); i++)
            {
                GemiddeldeProductiePerDagAlgemeen += metingen[i, 1];
                gemiddeldeProductiePerDag[i] = (float)Math.Round(metingen[i, 1] / metingen[i, 0], 2); ;
            }

            // Gemiddelde
            GemiddeldeProductiePerDagAlgemeen /= TotaleAantalMetingen;
        }

        public string ToonResultaten()
        {
            // Afdruk
            StringBuilder sb = new StringBuilder();
            sb.Append("SAMENVATTING VAN DE METINGEN:\r\n\r\n");
            for (int i = 0; i < metingen.GetUpperBound(0); i++)
            {
                float gem = gemiddeldeProductiePerDag[i];
                sb.AppendLine($"{maanden[i], -14} - \t{metingen[i, 0], 5} metingen   -\tGemiddelde Productie per dag: {gem, 6}");
            }
            sb.AppendLine();
            sb.AppendLine($"{"Algemeen",-14} - \t­{TotaleAantalMetingen,5} metingen   -\t­Gemiddelde Productie per dag: {Math.Round(GemiddeldeProductiePerDagAlgemeen, 2),6}");
            return sb.ToString();
        }
    }
}

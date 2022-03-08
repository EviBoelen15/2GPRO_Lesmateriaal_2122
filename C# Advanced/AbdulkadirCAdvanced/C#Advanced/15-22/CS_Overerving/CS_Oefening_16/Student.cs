using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace CS_Oefening_16
{
    public class Student : Persoon
    {
        // Auto-implemented properties (zowel get als set)
        public DateTime Startdatum { get; set; }
        public char Betaald { get; set; }
        public string TypeStudent { get; set; }
        public string Opleiding { get; set; }
        private int studiepunten;
        public int Studiepunten
        {
            get { return studiepunten; }
            set
            {
                if (value < 0)
                    studiepunten = 0;
                else if (studiepunten > 99)
                    studiepunten = 99;
                else
                    studiepunten = value;
            }
        }

        // Read-­only properties (enkel get), hier als expression-bodied properties (=> notatie)
        public float Inschrijvingsbedrag => (TypeStudent.Equals("I")) ? (50.0f + (8.666667f * studiepunten)) : 520.0f;
        protected override string InfoHeader => "Gegevens van de student:\r\n\r\n"; // eigen implementatie (override)
        public override string Gegevens => $"{VolledigeNaam()} - {TypeStudent} - {Betaald} - {Inschrijvingsbedrag:c}"; // eigen implementatie (override)

        public Student() : base() // constructor van de base class eerst oproepen
        {
            // daarna doe ik dit:
            Startdatum = DateTime.Now; 
        }

        // Expression-bodied methods (=> notatie om te returnen)
        public string AfdrukStartdatum() => $"{VolledigeNaam()} | {Startdatum}"; 
        public string AfdrukAdres() => $"{VolledigeNaam()}  {Straat} {Postcode}";

        // Eigen ToString methode
        // Elk object erft over van de class "object".
        // object heeft een virtual method ToString() die we kunnen overriden met onze eigen implementatie
        public override string ToString()
            =>
                $"{Voornaam} {Naam} "
                +
                ((TypeStudent.Equals("I"))
                    ? $"Student met individueel traject: {Studiepunten} SP"
                    : $"Standaardstudent: 60 SP")
                +
                $"- Inschrijvingsgeld: {Inschrijvingsbedrag:c} : Betaald: {Betaald}";
       

        public static List<Student> LeesStudenten(string bestand)
        {
            FileInfo fi = new FileInfo(bestand);
            if (!fi.Exists)
                throw new FileNotFoundException();

            List<Student> studenten = new List<Student>();
            using (StreamReader sr = fi.OpenText())
            {
                while (!sr.EndOfStream)
                {
                    string[] velden = sr.ReadLine().Split(';');
                    Student stud = new Student()
                    {
                        Naam = velden[0],
                        Voornaam = velden[1],
                        Straat = velden[2],
                        Postcode = velden[3],
                        Betaald = velden[4][0], // dit is 1 char, dus 0de char van string is genoeg
                        Opleiding = velden[5],
                        TypeStudent = velden[6]
                    };

                    if (stud.TypeStudent.Equals("I"))
                        stud.Studiepunten = int.Parse(velden[7]);
                    
                    studenten.Add(stud);
                }
            }

            return studenten;
        }
    }
}

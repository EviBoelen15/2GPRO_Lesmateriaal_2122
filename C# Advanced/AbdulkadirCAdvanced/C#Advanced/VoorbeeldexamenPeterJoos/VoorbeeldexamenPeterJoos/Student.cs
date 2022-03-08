using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoorbeeldexamenPeterJoos
{
    public class Student : Initialiseren, IStudentVak
    {
        public string Voornaam { get; set; }
        public string Naam { get; set; }
        public string VakCode { get; set; }
        public DataTable DtStudent { get; set; }

        public override string ToString()
        {
            string result = string.Empty;
            switch (VakCode)
            {
                case "PRO":
                    result = $"{Voornaam} {Naam.ToUpper()} - {VakCode.ToUpper()} (programmeren)";
                    break;
                case "SNE":
                    result = $"{Voornaam} {Naam.ToUpper()} - {VakCode.ToUpper()} (systemen en netwerken)";
                    break;
                case "DVG":
                    result = $"{Voornaam} {Naam.ToUpper()} - {VakCode.ToUpper()} (digitale vormgeving)";
                    break;
                case "IOT":
                    result = $"{Voornaam} {Naam.ToUpper()} - {VakCode.ToUpper()} (internet of things)";
                    break;
            }
            return result;
        }

        public Student(String[] StudGeg)
        {
            Initialiseer();
            if (StudGeg.Length > 2)
            {
                Voornaam = StudGeg[0];
                Naam = StudGeg[1];
                VakCode = StudGeg[2];
                VoegRijToe();
            }
        }
        public void VoegRijToe()
        {
            DataRow dr = DtStudent.NewRow();
            dr["Voornaam"] = Voornaam;
            dr["Naam"] = Naam;
            dr["VakCode"] = VakCode;
            DtStudent.Rows.Add(dr);
        }

        public void Initialiseer()
        {
            string TableName = "StudentenLijst";

            if (Bestand.dsStudent.Tables.Contains(TableName))
            {
                DtStudent = Bestand.dsStudent.Tables[TableName];
            }
            else
            {
                DtStudent = new DataTable(TableName);
                DtStudent.Columns.Add("Voornaam", typeof(string));
                DtStudent.Columns.Add("Naam", typeof(string));
                DtStudent.Columns.Add("VakCode", typeof(string));
                Bestand.dsStudent.Tables.Add(DtStudent);
            }
        }
    }
}

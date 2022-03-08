using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoorbeeldexamenPeterJoos
{
   public class Vak : Initialiseren, IStudentVak
    {
        public DataTable DtVak { get; set; }
        public string Code { get; set; }
        public string Omschrijving { get; set; }
        public Vak()
        {
            Initialiseer();
            VoegRijToe();
        }

        public void VoegRijToe()
        {
            DataRow dr = DtVak.NewRow();
            dr["PRO"] = "Programmeren";
            dr["SNE"] = "Systeem en netwerken";
            dr["DGV"] = "Digitale vormgeving";
            dr["IOT"] = "Internet of things";
            DtVak.Rows.Add(dr);
        }
        public void Initialiseer()
        {
            string TableName = "Vaklijst";

            if (Bestand.dsStudent.Tables.Contains(TableName))
            {
                DtVak = Bestand.dsStudent.Tables[TableName];
            }
            else
            {
                DtVak = new DataTable(TableName);
                DtVak.Columns.Add("PRO", typeof(string));
                DtVak.Columns.Add("SNE", typeof(string));
                DtVak.Columns.Add("DGV", typeof(string));
                DtVak.Columns.Add("IOT", typeof(string));
                Bestand.dsStudent.Tables.Add(DtVak);
            }
        }
    }
}

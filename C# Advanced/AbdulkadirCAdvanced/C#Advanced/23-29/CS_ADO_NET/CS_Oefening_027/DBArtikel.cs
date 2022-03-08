using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CS_Oefening_027
{
    public static class DBArtikel
    {
        public static void ArtikelUitCategorie(DataSet ds, int catid)
        {
            try
            {
                using (SqlConnection sqlcn = DBConnect.MaakConnectie())
                {
                    sqlcn.Open();

                    // SqlDataAdapter object om DataSet te vullen
                    SqlDataAdapter daArtikel = new SqlDataAdapter("ArtikelUitCategorie", sqlcn);

                    // Door het CommandType van het SelectCommand van de SqlDataAdapter
                    // geven we aan dat we met een Stored Procedure gaan werken
                    // voor het vullen van de DataSet
                    daArtikel.SelectCommand.CommandType = CommandType.StoredProcedure;

                    // Parameter voor de Stored Procedure invoegen
                    daArtikel.SelectCommand.Parameters.AddWithValue("@CatID", catid);

                    // In de DataSet de tabel "Artikel" vullen
                    ds.Tables["Artikel"].Clear();
                    daArtikel.Fill(ds, "Artikel");
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}

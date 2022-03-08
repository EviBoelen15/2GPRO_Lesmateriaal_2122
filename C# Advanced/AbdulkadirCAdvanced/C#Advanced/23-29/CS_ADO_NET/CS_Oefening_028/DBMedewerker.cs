using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace CS_Oefening_028
{
    public static class DBMedewerker
    {
        public static Medewerker ZoekMedewerker(int mnrID)
        {
            try
            {
                using (SqlConnection sqlcn = DBConnect.MaakConnectie())
                {
                    sqlcn.Open();
                    string query = @"select mnr, naam, voorn, functie, 
                                chef, gbdatum, maandsal, comm, afd
                                from medewerkers
                                where mnr = @mnrID";
                    SqlCommand cmd = new SqlCommand(query, sqlcn);
                    cmd.Parameters.AddWithValue("@mnrID", mnrID);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read()) // Er wordt maar 1 rij gereturned, dus if in plaats van while is genoeg
                    {
                        Medewerker medewerker = new Medewerker();
                        medewerker.MnrID = reader.GetInt16(0);
                        medewerker.Naam = reader.GetString(1);
                        medewerker.Voornaam = reader.GetString(2);
                        medewerker.Functie = (reader[3] == DBNull.Value) ? "" : reader.GetString(3); // kan NULL zijn
                        medewerker.Chef = (reader[4] == DBNull.Value) ? 0 : reader.GetInt16(4); // kan NULL zijn
                        medewerker.GebDatum = reader.GetDateTime(5);
                        // float in MS SQL Server is standaard 53 bits
                        // float in C# is 32 bits, dus niet genoeg.
                        // double in C# is 64 bits, dus genoeg.
                        // Gebruik dus GetDouble() in plaats van GetFloat()
                        // Nadien casten we terug naar float via (float), want de properties zijn floats.
                        medewerker.Maandsalaris = (float)reader.GetDouble(6);
                        medewerker.Comm = (reader[7] == DBNull.Value) ? 0 : (float)reader.GetDouble(7); // kan NULL zijn
                        medewerker.Afdeling = (reader[8] == DBNull.Value) ? 0 : reader.GetInt16(8); // kan NULL zijn
                        return medewerker;
                    }
                    else
                    {
                        throw new ApplicationException("Geen medewerker gevonden met dit nummer. Probeer aub opnieuw.");
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}

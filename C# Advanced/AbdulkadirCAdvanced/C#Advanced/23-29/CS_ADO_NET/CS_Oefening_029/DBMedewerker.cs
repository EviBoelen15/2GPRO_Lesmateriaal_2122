using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace CS_Oefening_029
{
    public static class DBMedewerker
    {
        public static string IDNaarNaam(int mnrID)
        {
            string naam = null;
            try
            {
                using (SqlConnection sqlcn = DBConnect.MaakConnectie())
                {
                    sqlcn.Open();
                    string query = @"select naam from medewerkers where mnr = @mnr";

                    SqlCommand cmd = new SqlCommand(query, sqlcn);
                    cmd.Parameters.AddWithValue("@mnr", mnrID);

                    naam = (string)cmd.ExecuteScalar(); // 1 waarde terugkrijgen
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return naam;
        }

        public static int ToevoegenMedewerker(Medewerker medewerker)
        {
            try
            {
                using (SqlConnection sqlcn = DBConnect.MaakConnectie())
                {
                    sqlcn.Open();
                    string insertString = @"insert into medewerkers(mnr, naam, voorn, functie, chef, gbdatum, maandsal, comm, afd)
                    values (@mnr, @naam, @voorn, @functie, @chef, @gbdatum, @maandsal, @comm, @afd)";
                    SqlCommand cmd = new SqlCommand(insertString, sqlcn);
                    cmd.Parameters.AddWithValue("@mnr", medewerker.MnrID);
                    cmd.Parameters.AddWithValue("@naam", medewerker.Naam);
                    cmd.Parameters.AddWithValue("@voorn", medewerker.Voornaam);
                    cmd.Parameters.AddWithValue("@functie", medewerker.Functie);
                    cmd.Parameters.AddWithValue("@chef", medewerker.Chef);
                    cmd.Parameters.AddWithValue("@gbdatum", medewerker.GebDatum);
                    cmd.Parameters.AddWithValue("@maandsal", medewerker.Maandsalaris);
                    cmd.Parameters.AddWithValue("@comm", medewerker.Comm);
                    cmd.Parameters.AddWithValue("@afd", medewerker.Afdeling);

                    cmd.ExecuteNonQuery(); // geen query maar commando => cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return 1;
        }

        public static bool UpdateMedewerker(Medewerker medewerker)
        {
            try
            {
                using (SqlConnection sqlcn = DBConnect.MaakConnectie())
                {
                    sqlcn.Open();
                    string updateString = @"update medewerkers 
                    set naam = @naam, 
                    voorn = @voorn,
                    functie = @functie,
                    chef = @chef,
                    gbdatum = @gbdatum,
                    maandsal = @maandsal,
                    comm = @comm,
                    afd = @afd
                    where mnr = @mnr";

                    SqlCommand cmd = new SqlCommand(updateString, sqlcn);
                    cmd.Parameters.AddWithValue("@mnr", medewerker.MnrID);
                    cmd.Parameters.AddWithValue("@naam", medewerker.Naam);
                    cmd.Parameters.AddWithValue("@voorn", medewerker.Voornaam);
                    cmd.Parameters.AddWithValue("@functie", medewerker.Functie);
                    cmd.Parameters.AddWithValue("@chef", medewerker.Chef);
                    cmd.Parameters.AddWithValue("@gbdatum", medewerker.GebDatum);
                    cmd.Parameters.AddWithValue("@maandsal", medewerker.Maandsalaris);
                    cmd.Parameters.AddWithValue("@comm", medewerker.Comm);
                    cmd.Parameters.AddWithValue("@afd", medewerker.Afdeling);

                    cmd.ExecuteNonQuery(); // geen query maar commando => cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return true;
        }

        public static bool VerwijderMedewerker(int mnrID)
        {
            try
            {
                using (SqlConnection sqlcn = DBConnect.MaakConnectie())
                {
                    sqlcn.Open();
                    string deleteString = @"delete from medewerkers where mnr = @mnr";

                    SqlCommand cmd = new SqlCommand(deleteString, sqlcn);
                    cmd.Parameters.AddWithValue("@mnr", mnrID);

                    cmd.ExecuteNonQuery(); // geen query maar commando => cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return true;
        }

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace CS_Oefening_026
{
    public static class KlantDB
    {
        public static List<Klant> LaadKlanten(string connectionString)
        {
            List<Klant> klanten = new List<Klant>();

            using (SqlConnection sqlcn = new SqlConnection(connectionString))
            {
                sqlcn.Open();
                string query = "select * from Klant";
                SqlCommand cmd = new SqlCommand(query, sqlcn);
                // SqlDataReader gebruiken we om elke rij (record) te inspecteren
                // Dankzij using wordt de SqlDataReader automatisch gesloten!
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // SqlDataReader gebruiken we om elke rij (record) te inspecteren
                    while (reader.Read())
                    {
                        // Let op dat je de juiste types neemt die overeenkomen met SQL server:
                        Klant klant = new Klant()
                        {
                            ID = reader.GetInt32(0),
                            Naam = reader.GetString(1),
                            Voornaam = reader.GetString(2),
                            Woonplaats = reader.GetString(3),
                            Geboortedatum = reader.GetDateTime(4),
                            Gebruikersnaam = reader[5].ToString(), // kan null zijn
                            Wachtwoord = reader[6].ToString() // kan null zijn
                        };
                        klanten.Add(klant);
                    }
                }
            }
            return klanten;
        }

        public static void AddKlant(Klant klant, string connectionString)
        {
            using (SqlConnection sqlcn = new SqlConnection(connectionString))
            {
                sqlcn.Open();
                string insertString = @"insert into Klant(Naam, Voornaam, Woonplaats, Geboortedatum, Gebruikersnaam, Pwd)
                    values (@naam, @voornaam, @woonplaats, @geboortedatum, @gebruikersnaam, @password)";

                SqlCommand cmd = new SqlCommand(insertString, sqlcn);
                cmd.Parameters.AddWithValue("@naam", klant.Naam);
                cmd.Parameters.AddWithValue("@voornaam", klant.Voornaam);
                cmd.Parameters.AddWithValue("@woonplaats", klant.Woonplaats);
                cmd.Parameters.AddWithValue("@geboortedatum", klant.Geboortedatum);
                cmd.Parameters.AddWithValue("@gebruikersnaam", klant.Gebruikersnaam);
                cmd.Parameters.AddWithValue("@password", klant.Wachtwoord);
                cmd.ExecuteNonQuery(); // geen query maar commando => cmd.ExecuteNonQuery();
                sqlcn.Close();
            }
        }

        public static void UpdateKlant(Klant klant, string connectionString)
        {
            using (SqlConnection sqlcn = new SqlConnection(connectionString))
            {
                sqlcn.Open();

                string updateString = @"update Klant 
                    set Naam = @naam, Voornaam = @voornaam, Woonplaats = @woonplaats, Geboortedatum = @geboortedatum,
                    Gebruikersnaam = @gebruikersnaam, Pwd = @password
                    where Klant_id = @id";
                SqlCommand updateCmd = new SqlCommand(updateString, sqlcn);
                updateCmd.Parameters.AddWithValue("@naam", klant.Naam);
                updateCmd.Parameters.AddWithValue("@voornaam", klant.Voornaam);
                updateCmd.Parameters.AddWithValue("@woonplaats", klant.Woonplaats);
                updateCmd.Parameters.AddWithValue("@geboortedatum", klant.Geboortedatum);
                updateCmd.Parameters.AddWithValue("@gebruikersnaam", klant.Gebruikersnaam);
                updateCmd.Parameters.AddWithValue("@password", klant.Wachtwoord);
                updateCmd.Parameters.AddWithValue("@id", klant.ID);
                updateCmd.ExecuteNonQuery();
            }
        }

        public static void DeleteKlant(int id, string connectionString)
        {
            using (SqlConnection sqlcn = new SqlConnection(connectionString))
            {
                sqlcn.Open();

                string deleteString = @"delete from Klant where Klant_id = @id";
                SqlCommand deleteCmd = new SqlCommand(deleteString, sqlcn);
                deleteCmd.Parameters.AddWithValue("@id", id);
                deleteCmd.ExecuteNonQuery();
            }
        }
    }
}

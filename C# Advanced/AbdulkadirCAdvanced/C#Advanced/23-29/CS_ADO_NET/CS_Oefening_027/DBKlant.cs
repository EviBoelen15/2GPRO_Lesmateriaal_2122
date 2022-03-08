using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace CS_Oefening_027
{
    public static class DBKlant
    {
        public static List<Klant> SelecteerKlanten(string woonplaats)
        {
            List<Klant> klanten = new List<Klant>();
            try
            {
                using (SqlConnection sqlcn = DBConnect.MaakConnectie())
                {
                    sqlcn.Open();

                    // Een parameter pakt niet wanneer hij binnen '' staat in een SQL query.
                    // Daarom doe ik ('%' + @woonplaats + '%') in plaats van '%@woonplaats%' !!!
                    string query = @"select Klant_id, Naam, Voornaam
                                from Klant
                                where Woonplaats like ('%' + @woonplaats + '%')
                                order by Klant_id asc";
                    SqlCommand cmd = new SqlCommand(query, sqlcn);
                    cmd.Parameters.AddWithValue("@woonplaats", woonplaats);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Klant klant = new Klant()
                            {
                                ID = reader.GetInt32(0),
                                Naam = reader.GetString(1),
                                Voornaam = reader.GetString(2)
                            };
                            klanten.Add(klant);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return klanten;
        }
    }
}

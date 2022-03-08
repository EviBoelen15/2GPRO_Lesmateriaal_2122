using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CS_Oefening_027
{
    public static class DBCategorie
    {
        public static List<Categorie> SelecteerAlleCategories()
        {
            List<Categorie> resultaat = new List<Categorie>();
            try
            {
                using (SqlConnection sqlcn = DBConnect.MaakConnectie())
                {
                    sqlcn.Open();
                    // Eerste letter in hoofdletter, overige letters in kleine letters
                    string query = @"select Cat_id, 
                                UPPER(SUBSTRING(Categorie, 1, 1)) +  
                                LOWER(SUBSTRING(Categorie, 2, LEN(Categorie))) 
                                from Categorie;";
                    SqlCommand cmd = new SqlCommand(query, sqlcn);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            resultaat.Add(new Categorie((short)reader.GetInt32(0), reader.GetString(1)));
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return resultaat;
        }
    }
}

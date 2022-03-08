using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace CS_Oefening_029
{
    public static class DBConnect
    {
        public static SqlConnection MaakConnectie()
        {
            return new SqlConnection(Properties.Settings.Default.CNstr);
        }
    }
}

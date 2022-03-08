using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Oefening_028
{
    public static class DBConnect
    {
        public static SqlConnection MaakConnectie()
        {
            return new SqlConnection(Properties.Settings.Default.CNstr);
        }
    }
}

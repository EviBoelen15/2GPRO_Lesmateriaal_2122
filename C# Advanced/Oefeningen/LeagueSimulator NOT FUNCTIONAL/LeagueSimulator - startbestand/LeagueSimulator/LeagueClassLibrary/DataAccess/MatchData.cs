using LeagueSimulator.LeagueClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueSimulator.LeagueClassLibrary.DataAccess
{
    class MatchData
    {
        private DataTable DataTableMatches = new DataTable();

        public void InitializeDataTableMatches()
        {

        }
        public void AddFinishedMatch(Match match)
        {

        }
        public DataView GetDataViewMatches()
        {
            DataView dt = new DataView();
            return dt;
        }
        public void ExportToXML()
        {

        }
        public bool IsUniqueCode(string code)
        {
            return false;
        }
    }
}

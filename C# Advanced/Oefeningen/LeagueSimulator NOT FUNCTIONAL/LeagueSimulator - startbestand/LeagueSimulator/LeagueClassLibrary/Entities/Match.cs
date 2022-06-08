using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueSimulator.LeagueClassLibrary.Entities
{
    abstract class Match : IWinnable
    {
        List<Champion> Team1Champions { get; set; }
        List<Champion> Team2Champions { get; set; }
        public int Winner { get; set; }
        public string Code { get; set; }

        public Match(string code)
        {

        }

        public void DecideWinner()
        {
            
        }

        public abstract void GenereerTeams();
    }
}

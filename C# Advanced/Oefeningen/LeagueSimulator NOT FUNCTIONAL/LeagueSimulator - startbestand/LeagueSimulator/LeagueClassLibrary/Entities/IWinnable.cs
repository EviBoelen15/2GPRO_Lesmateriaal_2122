using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueSimulator.LeagueClassLibrary.Entities
{
    interface IWinnable
    {
        int Winner { get; set; }
        void DecideWinner();
    }
    
}

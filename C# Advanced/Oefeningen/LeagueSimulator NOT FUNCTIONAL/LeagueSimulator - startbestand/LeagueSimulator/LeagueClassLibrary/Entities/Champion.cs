using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueSimulator.LeagueClassLibrary.Entities
{
    class Champion
    {
        string Name { get; set; }
        string Title { get; set; }
        string ChampionClass { get; set; }
        int ReleaseYear { get; set; }
        List<Ability> Abilities { get; set; }
        List<string> Positions { get; set; }
        string IconSource { get; set; }
        string BannerSource { get; set; }
        int CostIP { get; set; }
        int CostRP { get; set; }

        public Champion(string name, string title, string championClass, int releaseYear, List<Ability> abilities, List<string> positions, string iconSource, string bannerSource, int costIP, int costRP)
        {
            Name = name;
            Title = title;
            ChampionClass = championClass;
            ReleaseYear = releaseYear;
            Abilities = abilities;
            Positions = positions;
            IconSource = iconSource;
            BannerSource = bannerSource;
            CostIP = costIP;
            CostRP = costRP;
        }

        public string GetCost()
        {
            string str = "";
            return str;
        }
        public override string ToString()
        {
            string str = "";
            return str;
        }
    }
}

using LeagueSimulator.LeagueClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueSimulator.LeagueClassLibrary.DataAccess
{
    static class AbilityData
    {
        private static List<Ability> Abilities = new List<Ability>();
        static int indexAbility = 0;
        public static void LoadCSV(string pathToCSV)
        {
            using (StreamReader sr = new StreamReader(pathToCSV))
            {
                string line = sr.ReadLine();
                string[] abilityInfo = line.Split(';');
                Abilities.Add(new Ability(indexAbility, abilityInfo[0], abilityInfo[1]));
                indexAbility++;
            }
        }
        public static List<Ability> GetAbilitiesByChampionName(string championName)
        {
            var queryAbility = from a in Abilities
                               where a.ChampionName == championName
                               select a;

            return queryAbility.ToList();
        }
    }
}

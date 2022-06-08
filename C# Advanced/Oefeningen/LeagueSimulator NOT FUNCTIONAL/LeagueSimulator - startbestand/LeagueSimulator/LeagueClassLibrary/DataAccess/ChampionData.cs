using LeagueSimulator.LeagueClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LeagueSimulator.LeagueClassLibrary.DataAccess
{
    static class ChampionData
    {
        private static DataTable DataTableChampions { get; set; }
        private static Random r;

        public static void LoadCSV(string pathToCSV)
        {
            MakeDataTable();
            FillTable(pathToCSV);
        }
        private static void MakeDataTable()
        {
            DataTableChampions.Columns.Add("ChampionName");
            DataTableChampions.Columns.Add("ChampionTitle");
            DataTableChampions.Columns.Add("ChampionClass");
            DataTableChampions.Columns.Add("ReleaseYear");
            DataTableChampions.Columns.Add("ChampionPosition1");
            DataTableChampions.Columns.Add(new DataColumn { ColumnName = "ChampionPosition2", DataType = typeof(string), AllowDBNull = true });
            DataTableChampions.Columns.Add(new DataColumn { ColumnName = "ChampionPosition3", DataType = typeof(string), AllowDBNull = true });
            DataTableChampions.Columns.Add("ChampionIcon");
            DataTableChampions.Columns.Add("ChampionBanner");
            DataTableChampions.Columns.Add("RPCost");
            DataTableChampions.Columns.Add("IPCost");
        }
        private static void FillTable(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string line = sr.ReadLine();
                string[] championInfo = line.Split(';');
                DataTableChampions.Rows.Add(championInfo[0], championInfo[1], championInfo[2], championInfo[3],
                                            championInfo[4], championInfo[5], championInfo[6], championInfo[7],
                                            championInfo[8], championInfo[9], championInfo[10]);
                /*
                string champName= championInfo[0];
                string champTitle = championInfo[1];
                string champClass = championInfo[2];
                string champYear = championInfo[3];
                string champPos1 = championInfo[4];
                string champPos2 = championInfo[5];
                string champPos3 = championInfo[6];
                string icon = championInfo[7];
                string banner = championInfo[8];
                string rpCost = championInfo[9];
                string ipCost = championInfo[10];
                */

            }
        }

        public static DataView GetDataViewChampion()
        {
            DataView dv = new DataView(DataTableChampions);
            return dv;
        }
        public static DataView GetDataViewChampionByPosition(string position)
        {
            DataTable dtPosChamps = new DataTable();
            foreach (var row in DataTableChampions.AsEnumerable())
            {
                if (row.Field<string>(2).Equals(position))
                {
                    dtPosChamps.Rows.Add(row.Field<string>(0), row.Field<string>(1), row.Field<string>(2),
                                        row.Field<int>(3), row.Field<string>(4), row.Field<string>(5),
                                        row.Field<string>(6), row.Field<string>(7), row.Field<string>(8),
                                        row.Field<int>(9), row.Field<int>(10));
                }
            }
            DataView dv = new DataView(dtPosChamps);
            return dv;
        }
        public static DataView GetDataViewChampionByBestToWorst()
        {
            DataView dt = new DataView();
            return dt;
        }
        public static Champion GetRandomChampionByPosition(string position)
        {
            string name = "";
            string title ="";
            string championClass="";
            int year = 0;
            string pos1 = "";
            string pos2 = "";
            string pos3 = "";
            string icon = "";
            string banner = "";
            int rp = 0;
            int lp = 0;

            List<Ability> abilities = new List<Ability>();
            List<string> positions = new List<string>();


            position = r.Next(0, 5).ToString();

            DataTable dtRandomPosChamps = new DataTable();

            foreach (var row in DataTableChampions.AsEnumerable())
            {
                name = row.Field<string>(0);
                title = row.Field<string>(1);
                championClass = row.Field<string>(2);
                year = row.Field<int>(3);
                pos1 = row.Field<string>(4);
                pos2 = row.Field<string>(5);
                pos3 = row.Field<string>(6);
                icon = row.Field<string>(7);
                banner = row.Field<string>(8);
                rp = row.Field<int>(9);
                lp = row.Field<int>(10);

                if (row.Field<string>(2).Equals(position))
                {
                    dtRandomPosChamps.Rows.Add(name, title, championClass, year, pos1, pos2, pos3, icon, banner, rp, lp);

                    abilities = AbilityData.GetAbilitiesByChampionName(name);
                    positions = new List<string>();

                    positions.Add(pos1);
                    positions.Add(pos2);
                    positions.Add(pos3);

                    
                }
            }
            Champion cp = new Champion(name, title, championClass, year, abilities, positions, icon, banner, rp, lp);
            return cp;

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Oefening_027
{
    public class Categorie
    {
        public short CatID { get; set; }
        public string Naam { get; set; }

        public Categorie(short catID, string naam)
        {
            CatID = catID;
            Naam = naam;
        }

        public override string ToString() => Naam;
    }
}

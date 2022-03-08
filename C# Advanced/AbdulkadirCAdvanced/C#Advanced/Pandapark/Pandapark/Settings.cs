using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandapark
{
    public static class Settings
    {
        // Een static property waarvan we de getter aanpassen. 
        // Verder is het read-only, dus we hebben geen setter nodig.
        public static string AnimalCSV { get { return "diereninventaris.csv"; } }
    }
}

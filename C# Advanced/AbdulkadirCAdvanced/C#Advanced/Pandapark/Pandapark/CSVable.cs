using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandapark
{
    /// <summary>
    /// Deze interface verklaart dat er een manier is om de klasse om te zetten
    /// naar een csv string.
    /// </summary>
    interface CSVable
    {
        string ToCSV();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Oefening_20
{
    public interface IOuderdom
    {
        // Classes die de interface IOuderdom implementeren,
        // moeten de properties Ouderdom en Naam hebben.
        float Ouderdom { get; }
        string Naam { get; }
    }
}

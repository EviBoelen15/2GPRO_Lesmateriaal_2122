using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoorbeeldInterfaceBoomPersoon
{
	public interface IOuderdom
	{
		// Klassen die de interface IOuderdom implementeren, moeten de eigenschappen Ouderdom en Naam hebben.
		int Ouderdom { get; }
		string Naam { get; }
	}
}

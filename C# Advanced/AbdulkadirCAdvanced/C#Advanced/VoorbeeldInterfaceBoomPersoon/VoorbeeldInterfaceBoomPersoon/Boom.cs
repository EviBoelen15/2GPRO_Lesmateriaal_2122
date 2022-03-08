using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoorbeeldInterfaceBoomPersoon
{
	public class Boom : IOuderdom
	{
		// Instantievariabelen.
		private int ringen;
		private string soort;

		// Constructor.
		public Boom(string type, int plantjaar)
		{
			ringen = DateTime.Now.Year - plantjaar;
			soort = type;
		}

		// Property Ouderdom - implementatie van interface
		public int Ouderdom => ringen;

		// Property Naam - implementatie van interface
		public string Naam => "Boom: " + soort;

	}
}

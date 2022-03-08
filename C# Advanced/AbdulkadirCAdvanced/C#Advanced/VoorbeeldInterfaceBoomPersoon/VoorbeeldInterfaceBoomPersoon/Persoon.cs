using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoorbeeldInterfaceBoomPersoon
{
	public class Persoon : IOuderdom
	{
		// Instantievariabelen.
		private int geboortejaar;
		private string voornaam;
		private string naam;

		// Constructor.
		public Persoon(string firstName, string familyName, int yearOfBirth)
		{
			voornaam = firstName;
			naam = familyName;
			geboortejaar = yearOfBirth;
		}

		// Property Ouderdom - implementatie van interface
		public int Ouderdom => DateTime.Now.Year - geboortejaar;

		// Property Naam - implementatie van interface
		public string Naam => voornaam + " " + naam;

	}
}

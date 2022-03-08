using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandapark
{
    public class Mammal : Animal
    {
        // Deze property is read-only, we kunnen de setter weglaten.
        // De waarde wordt berekend obv de DayOfBirth van het dier.
        public bool IsInfant
        {
            get
            {
                return DateTime.Now - DayOfBirth <= TimeSpan.FromDays(365);
            }
        }

        // Constructor chaining helpt ons om minder duplicate code te schrijven.
        public Mammal(string name, string type, bool isDangerous, string diet, 
            string gender, DateTime dayOfBirth, string country) : 
            base(name, type, isDangerous, diet, gender, dayOfBirth, country)
        {
        }

        public Mammal(string csv) : base(csv) { }

        // Om aan te geven dat het een zoogdier is start de regel met een "M".
        public override string ToCSV()
        {
            return $"M;{base.ToCSV()}";
        }

        public override string Describe()
        {
            string infantText = "";
            if (IsInfant)
            {
                infantText = "is een jonge zuigeling en ";
            }

            return $"{Name} de {Type} {infantText}vermaakt zich fantastisch in {ZijnOfHaar} persoonlijke habitat " +
                    $"die aangepast is om te lijken op {ZijnOfHaar} thuisland, {Country}.";
        }
    }
}

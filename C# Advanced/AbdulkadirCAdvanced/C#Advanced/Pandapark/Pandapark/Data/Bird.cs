using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandapark
{
    public class Bird : Animal
    {
        public string NestType { get; set; }
        public double WingSpan { get; set; }

        public Bird() { }

        // Constructor chaining helpt ons om minder duplicate code te schrijven.
        public Bird(string name, string type, bool isDangerous, string diet,
            string gender, DateTime dayOfBirth, string country,
            string nestType, double wingSpan) :
            base(name, type, isDangerous, diet, gender, dayOfBirth, country)
        {
            NestType = nestType;
            WingSpan = wingSpan;
        }

        public Bird(string csv) : base(csv)
        {
            string[] values = csv.Split(';');
            NestType = values[8];
            WingSpan = Convert.ToDouble(values[9]);
        }

        // Er zijn meer properties om weg te schrijven, dus de methode moet overschreven worden.
        public override string ToCSV()
        {
            return $"B;{base.ToCSV()};{NestType};{WingSpan}";
        }

        public override string Describe()
        {
            return $"{Name} de {Type} vermaakt zich fantastisch in {ZijnOfHaar} {NestType.ToLower()} waar " +
                    $"{HijOfZij} rond vliegt met met {ZijnOfHaar} vleugels met een spanwijdte van {WingSpan} cm.";
        }
    }
}

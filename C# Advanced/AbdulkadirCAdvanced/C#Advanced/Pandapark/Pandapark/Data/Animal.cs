using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandapark
{
    public abstract class Animal : CSVable
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsDangerous { get; set; }
        public string Diet { get; set; }
        public string Gender { get; set; }
        public DateTime DayOfBirth { get; set; }
        public string Country { get; set; }

        protected string ZijnOfHaar
        {
            get 
            {
                if (this.Gender.Equals("Mannelijk"))
                {
                    return "zijn";
                }
                return "haar";
            }
        }

        protected string HijOfZij
        {
            get
            {
                if (this.Gender.Equals("Mannelijk"))
                {
                    return "hij";
                }
                return "zij";
            }
        }

        public Animal() { }

        public Animal(string name, string type, bool isDangerous, string diet, 
            string gender, DateTime dayOfBirth, string country)
        {
            Name = name;
            Type = type;
            IsDangerous = isDangerous;
            Diet = diet;
            Gender = gender;
            DayOfBirth = dayOfBirth;
            Country = country;
        }

        public Animal(string csv)
        {
            string[] values = csv.Split(';');
            Name = values[1];
            Type = values[2];
            IsDangerous = Convert.ToBoolean(values[3]);
            Diet = values[4];
            Gender = values[5];
            DayOfBirth = Convert.ToDateTime(values[6]);
            Country = values[7];
        }

        // Wanneer de methode virtual is kunnen we de implementatie overschrijven indien nodig (zoals bij Bird).
        public virtual string ToCSV()
        {
            return $"{Name};{Type};{IsDangerous};{Diet};{Gender};{DayOfBirth};{Country}";
        }

        public abstract string Describe();
    }
}

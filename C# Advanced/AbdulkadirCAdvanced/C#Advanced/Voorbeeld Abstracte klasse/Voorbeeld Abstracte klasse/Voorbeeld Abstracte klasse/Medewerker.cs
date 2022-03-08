namespace Voorbeeld_Abstracte_klasse
{
    public abstract class Medewerker
    {
            private double bruto;

            // De klasse Werknemer is een abstracte klasse.
            public string Voornaam { get; set; }
            public string Naam { get; set; }
            public double Uurloon { get; set; }
            public double UrenGewerkt { get; set; }
            public double Bruto() => bruto;

            // Constructor. 
            public Medewerker(string firstName, string familyName, double salary) // Bedienden
            {
                Voornaam = firstName;
                Naam = familyName;
                bruto = salary;
            }

            public Medewerker(string firstName, string familyName, double hourlyWage, double hours)   // Arbeiders
            {
                Voornaam = firstName;
                Naam = familyName;
                bruto = hourlyWage * hours;
            }
        
           

            // Abstracte methode.
            public abstract double RSZ();
            public abstract double BV();
            public abstract double Netto();
    }
}


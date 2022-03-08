using System;

using System.Linq; // LINQ gebruiken

using Pandapark; // Gebruik code uit andere namespace

namespace CS_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            // Oefening 1a
            // Druk al de woorden af in de array tekst, die langer zijn dan tienkarakters.
            var query1a =
                from t in LinqOef.Tekst
                where t.Length > 10
                select t;

            // Hetzelfde maar in method syntax
            var query1aMethod = LinqOef.Tekst.Where(t => t.Length > 10);

            Console.WriteLine("Oefening 1a");
            foreach (var item in query1a)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            // -----------------------------------------------------------------
            // Oefening 1b
            // Bereken het gemiddelde voor de getallen in de list driehoek die
            // groter zijn dan 100.
           double gemiddelde1b =
                (from g in LinqOef.Driehoek
                 where g > 100
                 select g).Average();

            // Hetzelfde maar in method syntax
            double gemiddelde1bMethod = LinqOef.Driehoek.Where(g => g > 100).Average();

            Console.WriteLine("Oefening 1b");
            Console.WriteLine($"Gemiddelde: {gemiddelde1b:n2} of in method syntax: {gemiddelde1bMethod:n2}");
            Console.WriteLine();

            // -----------------------------------------------------------------
            // Oefening 1c
            // Druk al de unieke getallen af uit de List driehoek
            var query1c =
                (from g in LinqOef.Driehoek
                select g).Distinct();

            // Hetzelfde maar in method syntax
            var query1cMethod = LinqOef.Driehoek.Distinct();

            Console.WriteLine("Oefening 1c");
            foreach (var item in query1c)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            // -----------------------------------------------------------------
            // Oefening 1d
            // Druk alle unieke getallen af uit de List, driehoek,
            // die deelbaar zijn door drie of vijf. De getallen worden in een
            // oplopende volgorde afgedrukt.
            var query1d =
                (from g in LinqOef.Driehoek
                 where g % 3 == 0 || g % 5 == 0
                 orderby g ascending
                 select g).Distinct();

            // Hetzelfde maar in method syntax
            var query1dMethod = LinqOef.Driehoek
                .Where(g => (g % 3 == 0 || g % 5 == 0))
                .OrderBy(g => g)
                .Distinct();

            Console.WriteLine("Oefening 1d");
            foreach (var item in query1dMethod)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            // -----------------------------------------------------------------
            // Oefening 1e
            // Druk de woorden uit de array, tekst, af in een aflopende volgorde
            // op basis van lengte. Verder zijn woorden met dezelfde lengte gesorteerd
            // op een oplopende alfabetische volgorde.

            var query1e =
                from t in LinqOef.Tekst
                orderby t.Length descending, t ascending // eerst op basis van lengte aflopend, dan alfab. oplopend
                select t;

            // Hetzelfde maar in method syntax
            // Let op, hier moeten we wel een andere volgorde gebruiken!!!
            // Dit toont aan dat in methodsyntax eerst de staart wordt uitgevoerd (laatste method eerst)
            var query1eMethod = LinqOef.Tekst
                .OrderBy(t => t)
                .OrderByDescending(t => t.Length);

            Console.WriteLine("Oefening 1e");
            foreach (var item in query1eMethod)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();


            // -----------------------------------------------------------------
            // Oefening 1f
            // Maak een groep op basis van de startletter van ieder woord voor
            // al de woorden in de array, tekst
            var query1f =
                from woord in LinqOef.Tekst
                orderby woord
                group woord by woord[0] into woordGroep
                select woordGroep;

            // Hetzelfde maar in method syntax
            var query1fMethod = LinqOef.Tekst
                .OrderBy(woord => woord)
                .GroupBy(woord => woord[0]);

            Console.WriteLine("Oefening 1f");
            foreach (var groep in query1fMethod)
            {
                Console.WriteLine($"{groep.Key}:");
                foreach (var woord in groep)
                {
                    Console.Write($"{woord} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            // -----------------------------------------------------------------
            // Oefening 1g
            // Vind alle paren van getallen en woorden waar de lengte van het woord
            // uit de array, tekst, gelijk is aan een getal uit de List, driehoek.
            // Druk het alle gevonden paren af.
            var query1g =
                (from woord in LinqOef.Tekst
                join getal in LinqOef.Driehoek
                on woord.Length equals getal
                select (woord, getal)); // tuple

            // Hetzelfde maar in method syntax
            var query1gMethod = LinqOef.Tekst
                .Join(LinqOef.Driehoek, 
                    woord => woord.Length, 
                    getal => getal, 
                    (woord, getal) => (woord, getal));

            Console.WriteLine("Oefening 1g");
            foreach (var tuple in query1gMethod)
            {
                Console.WriteLine($"{tuple.getal}, {tuple.woord}");
            }
            Console.WriteLine();

            // -----------------------------------------------------------------
            // Oefening 1h
            // Maak een uitbreiding op de vorige oefening die ervoor zorgt dat
            // elk woord slechts één maal voorkomt in de resulterende paren.
           var query1h =
                (from woord in LinqOef.Tekst
                 join getal in LinqOef.Driehoek
                 on woord.Length equals getal
                 select (woord, getal)).Distinct(); // tuple

            // Hetzelfde maar in method syntax
            var query1hMethod = LinqOef.Tekst
                .Join(LinqOef.Driehoek,
                    woord => woord.Length,
                    getal => getal,
                    (woord, getal) => (woord, getal))
                .Distinct();

            Console.WriteLine("Oefening 1h");
            foreach (var tuple in query1hMethod)
            {
                Console.WriteLine($"{tuple.getal}, {tuple.woord}");
            }
            Console.WriteLine();


            // -----------------------------------------------------------------
            // Oefening 1i
            // Druk alle woorden af uit de array, tekst,
            // die minstens drie klinkers bevatten.
            var query1i =
                (from woord in LinqOef.Tekst
                where 
                    (from letter in woord
                    where letter == 'a' || letter == 'e' || letter == 'i' || letter == 'o' || letter == 'u'
                    select letter).Count() >= 3
                select woord);

            // Hetzelfde maar in method syntax
            var query1iMethod = LinqOef.Tekst
                .Where(woord => 
                    (woord.Where(
                        letter => (letter == 'a' || letter == 'e' || letter == 'i' || letter == 'o' || letter == 'u')))
                    .Count() >= 3);

            Console.WriteLine("Oefening 1i");
            foreach (var woord in query1iMethod)
            {
                Console.WriteLine(woord);
            }
            Console.WriteLine();


            // -----------------------------------------------------------------
            // Oefening 3a
            // Wat zijn de namen van de magazijnen in Berchem?
            var query3a =
                from warehouse in LinqOef.Warehouses
                where warehouse.City.Equals("Berchem")
                select warehouse.BuildingName;

            // Hetzelfde maar in method syntax
            var query3aMethod = LinqOef.Warehouses
                .Where(w => w.City.Equals("Berchem"))
                .Select(w => w.BuildingName);

            Console.WriteLine("Oefening 3a");
            foreach (var naam in query3aMethod)
            {
                Console.WriteLine(naam);
            }
            Console.WriteLine();


            // -----------------------------------------------------------------
            // Oefening 3b
            // Wat zijn de namen en steden van al de magazijnen geordend (vanhoog naar laag)
            // op meeste ratings van hun werknemers?
            var query3b =
                from warehouse in LinqOef.Warehouses
                orderby warehouse.EmployeeSatisfactionRating.Count descending
                select (warehouse.BuildingName, warehouse.City);

            // Hetzelfde maar in method syntax
            var query3bMethod = LinqOef.Warehouses
                .OrderByDescending(w => w.EmployeeSatisfactionRating.Count)
                .Select(w => (w.BuildingName, w.City));

            Console.WriteLine("Oefening 3b");
            foreach (var paar in query3bMethod)
            {
                Console.WriteLine($"{paar.BuildingName}, { paar.City}");
            }
            Console.WriteLine();


            // -----------------------------------------------------------------
            // Oefening 3c
            // Wat zijn de volledige namen en id van al de werknemers alfabetisch
            // geordend op hun achternaam? (a tot z)
            var query3c =
                from employee in LinqOef.Employees
                orderby employee.LastName ascending
                select (employee.FirstName, employee.LastName, employee.ID);

            // Hetzelfde maar in method syntax
            var query3cMethod = LinqOef.Employees
                .OrderBy(employee => employee.LastName)
                .Select(employee => (employee.FirstName, employee.LastName, employee.ID));

            Console.WriteLine("Oefening 3c");
            foreach (var tuple in query3cMethod)
            {
                Console.WriteLine($"{tuple.FirstName} {tuple.LastName}, id: {tuple.ID}");
            }
            Console.WriteLine();


            // -----------------------------------------------------------------
            // Oefening 3d
            // Rangschik al de magazijnen van hoog naar laag op basis van
            // gemiddelde rating.
            var query3d =
                from warehouse in LinqOef.Warehouses
                // let: declareer read-only variabele om herberekening te vermijden
                let AvgRating = warehouse.EmployeeSatisfactionRating.Average()
                orderby AvgRating descending
                select (warehouse.BuildingName, AvgRating);

            // Hetzelfde maar in method syntax
            // Zoals je ziet worden lambda expressies voor ingewikkeldere queries minder praktisch...
            // Je gebruikt dus beter method syntax enkel voor korte queries!
            // Ik heb hier een tuple gemaakt dat bestaat uit een string voor de BuildingName
            // en een double AvgRating waar ik de gemiddelde rating in opsla om vervolgens
            // te gebruiken in de OrderByDescending() method.
            // Dit is best veel werk... Gemakkelijker hier is: query syntax!
            var query3dMethod = LinqOef.Warehouses
                .Select(warehouse => (BuildingName: warehouse.BuildingName, AvgRating: warehouse.EmployeeSatisfactionRating.Average()))
                .OrderByDescending(tuple => tuple.AvgRating);

            Console.WriteLine("Oefening 3d");
            foreach (var tuple in query3dMethod)
            {
                Console.WriteLine($"{tuple.BuildingName}, gemiddelde rating: {tuple.AvgRating:n2}");
            }
            Console.WriteLine();

            // -----------------------------------------------------------------
            // Oefening 3e
            // Wat zijn de magazijnen met postcode onder 4000 gegroepeerd per stad?
            var query3e =
                from warehouse in LinqOef.Warehouses
                where warehouse.PostCode < 4000
                group warehouse by warehouse.City into warehouseGroup
                select warehouseGroup;

            // Hetzelfde maar in method syntax
            var query3eMethod = LinqOef.Warehouses
                .Where(warehouse => (warehouse.PostCode < 4000))
                .GroupBy(warehouse => warehouse.City);

            Console.WriteLine("Oefening 3e");
            foreach (var warehouseGroup in query3eMethod)
            {
                Console.WriteLine($"Stad: {warehouseGroup.Key}");
                foreach (var warehouse in warehouseGroup)
                {
                    Console.Write($"\t{warehouse.BuildingName}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();


            // -----------------------------------------------------------------
            // Oefening 3f
            // Wat zijn de volledige namen van de werknemers die werken voor
            // een magazijn met een opslagcapaciteit groter dan 2000?
            // Vermeld ook de naam en capaciteit van het magazijn.
            var query3f =
                from warehouse in LinqOef.Warehouses
                // Ik zet where voor de join om eerst al te filteren (sneller)
                // Maar dit kan ook al geoptimaliseerd worden door de compiler.
                where warehouse.StorageCapacity > 2000 
                join employee in LinqOef.Employees
                on warehouse.WarehouseID equals employee.WarehouseID
                select (employee.FirstName, employee.LastName, warehouse.BuildingName, warehouse.StorageCapacity);

            // Hetzelfde maar in method syntax
            // Joins zijn veel moeilijker te begrijpen in lambda expressies...
            // Ook hier is query syntax dus duidelijker!
            var query3fMethod = LinqOef.Warehouses
                .Where(warehouse => (warehouse.StorageCapacity > 2000))
                .Join(LinqOef.Employees, 
                warehouse => warehouse.WarehouseID,
                employee => employee.WarehouseID, 
                (warehouse, employee) => (employee.FirstName, employee.LastName, warehouse.BuildingName, warehouse.StorageCapacity));

            Console.WriteLine("Oefening 3f");
            foreach (var tuple in query3f)
            {
                Console.WriteLine($"{tuple.FirstName} {tuple.LastName}, {tuple.BuildingName}, {tuple.StorageCapacity}m²");
            }
            Console.WriteLine();


            // -----------------------------------------------------------------
            // Oefening 3g
            // Wat zijn de id’s en voornamen van werknemers die een achternaam
            // delen met een andere werknemer van het magazijn?
            var query3g =
                from employee in LinqOef.Employees
                group employee by employee.LastName into employeeGroup
                where employeeGroup.Count() >= 2
                from employee in employeeGroup
                select (employee.ID, employee.FirstName);


            // Ook hier weer is method syntax moeilijker op te stellen.
            // Lambda expressies worden ingewikkelder...
            // We slaan dit over.
            Console.WriteLine("Oefening 3g");
            foreach (var tuple in query3g)
            {
                Console.WriteLine($"id: {tuple.ID}, voornaam: {tuple.FirstName}");
            }
            Console.WriteLine();


            // -----------------------------------------------------------------
            // Oefening 3h
            // Wat zijn de voornamen van de werknemers die werken voor een magazijn
            // met een opslagcapaciteit die groter is dan 5000.
            // Vermeld ook de volledige locatie (stad, postcode, straat, huisnummer)
            // van het magazijn.
            var query3h =
                from warehouse in LinqOef.Warehouses
                where warehouse.StorageCapacity > 5000
                join employee in LinqOef.Employees
                on warehouse.WarehouseID equals employee.WarehouseID
                select (employee.FirstName, warehouse.City, warehouse.PostCode, warehouse.Street, warehouse.HouseNumber);

            // Hetzelfde maar in method syntax
            // Joins zijn veel moeilijker te begrijpen in lambda expressies...
            // Ook hier is query syntax dus duidelijker!
            var query3hMethod = LinqOef.Warehouses
                .Where(warehouse => warehouse.StorageCapacity > 5000)
                .Join(LinqOef.Employees,
                    warehouse => warehouse.WarehouseID,
                    employee => employee.WarehouseID,
                    (warehouse, employee) => 
                        (employee.FirstName, warehouse.City, warehouse.PostCode, warehouse.Street, warehouse.HouseNumber));

            Console.WriteLine("Oefening 3h");
            foreach (var tuple in query3hMethod)
            {
                Console.WriteLine($"{tuple.FirstName}, {tuple.City}, {tuple.PostCode}, {tuple.Street}, {tuple.HouseNumber}");
            }
            Console.WriteLine();


            // -----------------------------------------------------------------
            // Oefening 3i
            // Groepeer de werknemers per straat van het magazijn waarvoor ze werken.
            var query3i =
                (from warehouse in LinqOef.Warehouses
                join employee in LinqOef.Employees
                on warehouse.WarehouseID equals employee.WarehouseID
                group warehouse by warehouse.Street into warehouseGroup
                    from warehouse in warehouseGroup
                    from employee in LinqOef.Employees
                    where employee.WarehouseID ==  warehouse.WarehouseID
                    orderby warehouse.Street ascending
                    select (employee.FirstName, employee.LastName, warehouse.Street)).Distinct();

            // Hetzelfde maar in method syntax
            // Joins zijn veel moeilijker te begrijpen in lambda expressies...
            // Ook hier is query syntax dus duidelijker!
            // We slaan bijgevolg deze manier over.

            Console.WriteLine("Oefening 3i");
            foreach (var tuple in query3i)
            {
                Console.WriteLine($"{tuple.Street}: {tuple.FirstName} {tuple.LastName}");
            }
            Console.WriteLine();

            Console.ReadLine(); // om console open te houden totdat ik op Enter druk
        }
    }
}

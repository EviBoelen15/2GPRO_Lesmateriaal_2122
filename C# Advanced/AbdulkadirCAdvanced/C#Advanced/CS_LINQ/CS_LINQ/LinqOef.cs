using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandapark
{
    public class Warehouse
    {
        public string BuildingName { get; set; }
        public int WarehouseID { get; set; }
        public string City { get; set; }
        public int PostCode { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public int StorageCapacity { get; set; }
        public List<int> EmployeeSatisfactionRating { get; set; }

        public Warehouse(string buildingName, int id, string city, 
            int postCode, string street, int nr, int storageCapacity, List<int> rating)
        {
            BuildingName = buildingName;
            WarehouseID = id;
            City = city;
            PostCode = postCode;
            Street = street;
            HouseNumber = nr;
            StorageCapacity = storageCapacity;
            EmployeeSatisfactionRating = rating;
        }
    }

    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ID { get; set; }
        public int WarehouseID { get; set; }

        public Employee(string firstName, string lastName,
            int id, int warehouseID)
        {
            FirstName = firstName;
            LastName = lastName;
            ID = id;
            WarehouseID = warehouseID;
        }
    }

    public static class LinqOef
    {
        public static List<int> Driehoek = new List<int>()
        {
            1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,
            1,   2,   3,   4,   5,   6,   7,   8,   9,   10,
            1,   3,   6,   10,  15,  21,  28,  36,  45,
            1,   4,   10,  20,  35,  56,  84,  120,
            1,   5,   15,  35,  70,  126, 210,
            1,   6,   21,  56,  126, 252,
            1,   7,   28,  84,  210,
            1,   8,   36,  120,
            1,   9,   45,
            1,   10,
            1
        };

        public static string[] Tekst = new string[]
        {
            "langspeelfilm", "vluchtmisdrijf", "dovemansgesprek", "containerpark",
            "confituur", "inox", "valavond", "enerverend", "lopen", "bank", "vieruurtje",
            "waterzooi", "maaltijdcheque", "arrondissement", "eindtermen", "nieuwjaarsbrief"
        };

        public static List<Warehouse> Warehouses = new List<Warehouse>
        {
            new Warehouse("Brug4", 0, "Arendonk", 2370, "Holstraat", 14, 3000, new List<int>{ 4, 3, 1, 5 }),
            new Warehouse("Brug1", 1, "Arendonk", 2370, "Holstraat", 3, 8000, new List<int>{ 1, 4, 3, 5, 2, 3, 3, 4, 4}),
            new Warehouse("Poort1", 2, "Gent", 9000, "Stropkaai", 12, 7000, new List<int>{ 5, 4, 3, 4 , 4}),
            new Warehouse("Rijsteller", 3, "Hasselt", 3500, "Industrielaan", 1, 2500, new List<int>{ 5, 4, 3, 5, 2, 3, 4, 4}),
            new Warehouse("Automa klein", 4, "Berchem", 2600, "Nieuwevaart", 77, 10000, new List<int>{ 4 }),
            new Warehouse("Schuifla", 5, "Hasselt", 3500, "Industrielaan", 15, 1500, new List<int>{ 3, 5, 2 }),
            new Warehouse("Automa groot", 6, "Berchem", 2600, "Nieuwevaart", 76, 30000, new List<int>{ 5 }),
            new Warehouse("Brug2", 7, "Arendonk", 2370, "Molenweg", 7, 3000, new List<int>{ 4, 3, 5, 2 }),
            new Warehouse("Veerhal", 8, "Melle", 9090, "Merelstraat", 48, 500, new List<int>{ 5, 5 }),
            new Warehouse("Poort2", 9, "Gent", 9000, "Burgstraat", 113, 6600, new List<int>{ 1, 2, 1, 1, 2, 3}),
            new Warehouse("D1", 10, "Knokke", 8300, "Vaart", 2, 2200, new List<int>{ 5, 4, 1 }),
            new Warehouse("Brug3", 11, "Arendonk", 2370, "Molenweg", 8, 8000, new List<int>{ 5, 2, 3, 5, 5 }),
            new Warehouse("D2", 12, "Knokke", 8300, "Vaart", 4, 2200, new List<int>{ 2, 3, 4 }),
            new Warehouse("D3", 13, "Knokke", 8300, "Vaart", 6, 2200, new List<int>{ 3, 4, 3 })
        };

        public static List<Employee> Employees = new List<Employee>
        {
            new Employee("Jos", "Jansen", 0, 1),
            new Employee("Ted", "Bériault", 1, 0),
            new Employee("Tony", "Hawk", 2, 3),
            new Employee("Peggy", "Corona", 3, 12),
            new Employee("Edna", "Goosen", 4, 0),
            new Employee("Mac", "Kowalski", 5, 11),
            new Employee("Alejandro", "Mendoza", 6, 8),
            new Employee("Aysha", "Lyon", 7, 7),
            new Employee("Tyson", "Dyer", 8, 4),
            new Employee("Nanou", "Hahn", 9, 6),
            new Employee("Kevin", "Hahn", 10, 5),
            new Employee("Kris", "Jacobsen", 11, 1),
            new Employee("Boros", "Orzsebet", 12, 2),
            new Employee("Buday", "Gedeon", 13, 2),
            new Employee("Szölôsi", "Taksony", 14, 1),
            new Employee("Kocsis", "Gyula", 15, 8),
            new Employee("Asif", "Atiyeh", 16, 7),
            new Employee("Ruwayd", "Akram", 17, 13),
            new Employee("Makary", "Sobczak", 18, 12),
            new Employee("Pawel", "Symanski", 19, 1),
            new Employee("Settimio", "Calabresi", 20, 10),
            new Employee("Ivo", "Bellucci", 21, 7),
            new Employee("Matthieu", "Camus", 22, 9),
            new Employee("Jacques", "Huard", 23, 8),
            new Employee("Melville", "Bériault", 24, 4),
            new Employee("René", "Michaud", 25, 9)
        };
    }
}

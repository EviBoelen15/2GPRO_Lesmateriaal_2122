using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Interfaces
{
    public interface IVliegend
    {
        string Vlieg();
    }

    public interface IRijdend
    {
        string Rij();
    }

    public class Vogel : IVliegend
    {
        public string Vlieg()
        {
            return "Ik heb vleugels";
        }
    }

    public class Auto : IRijdend
    {
        public string Rij() => "Ik heb wielen";
    }

    public class MagischeAuto : IVliegend, IRijdend
    {
        public string Rij()
        {
            return "Ik kan magisch rijden";
        }

        public string Vlieg()
        {
            return "Ik kan magisch vliegen";
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Auto auto = new Auto();
            MagischeAuto magischeAuto = new MagischeAuto();

            List<IRijdend> rijdendeVoertuigen = new List<IRijdend>();

            rijdendeVoertuigen.Add(auto);
            rijdendeVoertuigen.Add(magischeAuto);

            foreach (var rv in rijdendeVoertuigen)
            {
                Console.WriteLine(rv.Rij());
            }
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Oefening
{
    public class Teller
    {
        public int Counter { get; set; }

        public Teller()
        {
            Counter = 0;
        }

        public void CounterNegatiefMaken()
        {
            Counter = -Counter;
        }

        public void ResetTeller()
        {
            Counter = 0;
        }

        public void VerhoogTeller()
        {
            Counter++;
        }

        public void VerminderTeller()
        {
            Counter--;
        }

        public void Waarde(int waarde)
        {
            Counter += waarde;
        }

        /*
        public override string ToString()
        {
            return Counter.ToString();
        }
        */

        public override string ToString() => Counter.ToString();
    }
}

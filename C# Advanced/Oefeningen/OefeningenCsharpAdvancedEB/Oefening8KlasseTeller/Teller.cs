using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefening8KlasseTeller
{
    class Teller
    {
        public int Counter { get; set; }

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
        public void Waarde(int getal)
        {
            Counter += getal;
        }

    }
}

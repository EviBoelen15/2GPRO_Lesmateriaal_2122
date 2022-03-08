using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Oefening_21
{
    public interface IBankrekening
    {
        // Properties van interface zijn automatisch public.
        // Je moet er geen modifier (public) voor zetten!!!
        // Een class die "overerft" van deze interface moet
        // voor ALLE properties van de interface een implementatie voorzien.
        // Het keyword override is niet nodig bij overerven van interface.
        double Saldo { get; }
        string Naam { get; set; }
        string Rekeningnummer { get; }

        // Methods van interface zijn automatisch public.
        // Je moet er geen modifier (public) voor zetten!!!
        // Een class die "overerft" van deze interface moet
        // voor ALLE methods van de interface een implementatie voorzien.
        // Het keyword override is niet nodig bij overerven van interface.
        void Storting(double bedrag);
        void Opname(double bedrag);
    }
}

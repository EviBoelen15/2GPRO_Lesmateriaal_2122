using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Oefening_19
{
    // Met behulp van een generic type T kunnen
    // we de interface hergebruiken voor eender welk type.
    // T kan zijn: int, string, char, float, eender welke class,...
    public interface Modules<T>
    {
        // Zie ook de methods van de IList<T> interface in System.Collections.Generic
        // voor meer inspiratie:
        // https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ilist-1?view=net-5.0#methods
        //
        void Add(T item);
        int IndexOf(T item);
        bool Remove(T item);
    }
}

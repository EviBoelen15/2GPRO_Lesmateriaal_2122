using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Oefening_21
{
    public class BankException : ApplicationException
    {
        public BankException() : base()
        {
        }

        public BankException(string message) : base(message)
        {
        }
    }
}

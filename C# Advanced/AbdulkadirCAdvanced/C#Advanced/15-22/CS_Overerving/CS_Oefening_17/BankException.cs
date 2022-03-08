using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Oefening_17
{
    // BankException is een eigen class die overerft van ApplicationException
    // Vermits dat onze eigen BankException overerft van ApplicationException,
    // kunnen we die exception gaan gooien met throw new BankException();
    // En we kunnen die nadien opvangen met een try catch.
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

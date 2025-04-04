using System;

namespace SPG_Fachtheorie.Aufgabe1.Exceptions
{
    public class PaymentServiceException : Exception
    {
        public PaymentServiceException(string message) : base(message)
        {
        }
    }
}

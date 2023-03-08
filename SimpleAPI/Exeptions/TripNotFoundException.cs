using System;
using System.Globalization;


namespace SimpleAPI
{
    public class TripNotFoundException : Exception
    {
        public TripNotFoundException() : base() { }

        public TripNotFoundException(string message) : base(message) { }

        public TripNotFoundException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}

using System;

namespace KMACSharp04Hak.Exceptions
{
    internal class BirthDateInLongPastException : Exception
    {
        public BirthDateInLongPastException() { }
        public BirthDateInLongPastException(DateTime date) : base("Error. Date in long past picked: " + date.ToShortDateString()) { }
        public BirthDateInLongPastException(DateTime date, Exception inner) : base("Error. Date in long past picked: " + date.ToShortDateString(), inner) { }
    }
}
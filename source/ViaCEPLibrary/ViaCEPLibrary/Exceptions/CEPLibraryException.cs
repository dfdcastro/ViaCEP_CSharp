using System;

namespace CEPLibrary.Exceptions
{
    public class CEPLibraryException : Exception
    {        
        public CEPLibraryException()
        {
        }

        public CEPLibraryException(string message)
            : base(message)
        {
        }

        public CEPLibraryException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}

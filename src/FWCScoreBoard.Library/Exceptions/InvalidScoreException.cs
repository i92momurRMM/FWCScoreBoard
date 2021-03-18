using System;

namespace FWCScoreBoard.Library.Exceptions
{
    public class InvalidScoreException
        : Exception
    {
        public InvalidScoreException(string message)
            : base(message)
        {
        }
    }
}
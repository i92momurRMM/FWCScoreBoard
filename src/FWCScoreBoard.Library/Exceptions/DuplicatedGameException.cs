using System;

namespace FWCScoreBoard.Library.Exceptions
{
    public class DuplicatedGameException
        : Exception
    {
        public DuplicatedGameException(string message)
            : base(message)
        {
        }
    }
}
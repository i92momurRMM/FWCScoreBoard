using System;

namespace FWCScoreBoard.Library.Exceptions
{
    public class InvalidTeamException
        : Exception
    {
        public InvalidTeamException(string message)
            : base(message)
        {
        }
    }
}
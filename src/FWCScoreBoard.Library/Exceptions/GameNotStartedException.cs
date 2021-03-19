using System;

namespace FWCScoreBoard.Library.Exceptions
{
    public class GameNotStartedException
        : Exception
    {
        public GameNotStartedException(string message)
            : base(message)
        {
        }
    }
}
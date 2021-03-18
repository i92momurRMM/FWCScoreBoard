using System;

namespace FWCScoreBoard.Library.Domain
{
	public class Game
	{
		public Guid Id { get; }
		public DateTime StartDate { get; }

		public Game(Guid id)
		{
			Id = id;
			StartDate = DateTime.UtcNow;
		}
	}
}

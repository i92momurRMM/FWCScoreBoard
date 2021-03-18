using System;

namespace FWCScoreBoard.Library.Domain
{
	public class Game
	{
		public Guid Id { get; }

		public Game(Guid id)
		{
			Id = id;
		}
	}
}

using System;
using FWCScoreBoard.Library.Domain;

namespace FWCScoreBoard.Library.Services
{
	public class GamesBoardService
	{
		public GamesBoardService()
		{

		}

		public Guid StartGame(string homeTeam, string awayTeam)
		{
			var game = new Game ( Guid.NewGuid() );
			game.AddHomeTeam(homeTeam);
			game.AddAwayTeam(awayTeam);

			return game.Id;
		}
	}
}


using System;
using FWCScoreBoard.Library.Domain;
using FWCScoreBoard.Library.Repository;

namespace FWCScoreBoard.Library.Services
{
	public class GamesBoardService
	{
		private readonly IGamesRepository _gamesRepository;

		public GamesBoardService(IGamesRepository gamesRepository)
		{
			_gamesRepository = gamesRepository;
		}

		public Guid StartGame(string homeTeam, string awayTeam)
		{
			var game = new Game ( Guid.NewGuid() );
			game.AddHomeTeam(homeTeam);
			game.AddAwayTeam(awayTeam);

			_gamesRepository.AddGame(game);

			return game.Id;
		}
	}
}


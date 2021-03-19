using System;
using System.Collections.Generic;
using System.Linq;
using FWCScoreBoard.Library.Domain;
using FWCScoreBoard.Library.Exceptions;
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

			var games = _gamesRepository.GetGames();
			IsDuplicatedGame(game, games);

			_gamesRepository.AddGame(game);

			return game.Id;
		}

		public void FinishGame(Guid id)
		{
			_gamesRepository.RemoveGame(id);
		}

		#region validations and specifications in the service
		private void IsDuplicatedGame(Game game, IEnumerable<Game> games)
		{
			if (games.Where(w => w.HomeTeam == game.HomeTeam && w.AwayTeam == game.AwayTeam).Count() > 0)
				throw new DuplicatedGameException($"Invalid game {game.HomeTeam} - {game.AwayTeam}. It already on score board");
		}
		#endregion
	}
}


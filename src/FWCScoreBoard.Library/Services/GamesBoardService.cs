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
			var game = _gamesRepository.GetGame(id);

			IsStartedGame(id, game);

			_gamesRepository.RemoveGame(id);
		}

		public void UpdateScore(Guid id, int homeTeamScore, int awayTeamScore)
		{
			var game = _gamesRepository.GetGame(id);

			IsStartedGame(id, game);

			game.AddHomeTeamScore(homeTeamScore);
			game.AddAwayTeamScore(awayTeamScore);

			_gamesRepository.UpdateGame(id, game);
		}

		public IEnumerable<string> GetSummary()
		{
			var games = _gamesRepository.GetGames();
			return SettingGamesSummaryFormat(games);
		}

		#region validations and specifications in the service
		private void IsDuplicatedGame(Game game, IEnumerable<Game> games)
		{
			if (games.Where(w => w.HomeTeam == game.HomeTeam && w.AwayTeam == game.AwayTeam).Count() > 0)
				throw new DuplicatedGameException($"Invalid game {game.HomeTeam} - {game.AwayTeam}. It already on score board");
		}

		private void IsStartedGame(Guid id, Game game)
		{
			if (game == null || game.Id != id)
				throw new GameNotStartedException($"Invalid game {id}. It doesn't exist on score board");
		}

		private IEnumerable<string> SettingGamesSummaryFormat(IEnumerable<Game> games)
		{
			return games.OrderByDescending(o => o.HomeTeamScore + o.AwayTeamScore)
						.ThenByDescending(o => o.StartDate)
						.Select(s => s.GetSummary());
		}
		#endregion
	}
}


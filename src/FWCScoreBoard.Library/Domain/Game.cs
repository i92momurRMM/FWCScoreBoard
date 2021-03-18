using System;
using FWCScoreBoard.Library.Exceptions;

namespace FWCScoreBoard.Library.Domain
{
	public class Game
	{
		public Guid Id { get; }
		public DateTime StartDate { get; }
		public string HomeTeam { get; private set; }
		public string AwayTeam { get; private set; }
		public int HomeTeamScore { get; private set; }
		public int AwayTeamScore { get; private set; }

		public Game(Guid id)
		{
			Id = id;
			StartDate = DateTime.UtcNow;
		}

		public void AddHomeTeam(string homeTeam)
		{
			if (String.IsNullOrEmpty(homeTeam))
				throw new InvalidTeamException($"Invalid team code {homeTeam}. It must be not null and empty");

			HomeTeam = homeTeam;
		}

		public void AddAwayTeam(string awayTeam)
		{
			AwayTeam = awayTeam;
		}
	}
}

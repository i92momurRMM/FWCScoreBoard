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
		private string Summary => $"{HomeTeam} {HomeTeamScore} - {AwayTeam} {AwayTeamScore}";

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
			if (String.IsNullOrEmpty(awayTeam))
				throw new InvalidTeamException($"Invalid team code {awayTeam}. It must be not null and empty");

			AwayTeam = awayTeam;
		}

		public void AddHomeTeamScore(int homeTeamScore)
		{
			if (homeTeamScore < 0)
				throw new InvalidScoreException($"Invalid score {homeTeamScore}. It must be greater than or equal to zero");

			HomeTeamScore = homeTeamScore;
		}

		public void AddAwayTeamScore(int awayTeamScore)
		{
			if (awayTeamScore < 0)
				throw new InvalidScoreException($"Invalid score {awayTeamScore}. It this must be greater than or equal to zero");

			AwayTeamScore = awayTeamScore;
		}

		public string GetSummary()
		{
			return Summary;
		}
	}
}

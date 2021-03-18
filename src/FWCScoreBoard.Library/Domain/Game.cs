using System;

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
			HomeTeam = homeTeam;
		}
	}
}

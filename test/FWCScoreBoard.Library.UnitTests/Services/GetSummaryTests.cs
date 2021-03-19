using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Moq;
using FluentAssertions;
using FWCScoreBoard.Library.Services;
using FWCScoreBoard.Library.Repository;
using FWCScoreBoard.Library.Domain;
using FWCScoreBoard.Library.UnitTests.TestSupport;

namespace FWCScoreBoard.Library.UnitTests.Services
{
	public static class GetSummaryTests
	{
		public class Given_Multiple_Games_When_Requesting_Summary
			: Given_When_Then_Test
		{
			private GamesBoardService _sut;
			private Mock<IGamesRepository> _gamesRepositoryMock;
			private IEnumerable<string> _gameReports;

			protected override void Given()
			{
				_gamesRepositoryMock = new Mock<IGamesRepository>();
				_gamesRepositoryMock
					.Setup(x => x.GetGames())
					.Returns(ReturnGamesList());

				_sut = new GamesBoardService(_gamesRepositoryMock.Object);
			}

			protected override void When()
			{
				_gameReports = _sut.GetSummary();
			}

			[Fact]
			public void Then_It_Should_Use_The_GamesRepository()
			{
				_gamesRepositoryMock.Verify(x => x.GetGames());
			}

			private List<Game> ReturnGamesList()
			{
				var game1 = new Game(Guid.NewGuid());
				game1.AddHomeTeam("Mexico");
				game1.AddAwayTeam("Canada");
				game1.AddHomeTeamScore(0);
				game1.AddAwayTeamScore(5);

				var game2 = new Game(Guid.NewGuid());
				game2.AddHomeTeam("Spain");
				game2.AddAwayTeam("Brazil");
				game2.AddHomeTeamScore(10);
				game2.AddAwayTeamScore(2);

				var game3 = new Game(Guid.NewGuid());
				game3.AddHomeTeam("Germany");
				game3.AddAwayTeam("France");
				game3.AddHomeTeamScore(2);
				game3.AddAwayTeamScore(2);

				var game4 = new Game(Guid.NewGuid());
				game4.AddHomeTeam("Uruguay");
				game4.AddAwayTeam("Italy");
				game4.AddHomeTeamScore(6);
				game4.AddAwayTeamScore(6);

				var game5 = new Game(Guid.NewGuid());
				game5.AddHomeTeam("Argentina");
				game5.AddAwayTeam("Australia");
				game5.AddHomeTeamScore(3);
				game5.AddAwayTeamScore(1);

				return new List<Game> { game1, game2, game3, game4, game5};
			}
		}
	}
}


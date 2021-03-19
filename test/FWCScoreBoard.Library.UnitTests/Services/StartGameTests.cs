using System;
using System.Collections.Generic;
using Xunit;
using Moq;
using FluentAssertions;
using FWCScoreBoard.Library.Services;
using FWCScoreBoard.Library.Domain;
using FWCScoreBoard.Library.Repository;
using FWCScoreBoard.Library.UnitTests.TestSupport;
using FWCScoreBoard.Library.Exceptions;

namespace FWCScoreBoard.Library.UnitTests.Services
{
	public static class StartGameTests
	{
		public class Given_A_Game_When_Adding_Valid_Teams
			: Given_When_Then_Test
		{
			private GamesBoardService _sut;
			private Mock<IGamesRepository> _gamesRepositoryMock;
			private string _homeTeam;
			private string _awayTeam;
			private Guid _startedGameId;

			protected override void Given()
			{
		    	_homeTeam = "Mexico";
				_awayTeam = "Canada";

				_gamesRepositoryMock = new Mock<IGamesRepository>();
				_gamesRepositoryMock
					.Setup(x => x.GetGames())
					.Returns(new List<Game>());

				_sut = new GamesBoardService(_gamesRepositoryMock.Object);
			}

			protected override void When()
			{
				_startedGameId = _sut.StartGame(_homeTeam, _awayTeam);
			}

			[Fact]
			public void Then_It_Should_Return_A_Valid_Id()
			{
				_startedGameId.Should().NotBeEmpty();
			}

			[Fact]
			public void Then_It_Should_Use_The_GamesRepository_To_Save_A_Game()
			{
				_gamesRepositoryMock.Verify(x =>
					x.AddGame(It.Is<Game>(game => game.HomeTeam == _homeTeam && game.AwayTeam == _awayTeam)));
			}
		}

		public class Given_A_Duplicated_Game_When_Adding_Teams
			: Given_When_Then_Test
		{
			private GamesBoardService _sut;
			private Mock<IGamesRepository> _gamesRepositoryMock;
			private Action _action;
			private string _homeTeam;
			private string _awayTeam;

			protected override void Given()
			{
				_homeTeam = "Spain";
				_awayTeam = "Brazil";

				_gamesRepositoryMock = new Mock<IGamesRepository>();
				_gamesRepositoryMock
					.Setup(x => x.GetGames())
					.Returns(ReturnGamesList());

				_sut = new GamesBoardService(_gamesRepositoryMock.Object);
			}

			protected override void When()
			{
				_action = () => _sut.StartGame(_homeTeam, _awayTeam);
			}

			[Fact]
			public void Then_It_Should_Throw_An_DuplicatedGameException()
			{
				_action.Should().Throw<DuplicatedGameException>();
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

				return new List<Game> { game1, game2 };
			}
		}
	}
}

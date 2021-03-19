using System;
using Xunit;
using Moq;
using FluentAssertions;
using FWCScoreBoard.Library.Repository;
using FWCScoreBoard.Library.Services;
using FWCScoreBoard.Library.Domain;
using FWCScoreBoard.Library.Exceptions;
using FWCScoreBoard.Library.UnitTests.TestSupport;

namespace FWCScoreBoard.Library.UnitTests.Services
{
	public static class UpdateScoreTests
	{
		public class Given_A_Started_Game_When_Receiving_The_Pair_Score
			: Given_When_Then_Test
		{
			private GamesBoardService _sut;
			private Mock<IGamesRepository> _gamesRepositoryMock;
			private Guid _gameId;
			private int _homeTeamScore;
			private int _awayTeamScore;

			protected override void Given()
			{
				_gameId = Guid.NewGuid();
				_homeTeamScore = 1;
				_awayTeamScore = 1;

				var game = new Game(_gameId);
				game.AddHomeTeam("Mexico");
				game.AddAwayTeam("Canada");
				game.AddHomeTeamScore(_homeTeamScore);
				game.AddAwayTeamScore(_awayTeamScore);

				_gamesRepositoryMock = new Mock<IGamesRepository>();
				_gamesRepositoryMock
					.Setup(x => x.GetGame(_gameId))
					.Returns(
						game
					);

				_sut = new GamesBoardService(_gamesRepositoryMock.Object);
			}

			protected override void When()
			{
				_sut.UpdateScore(_gameId, _homeTeamScore, _awayTeamScore);
			}

			[Fact]
			public void Then_It_Should_Use_The_GamesRepository_To_Retrieve_The_Game()
			{
				_gamesRepositoryMock.Verify(x => x.GetGame(_gameId));
			}

			[Fact]
			public void Then_It_Should_Use_The_GamesRepository_To_Update_The_Game()
			{
				_gamesRepositoryMock.Verify(x => x.UpdateGame(_gameId, 
					It.Is<Game>( 
						game => 							
							game.HomeTeamScore == _homeTeamScore && 
							game.AwayTeamScore == _awayTeamScore)));
			}
		}

		public class Given_A_Non_Started_Game_When_Receiving_The_Pair_Score
			: Given_When_Then_Test
		{
			private GamesBoardService _sut;
			private Mock<IGamesRepository> _gamesRepositoryMock;
			private Guid _searchedGameId;
			private int _homeTeamScore;
			private int _awayTeamScore;
			private Action _action;

			protected override void Given()
			{
				_searchedGameId = Guid.NewGuid();

				Guid _loadedGameId = Guid.NewGuid();
				_homeTeamScore = 1;
				_awayTeamScore = 1;

				var game = new Game(_loadedGameId);
				game.AddHomeTeam("Mexico");
				game.AddAwayTeam("Canada");
				game.AddHomeTeamScore(_homeTeamScore);
				game.AddAwayTeamScore(_awayTeamScore);

				_gamesRepositoryMock = new Mock<IGamesRepository>();
				_gamesRepositoryMock
					.Setup(x => x.GetGame(_loadedGameId))
					.Returns(
						game
					);

				_sut = new GamesBoardService(_gamesRepositoryMock.Object);
			}

			protected override void When()
			{
				_action = () => _sut.UpdateScore(_searchedGameId, _homeTeamScore, _awayTeamScore);
			}

			[Fact]
			public void Then_It_Should_Throw_A_GameNotStartedException()
			{
				_action.Should().Throw<GameNotStartedException>();
			}
		}

	}
}

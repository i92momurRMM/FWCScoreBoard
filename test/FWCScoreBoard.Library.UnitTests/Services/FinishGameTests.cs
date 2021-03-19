using System;
using Xunit;
using FluentAssertions;
using Moq;
using FWCScoreBoard.Library.Services;
using FWCScoreBoard.Library.Repository;
using FWCScoreBoard.Library.Domain;
using FWCScoreBoard.Library.Exceptions;
using FWCScoreBoard.Library.UnitTests.TestSupport;

namespace FWCScoreBoard.Library.UnitTests.Services
{
	public static class FinishGameTests
	{
		public class Given_A_Started_Game_When_It_Finishes
			: Given_When_Then_Test
		{
			private GamesBoardService _sut;
			private Mock<IGamesRepository> _gamesRepositoryMock;
			private Guid _gameId = Guid.NewGuid();


			protected override void Given()
			{
				var game = new Game(_gameId);
				game.AddHomeTeam("Mexico");
				game.AddAwayTeam("Canada");

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
				_sut.FinishGame(_gameId);
			}

			[Fact]
			public void Then_It_Should_Use_The_GamesRepository_To_Remove_The_Game()
			{
				_gamesRepositoryMock.Verify(x => x.RemoveGame(_gameId));
			}
		}

		public class Given_A_Non_Started_Game_When_It_Finishes
			: Given_When_Then_Test
		{
			private GamesBoardService _sut;
			private Mock<IGamesRepository> _gamesRepositoryMock;
			private Action _action;

			protected override void Given()
			{	
				var gameId = Guid.NewGuid();
				var game = new Game(gameId);
				game.AddHomeTeam("Mexico");
				game.AddAwayTeam("Canada");

				_gamesRepositoryMock = new Mock<IGamesRepository>();
				_gamesRepositoryMock
					.Setup(x => x.GetGame(gameId))
					.Returns(
						game
					);
				_sut = new GamesBoardService(_gamesRepositoryMock.Object);
			}

			protected override void When()
			{
				_action = () => _sut.FinishGame(Guid.NewGuid());
			}

			[Fact]
			public void Then_It_Should_Not_Remove_Because_it_does_not_exist()
			{
				_action.Should().Throw<GameNotStartedException>();
			}
		}
	}
}

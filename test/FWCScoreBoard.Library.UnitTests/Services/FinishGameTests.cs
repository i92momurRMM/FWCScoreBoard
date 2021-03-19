using System;
using Xunit;
using Moq;
using FWCScoreBoard.Library.Services;
using FWCScoreBoard.Library.Repository;
using FWCScoreBoard.Library.Domain;
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
				var _game = new Game(_gameId);
				_game.AddHomeTeam("Mexico");
				_game.AddAwayTeam("Canada");

				_gamesRepositoryMock = new Mock<IGamesRepository>();

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
	}
}

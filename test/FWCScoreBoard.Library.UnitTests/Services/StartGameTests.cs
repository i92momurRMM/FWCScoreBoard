using System;
using Xunit;
using Moq;
using FluentAssertions;
using FWCScoreBoard.Library.Services;
using FWCScoreBoard.Library.Domain;
using FWCScoreBoard.Library.Repository;
using FWCScoreBoard.Library.UnitTests.TestSupport;

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
	}
}

using System;
using Xunit;
using FluentAssertions;
using FWCScoreBoard.Library.Services;
using FWCScoreBoard.Library.UnitTests.TestSupport;

namespace FWCScoreBoard.Library.UnitTests.Services
{
	public static class StartGameTests
	{
		public class Given_A_Game_When_Adding_Valid_Teams
			: Given_When_Then_Test
		{
			private GamesBoardService _sut;
			private string _homeTeam;
			private string _awayTeam;
			private Guid _startedGameId;

			protected override void Given()
			{
				_homeTeam = "Mexico";
				_awayTeam = "Canada";

				_sut = new GamesBoardService();
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
		}
	}
}

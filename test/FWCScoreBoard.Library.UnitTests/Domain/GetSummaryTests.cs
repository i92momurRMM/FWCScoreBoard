using System;
using Xunit;
using FluentAssertions;
using FWCScoreBoard.Library.Domain;
using FWCScoreBoard.Library.Exceptions;
using FWCScoreBoard.Library.UnitTests.TestSupport;

namespace FWCScoreBoard.Library.UnitTests.Domain
{
    public static class GetSummaryTests
    {
        public class Given_A_Game_When_Adding_Teams
            : Given_When_Then_Test
        {
            private Game _sut;
            private string _homeTeam;
            private string _awayTeam;
            private int _homeTeamScore;
            private int _awayTeamScore;
            private string _summary;

            protected override void Given()
            {
                var id = Guid.Empty;
                _sut = new Game(id);

                _homeTeam = "Mexico";
                _awayTeam = "Canada";
                _homeTeamScore = 0;
                _awayTeamScore = 5;

                _sut.AddHomeTeam(_homeTeam);
                _sut.AddAwayTeam(_awayTeam);
                _sut.AddHomeTeamScore(_homeTeamScore);
                _sut.AddAwayTeamScore(_awayTeamScore);
            }

            protected override void When()
            {
                _summary = _sut.GetSummary();
            }

            [Fact]
            public void Then_It_Should_Have_A_Expected_Summary()
            {
                var expectedSummary = $"{_homeTeam} {_homeTeamScore} - {_awayTeam} {_awayTeamScore}";
                _summary.Should().Be(expectedSummary);
            }
        }
    }
}
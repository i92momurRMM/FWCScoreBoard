using System;
using Xunit;
using FluentAssertions;
using FWCScoreBoard.Library.Domain;
using FWCScoreBoard.Library.UnitTests.TestSupport;

namespace FWCScoreBoard.Library.UnitTests.Domain
{
    public static class AddAwayTeamScoreTests
    {
        public class Given_A_Started_Game_When_Receiving_An_Away_Team_Score
            : Given_When_Then_Test
        {
            private Game _sut;
            private int _awayTeamScore;

            protected override void Given()
            {
                var id = Guid.Empty;
                _sut = new Game(id);
                
                _sut.AddHomeTeam("Mexico");
                _sut.AddAwayTeam("Canada");
                _awayTeamScore = 1;

            }

            protected override void When()
            {
                _sut.AddAwayTeamScore(_awayTeamScore);
            }
            
            [Fact]
            public void Then_It_Should_Have_The_Expected_Score()
            {
                _sut.AwayTeamScore.Should().Be(_awayTeamScore);
            }
            
        }
    }
}
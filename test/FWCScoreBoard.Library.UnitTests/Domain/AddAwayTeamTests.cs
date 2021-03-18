using System;
using Xunit;
using FluentAssertions;
using FWCScoreBoard.Library.Domain;
using FWCScoreBoard.Library.Exceptions;
using FWCScoreBoard.Library.UnitTests.TestSupport;

namespace FWCScoreBoard.Library.UnitTests.Domain
{
    public static class AddAwayTeamTests
    {
        public class Given_A_Game_When_Adding_A_Valid_Away_Team
            : Given_When_Then_Test
        {
            private Game _sut;
            private string _awayTeam;

            protected override void Given()
            {
                var id = Guid.Empty;
                _sut = new Game(id);

                _awayTeam = "Canada";
            }

            protected override void When()
            {
                _sut.AddAwayTeam(_awayTeam);
            }

            [Fact]
            public void Then_It_Should_Have_The_Expected_Away_Team_Code()
            {
                _sut.AwayTeam.Should().Be(_awayTeam);
            }      
        }
    }
}
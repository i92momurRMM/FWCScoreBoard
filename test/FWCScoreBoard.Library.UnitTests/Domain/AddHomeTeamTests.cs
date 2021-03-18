using System;
using Xunit;
using FluentAssertions;
using FWCScoreBoard.Library.Domain;
using FWCScoreBoard.Library.UnitTests.TestSupport;


namespace FWCScoreBoard.Library.UnitTests.Domain
{
    public static class AddHomeTeamTests
    {
        public class Given_A_Game_When_Adding_A_Valid_Home_Team
            : Given_When_Then_Test
        {
            private Game _sut;
            private string _homeTeam;

            protected override void Given()
            {
                var id = Guid.Empty;
                _sut = new Game(id);

                _homeTeam = "Mexico";
            }

            protected override void When()
            {
                _sut.AddHomeTeam(_homeTeam);
            }

            [Fact]
            public void Then_It_Should_Have_The_Expected_Home_Team()
            {
                _sut.HomeTeam.Should().Be(_homeTeam);
            }           
        }
    }
}
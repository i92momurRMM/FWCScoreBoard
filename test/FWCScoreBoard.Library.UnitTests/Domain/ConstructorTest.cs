using System;
using FluentAssertions;
using Xunit;
using FWCScoreBoard.Library.Domain;
using FWCScoreBoard.Library.UnitTests.TestSupport;

namespace FWCScoreBoard.Library.UnitTests.Domain
{
    public static class ConstructorTest
    {
        public class Given_Valid_Dependencies_When_Constructing_Instance
            : Given_When_Then_Test
        {
            private Game _sut;
            private Guid _id;

            protected override void Given()
            {
                _id = Guid.Empty;
            }

            protected override void When()
            {
                _sut = new Game(_id);
            }

            [Fact]
            public void Then_It_Should_Have_Created_A_Valid_Instance()
            {
                _sut.Should().NotBeNull();
            }

            [Fact]
            public void Then_It_Should_Have_The_Expected_Id()
            {
                _sut.Id.Should().Be(_id);
            }

            [Fact]
            public void Then_It_Should_Have_Start_Date()
            {
                _sut.StartDate.Should().NotBeSameDateAs(new DateTime());
            }

            [Fact]
            public void Then_It_Should_Have_Null_Home_Team()
            {
                _sut.HomeTeam.Should().BeNull();
            }

            [Fact]
            public void Then_It_Should_Have_Null_Away_Team()
            {
                _sut.AwayTeam.Should().BeNull();
            }

            [Fact]
            public void Then_It_Should_Have_Home_Team_Score_To_Zero()
            {
                _sut.HomeTeamScore.Should().Be(0);
            }
        }
    }
}
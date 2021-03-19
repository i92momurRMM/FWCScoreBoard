using System;
using Xunit;
using FluentAssertions;
using FWCScoreBoard.Library.IntegrationTests.TestSupport;
using FWCScoreBoard.Library.Repository;
using FWCScoreBoard.Library.Services;

namespace FWCScoreBoard.Library.IntegrationTests
{
    public static class AddGameTests
    {
        public class Given_A_NewGame_When_Adding
            : Given_When_Then_Test
        {
            private GamesBoardService _sut;
            private IGamesRepository _gameRepository;
            private Guid _insertedGameId;
            private string _homeTeam;
            private string _awayTeam;
            private int _homeTeamScore;
            private int _awayTeamScore;


            protected override void Given()         
            {
                _homeTeam = "Mexico";
                _awayTeam = "Canada";
                _homeTeamScore = 0;
                _awayTeamScore = 0;

                _gameRepository = new InMemoryGamesRepository();
                _sut = new GamesBoardService(_gameRepository);
            }

            protected override void When()
            {
                _insertedGameId = _sut.StartGame(_homeTeam, _awayTeam);
            }
            
            [Fact]
            public void Then_It_Should_Return_A_Valid_Id()
            {
                var expectedResult = $"{_homeTeam} {_homeTeamScore} - {_awayTeam} {_awayTeamScore}";
                var games = _sut.GetSummary();
                games.Should().Contain(expectedResult);
            }
        }
    }
}
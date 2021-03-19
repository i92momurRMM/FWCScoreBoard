using System;
using FluentAssertions;
using Xunit;
using FWCScoreBoard.Library.IntegrationTests.TestSupport;
using FWCScoreBoard.Library.Repository;
using FWCScoreBoard.Library.Services;

namespace FWCScoreBoard.Library.IntegrationTests
{
    public static class FinishGameTests
    {
        public class Given_A_Started_Game_When_It_Finishes
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
                _insertedGameId = _sut.StartGame(_homeTeam, _awayTeam);
            }

            protected override void When()
            {
                _sut.FinishGame(_insertedGameId);
            }
            
            [Fact]
            public void Then_It_Should_Be_Remove_On_Score_Board()
            {
                var expectedResult = $"{_homeTeam} {_homeTeamScore} - {_awayTeam} {_awayTeamScore}";
                var games = _sut.GetSummary();
                games.Should().NotContain(expectedResult);
            }
        }
    }
}
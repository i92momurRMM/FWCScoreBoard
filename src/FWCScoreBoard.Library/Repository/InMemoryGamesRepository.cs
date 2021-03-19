using System;
using System.Collections.Generic;
using FWCScoreBoard.Library.Domain;

namespace FWCScoreBoard.Library.Repository
{
    public class InMemoryGamesRepository
        : IGamesRepository
    {
        private readonly IDictionary<Guid, Game> _games = new Dictionary<Guid, Game>();

        public void AddGame(Game game)
        {
            _games.Add(game.Id, game);
        }

        public IEnumerable<Game> GetGames()
        {
            return _games.Values;
        }
    }
}

using FWCScoreBoard.Library.Domain;
using System;
using System.Collections.Generic;

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
    }
}

using System;
using System.Collections.Generic;
using FWCScoreBoard.Library.Domain;

namespace FWCScoreBoard.Library.Repository
{
    public interface IGamesRepository
    {
        void AddGame(Game game);
        IEnumerable<Game> GetGames();
        void RemoveGame(Guid id);
        Game GetGame(Guid id);
        void UpdateGame(Guid id, Game game);
    }
}

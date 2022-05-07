using ChessEngine.Board.Contracts;
using ChessEngine.Player.Contracts;
using System.Collections.Generic;

namespace ChessEngine.Engine.Contracts;

public interface IGameInitializationStrategy
{
    void Initialize(IList<IPlayer> players, IBoard board);
}
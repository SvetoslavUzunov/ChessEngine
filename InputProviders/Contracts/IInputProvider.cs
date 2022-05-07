namespace ChessEngine.InputProviders.Contracts;

using ChessEngine.Common;
using ChessEngine.Player.Contracts;
using System.Collections.Generic;

public interface IInputProvider
{
    IList<IPlayer> GetPlayers(int numberOfPlayers);
    Move GetNextPlayerMove(IPlayer player);
}
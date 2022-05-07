using ChessEngine.Player.Contracts;
using System.Collections.Generic;

namespace ChessEngine.Engine.Contracts;

public interface IChessEngine
{
    IEnumerable<IPlayer> Players { get; }
    void Initialize(IGameInitializationStrategy gameStrategy);

    void Start();

    void WinningConditions();
}
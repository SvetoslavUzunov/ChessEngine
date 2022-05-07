using ChessEngine.Board.Contracts;
using ChessEngine.Common;
using ChessEngine.Engine.Contracts;
using ChessEngine.Figures;
using ChessEngine.Figures.Contracts;
using ChessEngine.Player.Contracts;
using System;
using System.Collections.Generic;

namespace ChessEngine.Engine.Initializations;

public class StandardStartGameInitializationStrategy : IGameInitializationStrategy
{ 
    private const int BoardTotalRowsAndCols = 8;

    private IList<Type> figureTypes;

    public StandardStartGameInitializationStrategy()
    {
        this.figureTypes = new List<Type>
        {
            typeof(Rook),
            typeof(Knight),
            typeof(Bishop),
            typeof(Queen),
            typeof(King),
            typeof(Bishop),
            typeof(Knight),
            typeof(Rook)
        };
    }
    public void Initialize(IList<IPlayer> players, IBoard board)
    {
        ValidateStrategy(players, board);

        var firstPlayer = players[0];
        var secondPlayer = players[1];

        AddOtherFiguresToBoard(firstPlayer, board, 8);
        AddPawnsToBoard(firstPlayer, board, 7);

        AddOtherFiguresToBoard(secondPlayer, board, 1);
        AddPawnsToBoard(secondPlayer, board, 2);
    }

    private void AddPawnsToBoard(IPlayer player, IBoard board, int chessRow)
    {
        for (int i = 0; i < BoardTotalRowsAndCols; i++)
        {
            var pawn = new Pawn(player.Color);
            player.AddFigure(pawn);
            var position = new Position(chessRow, (char)(i + 'a'));
            board.AddFigure(pawn, position);
        }
    }

    private void AddOtherFiguresToBoard(IPlayer player, IBoard board, int chessRow)
    {
        for (int i = 0; i < BoardTotalRowsAndCols; i++)
        {
            var figureType = this.figureTypes[i];
            var figureInstance = (IFigure)Activator.CreateInstance(figureType, player.Color);
            var position = new Position(chessRow, (char)(i + 'a'));
            player.AddFigure(figureInstance);
            board.AddFigure(figureInstance, position);
        }
    }

    private void ValidateStrategy(ICollection<IPlayer> players, IBoard board)
    {
        if (players.Count != GlobalConstants.StandardNumberOfPlayers)
        {
            throw new InvalidOperationException("Must have only two players");
        }

        if (board.TotalRows != BoardTotalRowsAndCols || board.TotalCols != BoardTotalRowsAndCols)
        {
            throw new InvalidOperationException("Must have only 8x8 board");
        }
    }
}
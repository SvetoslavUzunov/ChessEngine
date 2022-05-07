using ChessEngine.Board;
using System;

namespace ChessEngine.Common;

public struct Position
{
    public Position(int row, char col) : this()
    {
        this.Row = row;
        this.Col = col;
    }

    public int Row { get; set; }

    public char Col { get; set; }

    public static Position FromArrayCoordinates(int arrRow, int arrCol, int totalRows)
    {
        return new Position(totalRows - arrRow, (char)(arrCol + 'a'));
    }

    public static void CheckIfValid(Position position)
    {
        if (position.Row < GlobalConstants.MinimumRowValueOnBoard || position.Row > GlobalConstants.MaximumRowValueOnBoard)
        {
            throw new IndexOutOfRangeException("Selected row is invalid!");
        }

        if (position.Col < GlobalConstants.MinimumColOnBoard || position.Col > GlobalConstants.MaximumColOnBoard)
        {
            throw new IndexOutOfRangeException("Selected col is invalid!");
        }
    }

    public static Position FromChessCoordinates(int chessRow, char chessCol)
    {
        var newPosition = new Position(chessRow, chessCol);
        CheckIfValid(newPosition);
        return newPosition;
    }
}

namespace ChessEngine.Board;

using ChessEngine.Board.Contracts;
using ChessEngine.Common;
using ChessEngine.Figures.Contracts;
using System;

public class Board : IBoard
{
    private IFigure[,] board;

    public Board(int rows = GlobalConstants.StandardGameTotalRows, int cols = GlobalConstants.StandardGameTotalCols)
    {
        this.TotalRows = rows;
        this.TotalCols = cols;
        this.board = new IFigure[TotalRows, TotalCols];
    }

    public int TotalRows { get; private set; }
    public int TotalCols { get; private set; }

    public void AddFigure(IFigure figure, Position position)
    {
        ObjectValidator.CheckIfObjectIsNull(figure, GlobalErrorMessages.NullFigureErrorMessages);
        Position.CheckIfValid(position);

        int arrayRow = this.GetArrayRow(position.Row);
        int arrayCol = this.GetArrayCol(position.Col);
        this.board[arrayRow, arrayCol] = figure;
    }

    public IFigure GetFigureAtPosition(Position position)
    {
        int arrRow = GetArrayRow(position.Row);
        int arrCol = GetArrayCol(position.Col);

        return board[arrRow, arrCol];
    }

    public void RemoveFigure(Position position)
    {
        Position.CheckIfValid(position);

        int arrayRow = this.GetArrayRow(position.Row);
        int arrayCol = this.GetArrayCol(position.Col);
        this.board[arrayRow, arrayCol] = null;
    }

    private int GetArrayRow(int chessRow)
    {
        return this.TotalRows - chessRow;
    }

    private int GetArrayCol(char chessCol)
    {
        return chessCol - 'a';
    }
}

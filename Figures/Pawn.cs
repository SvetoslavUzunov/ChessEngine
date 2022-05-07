using ChessEngine.Common;
using ChessEngine.Figures.Contracts;

namespace ChessEngine.Figures;

public class Pawn : BaseFigure, IFigure
{

    public Pawn(ChessColor color) : base(color)
    {
    }

}
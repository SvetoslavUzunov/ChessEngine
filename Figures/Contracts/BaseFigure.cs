using ChessEngine.Common;

namespace ChessEngine.Figures.Contracts;

public abstract class BaseFigure:IFigure
{
    protected BaseFigure(ChessColor color)
    {
        this.Color = color;
    }

    public ChessColor Color { get; private set; }
}
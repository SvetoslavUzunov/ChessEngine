namespace ChessEngine.Engine;

using ChessEngine.Common;
using ChessEngine.Engine.Contracts;
using ChessEngine.InputProviders.Contracts;
using ChessEngine.Player.Contracts;
using ChessEngine.Renderers.Contracts;
using System.Collections.Generic;
using ChessEngine.Board;
using ChessEngine.Board.Contracts;
using ChessEngine.Players;
using System.Linq;
using System;

public class StandardTwoPlayerEngine : IChessEngine
{
    private IList<IPlayer> players;
    private readonly IRenderer renderer;
    private readonly IInputProvider input;
    private readonly IBoard board;
    private int currentPlayerIndex;

    public StandardTwoPlayerEngine(IRenderer renderer, IInputProvider inputProvider)
    {
        this.renderer = renderer;
        this.input = inputProvider;
        this.board = new Board();
    }

    public IEnumerable<IPlayer> Players
    {
        get
        {
            return new List<IPlayer>(this.players);
        }
    }

    public void Initialize(IGameInitializationStrategy gameStrategy)
    {
        this.players = new List<IPlayer>
        {
            new Player("Pesho", ChessColor.Black),
            new Player("Gosho", ChessColor.White)
        };
        //var players = this.input.GetPlayers(GlobalConstants.StandardNumberOfPlayers);

        this.SetFirstplayerIndex();
        gameStrategy.Initialize(this.players, this.board);
        this.renderer.RenderBoard(board);
    }

    public void Start()
    {
        while (true)
        {
            try
            {
                var player = GetNextPlayer();
                var move = input.GetNextPlayerMove(player);
                var from = move.From;
            }
            catch(Exception ex)
            {
                this.currentPlayerIndex--;
                this.renderer.PrintErrorMessage(ex.Message);
            }
        }

    }

    public void WinningConditions()
    {
        throw new System.NotImplementedException();
    }

    private void SetFirstplayerIndex()
    {
        for (int i = 0; i < this.players.Count; i++)
        {
            if (this.players[i].Color == ChessColor.White)
            {
                this.currentPlayerIndex = i;
                return;
            }
        }
    }

    private IPlayer GetNextPlayer()
    {
        this.currentPlayerIndex++;
        if (this.currentPlayerIndex >= this.players.Count)
        {
            this.currentPlayerIndex = 0;
        }
        return this.players[this.currentPlayerIndex];
    }
}
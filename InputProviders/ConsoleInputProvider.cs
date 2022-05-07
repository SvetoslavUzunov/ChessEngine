namespace ChessEngine.InputProviders;

using ChessEngine.Common.Console;
using ChessEngine.Player.Contracts;
using System;
using System.Collections.Generic;
using ChessEngine.Common;
using ChessEngine.Players;
using ChessEngine.InputProviders.Contracts;

public class ConsoleInputProvider : IInputProvider
{
    private const string PlayerNameText = "Enter Player {0} name: ";


    public IList<IPlayer> GetPlayers(int numberOfPlayers)
    {
        var players = new List<IPlayer>();
        for (int i = 1; i <= numberOfPlayers; i++)
        {
            Console.Clear();
            ConsoleHelpers.SetCursorAtCenter(PlayerNameText.Length);
            Console.Write(String.Format(PlayerNameText, i));
            string name = Console.ReadLine();
            var player = new Player(name, (ChessColor)(i - 1));
            players.Add(player);
        }
        return players;
    }


    //Format: a5-c5
    public Move GetNextPlayerMove(IPlayer player)
    {
        ConsoleHelpers.ClearRow(ConsoleConstants.ConsoleRowForPlayerIO);
        Console.BackgroundColor = ConsoleColor.Black;
        Console.SetCursorPosition(Console.WindowWidth / 2 - 8, ConsoleConstants.ConsoleRowForPlayerIO);
        Console.Write($"{player.Name} is next: ");
        var positionAsString = Console.ReadLine().Trim().ToLower();
        return ConsoleHelpers.CreateMoveFromCommand(positionAsString);
    }
}
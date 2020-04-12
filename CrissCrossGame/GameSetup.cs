using System;
using System.Collections.Generic;
using System.Text;

namespace CrissCrossGame
{
	public static class GameSetup
	{
		public static Game GameSet()
		{
			Game newGame;
			Console.WriteLine(" Tic Tac Toe ");
			Console.WriteLine("Select 1 for single player and 2 for multiplayer");
			var modeAsString = Console.ReadLine();
			int mode;
			while (true)
				if (int.TryParse(modeAsString, out mode))
				{
					if (mode == 1)
					{
						Console.WriteLine($"Starting Single Player");
						Console.WriteLine("What is your name?");
						var nameAsString = Console.ReadLine();
						if (string.IsNullOrWhiteSpace(nameAsString))
						{
							newGame = new Game(1);
							break;
						}
						else
						{
							newGame = new Game(mode, nameAsString, "Terminator");
							break;
						}
					}
					else if (mode >= 2)
					{
						Console.WriteLine($"Starting Multiplayer Player");
						Console.WriteLine("What is player 1 name?");
						var playerOneAsString = Console.ReadLine();
						Console.WriteLine("What is player 2 name?");
						var playerTwoAsString = Console.ReadLine();
						if (string.IsNullOrWhiteSpace(playerOneAsString) || string.IsNullOrWhiteSpace(playerTwoAsString))
						{
							newGame = new Game(2);
							break;
						}
						else
						{
							newGame = new Game(mode, playerOneAsString, playerTwoAsString);
							break;
						}
					}
				}
			return newGame;
		}
	}
}

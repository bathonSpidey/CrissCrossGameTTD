using System;
using System.Collections.Generic;
using System.Text;

namespace CrissCrossGame
{
	public class Game
	{
		public Game(int mode):this(mode,"Mario","Luigi")
		{
		}
		public Game(int mode, string playerOne, string playerTwo)
		{
			PlayerOne = new Player(playerOne);
			PlayerTwo = new Player(playerTwo);
			Mode = mode;
			Play = true;
		}
	
		public int Mode {get; set;}
		public bool Play { get; set; }
		public int[] GivenPosition { get; set; }
		public Player PlayerOne { get; set; }
		public Player PlayerTwo { get; set; }
		private int[] AIPosition { get; set; }
		private string Winner { get; set; }

		public void PlayGame()
		{
			Board newBoard = new Board();
			PlayerOne.Role = "X";
			PlayerTwo.Role = "O";
			DisplayUtilities.DisplayGame(newBoard);
			Console.WriteLine($"May the odds with you {PlayerOne.Name}, {PlayerTwo.Name}");
			while (Play)
			{
				Console.WriteLine($"Please insert positions {PlayerOne.Name}");
				GivenPosition = PositionInput.PlayerInput();
				newBoard.UpdateState(PlayerOne.Role, GivenPosition[0], GivenPosition[1]);
				if (Utilities.IsGameFinish(newBoard))
				{
					Console.WriteLine($"It's a Draw");
					Play = false;
					break;
				}
				DisplayUtilities.DisplayGame(newBoard);
				if (Mode == 1) 
				{
					Console.WriteLine("Computers Turn");
					AIPosition = Utilities.GetNearestFreePlace(newBoard.GameBoard);
				}

				else
				{
					Console.WriteLine($"Please insert positions {PlayerTwo.Name}");
					AIPosition= PositionInput.PlayerInput();
				}
				newBoard.UpdateState(PlayerTwo.Role, AIPosition[0], AIPosition[1]);
				DisplayUtilities.DisplayGame(newBoard);
				Winner = Utilities.CheckWinner(newBoard);
				if (Winner == "O" || Winner == "X" || Utilities.IsGameFinish(newBoard))
				{
					if (Winner == "X")
					{
						Console.WriteLine($"****{PlayerOne.Name} won***** :) ");
					}
					else if (Winner == "O")
					{
						Console.WriteLine($"{PlayerTwo.Name} won! Better luck next time {PlayerOne.Name}");
					}
					else
					{
						Console.WriteLine($"It's a Draw");
					}
					Play = false;
				}
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CrissCrossGame
{
	public static class DisplayUtilities
	{
		public static void DisplayGame(Board board)
		{
			string[,] gameBoard = board.GameBoard;
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					if (j == 2)
					{
						Console.WriteLine($" {gameBoard[i, j]} ");
					}
					else
					{
						Console.Write($" {gameBoard[i, j]}  |  ");
					}
				}
				if (i == 2)
				{
					Console.WriteLine();
				}
				else
				{
					Console.WriteLine("________________");
				}
			}
		}
	}
}

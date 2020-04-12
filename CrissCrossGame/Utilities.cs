using System;
using System.Collections.Generic;
using System.Text;

namespace CrissCrossGame
{
	public static class Utilities
	{
		public static bool CheckFreePlace(string[,] board, int[] positions)
		{
			if (board[positions[0], positions[1]] == "_")
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public static int[] GetNearestFreePlace(string[,] board)
		{
			var positions = new int[2] { 0, 0 };
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					if (board[i, j] == "_")
					{
						positions[0] = i;
						positions[1] = j;
						return positions;
					}
				}
			}
			return positions;
		}
		public static bool IsGameFinish(Board board)
		{
			var game = board.GameBoard;
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					if (game[i, j] == "_")
					{
						return false;
					}
				}
			}
			return true;
		}
		public static string CheckWinner(Board board)
		{
			var game = board.GameBoard;
			var role = "_";
			if (string.Equals(game[0, 0], game[1, 1]) && string.Equals(game[0, 0], game[2, 2]) && game[0, 0] != "_")
			{
				role = game[0, 0];
				return role;
			}
				
			else if (string.Equals(game[0, 2], game[1, 1]) && string.Equals(game[0, 2], game[2, 0]) && game[0, 2] != "_")
			{
				role = game[0, 2];
				return role;
			}
			for (int i = 0; i < 3; i++)
			{
				if (string.Equals(game[i, 0], game[i, 1]) && string.Equals(game[i, 0], game[i, 2]) && game[i, 0] != "_")
				{
					role = game[i, 0];
					return role;
				}
				if (string.Equals(game[0, i], game[1, i]) && string.Equals(game[0, i], game[2, i]) && game[0, i] != "_")
				{
					role = game[0, i];
					return role;
				}
			}
			return role;
		}
	}
}

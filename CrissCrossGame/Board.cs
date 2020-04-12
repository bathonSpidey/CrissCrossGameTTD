using System;
using System.Collections.Generic;
using System.Text;

namespace CrissCrossGame
{
	public class Board
	{
		public Board()
		{
			GameBoard = new string[3, 3] { { "_", "_" ,"_"}, { "_", "_", "_" }, { "_", "_", "_" } };
		}

		public string[,] GameBoard { get;set;}
		public void UpdateState(string move, int positionX, int positionY)
		{
			var positions = new int[2] { positionX,positionY};
			var checkFreeSpace = Utilities.CheckFreePlace(GameBoard, positions);
			if (checkFreeSpace)
			{
				GameBoard[positionX, positionY] = move;
			}
			else
			{
				var freePositions = Utilities.GetNearestFreePlace(GameBoard);
				GameBoard[freePositions[0], freePositions[1]] = move;
			}
		}
	}
}

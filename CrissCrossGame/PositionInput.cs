using System;
using System.Collections.Generic;
using System.Text;

namespace CrissCrossGame
{
	public static class PositionInput
	{
		public static int[] PlayerInput()
		{
			var positions = new int[2] { 0, 0 };
			while (true)
			{
				Console.Write("Please insert row position starts from 1: ");
				var rowAsString = Console.ReadLine();
				Console.Write("Please insert column starts from 1: ");
				var colAsString = Console.ReadLine();
				Console.WriteLine("");
				int row;
				int column;
				if (int.TryParse(rowAsString, out row) && int.TryParse(colAsString, out column))
				{
					if ((row > 3 || row <= 0) || (column > 3 || column <= 0))
					{
						Console.WriteLine("Invalid row or column input please try again");
					}
					else
					{
						positions[0] = row - 1;
						positions[1] = column - 1;
						break;
					}
				}
				else
				{
					Console.WriteLine("Not a valid number try again");
				}
			}
			return positions;
		}
	}
}

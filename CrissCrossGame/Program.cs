using System;

namespace CrissCrossGame
{
	class Program
	{
		static void Main(string[] args)
		{
			Game newGame = GameSetup.GameSet();
			newGame.PlayGame();
		}
	}
}

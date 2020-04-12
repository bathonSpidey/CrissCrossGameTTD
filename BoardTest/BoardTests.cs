using CrissCrossGame;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Globalization;
using System.Security.Cryptography;

namespace BoardTest
{
	public class Tests
	{
		[Test]
		public void CreateBoard()
		{
			Board testBoard = new Board();
			var expected = 2;
			Assert.AreEqual(expected, testBoard.GameBoard.Rank);
		}
		[Test]
		public void TestBoardDefaultState()
		{
			Board testBoard = new Board();
			var expected = "_";
			Assert.AreEqual(expected, testBoard.GameBoard[0, 0]);
		}
		[Test]
		public void TestBoardUpdateState()
		{
			Board testBoard = new Board();
			var expected = "O";
			var expectedOther = "_";
			testBoard.UpdateState("O", 0, 0);
			Assert.AreEqual(expected, testBoard.GameBoard[0, 0]);
			Assert.AreEqual(expectedOther, testBoard.GameBoard[0, 1]);
		}
		[Test]
		public void TestDisplay()
		{
			Board testBoard = new Board();
			DisplayUtilities.DisplayGame(testBoard);
			testBoard.UpdateState("X", 0, 0);
			DisplayUtilities.DisplayGame(testBoard);
		}
		[Test]
		public void GameFinishCheck()
		{
			Board testBoard = new Board();
			DisplayUtilities.DisplayGame(testBoard);
			FillBoard(testBoard);
			var isGameFinished = Utilities.IsGameFinish(testBoard);
			var expected = true;
			Assert.AreEqual(expected, isGameFinished);
		}
		[Test]
		public void CheckHorizantalHalfGameWinner()
		{ 
			Board testBoard1 = new Board();
			testBoard1.UpdateState("X", 0, 0);
			testBoard1.UpdateState("X", 0, 1);
			var isGameWon1 = Utilities.CheckWinner(testBoard1);
			var expectedHalf1 = "_";
			Assert.AreEqual(expectedHalf1, isGameWon1);
			DisplayUtilities.DisplayGame(testBoard1);
		}
		[Test]
		public void CheckHorizantalGameWinner()
		{
			Board testBoard1 = new Board();
			testBoard1.UpdateState("O", 0, 0);
			testBoard1.UpdateState("O", 0, 1);
			testBoard1.UpdateState("O", 0, 2);
			var isGameWon1 = Utilities.CheckWinner(testBoard1);
			var expectedHalf1 = "O";
			Assert.AreEqual(expectedHalf1, isGameWon1);
			DisplayUtilities.DisplayGame(testBoard1);
		}
		[Test]
		public void CheckMiddleRowGameWinner()
		{
			Board testBoard1 = new Board();
			testBoard1.UpdateState("X", 1, 0);
			testBoard1.UpdateState("X", 1, 1);
			testBoard1.UpdateState("X", 1, 2);
			var isGameWon1 = Utilities.CheckWinner(testBoard1);
			var expectedHalf1 = "X";
			Assert.AreEqual(expectedHalf1, isGameWon1);
			DisplayUtilities.DisplayGame(testBoard1);
		}
		[Test]
		public void CheckLastRowGameWinner()
		{
			Board testBoard1 = new Board();
			testBoard1.UpdateState("X", 2, 0);
			testBoard1.UpdateState("X", 2, 1);
			testBoard1.UpdateState("X", 2, 2);
			var isGameWon1 = Utilities.CheckWinner(testBoard1);
			var expectedHalf1 = "X";
			Assert.AreEqual(expectedHalf1, isGameWon1);
			DisplayUtilities.DisplayGame(testBoard1);
		}
		[Test]
		public void CheckFirstColumnGameWinner()
		{
			Board testBoard1 = new Board();
			testBoard1.UpdateState("O", 0, 0);
			testBoard1.UpdateState("O", 1, 0);
			testBoard1.UpdateState("O", 2, 0);
			var isGameWon1 = Utilities.CheckWinner(testBoard1);
			var expectedHalf1 = "O";
			Assert.AreEqual(expectedHalf1, isGameWon1);
			DisplayUtilities.DisplayGame(testBoard1);
		}
		[Test]
		public void CheckSecondColumnGameWinner()
		{
			Board testBoard1 = new Board();
			testBoard1.UpdateState("X", 0, 1);
			testBoard1.UpdateState("X", 1, 1);
			testBoard1.UpdateState("X", 2, 1);
			var isGameWon1 = Utilities.CheckWinner(testBoard1);
			var expectedHalf1 = "X";
			Assert.AreEqual(expectedHalf1, isGameWon1);
			DisplayUtilities.DisplayGame(testBoard1);
		}
		[Test]
		public void CheckDrawGameWinner()
		{
			Board testBoard1 = new Board();
			testBoard1.UpdateState("X", 0, 0);
			testBoard1.UpdateState("O", 1, 0);
			testBoard1.UpdateState("X", 2, 0);
			testBoard1.UpdateState("X", 0, 1);
			testBoard1.UpdateState("O", 1, 1);
			testBoard1.UpdateState("O", 2, 1);
			testBoard1.UpdateState("O", 0, 2);
			testBoard1.UpdateState("X", 1, 2);
			testBoard1.UpdateState("X", 2, 2);
			var isGameWon1 = Utilities.CheckWinner(testBoard1);
			var expectedHalf1 = "_";
			Assert.AreEqual(expectedHalf1, isGameWon1);
			DisplayUtilities.DisplayGame(testBoard1);
		}
		[Test]
		public void CheckFreeSpaces()
		{
			Board testBoard1 = new Board();
			testBoard1.UpdateState("X", 0, 1);
			testBoard1.UpdateState("X", 1, 1);
			testBoard1.UpdateState("O", 0, 1);
			var expectedHalf1 = "X";
			Assert.AreEqual(expectedHalf1, testBoard1.GameBoard[0,1]);
			DisplayUtilities.DisplayGame(testBoard1);
		}
		[Test]
		public void CheckNearestFreeSpaces()
		{
			Board testBoard1 = new Board();
			testBoard1.UpdateState("X", 0, 0);
			testBoard1.UpdateState("X", 1, 1);
			testBoard1.UpdateState("O", 2, 1);
			var nearestFreeSpace = Utilities.GetNearestFreePlace(testBoard1.GameBoard);
			var expectedHalf1 = 1;
			Assert.AreEqual(expectedHalf1, nearestFreeSpace[1]);
			DisplayUtilities.DisplayGame(testBoard1);
		}



		private static void FillBoard(Board testBoard)
		{
			Random random = new Random();
			int randomNumber;
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					randomNumber = random.Next(0, 10);
					if (randomNumber <= 5)
					{
						testBoard.UpdateState("X", i, j);
					}
					else
					{
						testBoard.UpdateState("O", i, j);
					}
				}
				DisplayUtilities.DisplayGame(testBoard);
			}
		}
	}
}
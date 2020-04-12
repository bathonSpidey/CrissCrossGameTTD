using CrissCrossGame;
using NUnit.Framework;

namespace PlayerTest
{
	public class Tests
	{
		[Test]
		public void Name()
		{
			Player player1 = new Player("Abir");
			Player player2 = new Player();
			var expected = "Abir";
			var expectedPlayer2 = "Default";
			Assert.AreEqual(expected, player1.Name);
			Assert.AreEqual(expectedPlayer2, player2.Name);
		}
		[Test]
		public void Role()
		{
			Player player1 = new Player();
			player1.Role = "O";
			Assert.AreEqual("O", player1.Role);
		}
	}
}
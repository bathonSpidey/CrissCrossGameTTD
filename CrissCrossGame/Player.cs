using System;
using System.Collections.Generic;
using System.Text;

namespace CrissCrossGame
{
	public class Player
	{
		public Player() => Name = "Default";
		public Player(string name) => Name = name;
		public string Name { get; set; }
		public string Role { get; set; }
	}
}

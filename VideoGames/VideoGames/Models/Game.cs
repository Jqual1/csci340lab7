using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoGames.Models
{
	public class Game
	{
		public int ID { get; set; }
		public string Name { get; set; }

		public string GameType { get; set; }
		public string Device { get; set; }
		public bool LocalMultiplayer { get; set; }
	}
}

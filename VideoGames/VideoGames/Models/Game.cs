using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoGames.Models
{
	public class Game
	{
		public int ID { get; set; }

		[StringLength(60, MinimumLength = 3)]
		[Required]
		public string Name { get; set; }

		[StringLength(60, MinimumLength = 3)]
		[Required]
		public string GameType { get; set; }

		[StringLength(15, MinimumLength = 2)]
		[Required]
		public string Device { get; set; }

		public bool LocalMultiplayer { get; set; }
	}
}

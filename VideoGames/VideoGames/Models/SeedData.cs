using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VideoGames.Data;

namespace VideoGames.Models
{
	public class SeedData
	{
		public static void Initialize(IServiceProvider serviceProvider)
		{
			using (var context = new VideoGamesContext(
				serviceProvider.GetRequiredService<
					DbContextOptions<VideoGamesContext>>()))
			{
				if (context.Game.Any())
				{
					return; // The DB has been seeded
				}

				context.Game.AddRange(
					new Game
					{
						Name = "Minecraft",
						GameType = "Survival Sandbox",
						Device = "PS5",
						LocalMultiplayer = true
					},
					new Game
					{
					Name = "Minecraft",
						GameType = "Survival Sandbox",
						Device = "PC",
						LocalMultiplayer = false
					},
					new Game
					{
						Name = "Skyrim",
						GameType = "OpenWorld ARPG",
						Device = "PS5",
						LocalMultiplayer = false
					},
					new Game
					{
						Name = "Mortal Kombat XI",
						GameType = "Fighting",
						Device = "PS5",
						LocalMultiplayer = true
					}
					);
				context.SaveChanges();
			}
		}
	}
}

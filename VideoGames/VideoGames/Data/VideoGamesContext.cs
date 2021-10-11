using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VideoGames.Models;

namespace VideoGames.Data
{
    public class VideoGamesContext : DbContext
    {
        public VideoGamesContext (DbContextOptions<VideoGamesContext> options)
            : base(options)
        {
        }

        public DbSet<VideoGames.Models.Game> Game { get; set; }
    }
}

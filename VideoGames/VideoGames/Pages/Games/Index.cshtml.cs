using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VideoGames.Data;
using VideoGames.Models;

namespace VideoGames.Pages.Games
{
    public class IndexModel : PageModel
    {
        private readonly VideoGames.Data.VideoGamesContext _context;

        public IndexModel(VideoGames.Data.VideoGamesContext context)
        {
            _context = context;
        }

        public IList<Game> Game { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList GameTypes { get; set; }
        [BindProperty(SupportsGet = true)]
        public string GameType { get; set; }
        public SelectList Devices { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Device { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> gameTypeQuery = from g in _context.Game
                                               orderby g.GameType
                                               select g.GameType;
            IQueryable<string> deviceQuery = from g in _context.Game
                                               orderby g.Device
                                               select g.Device;
            var games = from g in _context.Game
                        select g;
            if (!string.IsNullOrEmpty(SearchString))
			{
                games = games.Where(s => s.Name.Contains(SearchString));
			}
            if (!string.IsNullOrEmpty(GameType))
            {
                games = games.Where(t => t.GameType == GameType);
            }
            if (!string.IsNullOrEmpty(GameType))
            {
                games = games.Where(d => d.Device == Device);
            }
            GameTypes = new SelectList(await gameTypeQuery.Distinct().ToListAsync());
            Devices = new SelectList(await deviceQuery.Distinct().ToListAsync());
            Game = await games.ToListAsync();
        }
    }
}

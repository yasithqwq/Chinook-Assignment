using Chinook.Data.Interfaces;
using Chinook.Models;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Data
{
    public class NavBarData: INavBarData
    {
        private readonly IDbContextFactory<ChinookContext> _dbFactory;

        public NavBarData(IDbContextFactory<ChinookContext> DbFactory)
        {
            _dbFactory = DbFactory;
        }

        public async Task<List<Playlist>> GetArtists(string currentUserId)
        {
            var DbContext = await _dbFactory.CreateDbContextAsync();
            return DbContext.Playlists.Include(p => p.UserPlaylists).Where(p => p.UserPlaylists.Any(up => up.UserId == currentUserId)).ToList();
        }
    }
}

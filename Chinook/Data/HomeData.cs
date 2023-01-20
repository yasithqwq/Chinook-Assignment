using Chinook.Data.Interfaces;
using Chinook.Models;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Data
{
    public class HomeData : IHomeData
    {
        private readonly IDbContextFactory<ChinookContext> _dbFactory;

        public HomeData(IDbContextFactory<ChinookContext> DbFactory)
        {
            _dbFactory = DbFactory;
        }

        public async Task<List<Artist>> GetArtists()
        {
            var dbContext = await _dbFactory.CreateDbContextAsync();
            return dbContext.Artists.ToList();
        }

        public async Task<List<Album>> GetAlbumsForArtist(int artistId)
        {
            var dbContext = await _dbFactory.CreateDbContextAsync();
            return dbContext.Albums.Where(a => a.ArtistId == artistId).ToList();
        }
    }
}

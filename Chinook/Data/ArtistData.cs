using Chinook.Data.Interfaces;
using Chinook.Models;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Data
{
    public class ArtistData : IArtistData
    {
        private readonly IDbContextFactory<ChinookContext> _dbFactory;

        public ArtistData(IDbContextFactory<ChinookContext> DbFactory)
        {
            _dbFactory = DbFactory;
        }

        public async Task<Artist> GetArtistData(long artistId)
        {
            var dbContext = await _dbFactory.CreateDbContextAsync();

            return dbContext.Artists.SingleOrDefault(a => a.ArtistId == artistId);
        }

        public async Task<List<ClientModels.PlaylistTrack>> GetTracks(long artistId,string currentUserId)
        {
            var dbContext = await _dbFactory.CreateDbContextAsync();

            return dbContext.Tracks.Where(a => a.Album.ArtistId == artistId)
              .Include<Track, Album>(a => a.Album)
                .Select(t => new ClientModels.PlaylistTrack()
             {
                 AlbumTitle = (t.Album == null ? "-" : t.Album.Title),
                 TrackId = t.TrackId,
                 TrackName = t.Name,
                IsFavorite = t.Playlists.Where<Models.Playlist>(p => p.UserPlaylists.Any<UserPlaylist>(up => up.UserId == currentUserId && up.Playlist.Name == "Favorites")).Any()
             })
             .ToList();
        }
    }
}

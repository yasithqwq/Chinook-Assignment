using Chinook.Data.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Data
{
    public class PlayListData: IPlayListData
    {
        private readonly IDbContextFactory<ChinookContext> _dbFactory;

        public PlayListData(IDbContextFactory<ChinookContext> DbFactory)
        {
            _dbFactory = DbFactory;
        }
        public async Task<Chinook.ClientModels.Playlist> GetPlayList(long playListId, string currentUserId)
        {
            var dbContext = await _dbFactory.CreateDbContextAsync();
            return dbContext.Playlists
                   .Include(a => a.Tracks).ThenInclude(a => a.Album).ThenInclude(a => a.Artist)
                   .Where(p => p.PlaylistId == playListId)
                   .Select(p => new ClientModels.Playlist()
                   {
                       Name = p.Name,
                       Tracks = p.Tracks.Select(t => new ClientModels.PlaylistTrack()
                       {
                           AlbumTitle = t.Album.Title,
                           ArtistName = t.Album.Artist.Name,
                           TrackId = t.TrackId,
                           TrackName = t.Name,
                           IsFavorite = t.Playlists.Where(p => p.UserPlaylists.Any(up => up.UserId == currentUserId && up.Playlist.Name == "Favorites")).Any()
                       }).ToList()
                   })
                   .FirstOrDefault();
        }

        public async Task<bool> RemoveTrack(long playListId,long trackId)
        {
            try
            {
                //Note: here we can not delete PLaylistTrack since the entity is not in the context
                //var dbContext = await _dbFactory.CreateDbContextAsync();
                //var trackToDel = dbContext.Tracks.FirstOrDefault(t => t.TrackId == trackId);
                //dbContext.Tracks.Remove(trackToDel);
                //dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

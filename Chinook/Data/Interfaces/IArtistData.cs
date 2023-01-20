using Chinook.Models;

namespace Chinook.Data.Interfaces
{
    public interface IArtistData
    {
        Task<Artist> GetArtistData(long artistId);
        Task<List<ClientModels.PlaylistTrack>> GetTracks(long artistId, string currentUserId);
    }
}

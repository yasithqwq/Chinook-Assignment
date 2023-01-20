using Chinook.Models;

namespace Chinook.Data.Interfaces
{
    public interface IHomeData
    {
        Task<List<Artist>> GetArtists();
        Task<List<Album>> GetAlbumsForArtist(int artistId);
    }
}

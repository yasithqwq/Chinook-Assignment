

using Chinook.Models;

namespace Chinook.Data.Interfaces
{
    public interface INavBarData
    {
        Task<List<Playlist>> GetArtists(string currentUserId);
    }
}

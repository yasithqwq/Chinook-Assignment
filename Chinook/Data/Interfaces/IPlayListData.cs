namespace Chinook.Data.Interfaces
{
    public interface IPlayListData
    {
        Task<Chinook.ClientModels.Playlist> GetPlayList(long playListId, string currentUserId);
        Task<bool> RemoveTrack(long playlistId, long trackId);
    }
}

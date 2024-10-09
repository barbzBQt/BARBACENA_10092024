using BARBACENA_10092024.Data.Entities;

namespace BARBACENA_10092024.App.Services.Interface
{
    public interface IVideoService
    {
        Task<IEnumerable<Video>> GetAllVideos();
    }
}

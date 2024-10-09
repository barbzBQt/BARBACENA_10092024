using BARBACENA_10092024.App.Models;
using BARBACENA_10092024.Data.Entities;

namespace BARBACENA_10092024.App.Repositories.Interface
{
    public interface IVideoRepository
    {
        Task<IEnumerable<Video>> GetAllVideos();
        Task UploadVideo(Video video);
    }
}

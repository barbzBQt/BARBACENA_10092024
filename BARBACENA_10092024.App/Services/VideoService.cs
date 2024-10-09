using BARBACENA_10092024.App.Repositories.Interface;
using BARBACENA_10092024.App.Services.Interface;
using BARBACENA_10092024.Data.Entities;

namespace BARBACENA_10092024.App.Services
{
    public class VideoService : IVideoService
    {
        private readonly IConfiguration _config;
        private readonly IVideoRepository _repo;

        public VideoService(IConfiguration config, IVideoRepository repo)
        {
            _config = config;
            _repo = repo;
        }

        public async Task<IEnumerable<Video>> GetAllVideos()
        {
            return await _repo.GetAllVideos(); ;
        }
    }
}

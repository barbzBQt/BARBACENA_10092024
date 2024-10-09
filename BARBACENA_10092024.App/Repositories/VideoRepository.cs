using BARBACENA_10092024.App.Repositories.Interface;
using BARBACENA_10092024.Data;
using BARBACENA_10092024.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BARBACENA_10092024.App.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private readonly DataContext _context;

        public VideoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Video>> GetAllVideos()
        {
            return await _context.Videos.ToListAsync();
        }
    }
}

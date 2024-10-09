using BARBACENA_10092024.App.Helpers;
using BARBACENA_10092024.App.Models;
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
            return await _repo.GetAllVideos();
        }

        public async Task<VideoResponseModel> UploadVideo(VideoRequestModel request)
        {
            try
            {
                string videosPath = _config["Directories:Videos"];
                string thumbnailsPath = _config["Directories:Thumbnails"];

                var filePath = Path.Combine(videosPath, request.File.FileName);

                // Save the video file
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await request.File.CopyToAsync(stream);
                }

                // Generate the thumbnail
                var thumbnail = FileHelper.GenerateThumbnail(filePath, _config);

                // Create and save video metadata
                var video = new Video
                {
                    Title = request.Title,
                    Description = request.Description,
                    Categories = request.Categories,
                    FileName = request.File.FileName,
                    FilePath = $"{videosPath}/{request.File.FileName}",
                    Thumbnail = thumbnail,
                    CreatedDate = DateTime.Now
                };

                await _repo.UploadVideo(video);

                return new VideoResponseModel
                {
                    Success = true,
                    Message = "Video created successfully"
                };
            }
            catch (Exception ex)
            {
                return new VideoResponseModel
                {
                    Success = false,
                    Message = ex.Message
                };
            }
            
        }
    }
}

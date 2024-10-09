using BARBACENA_10092024.App.Models;
using BARBACENA_10092024.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BARBACENA_10092024.App.Services.Interface
{
    public interface IVideoService
    {
        Task<IEnumerable<VideoModel>> GetAllVideos();
        Task<VideoResponseModel> UploadVideo(VideoRequestModel request);
    }
}

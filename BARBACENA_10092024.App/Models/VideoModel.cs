using BARBACENA_10092024.Data.Entities;

namespace BARBACENA_10092024.App.Models
{
    public class VideoModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Categories { get; set; }
        public string FileName { get; set; }
        public string Thumbnail { get; set; }
        public string FilePath { get; set; }

        public static VideoModel ParseToModel(Video video)
        {
            return new VideoModel()
            {
                Id = video.Id,
                Title = video.Title,
                Description = video.Description,
                Categories = video.Categories,
                FileName = video.FileName,
                Thumbnail = Convert.ToBase64String(video.Thumbnail),
                FilePath = video.FilePath
            };
        }
    }
}

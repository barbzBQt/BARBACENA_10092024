using BARBACENA_10092024.App.Helpers;
using System.Linq;

namespace BARBACENA_10092024.App.Models
{
    public class VideoRequestModel
    {
        public IFormFile File { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Categories { get; set; }
    }
}

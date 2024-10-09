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
        public string? ErrorMessage { get; set; }

        public void Validate()
        {
            var errorMessages = new List<string>();

            if (FileHelper.IsFileExceedsSizeLimit(File.Length))
            {
                errorMessages.Add("File size should be up to 100 mb only.");
            }

            if (FileHelper.IsFileExtensionValid(File.FileName))
            {
                errorMessages.Add("Please select a valid video file (MP4, AVI, MOV).");
            }

            ErrorMessage = string.Join('\n', errorMessages);
        }
    }
}

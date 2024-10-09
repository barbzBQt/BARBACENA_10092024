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
        public string ErrorMessage { get; set; }

        public void Validate()
        {
            List<string> errorMessages = new List<string>();

            if (File == null || File.Length == 0)
            {
                errorMessages.Add("No file provided.");
            }
            else if (FileHelper.ConvertBytesToMb(File.Length) > 100)
            {
                errorMessages.Add("File size should be up to 100 mb only.");
            }

            if (!string.IsNullOrEmpty(Description) && Description.Length > 160)
            {
                errorMessages.Add("Description should be up to 160 characters only."); 
            }

            ErrorMessage = string.Join('\n', errorMessages);
        }
    }
}

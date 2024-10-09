using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace BARBACENA_10092024.App.Helpers
{
    public static class FileHelper
    {
        public static bool IsFileExceedsSizeLimit(double fileSize)
        {
            double fileSizeInMb = fileSize / (1024 * 1024);
            return fileSizeInMb > 100;
        }

        public static bool IsFileExtensionValid(string fileName)
        {
            string[] validFileTypes = new string[] { ".mp4", ".avi", ".mov" };
            return validFileTypes.Contains(Path.GetExtension(fileName).ToLower());
        }

        public static byte[] GenerateThumbnail(string videoPath, IConfiguration config)
        {            
            // FFmpeg command to extract a frame at 1 second
            string ffmpegArgs = $"-i \"{videoPath}\" -ss 00:00:01 -vframes 1 -vf \"scale=256:256\" -f image2 pipe:1";

            // Execute FFmpeg process

            return RunFFmpegProcess(ffmpegArgs, config);
        }
        
        private static byte[] RunFFmpegProcess(string arguments, IConfiguration config)
        {
            var ffmpegPath = Path.Combine(config["Ffmpeg"], "ffmpeg.exe");
        
            var processStartInfo = new ProcessStartInfo
            {
                FileName = ffmpegPath,
                Arguments = arguments,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
        
            using (var process = new Process { StartInfo = processStartInfo })
            {
                process.Start();
                using (var ms = new MemoryStream())
                {
                    process.StandardOutput.BaseStream.CopyTo(ms);
                    process.WaitForExit();
                    return ms.ToArray();
                }
            }
        }
    }
}

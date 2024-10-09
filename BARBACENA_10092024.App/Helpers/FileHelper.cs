using System.Diagnostics;
using Xabe.FFmpeg;

namespace BARBACENA_10092024.App.Helpers
{
    public static class FileHelper
    {
        public static string GenerateThumbnail(string videoPath, IConfiguration config)
        {
            //var sourceFilePath = Path.ChangeExtension(videoPath, ".jpg");
            var thumbnailPath = Path.Combine(config["Directories:Thumbnails"], Path.GetFileNameWithoutExtension(videoPath) + ".jpg");
            
            // FFmpeg command to extract a frame at 1 second
            string ffmpegArgs = $"-i \"{videoPath}\" -ss 00:00:01.000 -vframes 1 \"{thumbnailPath}\"";

            // Execute FFmpeg process
            RunFFmpegProcess(ffmpegArgs, config);

            return Path.GetFileName(thumbnailPath);
        }

        private static void RunFFmpegProcess(string arguments, IConfiguration config)
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
            }
        }
    }
}

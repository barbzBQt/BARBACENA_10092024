using Xabe.FFmpeg;

namespace BARBACENA_10092024.App.Helpers
{
    public static class FileHelper
    {
        public static double ConvertBytesToMb(double fileSize)
        {
            return fileSize / (1024 * 1024);
        }

        public static string GenerateThumbnail(string videoPath, IConfiguration config)
        {
            var resultPath = Path.Combine(config["ThumbnailDirectory"], Path.GetFileNameWithoutExtension(videoPath) + ".jpg");

            // Ensure FFmpeg is initialized and ready to use
            FFmpeg.SetExecutablesPath(@"C:\path\to\ffmpeg");  // Path where ffmpeg.exe is located on your machine

            // Generate a thumbnail at 5 seconds into the video
            var conversion = FFmpeg.Conversions.FromSnippet.Snapshot(videoPath, resultPath, TimeSpan.FromSeconds(5));

            conversion.Start();

            return resultPath;
        }
    }
}

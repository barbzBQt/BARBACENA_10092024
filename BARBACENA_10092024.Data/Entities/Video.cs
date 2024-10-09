using System.ComponentModel.DataAnnotations;

namespace BARBACENA_10092024.Data.Entities
{
    public class Video
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Categories { get; set; }
        public string FileName { get; set; }
        public byte[] Thumbnail { get; set; }
        public string FilePath { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

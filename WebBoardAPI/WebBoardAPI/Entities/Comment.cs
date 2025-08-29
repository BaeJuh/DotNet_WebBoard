using System.ComponentModel.DataAnnotations;

namespace WebBoardAPI.Entities
{
    public class Comment
    {
        public long Id { get; set; }
        [Required]
        public string Content { get; set; } = string.Empty;
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }
    }
}

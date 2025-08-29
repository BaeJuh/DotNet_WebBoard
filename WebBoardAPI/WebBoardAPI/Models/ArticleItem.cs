namespace WebBoardAPI.Models
{
    public class ArticleItem
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<CommentItem> Comments { get; set; } = new List<CommentItem>();
    }
}

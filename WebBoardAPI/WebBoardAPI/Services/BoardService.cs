using WebBoardAPI.Context;
using WebBoardAPI.Entities;
using WebBoardAPI.Models;

namespace WebBoardAPI.Services
{
    
    public class BoardService
    {
        private readonly DBContext dBContext;

        public BoardService(DBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public string index()
        {
            return "Hello Server";
        }

        public List<ArticleListItem> GetArticles()
        {
            List<Article> articles = dBContext.Articles.Where(article => !article.IsDeleted).OrderBy(article => article.CreatedAt).ToList();

            return articles.Select(article => new ArticleListItem
            {
                Title = article.Title,
                CreatedAt = article.CreatedAt
            }).ToList();
        }

        public ArticleItem GetArticleItem(long id)
        {
            Article article = dBContext.Articles.SingleOrDefault(article => article.Id == id) ?? throw new Exception("글을 찾을 수 없음");

            return new ArticleItem
            {
                Title = article.Title,
                Content = article.Content,
                CreatedAt = article.CreatedAt,
                Comments = article.Comments.Select(comment => 
                new CommentItem
                {
                    Content = comment.Content,
                    CreatedAt = comment.CreatedAt
                    
                }).ToList()
            };
        }

        public void SetArticle(ArticleUploadRequest request)
        {
            Article article = new Article
            {
                Title = request.Title,
                Content = request.Content,
                CreatedAt = DateTime.UtcNow
            };

            dBContext.Articles.Add(article);
            dBContext.SaveChanges();
        }
    }
}

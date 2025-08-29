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

        public void SetArticleTest(ArticleUploadRequest request)
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

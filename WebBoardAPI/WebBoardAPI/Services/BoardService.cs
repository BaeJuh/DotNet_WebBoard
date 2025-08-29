using Microsoft.EntityFrameworkCore;
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
            Article article = dBContext.Articles.Include(article => article.Comments).SingleOrDefault(article => article.Id == id) ?? throw new Exception("글을 찾을 수 없음");

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

        public void DeleteArticle(long id)
        {
            Article article = dBContext.Articles.SingleOrDefault(article => article.Id == id) ?? throw new Exception("글을 찾을 수 없음");
            article.IsDeleted = true;
            article.DeletedAt = DateTime.UtcNow;
            dBContext.SaveChanges();
        }

        public void UpdateArticle(long id, ArticleUpdateRequest request)
        {
            Article article = dBContext.Articles.SingleOrDefault(article => article.Id == id) ?? throw new Exception("글을 찾을 수 없음");
            
            article.Title = request.Title == String.Empty ? article.Title : request.Title;
            article.Content = request.Content == String.Empty ? article.Content : request.Content;

            dBContext.SaveChanges();
        }

        public void SetComment(long articleId, CommentRequest request)
        {
            Comment comment = new Comment
            {
                Content = request.Content,
                CreatedAt = DateTime.UtcNow
            };

            Article article = dBContext.Articles.SingleOrDefault(article => article.Id == articleId) ?? throw new Exception("글을 찾을 수 없음");

            article.Comments.Add(comment);
            dBContext.SaveChanges();
        }
    }
}

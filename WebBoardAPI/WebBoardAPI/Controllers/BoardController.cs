using Microsoft.AspNetCore.Mvc;
using WebBoardAPI.Models;
using WebBoardAPI.Services;

namespace WebBoardAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoardController: ControllerBase
    {
        private readonly BoardService boardService;

        public BoardController(BoardService boardService)
        {
            this.boardService = boardService;
        }

        [HttpGet("")]
        public string Index()
        {
            return boardService.index();
        }

        [HttpGet("article/all")]
        public List<ArticleListItem> GetArticles()
        {
            return boardService.GetArticles();
        }

        [HttpGet("article/{id}")]
        public ArticleItem GetArticle(long id)
        {
            return boardService.GetArticleItem(id);
        }

        [HttpPost("article/upload")]
        public void Test([FromBody] ArticleUploadRequest request)
        {
            boardService.SetArticle(request);
        }

        //[HttpGet("index")]
        //[HttpGet("article")]
        //[HttpPost("upload")]
        //[HttpPatch("update")]
        //[HttpDelete("delete")]
    }
}

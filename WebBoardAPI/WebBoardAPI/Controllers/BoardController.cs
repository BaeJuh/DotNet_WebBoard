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

        [HttpPost("test")]
        public void Test([FromBody] ArticleUploadRequest request)
        {
            boardService.SetArticleTest(request);
        }

        //[HttpGet("index")]
        //[HttpGet("article")]
        //[HttpPost("upload")]
        //[HttpPatch("update")]
        //[HttpDelete("delete")]
    }
}

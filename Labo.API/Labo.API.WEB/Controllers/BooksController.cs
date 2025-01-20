using Labo.API.Contracts.Models;
using Labo.API.WEB.Services;
using Microsoft.AspNetCore.Mvc;

namespace Labo.API.WEB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        IManagerService BookService { get; init; } = default!;
        public BooksController(IManagerService service)
        { BookService = service; }

        //private readonly ILogger<BooksController> _logger;

        //public BooksController(ILogger<BooksController> logger)// check serilog nugget
        //{
        //    _logger = logger;
        //}
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Books>>> GetBooks()
        {
            return Ok(await BookService.GetAllAsync());
        }

        [HttpGet("find/Books/{BookTitle}")]
        public async Task<ActionResult<Books>> FindBooks(string BookTitle)
        {
            return Ok(await BookService.FindBookAsync(BookTitle));
        }

        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<Books>>> FilterBooks(

            [FromQuery] string? id = null,
            [FromQuery] string? BookTitle = null,
            [FromQuery] string? GenreName = null,
            [FromQuery] string? FirstName = null,
            [FromQuery] string? LastName = null
            )
        {
            return Ok(await BookService.FilterAsync(id, BookTitle, GenreName, FirstName, LastName));

        }
        [HttpPost]
        public async Task<ActionResult<bool>> AddBookAsync(Books book)
        {
            return Ok(await BookService.AddBookAsync(book));
        }
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteBookAsync(string id)
        {
            return Ok(await BookService.DeleteAsync(id));
        }
        [HttpPut("Manage/upsert")]
        public async Task<ActionResult<bool>> UpsertBook(Books book) 
        {
            return Ok(await BookService.UpsertAsync(book));
        }
    }
}
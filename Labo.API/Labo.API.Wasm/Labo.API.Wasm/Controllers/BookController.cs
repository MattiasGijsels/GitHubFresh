using Labo.API.WEB.Services;
using Microsoft.AspNetCore.Mvc;
using Labo.API.Contracts.Models;

namespace Labo.API.Wasm.Controllers
{
    [ApiController]
    [Route ("api/[controller]")]
    public class BookController : ControllerBase
    {
        IManagerService BookService { get; init; } = default!;
        public BookController(IManagerService service)
        { BookService = service; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Books>>> GetBooks()
        {
            return Ok(await BookService.GetAllAsync());
        }
    }
}

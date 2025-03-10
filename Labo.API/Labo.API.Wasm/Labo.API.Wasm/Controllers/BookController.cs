﻿
using Microsoft.AspNetCore.Mvc;
using Labo.API.Contracts.Models;
using Labo.API.Wasm.Shared;

namespace Labo.API.Wasm.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        IManagerService BookService { get; init; } = default!;
        public BookController(IManagerService service)
        { BookService = service; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Books>>> GetBooks()//restrict no searchterm possibilty
        {
            return Ok(await BookService.GetAllAsync());
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
            return Ok(await BookService.FilterAsync(id, BookTitle, GenreName, FirstName, LastName));//restrict no searchterm possibilty

        }
        [HttpGet("find/{data}")]
        public async Task<ActionResult<Books>> FindBooks(string data)
        {
            return Ok(await BookService.FindAsync(data));
        }
        [HttpGet("Get/{BookId}")]
        public async Task<ActionResult<Books>> GetBookId(string BookId)
        {
            return Ok(await BookService.GetByIdAsync(BookId));
        }

    }
}

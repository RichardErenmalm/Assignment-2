using ApplicationLayer.Books.Commands;
using ApplicationLayer.Books.Commands.AddBook;
using ApplicationLayer.Books.Commands.DeleteBook;
using ApplicationLayer.Books.Commands.UpdateBook;
using ApplicationLayer.Books.Querries;
using ApplicationLayer.DTOs.BookDTOs;
using ApplicationLayer.Responses;
using DomainLayer.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace API_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _mediator.Send(new GetAllBooksQuery());

            var result = OperationResult<List<Book>>.Ok(books, "Böcker hämtades.");
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> AddBook([FromBody] BookDTO book)
        {
            var result = await _mediator.Send(new AddBookCommand(book));

            if (result == null)
                return BadRequest(OperationResult<string>.Fail("Boken kunde inte skapas"));

            var response = OperationResult<string>.Ok(result, "Bok skapades");
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBook(int id, UpdateBookCommand command)
        {
            if (id != command.Book.Id) return BadRequest(OperationResult<bool>.Fail("ID i URL matchar inte ID i objektet."));

            var success = await _mediator.Send(command);

            if (!success) return NotFound(OperationResult<bool>.Fail("Boken kunde inte hittas."));

            return Ok(OperationResult<bool>.Ok(true, "Boken uppdaterades."));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            var command = new DeleteBookCommand(id);

            if (id != command.BookId) return BadRequest(OperationResult<bool>.Fail("ID i URL matchar inte kommando-ID."));

            var success = await _mediator.Send(command);

            if (!success) return NotFound(OperationResult<bool>.Fail("Boken kunde inte hittas eller tas bort."));

            return Ok(OperationResult<bool>.Ok(true, "Boken togs bort."));
        }
    }
}

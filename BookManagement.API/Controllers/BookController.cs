using BookManagement.Application.Commands.CreateBook;
using BookManagement.Application.Commands.DeleteBookById;
using BookManagement.Application.Queries.GetAllBooks;
using BookManagement.Application.Queries.GetBookById;
using BookManagement.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.API.Controllers;

[Route("api/v1/books")]
[ApiController]
public class BookController(IMediator mediator) : ControllerBase {
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<OkObjectResult> GetAll() {
        GetAllBooksQuery getAllBooksQuery = new();
        IEnumerable<Book> books = await this._mediator.Send(getAllBooksQuery);
        return this.Ok(books);
    }

    [HttpGet("{bookId}")]
    public async Task<OkObjectResult> GetBookById(int bookId) {
        GetBookByIdQuery getBookByIdQuery = new(bookId);
        Book book = await this._mediator.Send(getBookByIdQuery);
        return this.Ok(book);
    }

    [HttpPost]
    public async Task<CreatedAtActionResult> Create([FromBody] CreateBookCommand command) {
        int bookId = await this._mediator.Send(command);
        return this.CreatedAtAction(nameof(this.GetBookById), new { bookId }, command);
    }

    [HttpDelete("{bookId}")]
    public async Task<NoContentResult> Delete(int bookId) {
        DeleteBookByIdCommand deleteBookByIdCommand = new(bookId);
        await this._mediator.Send(deleteBookByIdCommand);
        return this.NoContent();
    }
}
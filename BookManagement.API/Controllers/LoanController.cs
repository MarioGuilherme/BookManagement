using BookManagement.Application.Commands.CreateLoan;
using BookManagement.Application.Commands.ReturnBook;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.API.Controllers;

[Route("api/v1/loans")]
[ApiController]
public class LoanController(IMediator mediator) : ControllerBase {
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    public async Task<NoContentResult> Create([FromBody] CreateLoanCommand command) {
        await this._mediator.Send(command);
        return this.NoContent();
    }

    [HttpPatch("{loanId}/returnBook")]
    public async Task<NoContentResult> ReturnBook(int loanId) {
        await this._mediator.Send(new ReturnBookCommand(loanId));
        return this.NoContent();
    }
}
using BookManagement.Application.Commands.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.API.Controllers;

[Route("api/v1/users")]
[ApiController]
public class UserController(IMediator mediator) : ControllerBase {
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    public async Task<NoContentResult> Create([FromBody] CreateUserCommand command) {
        await this._mediator.Send(command);
        return this.NoContent();
    }
}
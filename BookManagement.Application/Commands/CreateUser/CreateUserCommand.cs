using MediatR;

namespace BookManagement.Application.Commands.CreateUser;

public class CreateUserCommand(string name, string email) : IRequest<Unit> {
    public string Name { get; private set; } = name;
    public string Email { get; private set; } = email;
}
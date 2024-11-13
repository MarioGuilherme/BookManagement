using BookManagement.Core.Entities;
using BookManagement.Infrastructure.Persistence;
using MediatR;

namespace BookManagement.Application.Commands.CreateUser;

public class CreateUserCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateUserCommand, Unit> {
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken) {
        User user = new(request.Name, request.Email);

        await this._unitOfWork.Users.AddAsync(user);
        await this._unitOfWork.CompleteAsync();

        return Unit.Value;
    }
}
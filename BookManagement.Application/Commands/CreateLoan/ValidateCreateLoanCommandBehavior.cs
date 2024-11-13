using BookManagement.Core.Entities;
using BookManagement.Core.Exceptions;
using BookManagement.Infrastructure.Persistence;
using MediatR;

namespace BookManagement.Application.Commands.CreateLoan;

public class ValidateCreateLoanCommandBehavior(IUnitOfWork unitOfWork) : IPipelineBehavior<CreateLoanCommand, Unit> {
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Unit> Handle(CreateLoanCommand request, RequestHandlerDelegate<Unit> next, CancellationToken cancellationToken) {
        _ = await this._unitOfWork.Books.GetByIdAsync(request.BookId) ?? throw new BookNotFoundException();
        _ = await this._unitOfWork.Users.GetByIdAsync(request.UserId) ?? throw new UserNotFoundException();

        return await next();
    }
}
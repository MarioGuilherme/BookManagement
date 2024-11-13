using BookManagement.Core.Entities;
using BookManagement.Infrastructure.Persistence;
using MediatR;

namespace BookManagement.Application.Commands.CreateLoan;

public class CreateLoanCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateLoanCommand, Unit> {
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Unit> Handle(CreateLoanCommand request, CancellationToken cancellationToken) {
        Loan loan = new(request.UserId, request.BookId, request.ToReturn, request.ReturnedAt);

        await this._unitOfWork.Loans.AddAsync(loan);
        await this._unitOfWork.CompleteAsync();

        return Unit.Value;
    }
}
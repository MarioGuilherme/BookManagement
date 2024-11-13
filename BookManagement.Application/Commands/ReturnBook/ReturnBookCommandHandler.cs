using BookManagement.Application.Notifications.ReturnedBook;
using BookManagement.Core.Entities;
using BookManagement.Core.Exceptions;
using BookManagement.Infrastructure.Persistence;
using MediatR;

namespace BookManagement.Application.Commands.ReturnBook;

public class ReturnBookCommandHandler(IUnitOfWork unitOfWork, IMediator mediator) : IRequestHandler<ReturnBookCommand, Unit> {
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMediator _mediator = mediator;

    public async Task<Unit> Handle(ReturnBookCommand request, CancellationToken cancellationToken) {
        Loan loan = await this._unitOfWork.Loans.GetByIdAsync(request.LoanId) ?? throw new LoanNotFoundException();

        loan.MarkAsReturned();

        await this._unitOfWork.CompleteAsync();

        ReturnedBookNotification returnedBookNotification = new(loan.ToReturn, loan.ReturnedAt);
        await this._mediator.Publish(returnedBookNotification, cancellationToken);

        return Unit.Value;
    }
}
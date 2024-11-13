using MediatR;

namespace BookManagement.Application.Commands.ReturnBook;

public class ReturnBookCommand(int loanId) : IRequest<Unit> {
    public int LoanId { get; private set; } = loanId;
}
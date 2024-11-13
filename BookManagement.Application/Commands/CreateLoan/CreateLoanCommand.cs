using MediatR;

namespace BookManagement.Application.Commands.CreateLoan;

public class CreateLoanCommand(int userId, int bookId, DateTime toReturn, DateTime? returnedAt) : IRequest<Unit> {
    public int UserId { get; private set; } = userId;
    public int BookId { get; private set; } = bookId;
    public DateTime ToReturn { get; private set; } = toReturn;
    public DateTime? ReturnedAt { get; private set; } = returnedAt;
}
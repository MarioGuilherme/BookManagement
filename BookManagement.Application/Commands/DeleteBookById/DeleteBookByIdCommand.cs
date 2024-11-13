using MediatR;

namespace BookManagement.Application.Commands.DeleteBookById;

public class DeleteBookByIdCommand(int bookId) : IRequest<Unit> {
    public int BookId { get; private set; } = bookId;
}
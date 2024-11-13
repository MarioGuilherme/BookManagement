using BookManagement.Core.Entities;
using MediatR;

namespace BookManagement.Application.Queries.GetBookById;

public class GetBookByIdQuery(int bookId) : IRequest<Book> {
    public int BookId { get; private set; } = bookId;
}
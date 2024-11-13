using BookManagement.Core.Entities;
using BookManagement.Core.Exceptions;
using BookManagement.Infrastructure.Persistence;
using MediatR;

namespace BookManagement.Application.Queries.GetBookById;

public class GetBookByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetBookByIdQuery, Book> {
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken) {
        Book book = await this._unitOfWork.Books.GetByIdAsync(request.BookId) ?? throw new BookNotFoundException();
        return book;
    }
}
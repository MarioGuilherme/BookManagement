using BookManagement.Core.Entities;
using BookManagement.Infrastructure.Persistence;
using MediatR;

namespace BookManagement.Application.Queries.GetAllBooks;

public class GetAllBooksQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllBooksQuery, List<Book>> {
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public Task<List<Book>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken) => this._unitOfWork.Books.GetAllAsync();
}
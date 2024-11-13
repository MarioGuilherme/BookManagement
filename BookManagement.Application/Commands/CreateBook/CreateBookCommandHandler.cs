using BookManagement.Core.Entities;
using BookManagement.Infrastructure.Persistence;
using MediatR;

namespace BookManagement.Application.Commands.CreateBook;

public class CreateBookCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateBookCommand, int> {
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken) {
        Book book = new(request.Title, request.Author, request.ISBN, request.PublishYear);

        await this._unitOfWork.Books.AddAsync(book);
        await this._unitOfWork.CompleteAsync();

        return book.Id;
    }
}
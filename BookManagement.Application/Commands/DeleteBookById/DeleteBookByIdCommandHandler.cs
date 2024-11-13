using BookManagement.Core.Entities;
using BookManagement.Core.Exceptions;
using BookManagement.Infrastructure.Persistence;
using MediatR;

namespace BookManagement.Application.Commands.DeleteBookById;

public class DeleteBookByIdCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteBookByIdCommand, Unit> {
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Unit> Handle(DeleteBookByIdCommand request, CancellationToken cancellationToken) {
        Book book = await this._unitOfWork.Books.GetByIdAsync(request.BookId) ?? throw new BookNotFoundException();
        if (await this._unitOfWork.Loans.HavePendentLoanByBookIdAsync(book.Id)) throw new BookWithPendentLoanException();

        this._unitOfWork.Books.Delete(book);
        await this._unitOfWork.CompleteAsync();

        return Unit.Value;
    }
}
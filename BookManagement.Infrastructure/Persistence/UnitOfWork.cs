using BookManagement.Core.Persistence.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace BookManagement.Infrastructure.Persistence;

public class UnitOfWork(
    BookManagerDbContext dbContext,
    IUserRepository users,
    IBookRepository books,
    ILoanRepository loans
) : IUnitOfWork {
    private readonly BookManagerDbContext _dbContext = dbContext;

    public IUserRepository Users => users;

    public IBookRepository Books => books;

    public ILoanRepository Loans => loans;

    public Task<int> CompleteAsync() => this._dbContext.SaveChangesAsync();

    public void Dispose() {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing) {
        if (disposing)
            this._dbContext.Dispose();
    }
}
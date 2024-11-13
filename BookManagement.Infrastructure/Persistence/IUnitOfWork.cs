using BookManagement.Core.Persistence.Repositories;

namespace BookManagement.Infrastructure.Persistence;

public interface IUnitOfWork : IDisposable {
    IUserRepository Users { get; }
    IBookRepository Books { get; }
    ILoanRepository Loans { get; }
    Task<int> CompleteAsync();
}
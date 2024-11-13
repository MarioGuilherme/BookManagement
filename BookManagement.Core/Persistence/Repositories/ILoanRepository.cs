using BookManagement.Core.Entities;

namespace BookManagement.Core.Persistence.Repositories;

public interface ILoanRepository {
    Task AddAsync(Loan loan);
    Task<Loan?> GetByIdAsync(int loanId);
    Task<bool> HavePendentLoanByBookIdAsync(int bookId);
    Task<int> CompleteAsync();
}
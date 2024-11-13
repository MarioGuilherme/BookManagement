using BookManagement.Core.Entities;
using BookManagement.Core.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Infrastructure.Persistence.Repositories;

public class LoanRepository(BookManagerDbContext dbContext) : ILoanRepository {
    private readonly BookManagerDbContext _dbContext = dbContext;

    public async Task AddAsync(Loan loan) {
        await this._dbContext.Loans.AddAsync(loan);
    }

    public Task<Loan?> GetByIdAsync(int loanId) => this._dbContext.Loans.FirstOrDefaultAsync(l => l.Id == loanId);

    public Task<bool> HavePendentLoanByBookIdAsync(int bookId) => this._dbContext.Loans.AnyAsync(l => l.BookId == bookId && l.ReturnedAt == null);

    public Task<int> CompleteAsync() => this._dbContext.SaveChangesAsync();
}
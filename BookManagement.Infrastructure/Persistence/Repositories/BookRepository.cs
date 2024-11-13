using BookManagement.Core.Entities;
using BookManagement.Core.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Infrastructure.Persistence.Repositories;

public class BookRepository(BookManagerDbContext dbContext) : IBookRepository {
    private readonly BookManagerDbContext _dbContext = dbContext;

    public async Task AddAsync(Book book) {
        await this._dbContext.Books.AddAsync(book);
    }

    public void Delete(Book book) => this._dbContext.Books.Remove(book);

    public Task<List<Book>> GetAllAsync() => this._dbContext.Books.AsNoTracking().ToListAsync();

    public Task<Book?> GetByIdAsync(int bookId) => this._dbContext.Books.FirstOrDefaultAsync(b => b.Id == bookId);
}
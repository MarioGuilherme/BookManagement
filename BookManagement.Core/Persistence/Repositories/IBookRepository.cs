using BookManagement.Core.Entities;

namespace BookManagement.Core.Persistence.Repositories;

public interface IBookRepository {
    Task AddAsync(Book book);
    void Delete(Book book);
    Task<List<Book>> GetAllAsync();
    Task<Book?> GetByIdAsync(int bookId);
}
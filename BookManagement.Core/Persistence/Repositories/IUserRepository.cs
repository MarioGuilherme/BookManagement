using BookManagement.Core.Entities;

namespace BookManagement.Core.Persistence.Repositories;

public interface IUserRepository {
    Task AddAsync(User user);
    Task<User?> GetByIdAsync(int userId);
}
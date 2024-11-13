using BookManagement.Core.Entities;
using BookManagement.Core.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Infrastructure.Persistence.Repositories;

public class UserRepository(BookManagerDbContext dbContext) : IUserRepository {
    private readonly BookManagerDbContext _dbContext = dbContext;

    public async Task AddAsync(User user) {
        await this._dbContext.Users.AddAsync(user);
    }

    public Task<User?> GetByIdAsync(int userId) => this._dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
}
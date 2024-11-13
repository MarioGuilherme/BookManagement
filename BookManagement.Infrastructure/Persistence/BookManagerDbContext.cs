using BookManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BookManagement.Infrastructure.Persistence;

public class BookManagerDbContext(DbContextOptions<BookManagerDbContext> options) : DbContext(options) {
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<Loan> Loans { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}
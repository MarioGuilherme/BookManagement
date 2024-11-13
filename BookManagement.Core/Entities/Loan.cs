namespace BookManagement.Core.Entities;

public class Loan(int userId, int bookId, DateTime toReturn, DateTime? returnedAt) : IEntityBase {
    public int Id { get; private set; }
    public int UserId { get; private set; } = userId;
    public User User { get; private set; } = null!;
    public int BookId { get; private set; } = bookId;
    public Book Book { get; private set; } = null!;
    public DateTime ToReturn { get; private set; } = toReturn;
    public DateTime? ReturnedAt { get; private set; } = returnedAt;

    public void MarkAsReturned() => this.ReturnedAt = DateTime.Now;
}
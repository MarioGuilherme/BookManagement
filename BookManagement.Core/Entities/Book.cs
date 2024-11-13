namespace BookManagement.Core.Entities;

public class Book(string title, string author, string isbn, int publishYear) : IEntityBase {
    public int Id { get; private set; }
    public string Title { get; private set; } = title;
    public string Author { get; private set; } = author;
    public string Isbn { get; private set; } = isbn;
    public int PublishYear { get; private set; } = publishYear;
}
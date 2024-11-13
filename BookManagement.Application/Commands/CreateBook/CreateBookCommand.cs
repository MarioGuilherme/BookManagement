using MediatR;

namespace BookManagement.Application.Commands.CreateBook;

public class CreateBookCommand(string title, string author, string iSBN, int publishYear) : IRequest<int> {
    public string Title { get; private set; } = title;
    public string Author { get; private set; } = author;
    public string ISBN { get; private set; } = iSBN;
    public int PublishYear { get; private set; } = publishYear;
}
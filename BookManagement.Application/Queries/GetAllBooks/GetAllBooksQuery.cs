using BookManagement.Core.Entities;
using MediatR;

namespace BookManagement.Application.Queries.GetAllBooks;

public class GetAllBooksQuery : IRequest<List<Book>> { }
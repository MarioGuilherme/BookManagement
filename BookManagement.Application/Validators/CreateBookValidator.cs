using BookManagement.Application.Commands.CreateBook;
using FluentValidation;

namespace BookManagement.Application.Validators;

public class CreateBookValidator : AbstractValidator<CreateBookCommand> {
    public CreateBookValidator() {
        this.RuleFor(c => c.Title).NotEmpty().WithMessage("É necessário informar o título do livro!");
        this.RuleFor(c => c.Author).NotEmpty().WithMessage("É necessário informar o autor do livro!");
        this.RuleFor(c => c.ISBN).NotEmpty().WithMessage("É necessário informar o ISBN do livro!");
        this.RuleFor(c => c.PublishYear).NotEmpty().WithMessage("É necessário informar o ano de publicação do livro!");
    }
}
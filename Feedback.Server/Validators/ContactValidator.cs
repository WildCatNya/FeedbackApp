using Feedback.Server.Database.Entities;
using Feedback.Server.Validators.Abstract;
using FluentValidation;

namespace Feedback.Server.Validators;

public sealed class ContactValidator : BaseValidator<Contact>
{
    public ContactValidator()
    {
        RuleFor(x => x.IdSubject)
            .GreaterThan(0)
            .WithMessage("Необходимо выбрать тему обращения");

        RuleFor(x => x.IdTopic)
            .GreaterThan(0)
            .WithMessage("Необходимо выбрать предмет обращения");

        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("Фамилия обязательна");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Имя обязательно");

        RuleFor(x => x.StudentGroup)
            .Matches(@"^(([А-Я]{1,3}-?){2}-(\d{2,3}-?){3})|((\d{1,2})?[А-Я]{2,4}-\d{2,3})$")
            .When(x => !string.IsNullOrWhiteSpace(x.StudentGroup))
            .WithMessage("Шифр должен быть как в зачетной книжке");

        RuleFor(x => x.Telephone)
            .Matches(@"\+7\s\d{3}\s(\d{2,3}-?){3}")
            .When(x => !string.IsNullOrWhiteSpace(x.Telephone))
            .WithMessage("Телефон должен быть вида: +7 777 777-77-77");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Почта обязательна")
            .EmailAddress()
            .WithMessage("Неверный адрес почты");

        RuleFor(x => x.Message)
            .NotEmpty()
            .WithMessage("Текст обращения обязателен");
    }
}
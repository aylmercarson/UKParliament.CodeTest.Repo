using FluentValidation;
using UKParliament.CodeTest.Core.Dtos;

namespace UKParliament.CodeTest.Web.Validators
{
    public class PersonDtoValidator : AbstractValidator<PersonDto>
    {
        public PersonDtoValidator()
        {
            RuleFor(person => person.FirstName)
                .NotNull()
                .Length(3, 20);

            RuleFor(person => person.LastName)
                .NotNull()
                .Length(3, 20);

            RuleFor(person => person.Mobile)
                .NotNull()
                .Length(10, 15);

            RuleFor(person => person.Email)
                .NotNull()
                .MaximumLength(35)
                .EmailAddress();

            RuleFor(person => person.DateOfBirth)
                .Must(BeAReasonableDateOfBirth)
                .WithMessage("Invalid Date Of Birth");

            RuleFor(person => person.Department)
                .NotNull()
                .InclusiveBetween(1, 4);
        }

        private bool BeAReasonableDateOfBirth(DateTime date)
        {
            int currentYear = DateTime.Now.Year;
            int dobYear = date.Year;

            if (dobYear <= currentYear && dobYear > (currentYear - 120))
            {
                return true;
            }

            return false;
        }
    }
}

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
                .EmailAddress();

            RuleFor(p => p.DateOfBirth)
                .Must(BeAReasonableDateOfBirth)
                .WithMessage("Invalid {PropertyName}");
        }

        protected bool BeAReasonableDateOfBirth(DateTime date)
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

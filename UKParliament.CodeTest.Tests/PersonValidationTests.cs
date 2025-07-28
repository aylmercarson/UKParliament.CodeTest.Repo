using FluentValidation.TestHelper;
using UKParliament.CodeTest.Tests.TestData;
using UKParliament.CodeTest.Web.Validators;
using Xunit;

namespace UKParliament.CodeTest.Tests
{
    public class PersonValidationTests
    {
        private PersonDtoValidator dtoValidator = new PersonDtoValidator();

        [Fact]
        public void Should_Pass_When_FirstName_Correct_Length()
        {
            var person = TestDataPersons.ValidPersonDtoForValidationTests();
            person.FirstName = "Barney";
            var result = dtoValidator.TestValidate(person);
            result.ShouldNotHaveValidationErrorFor(person => person.FirstName);
        }

        [Fact]
        public void Should_Pass_When_LastName_Correct_Length()
        {
            var person = TestDataPersons.ValidPersonDtoForValidationTests();
            person.LastName = "Rubble";
            var result = dtoValidator.TestValidate(person);
            result.ShouldNotHaveValidationErrorFor(person => person.LastName);
        }

        [Fact]
        public void Should_Pass_When_Email_Correct_Format()
        {
            var person = TestDataPersons.ValidPersonDtoForValidationTests();
            person.Email = "donotreply@donotreply.com";
            var result = dtoValidator.TestValidate(person);
            result.ShouldNotHaveValidationErrorFor(person => person.Email);
        }

        [Fact]
        public void Should_Pass_When_Mobile_Correct_Length()
        {
            var person = TestDataPersons.ValidPersonDtoForValidationTests();
            person.Mobile = "07 123 123 123";
            var result = dtoValidator.TestValidate(person);
            result.ShouldNotHaveValidationErrorFor(person => person.Mobile);
        }

        [Fact]
        public void Should_Pass_When_DateOfBirth_Reasonable()
        {
            var person = TestDataPersons.ValidPersonDtoForValidationTests();
            person.DateOfBirth = new DateTime(1999, 05, 09, 9, 15, 0);
            var result = dtoValidator.TestValidate(person);
            result.ShouldNotHaveValidationErrorFor(person => person.DateOfBirth);
        }

        [Fact]
        public void Should_Error_When_FirstName_is_short()
        {
            var person = TestDataPersons.ValidPersonDtoForValidationTests();
            person.FirstName = "A";
            var result = dtoValidator.TestValidate(person);
            result.ShouldHaveValidationErrorFor(person => person.FirstName);
        }

        [Fact]
        public void Should_Error_When_FirstName_is_long()
        {
            var person = TestDataPersons.ValidPersonDtoForValidationTests();
            person.FirstName = "ThisIsAVeryLongFirstNameThatExceedsTheMaximumLengthAllowed";
            var result = dtoValidator.TestValidate(person);
            result.ShouldHaveValidationErrorFor(person => person.FirstName);
        }


        [Fact]
        public void Should_Error_When_LastName_is_short()
        {
            var person = TestDataPersons.ValidPersonDtoForValidationTests();
            person.LastName = "A";
            var result = dtoValidator.TestValidate(person);
            result.ShouldHaveValidationErrorFor(person => person.LastName);
        }

        [Fact]
        public void Should_Error_When_LastName_is_long()
        {
            var person = TestDataPersons.ValidPersonDtoForValidationTests();
            person.LastName = "ThisIsAVeryLongLastNameThatExceedsTheMaximumLengthAllowed";
            var result = dtoValidator.TestValidate(person);
            result.ShouldHaveValidationErrorFor(person => person.LastName);
        }

        [Fact]
        public void Should_Error_When_Email_Invalid()
        {
            var person = TestDataPersons.ValidPersonDtoForValidationTests();
            person.Email = "invalid-email-format";
            var result = dtoValidator.TestValidate(person);
            result.ShouldHaveValidationErrorFor(person => person.Email);
        }

        [Fact]
        public void Should_Error_When_Mobile_is_short()
        {
            var person = TestDataPersons.ValidPersonDtoForValidationTests();
            person.Mobile = "07 123";
            var result = dtoValidator.TestValidate(person);
            result.ShouldHaveValidationErrorFor(person => person.Mobile);
        }

        [Fact]
        public void Should_Error_When_Mobile_is_long()
        {
            var person = TestDataPersons.ValidPersonDtoForValidationTests();
            person.Mobile = "07 123 123 123 123 123 123 123 123 123 123 123 123";
            var result = dtoValidator.TestValidate(person);
            result.ShouldHaveValidationErrorFor(person => person.Mobile);
        }

        [Fact]
        public void Should_Error_When_DateOfBirth_Unreasonable()
        {
            var person = TestDataPersons.ValidPersonDtoForValidationTests();
            person.DateOfBirth = new DateTime(1899, 05, 09, 9, 15, 0);
            var result = dtoValidator.TestValidate(person);
            result.ShouldHaveValidationErrorFor(person => person.DateOfBirth);
        }
    }
}

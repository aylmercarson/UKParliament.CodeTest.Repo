using System.ComponentModel.DataAnnotations;

namespace UKParliament.CodeTest.Core.Dtos
{
    public class PersonDto
    {
        public Guid Id { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string Email { get; set; }

        public required string Mobile { get; set; }

        public required int Department { get; set; }

        public required DateTime DateOfBirth { get; set; }
    }
}
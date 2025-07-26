using UKParliament.CodeTest.Core.Entities;

namespace UKParliament.CodeTest.Tests.TestData
{
    public static class TestDataDepartments
    {
        public static List<Department> GetTestDepartments()
        {
            var departments = new List<Department>();

            departments.Add(new Department()
            {
                Id = 1,
                Name = "Finance",
            });

            departments.Add(new Department()
            {
                Id = 2,
                Name = "Human Resources"
            });

            departments.Add(new Department()
            {
                Id = 3,
                Name = "Information Technology"
            });

            return departments;
        }
    }
}

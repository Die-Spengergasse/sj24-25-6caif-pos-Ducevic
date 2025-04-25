using System;
using Xunit;
using SPG_Fachtheorie.Aufgabe1.Model;

namespace SPG_Fachtheorie.Aufgabe1.Tests
{
    public class EmployeeTests
    {
        [Theory]
        [InlineData(1, "Anna", "Müller")]
        [InlineData(2, "Bob", "Schmidt")]
        [InlineData(3, "Carla", "Meier")]
        public void Constructor_SetsPropertiesCorrectly(int regNo, string firstName, string lastName)
        {
            var address = new Address
            {
                Street = "Teststraße",
                City = "Teststadt",
                ZipCode = "1234"
            };

            var employee = new TestEmployee(regNo, firstName, lastName, address);

            Assert.Equal(regNo, employee.RegistrationNumber);
            Assert.Equal(firstName, employee.FirstName);
            Assert.Equal(lastName, employee.LastName);
            Assert.Equal(address, employee.Address);
        }
    }
}

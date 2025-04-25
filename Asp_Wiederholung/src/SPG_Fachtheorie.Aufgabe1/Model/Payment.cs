using System;
using Xunit;
using System.Collections.Generic;
using SPG_Fachtheorie.Aufgabe1.Model;

namespace SPG_Fachtheorie.Aufgabe1.Tests
{
    public class PaymentTests
    {
        [Theory]
        [InlineData(2024, 4, 25)]
        [InlineData(2023, 12, 1)]
        [InlineData(2025, 1, 10)]
        public void Constructor_SetsPropertiesCorrectly(int year, int month, int day)
        {
            // Arrange
            var testDate = new DateTime(year, month, day);
            var cashDesk = new CashDesk { Name = "Kasse 1" };
            var employee = new TestEmployee(1, "Anna", "Müller", null);
            var paymentType = new PaymentType { Name = "Barzahlung" };

            // Act
            var payment = new Payment(cashDesk, testDate, employee, paymentType);

            // Assert
            Assert.Equal(cashDesk, payment.CashDesk);
            Assert.Equal(employee, payment.Employee);
            Assert.Equal(paymentType, payment.PaymentType);
            Assert.Equal(testDate, payment.PaymentDateTime);
            Assert.Empty(payment.PaymentItems);
            Assert.Null(payment.Confirmed);
        }
    }
}

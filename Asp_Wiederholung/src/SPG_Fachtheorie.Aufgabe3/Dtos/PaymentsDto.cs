using SPG_Fachtheorie.Aufgabe1.Model;
namespace SPG_Fachtheorie.Aufgabe3.Dtos
{
    public record PaymentsDto(int id, string employeeFirstName,
        string employeeLastName, int cashDeskNumber,
        string paymentType, decimal totalAmount);
}

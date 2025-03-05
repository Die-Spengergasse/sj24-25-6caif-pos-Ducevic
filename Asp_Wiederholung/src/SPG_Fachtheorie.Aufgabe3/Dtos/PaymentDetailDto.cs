// Datei: PaymentDetailDto.java
using SPG_Fachtheorie.Aufgabe3.Dtos;



public record PaymentDetailDto(
    int id,
    String employeeFirstName,
    String employeeLastName,
    int cashDeskNumber,
    String paymentType,
    List<PaymentItemDto> paymentItems
)
{ }

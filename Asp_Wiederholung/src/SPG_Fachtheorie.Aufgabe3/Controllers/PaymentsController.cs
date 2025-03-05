using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPG_Fachtheorie.Aufgabe1.Infrastructure;
using SPG_Fachtheorie.Aufgabe3.Dtos;
using System.Linq;

namespace SPG_Fachtheorie.Aufgabe3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {

        private readonly AppointmentContext _db;

        public PaymentsController(AppointmentContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<List<PaymentsDto>> getPayments()
        {
            var payments = _db.Payments
            .Select(p => new PaymentsDto(
                p.Id, p.Employee.FirstName, p.Employee.LastName,
                p.CashDesk.Number, p.PaymentType.ToString(),
                 p.PaymentItems.Sum(p => p.Price)))
                .ToList();
            return Ok(payments);
        }

        // Neuer Endpoint: Gibt ein Payment mit der angegebenen ID zurück
        [HttpGet("{id}")]
        public ActionResult<PaymentDetailDto> getPaymentById(int id)
        {
            var payment = _db.Payments
                .Where(p => p.Id == id)
                .Select(p => new PaymentDetailDto(
                    p.Id,
                    p.Employee.FirstName,
                    p.Employee.LastName,
                    p.CashDesk.Number,
                    p.PaymentType.ToString(),
                    p.PaymentItems.Select(pi => new PaymentItemDto(
                        pi.ArticleName,
                        pi.Amount,
                        pi.Price
                    )).ToList()
                ))
                .FirstOrDefault();

            if (payment == null)
            {
                return NotFound();
            }

            return Ok(payment);
        }
    }
}

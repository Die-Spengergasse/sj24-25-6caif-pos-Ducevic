using SPG_Fachtheorie.Aufgabe1.Exceptions;
using SPG_Fachtheorie.Aufgabe1.Infrastructure;
using SPG_Fachtheorie.Aufgabe1.Model;
using System.Collections.Generic;
using System;
using System.Linq;
using SPG_Fachtheorie.Aufgabe1.Commands;

public class PaymentService : IPaymentService
{
    private readonly AppointmentContext _db;

    public PaymentService(AppointmentContext db)
    {
        _db = db;
    }

    public Payment CreatePayment(NewPaymentCommand cmd)
    {
        // 1. Prüfen auf offenes Payment
        bool openPaymentExists = _db.Payments
            .Any(p => p.CashDesk.Id == cmd.CashDeskId && p.Confirmed == null);

        if (openPaymentExists)
        {
            throw new PaymentServiceException("Open payment for cashdesk.");
        }

        // 2. Rechte prüfen
        var employee = _db.Employees.FirstOrDefault(e => e.Id == cmd.EmployeeId);
        if (cmd.PaymentType == PaymentTypes.CreditCard && employee is not Manager)
        {
            throw new PaymentServiceException("Insufficient rights to create a credit card payment.");
        }

        // 3. Payment erstellen
        var payment = new Payment
        {
            Amount = cmd.Amount,
            CashDesk = _db.CashDesks.First(cd => cd.Id == cmd.CashDeskId),
            Employee = employee!,
            PaymentItems = new List<PaymentItem>(),
            PaymentType = cmd.PaymentType,
            PaymentDateTime = DateTime.UtcNow,
            Confirmed = null
        };

        _db.Payments.Add(payment);
        _db.SaveChanges();

        return payment;
    }

    public void ConfirmPayment(int paymentId)
    {
        var payment = _db.Payments.FirstOrDefault(p => p.Id == paymentId);

        if (payment == null)
        {
            throw new PaymentServiceException("Payment not found.");
        }

        if (payment.Confirmed != null)
        {
            throw new PaymentServiceException("Payment already confirmed.");
        }

        payment.Confirmed = DateTime.UtcNow;
        _db.SaveChanges();
    }
}
using SPG_Fachtheorie.Aufgabe1.Exceptions;
using SPG_Fachtheorie.Aufgabe1.Infrastructure;
using SPG_Fachtheorie.Aufgabe1.Model;
using System.Collections.Generic;
using System;
using System.Linq;

public class PaymentService : IPaymentService
{
    private readonly AppointmentContext _db;

    public PaymentService(AppointmentContext db)
    {
        _db = db;
    }

    public Payment CreatePayment(NewPaymentCommand cmd)
    {
        // 1. Prüfen auf offenes Payment
        bool openPaymentExists = _db.Payments
            .Any(p => p.CashDesk.Id == cmd.CashDeskId && p.Confirmed == null);

        if (openPaymentExists)
        {
            throw new PaymentServiceException("Open payment for cashdesk.");
        }

        // 2. Rechte prüfen
        var employee = _db.Employees.FirstOrDefault(e => e.Id == cmd.EmployeeId);
        if (cmd.PaymentType == PaymentTypes.CreditCard && employee is not Manager)
        {
            throw new PaymentServiceException("Insufficient rights to create a credit card payment.");
        }

        // 3. Payment erstellen
        var payment = new Payment
        {
            Amount = cmd.Amount,
            CashDesk = _db.CashDesks.First(cd => cd.Id == cmd.CashDeskId),
            Employee = employee!,
            PaymentItems = new List<PaymentItem>(),
            PaymentType = cmd.PaymentType,
            PaymentDateTime = DateTime.UtcNow,
            Confirmed = null
        };

        _db.Payments.Add(payment);
        _db.SaveChanges();

        return payment;
    }

    public void ConfirmPayment(int paymentId)
    {
        var payment = _db.Payments.FirstOrDefault(p => p.Id == paymentId);

        if (payment == null)
        {
            throw new PaymentServiceException("Payment not found.");
        }

        if (payment.Confirmed != null)
        {
            throw new PaymentServiceException("Payment already confirmed.");
        }

        payment.Confirmed = DateTime.UtcNow;
        _db.SaveChanges();
    }

    public void AddPaymentItem(NewPaymentItemCommand cmd)
    {
        var payment = _db.Payments.FirstOrDefault(p => p.Id == cmd.PaymentId);

        if (payment == null)
        {
            throw new PaymentServiceException("Payment not found.");
        }

        if (payment.Confirmed != null)
        {
            throw new PaymentServiceException("Payment already confirmed.");
        }

        var item = new PaymentItem
        {
            ArticleName = cmd.ArticleName,
            Amount = cmd.Amount,
            Price = cmd.Price,
            Payment = payment
        };

        _db.PaymentItems.Add(item);
        _db.SaveChanges();
    }
    public void DeletePayment(int paymentId, bool deleteItems)
    {
        var payment = _db.Payments.FirstOrDefault(p => p.Id == paymentId);

        if (payment == null)
        {
            throw new PaymentServiceException("Payment not found.");
        }

        if (deleteItems)
        {
            var items = _db.PaymentItems.Where(pi => pi.Payment.Id == paymentId).ToList();
            _db.PaymentItems.RemoveRange(items);
        }

        _db.Payments.Remove(payment);
        _db.SaveChanges();
    }



}

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SPG_Fachtheorie.Aufgabe1.Services;

var builder = WebApplication.CreateBuilder(args);

// PaymentService registrieren
builder.Services.AddScoped<IPaymentService, PaymentService>();

var app = builder.Build();

// Einfacher Test-Endpunkt
app.MapGet("/", () => "PaymentService läuft!");

app.Run();

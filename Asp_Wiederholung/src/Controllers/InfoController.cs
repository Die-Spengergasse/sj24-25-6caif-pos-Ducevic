
using Asp_Wiederholung.Services;
using Microsoft.AspNetCore.Mvc;

namespace Asp_Wiederholung.Controllers
{
    public class InfoController : Controller
    {
        private readonly ITimeService _timeService;
        private readonly IGuidService _guidService;
        private readonly ICounterService _counterSingleton;
        private readonly ICounterService _counterScoped;
        private readonly ICounterService _counterTransient;

        public InfoController(
            ITimeService timeService,
            IGuidService guidService,
            [FromKeyedServices("Singleton")] ICounterService counterSingleton,
            [FromKeyedServices("Scoped")] ICounterService counterScoped,
            [FromKeyedServices("Transient")] ICounterService counterTransient)
        {
            _timeService = timeService;
            _guidService = guidService;
            _counterSingleton = counterSingleton;
            _counterScoped = counterScoped;
            _counterTransient = counterTransient;
        }

        public IActionResult Index()
        {
            ViewData["Time"] = _timeService.GetCurrentTime();
            ViewData["Guid"] = _guidService.GetGuid();
            ViewData["Singleton"] = _counterSingleton.GetCount();
            ViewData["Scoped"] = _counterScoped.GetCount();
            ViewData["Transient"] = _counterTransient.GetCount();

            return View();
        }
    }
}

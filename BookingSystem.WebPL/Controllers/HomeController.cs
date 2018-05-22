using BookingSystem.BL.Interfaces;
using System.Web.Mvc;

namespace BookingSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private IAirportService airportService;

        public HomeController(IAirportService service)
        {
            airportService = service;
        }

        public ActionResult Index()
        {
            var airports = airportService.GetAll();
            return View(airports);
        }
    }
}
using BookingSystem.BL.Interfaces;
using BookingSystem.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
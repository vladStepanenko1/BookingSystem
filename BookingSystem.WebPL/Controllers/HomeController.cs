using BookingSystem.BL.DTO;
using BookingSystem.BL.Interfaces;
using BookingSystem.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            IEnumerable<AirportDTO> airportDTOs = airportService.GetAll();
            var airports = airportDTOs.Select(a => new AirportViewModel
            {
                Id = a.Id,
                Name = a.Name,
                Address = a.Address,
                Country = a.Country
            });
            return View(airports);
        }

        public ActionResult Show(int id)
        {
            try
            {
                AirportDTO airportDTO = airportService.Get(id);
                AirportViewModel airport = new AirportViewModel
                {
                    Id = airportDTO.Id,
                    Name = airportDTO.Name,
                    Address = airportDTO.Address,
                    Country = airportDTO.Country
                };
                return View(airport);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Error", ex);
            }
            return View(id);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                AirportDTO airportDTO = airportService.Get(id);
                AirportViewModel airportView = new AirportViewModel { Id = airportDTO.Id, Name = airportDTO.Name,
                    Address = airportDTO.Address, Country = airportDTO.Country };
                return View(airportView);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Error", ex);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(int id, [Bind]AirportViewModel airportView)
        {
            try
            {
                airportService.Edit(airportView.Id, airportView.Name, airportView.Address, airportView.Country);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Error", ex);
            }
            return View(airportView);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                AirportDTO airportDTO = airportService.Get(id);
                AirportViewModel airportView = new AirportViewModel
                {
                    Id = airportDTO.Id,
                    Name = airportDTO.Name,
                    Address = airportDTO.Address,
                    Country = airportDTO.Country
                };
                return View(airportView);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex);
            }
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            try
            {
                airportService.Delete(id);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Error", ex);
            }
            return RedirectToAction("Index");
        }
    }
}
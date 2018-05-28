using BookingSystem.BL.DTO;
using BookingSystem.BL.Interfaces;
using NLog;
using System;
using System.Collections.Generic;

namespace BookingSystem.BL.Services
{
    public class AirportServiceDecorator : IAirportService
    {
        private Logger logger = LogManager.GetCurrentClassLogger();
        private IAirportService service;

        public AirportServiceDecorator(IAirportService airportService)
        {
            service = airportService;
        }

        public virtual void Delete(int id)
        {
            logger.Info($"Delete airport with id = {id}");
            try
            {
                service.Delete(id);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }
        }

        public virtual void Edit(int id, string name, string address, string country)
        {
            logger.Info($"Edit airport with id = {id}");
            try
            {
                service.Edit(id, name, address, country);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }
        }

        public virtual AirportDTO Get(int id)
        {
            logger.Info($"Get airport with id = {id}");
            try
            {
                return service.Get(id);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }
        }

        public virtual IEnumerable<AirportDTO> GetAll()
        {
            logger.Info("GetAll airports");
            return service.GetAll();
        }

        public virtual void Save(int id, string name, string address, string country)
        {
            logger.Info($"Save airport with id = {id}");
            try
            {
                service.Save(id, name, address, country);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }
        }
    }
}

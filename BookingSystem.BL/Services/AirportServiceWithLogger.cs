using System;
using System.Collections.Generic;
using BookingSystem.BL.DTO;
using BookingSystem.BL.Interfaces;
using NLog;

namespace BookingSystem.BL.Services
{
    public class AirportServiceWithLogger : AirportServiceDecorator
    {
        Logger logger = LogManager.GetCurrentClassLogger();

        public AirportServiceWithLogger(IAirportService airportService) : base(airportService)
        {
        }

        public override void Delete(int id)
        {
            logger.Info($"Delete airport with id = {id}");
            try
            {
                base.Delete(id);
            }
            catch(Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }
        }

        public override void Edit(int id, string name, string address, string country)
        {
            logger.Info($"Edit airport with id = {id}");
            try
            {
                base.Edit(id, name, address, country);
            }
            catch(Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }
        }

        public override AirportDTO Get(int id)
        {
            logger.Info($"Get airport with id = {id}");
            try
            {
                return base.Get(id);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }
        }

        public override IEnumerable<AirportDTO> GetAll()
        {
            logger.Info("GetAll airports");
            return base.GetAll();
        }

        public override void Save(int id, string name, string address, string country)
        {
            logger.Info($"Save airport with id = {id}");
            try
            {
                base.Save(id, name, address, country);
            }
            catch(Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }
        }
    }
}

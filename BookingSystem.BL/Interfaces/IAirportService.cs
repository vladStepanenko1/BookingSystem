using BookingSystem.BL.DTO;
using System.Collections.Generic;

namespace BookingSystem.BL.Interfaces
{
    /// <summary>
    /// The AirportService interface
    /// </summary>
    public interface IAirportService
    {
        /// <summary>
        /// Saves airport to storage with specified parameters
        /// </summary>
        /// <param name="id">Unique value</param>
        /// <param name="name">Represents the name of airport</param>
        /// <param name="address">Represents the address of airport</param>
        /// <param name="country">Represents the country where airport located</param>
        /// <exception cref="System.Exception">Throws when airport with specified id already exists in storage</exception>
        void Save(int id, string name, string address, string country);

        /// <summary>
        /// Retrieves airport from storage with specified id
        /// </summary>
        /// <param name="id">Unique parameter</param>
        /// <returns>Airport data transfer object</returns>
        AirportDTO Get(int id);

        /// <summary>
        /// Retrieves all airports from storage
        /// </summary>
        /// <returns>All Airports</returns>
        IEnumerable<AirportDTO> GetAll();

        /// <summary>
        /// Edits airport in storage with specified parameters
        /// </summary>
        /// <param name="id">Unique value</param>
        /// <param name="name">Represents the name of airport</param>
        /// <param name="address">Represents the address of airport</param>
        /// <param name="country">Represents the country where airport located</param>
        /// <exception cref="System.Exception">Throws when airport with specified id not found in storage</exception>
        void Edit(int id, string name, string address, string country);

        /// <summary>
        /// Deletes airport from storage with specified id
        /// </summary>
        /// <param name="id">Unique parameter for identifying airport</param>
        /// /// <exception cref="System.Exception">Throws when airport with specified id not found in storage</exception>
        void Delete(int id);
    }
}

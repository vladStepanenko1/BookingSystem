using BookingSystem.DAL.Domain;
using BookingSystem.DAL.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BookingSystem.DAL.Repositories
{
    public class AdoNetAirportRepository : IRepository<Airport>
    {
        private SqlConnection connection;

        public AdoNetAirportRepository(string connectionString)
        {
            connection = new SqlConnection(connectionString);
        }

        public void Add(Airport entity)
        {
            string sql = "insert into Airports (Name, Address, Country) values (@Name, @Address, @Country)";
            connection.Open();
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                SqlParameter parameter = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = entity.Name,
                    SqlDbType = SqlDbType.Char,
                    Size = 20
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@Address",
                    Value = entity.Address,
                    SqlDbType = SqlDbType.Char,
                    Size = 20
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@Country",
                    Value = entity.Country,
                    SqlDbType = SqlDbType.Char,
                    Size = 20
                };
                command.Parameters.Add(parameter);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public Airport Get(int id)
        {
            string sql = "select * from Airports where Id = @Id";
            Airport airport = null;
            connection.Open();
            using(SqlCommand command = new SqlCommand(sql, connection))
            {
                SqlParameter parameter = new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = id,
                    SqlDbType = SqlDbType.Int,
                };
                command.Parameters.Add(parameter);

                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    int airportId = (int)dataReader["Id"];
                    string name = (string)dataReader["Name"];
                    string address = (string)dataReader["Address"];
                    string country = (string)dataReader["Country"];
                    airport = new Airport(airportId, name, address, country);
                }
                dataReader.Close();
            }
            connection.Close();
            return airport;
        }

        public List<Airport> GetAll()
        {
            string sql = "select * from Airports";
            List<Airport> airports = new List<Airport>();
            connection.Open();
            using(SqlCommand command = new SqlCommand(sql, connection))
            {
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    int airportId = (int)dataReader["Id"];
                    string name = (string)dataReader["Name"];
                    string address = (string)dataReader["Address"];
                    string country = (string)dataReader["Country"];
                    Airport airport = new Airport(airportId, name, address, country);
                    airports.Add(airport);
                }
                dataReader.Close();
            }
            connection.Close();
            return airports;
        }

        public void Remove(int id)
        {
            string sql = "delete from Airports where Id = @Id";
            connection.Open();
            using(SqlCommand command = new SqlCommand(sql, connection))
            {
                SqlParameter parameter = new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = id,
                    SqlDbType = SqlDbType.Int,
                };
                command.Parameters.Add(parameter);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public void Update(Airport entity)
        {
            string sql = "update Airports set Name = @Name, Address = @Address, Country = @Country where Id = @Id";
            connection.Open();
            using(SqlCommand command = new SqlCommand(sql, connection))
            {
                SqlParameter parameter = new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = entity.Id,
                    SqlDbType = SqlDbType.Int,
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = entity.Name,
                    SqlDbType = SqlDbType.Char,
                    Size = 20
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@Address",
                    Value = entity.Address,
                    SqlDbType = SqlDbType.Char,
                    Size = 20
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@Country",
                    Value = entity.Country,
                    SqlDbType = SqlDbType.Char,
                    Size = 20
                };
                command.Parameters.Add(parameter);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }
}

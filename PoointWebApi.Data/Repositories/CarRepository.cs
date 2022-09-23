using MySql.Data.MySqlClient;
using PoointWebApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace PoointWebApi.Data.Repositories
{
    public class CarRepository : ICarRepository
    {
        private MySQLConfiguration _connectionString;
        public CarRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<Car>> GetAllCars()
        {
            var db = dbConnection();

            var sql = @"select id, make, model, color, year, doors from cars";

            return await db.QueryAsync<Car>(sql, new { });
        }

        public async Task<Car> GetCardDetails(int id)
        {
            var db = dbConnection();

            var sql = @"select id, make, model, color, year, doors from cars where id = @Id";

            return await db.QueryFirstOrDefaultAsync<Car>(sql, new { Id = id });
        }

        public async Task<bool> InsertCar(Car car)
        {
            var db = dbConnection();

            var sql = @"insert into cars (make, model, color, year, doors) 
                        values (@Make, @Model, @Color, @Year, @Doors) ";

            var result = await db.ExecuteAsync(sql, new { car.Make, car.Model, car.Color, car.Year, car.Doors });

            return result > 0; 
        }

        public async Task<bool> UpdateCar(Car car)
        {
            var db = dbConnection();

            var sql = @"update cars set make = @Make, model = @Model, color = @Color, year = @Year, doors = @Doors  
                        where id = @Id ";

            var result = await db.ExecuteAsync(sql, new { car.Make, car.Model, car.Color, car.Year, car.Doors, car.Id });

            return result > 0;
        }

        public async Task<bool> DeleteCar(Car car)
        {
            var db = dbConnection();

            var sql = @"delete from cars where id = @Id";

            var result = await db.ExecuteAsync(sql, new { Id = car.Id });
            return result > 0;
        }
    }
}

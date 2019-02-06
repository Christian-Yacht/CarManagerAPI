using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIassignment2.Domein;
using APIassignment2.Models;
using APIassignment2.Business;
using APIassignment2.Interfaces;

namespace APIassignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IProcessable<Car> _processable;

        public CarsController(IProcessable<Car> processable)
        {
            _processable = processable;
        }

        // GET: api/Cars
        [HttpGet]
        public IEnumerable<Car> GetCars()
        {
            return _processable.GetData();
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public Task<Car> GetCarsById(int id)
        {
            return _processable.GetDataById(id);
        }

        // ADD: api/Cars/5
        [HttpPut]
        public Task AddCar(Car car)
        {
            return _processable.AddData(car);
        }

        // UPDATE: api/Cars
        [HttpPost]
        public Task UpdateCar(int id, Car car)
        {
            return _processable.UpdateData(id, car);
        }

        // DELETE: api/Cars/5
        [HttpDelete]
        public Task<Car> DeleteCar(int id)
        {
            return _processable.DeleteData(id);
        }
    }
}
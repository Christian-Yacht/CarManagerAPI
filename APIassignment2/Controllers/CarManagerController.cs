using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIassignment2.Domein;
using APIassignment2.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIassignment2.Controllers
{
    [Route("api/[controller]")]
    public class CarManagerController : Controller
    {
        private Assignment2_DbContext _context;
        public CarManagerController(Assignment2_DbContext context)
        {
            _context = context;
        }

        [HttpGet("cars")]
        public List<Car> GetCars()
        {
            return _context.Cars.ToList();
        }

        [HttpGet("Users")]
        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        [HttpGet("Companies")]
        public List<Company> GetCompanies()
        {
            return _context.Companies.ToList();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
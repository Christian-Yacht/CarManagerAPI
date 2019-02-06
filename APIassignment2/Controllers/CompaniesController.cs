using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIassignment2.Domein;
using APIassignment2.Models;

namespace APIassignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly Assignment2_DbContext _context;

        public CompaniesController(Assignment2_DbContext context)
        {
            _context = context;
        }

        // GET: api/Companies
        [HttpGet("Companies")]
        public IEnumerable<Company> GetCompanies()
        {
            return _context.Companies;
        }

        // GET: api/Cars
        [HttpGet("{CompanyName}")]
        public IEnumerable<Car> GetCarsByCompany(string CompanyName)
        {
            return _context.Cars.Where(x => CompanyName == x.CarCompanyName);
            // geeft alle info van de auto, hoe alleen CompanyName?
            // "including the current user"
        }

        // GET: api/Cars
        [HttpGet("ordered/{CompanyName}")]
        public IEnumerable<Car> GetOrderedCarsByCompany(string CompanyName)
        {
            return _context.Cars.Where(x => CompanyName == x.CarCompanyName).OrderBy(Car => Car.Make);
            
            // OrderedCars = ^^
            // return OrderedCars.ToList().GetRange(x, x + 19);

            // _context.Car.Make
        }

        // GET: api/Companies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompany([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var company = await _context.Companies.FindAsync(id);

            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        // PUT: api/Companies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany([FromRoute] string id, [FromBody] Company company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != company.Name)
            {
                return BadRequest();
            }

            _context.Entry(company).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Companies
        [HttpPost]
        public async Task<IActionResult> PostCompany([FromBody] Company company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Companies.Add(company);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompany", new { id = company.Name }, company);
        }

        // DELETE: api/Companies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var company = await _context.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();

            return Ok(company);
        }

        private bool CompanyExists(string id)
        {
            return _context.Companies.Any(e => e.Name == id);
        }
    }
}
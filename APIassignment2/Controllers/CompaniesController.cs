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
    public class CompaniesController : ControllerBase
    {
        private readonly IProcessable<Company> _processable;

        public CompaniesController(IProcessable<Company> processable)
        {
            _processable = processable;
        }

        // GET: api/Companies
        [HttpGet]
        public IEnumerable<Company> GetCompanies()
        {
            return _processable.GetData();
        }

        // GET: api/Companies/5
        [HttpGet("{id}")]
        public Task<Company> GetCompaniesById(int id)
        {
            return _processable.GetDataById(id);
        }

        // ADD: api/Companies/5
        [HttpPut]
        public Task AddCompany(Company Company)
        {
            return _processable.AddData(Company);
        }

        // UPDATE: api/Companies
        [HttpPost]
        public Task UpdateCompany(int id, Company Company)
        {
            return _processable.UpdateData(id, Company);
        }

        // DELETE: api/Companies/5
        [HttpDelete]
        public Task<Company> DeleteCompany(int id)
        {
            return _processable.DeleteData(id);
        }
    }
}
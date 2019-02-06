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
    public class UsersController : ControllerBase
    {
        private readonly IProcessable<User> _processable;

        public UsersController(IProcessable<User> processable)
        {
            _processable = processable;
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return _processable.GetData();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public Task<User> GetUsersById(int id)
        {
            return _processable.GetDataById(id);
        }

        // ADD: api/Users/5
        [HttpPut]
        public Task AddUser(User User)
        {
            return _processable.AddData(User);
        }

        // UPDATE: api/Users
        [HttpPost]
        public Task UpdateUser(int id, User User)
        {
            return _processable.UpdateData(id, User);
        }

        // DELETE: api/Users/5
        [HttpDelete]
        public Task<User> DeleteUser(int id)
        {
            return _processable.DeleteData(id);
        }
    }
}
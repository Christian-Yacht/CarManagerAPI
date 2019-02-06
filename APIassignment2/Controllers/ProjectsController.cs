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
    public class ProjectsController : ControllerBase
    {
        private readonly IProcessable<Project> _processable;

        public ProjectsController(IProcessable<Project> processable)
        {
            _processable = processable;
        }

        // GET: api/Projects
        [HttpGet]
        public IEnumerable<Project> GetProjects()
        {
            return _processable.GetData();
        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public Task<Project> GetProjectsById(int id)
        {
            return _processable.GetDataById(id);
        }

        // ADD: api/Projects/5
        [HttpPut]
        public Task AddProject(Project Project)
        {
            return _processable.AddData(Project);
        }

        // UPDATE: api/Projects
        [HttpPost]
        public Task UpdateProject(int id, Project Project)
        {
            return _processable.UpdateData(id, Project);
        }

        // DELETE: api/Projects/5
        [HttpDelete]
        public Task<Project> DeleteProject(int id)
        {
            return _processable.DeleteData(id);
        }
    }
}
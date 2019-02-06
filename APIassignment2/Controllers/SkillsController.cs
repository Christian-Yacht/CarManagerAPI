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
    public class SkillsController : ControllerBase
    {
        private readonly IProcessable<Skill> _processable;

        public SkillsController(IProcessable<Skill> processable)
        {
            _processable = processable;
        }

        // GET: api/Skills
        [HttpGet]
        public IEnumerable<Skill> GetSkills()
        {
            return _processable.GetData();
        }

        // GET: api/Skills/5
        [HttpGet("{id}")]
        public Task<Skill> GetSkillsById(int id)
        {
            return _processable.GetDataById(id);
        }

        // ADD: api/Skills/5
        [HttpPut]
        public Task AddSkill(Skill Skill)
        {
            return _processable.AddData(Skill);
        }

        // UPDATE: api/Skills
        [HttpPost]
        public Task UpdateSkill(int id, Skill Skill)
        {
            return _processable.UpdateData(id, Skill);
        }

        // DELETE: api/Skills/5
        [HttpDelete]
        public Task<Skill> DeleteSkill(int id)
        {
            return _processable.DeleteData(id);
        }
    }
}
using APIassignment2.Domein;
using APIassignment2.Interfaces;
using APIassignment2.Models;
using APIassignment2.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIassignment2.Business
{
    public class B_Skill : Processable<Skill, int>, IProcessable<Skill>
    {

        public B_Skill(Assignment2_DbContext context) : base(context)
        {
        }

        public Task AddSkill(Skill Skill)
        {
            return this.AddData(Skill);
        }

        public Task<Skill> DeleteSkill(int id)
        {
            return this.DeleteData(id);
        }

        public IEnumerable<Skill> GetSkill()
        {
            return this.GetData();
        }

        public Task<Skill> GetSkill(int id)
        {
            return this.GetDataById(id);
        }

        public Task UpdateSkill(int id, Skill Skill)
        {
            return this.UpdateData(id, Skill);
        }
    }
}

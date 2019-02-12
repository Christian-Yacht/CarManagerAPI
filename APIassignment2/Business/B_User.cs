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
using APIassignment2.Exceptions;

namespace APIassignment2.Business
{
    public class B_User : Processable<User, int>, IProcessable<User>
    {

        public B_User(Assignment2_DbContext context) : base(context)
        {
        }

        public Task AddUser(User User)
        {
            return this.AddData(User);
        }

        public Task<User> DeleteUser(int id)
        {
            return this.DeleteData(id);
        }

        public IEnumerable<User> GetUser()
        {
            return this.GetData();
        }

        // override zodat je bij het ophalen van Users ook de one-to-many lijsten (cars) mee krijgt
        public override async Task<User> GetDataById(int id)
        {
            var data = await _context.Set<User>().Include(x => x.Cars).FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (data == null)
            {
                throw new DataNotFoundException();
            }

            return data;
            //return await base._context.Set<User>().Include(x => x.Cars).Include(x => x.UserSkills).FirstOrDefaultAsync(x => x.Id == id);

            //return this.GetDataById(id);

        }

        public Task UpdateUser(int id, User User)
        {
            return this.UpdateData(id, User);
        }
    }
}

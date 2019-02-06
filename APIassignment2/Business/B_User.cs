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

        public Task<User> GetUser(int id)
        {
            return this.GetDataById(id);
        }

        public Task UpdateUser(int id, User User)
        {
            return this.UpdateData(id, User);
        }
    }
}

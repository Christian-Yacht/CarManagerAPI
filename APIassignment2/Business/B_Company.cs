﻿using APIassignment2.Domein;
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
    public class B_Company : Processable<Company, int>, IProcessable<Company>
    {

        public B_Company(Assignment2_DbContext context) : base(context)
        {
        }

        public Task AddCompany(Company Company)
        {
            return this.AddData(Company);
        }

        public Task<Company> DeleteCompany(int id)
        {
            return this.DeleteData(id);
        }

        public IEnumerable<Company> GetCompany()
        {
            return this.GetData();
        }

        public async Task<Company> GetCompany(int id)
        {
            //return this.GetDataById(id);

            var data = await _context.Set<Company>().Include(x => x.ListOfCars).FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (data == null)
            {
                throw new DataNotFoundException();
            }

            return data;
        }

        public Task UpdateCompany(int id, Company Company)
        {
            return this.UpdateData(id, Company);
        }
    }
}

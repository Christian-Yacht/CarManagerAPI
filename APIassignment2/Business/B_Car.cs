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
    public class B_Car : Processable<Car, int>, IProcessable<Car>
    {

        public B_Car(Assignment2_DbContext context) : base(context)
        {
        }

        public Task AddCar(Car Car)
        {
            return this.AddData(Car);
        }

        public Task<Car> DeleteCar(int id)
        {
            return this.DeleteData(id);
        }

        public IEnumerable<Car> GetCar()
        {
            return this.GetData();
        }

        public async override Task<Car> GetDataById(int id)
        {
            var data = await _context.Set<Car>().Include(x => x.CarCompany).Include(x => x.CarUser).FirstOrDefaultAsync(x => x.Id.Equals(id));

            if(data == null)
            {
                throw new DataNotFoundException();
            }

            return data;
            //return this.GetDataById(id);
        }

        public Task UpdateCar(int id, Car Car)
        {
            return this.UpdateData(id, Car);
        }
    }
}

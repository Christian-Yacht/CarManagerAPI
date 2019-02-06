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

        public Task<Car> GetCar(int id)
        {
            return this.GetDataById(id);
        }

        public Task UpdateCar(int id, Car Car)
        {
            return this.UpdateData(id, Car);
        }
    }
}

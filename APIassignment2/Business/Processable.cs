using APIassignment2.Interfaces;
using APIassignment2.Domein;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIassignment2.Models;
using APIassignment2.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace APIassignment2.Business
{
    public abstract class Processable<T, TId> where T : BaseDomain<TId>
    {
        public readonly Assignment2_DbContext _context;

        public Processable(Assignment2_DbContext context)
        {
            _context = context;
        }

        public async Task AddData(T t)
        {
            _context.Set<T>().Add(t);
            await _context.SaveChangesAsync();
        }

        public async Task<T> DeleteData(int id)
        {

            var data = await _context.Set<T>().FindAsync(id);
            if (data == null)
            {
                throw new DataNotFoundException();
            }

            _context.Set<T>().Remove(data);
            await _context.SaveChangesAsync();

            return data;
        }

        public IEnumerable<T> GetData()
        {
            return _context.Set<T>();
        }

        public virtual async Task<T> GetDataById(int id)
        {
            var data = await _context.Set<T>().FindAsync(id);

            if (data == null)
            {
                throw new DataNotFoundException();
            }

            return data;

            // idris' methode:
            // return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        

        public async Task UpdateData(int id, T t)
        {
            _context.Entry(t).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DataExists(id))
                {
                    throw new DataNotFoundException();
                }
                else
                {
                    throw;
                }
            }
        }

        public bool DataExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}

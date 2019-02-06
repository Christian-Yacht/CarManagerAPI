using APIassignment2.Domein;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIassignment2.Business
{
    public class B_Project : IProject
    {
        private readonly Assignment2_DbContext _context;

        public B_Project(Assignment2_DbContext context)
        {
            _context = context;
        } 
    }

    public interface IProject
    {

    }

    // from idris's repo
    //public interface IProject
    //{
    //    IEnumerable<Project> GetData();
    //    Task<Project> GetDataById(int id);
    //    Task UpdateData(int id, Project t);
    //    Task AddData(Project t);
    //    Task<Project> DeleteData(int id);
    //}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyProject.Models.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object EmployeeID);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object EmployeeID);
        void Save();
    }
}
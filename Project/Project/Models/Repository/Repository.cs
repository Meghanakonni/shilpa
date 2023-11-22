using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Project.Models;

namespace Project.Models.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        RegisterContext pc;
        DbSet<T> dbset;
        public Repository()
        {
            pc = new RegisterContext();
            dbset = pc.Set<T>();
        }

        //Implementation of Interface Methods
        public IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }

        public T GetById(object Id)
        {
            return dbset.Find(Id);
        }

        public void Insert(T obj)
        {
            dbset.Add(obj);
        }

        public void Update(T obj)
        {
            pc.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object Id)
        {
            T getModel = dbset.Find(Id);
            dbset.Remove(getModel);
        }
        public void Save()
        {
            pc.SaveChanges();
        }
    }
}
using ClientService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClientService.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        //T Get(long id);
        int Insert(T entity);
        int Update(T entity);
        int Delete(T entity);
    }

    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDBContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;
        public Repository(AppDBContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }
        //public T Get(long id)
        //{
        //    return entities.Where(s => s.Id == id);
        //}

        public int Insert(T entity)
        {
            entities.Add(entity);
            int res = context.SaveChanges();
            return res;
        }
        public int Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(entity.ToString());
            }
            entities.Update(entity);
            int res = context.SaveChanges();
            return res;
        }
        public int Delete(T entity)
        {
            //var entity = entities.Where(obj=>obj.id == id);
            int res = 0;
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            res = context.SaveChanges();
            return res;
        }

        //public int DeleteAuditProfile(int id)
        //{
        //    int res = 0;
        //    var auditProfile = entities.AuditProfiles.FirstOrDefault(b => b.Id == id);
        //    if (auditProfile != null)
        //    {
        //        ctx.AuditProfiles.Remove(auditProfile);
        //        res = ctx.SaveChanges();
        //    }
        //    return res;
        //}

    }
}

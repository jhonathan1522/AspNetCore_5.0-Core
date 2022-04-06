using Microsoft.EntityFrameworkCore;
using AspNetCore.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCore.DataAccess
{
    public class DbContext<T> : IDbContext<T> where T : class,IEntity
    {

        private readonly DbSet<T> _items;
        private readonly ApiDbContext _ctx;


        public DbContext(ApiDbContext ctx)
        {
            _ctx = ctx;
            _items = ctx.Set<T>();
        }

        public void Delete(int id)
        {
        }

        public IList<T> GetAll()
        {
            return _items.ToList();
        }

        public T GetById(int id)
        {
            return _items.Where(i => i.Id.Equals(id)).FirstOrDefault();
        }

        public T Save(T entity)
        {
            _items.Add(entity);
            _ctx.SaveChanges();
            return entity;
        }
    }
}

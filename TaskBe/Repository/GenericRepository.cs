using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskBe.Models;
using TaskBe.Services;

namespace TaskBe.Repository
{
    public class GenericRepository<Entity, TContext, TId> : IGenericRepository<Entity, TId>
        where Entity : class
        where TContext : Context
    {

        private readonly Context context;

        public GenericRepository(Context context)
        {
            this.context = context;
        }

        public int Delete(TId Id)
        {
            var deleted = GetById(Id);
            context.Set<Entity>().Remove(deleted);
            var result = context.SaveChanges();
            return result;
        }

        public virtual IEnumerable<Entity> GetAll()
        {
            var getAll = context.Set<Entity>().ToList();
            return getAll;
        }

        public virtual Entity GetById(TId Id)
        {
            var getById = context.Set<Entity>().Find(Id);
            return getById;
        }

        public int Post(Entity entity)
        {
            context.Set<Entity>().Add(entity);
            var result = context.SaveChanges();
            return result;
        }

        public int Put(Entity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            var result = context.SaveChanges();
            return result;
        }
    }
}

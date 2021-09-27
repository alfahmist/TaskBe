using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskBe.Services
{
    public interface IGenericRepository<Entity, TId> where Entity : class
    {
        IEnumerable<Entity> GetAll();
        Entity GetById(TId Id);
        int Post(Entity entity);
        int Put(Entity entity);
        int Delete(TId Id);
    }
}

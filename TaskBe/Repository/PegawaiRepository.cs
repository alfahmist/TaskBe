using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskBe.Models;

namespace TaskBe.Repository
{
    public class PegawaiRepository : GenericRepository<Pegawai, Context, int>
    {
        private readonly Context context;
        public PegawaiRepository(Context context) : base(context)
        {
            this.context = context;
        }

        public override IEnumerable<Pegawai> GetAll()
        {
            var getAll = context.Set<Pegawai>().Include(p => p.Unit);
            return getAll;
        }

        public override Pegawai GetById(int id)
        {
            var get = context.Set<Pegawai>().Include(p => p.Unit).Where(p=> p.Id == id).FirstOrDefault();
            return get;
        }

        public Pegawai GetByName(string name)
        {
            var get = context.Set<Pegawai>().First(p=>p.Name == name);
            return get;
        }
    }
}

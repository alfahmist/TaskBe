using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskBe.Models;

namespace TaskBe.Repository
{
    public class UnitRepository : GenericRepository<Unit, Context, int>
    {
        public UnitRepository(Context context) : base(context)
        {
        }
    }
}

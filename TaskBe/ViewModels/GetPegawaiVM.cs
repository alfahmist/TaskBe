using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskBe.ViewModels
{
    public class GetPegawaiVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GetUnitVM Unit { get; set; }
        public DateTime? Created_at { get; set; }
        public string Created_by { get; set; }
        public bool? Isactive { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskBe.Models
{
    public class Pegawai
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Unit_id { get; set; }
        [ForeignKey("Unit_id")]
        public Unit Unit { get; set; }
        public DateTime? Created_at { get; set; }
        public string Created_by { get; set; }
        public bool? Isactive { get; set; }
        public DateTime? Update_at { get; set; }
        public string Update_by { get; set; }
        [DefaultValue(false)]
        public bool Isdelete { get; set; }
        public string Password { get; set; }
    }
}

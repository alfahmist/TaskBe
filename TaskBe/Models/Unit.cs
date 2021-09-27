using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TaskBe.Models
{
    public class Unit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime? Created_at { get; set; }
        public string Created_by { get; set; }
        public bool? Isactive { get; set; }
        public DateTime? Update_at { get; set; }
        public string Update_by { get; set; }
        [DefaultValue(false)]
        public bool Isdelete { get; set; }
        [JsonIgnore]
        public ICollection<Pegawai> Pegawais { get; set; }
    }
}

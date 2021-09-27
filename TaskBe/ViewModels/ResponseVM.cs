using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskBe.ViewModels
{
    public class ResponseVM
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int Total_data { get; set; }
        public Object Data { get; set; }
    }
}

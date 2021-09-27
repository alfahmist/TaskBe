using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskBe.ViewModels
{
    public class PaginationVM
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public PaginationVM()
        {
            this.PageNumber = 1;
            this.PageSize = 100;
        }
        public PaginationVM(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize <= 100 ? pageSize : 100;
        }
    }
}

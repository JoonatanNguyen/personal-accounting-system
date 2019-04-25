using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Accounting_System_WPFApp.Dtos
{
    class CategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int FinancialTypeId { get; set; }

        public DateTime DisableTime { get; set; }
    }
}

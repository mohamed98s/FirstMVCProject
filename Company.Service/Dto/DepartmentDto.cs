using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Data.Models;

namespace Company.Service.Dto
{
    public class DepartmentDto : BaseEntity
    {
        public string name { get; set; }
        public string Code { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<EmployeeDto> Employees { get; set; } = new List<EmployeeDto>();
    }
}

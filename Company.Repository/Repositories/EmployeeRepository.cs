using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Data.Contexts;
using Company.Data.Models;
using Company.Repository.Interfaces;

namespace Company.Repository.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly CompanyDbContext _context;
        public EmployeeRepository(CompanyDbContext context) : base(context)
        {
            _context = context;
        }
       
    }
}

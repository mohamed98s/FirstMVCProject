using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Data.Models;
using Company.Service.Dto;

namespace Company.Service.Interfaces
{
    public interface IDepartmentService
	{
		DepartmentDto GetById(int? id);
		IEnumerable<Department> GetAll();
		void Add(DepartmentDto entity);
		void Update(DepartmentDto entity);
		void Delete(DepartmentDto entity);
	}
}

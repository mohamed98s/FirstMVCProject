using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Data.Models;

namespace Company.Service.Interfaces
{
	public interface IDepartmentService
	{
		Department GetById(int? id);
		IEnumerable<Department> GetAll();
		void Add(Department entity);
		void Update(Department entity);
		void Delete(Department entity);
	}
}

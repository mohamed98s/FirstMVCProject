using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Data.Models;
using Company.Repository.Interfaces;
using Company.Service.Interfaces;

namespace Company.Service.Services
{
	public class DepartmentService : IDepartmentService
	{
		private readonly IDepartmentRepository _departmentRepository;

		public DepartmentService(IDepartmentRepository departmentRepository)
		{
			_departmentRepository = departmentRepository;
		}

		public void Add(Department entity)
		{
			_departmentRepository.Add(entity);
		}

		public void Delete(Department entity)
		{
			_departmentRepository.Delete(entity);
		}

		public IEnumerable<Department> GetAll()
		{
			var dept = _departmentRepository.GetAll();
			return dept;
		}

		public Department GetById(int? id)
		{
			if(id == null)
			{
				return null;
			}
			var dept = _departmentRepository.GetById(id.Value);
			if(dept == null)
			{
				return null;
			}
			return dept;
		}

		public void Update(Department entity)
		{
			var dept  = GetById(entity.Id);
			if (dept.name == entity.name)
			{
				if (GetAll().Any(x=>x.name == entity.name))
				{
					throw new Exception("name already exist");
				}
			}
			dept.name = entity.name;
			dept.Code = entity.Code;
			_departmentRepository.Update(dept);

		}
	}
}

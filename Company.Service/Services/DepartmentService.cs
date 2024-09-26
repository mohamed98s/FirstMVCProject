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
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork)
		{
           _unitOfWork = unitOfWork;
        }

		public void Add(Department entity)
		{
			var MappedDept = new Department
			{
				Code = entity.Code,
				name = entity.name,
				CreatedAt = DateTime.Now,
			};
			_unitOfWork.departmentRepository.Add(MappedDept);
			_unitOfWork.Complete();
		}

		public void Delete(Department entity)
		{
			_unitOfWork.departmentRepository.Delete(entity);
		}

		public IEnumerable<Department> GetAll()
		{
			var dept = _unitOfWork.departmentRepository.GetAll().Where(x=>x.IsDeleted != true);
			return dept;
		}

		public Department GetById(int? id)
		{
			if(id == null)
			{
				return null;
			}
			var dept = _unitOfWork.departmentRepository.GetById(id.Value);
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
			_unitOfWork.departmentRepository.Update(dept);
			_unitOfWork.Complete();

		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Company.Data.Models;
using Company.Repository.Interfaces;
using Company.Service.Dto;
using Company.Service.Interfaces;

namespace Company.Service.Services
{
    public class DepartmentService : IDepartmentService
	{
        private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public DepartmentService(IUnitOfWork unitOfWork, IMapper mapper)
		{
           _unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public void Add(DepartmentDto entity)
		{
			//var MappedDept = new Department
			//{
			//	Code = entity.Code,
			//	name = entity.name,
			//	CreatedAt = DateTime.Now,
			//};
			Department dept = _mapper.Map<Department>(entity);
			_unitOfWork.departmentRepository.Add(dept);
			_unitOfWork.Complete();
		}

		public void Delete(DepartmentDto entity)
		{
			Department dept = _mapper.Map<Department>(entity);

			_unitOfWork.departmentRepository.Delete(dept);
		}

		public IEnumerable<Department> GetAll()
		{
			var dept = _unitOfWork.departmentRepository.GetAll().Where(x=>x.IsDeleted != true);
			//IEnumerable<DepartmentDto> MappedDept = _mapper.Map<IEnumerable<DepartmentDto>>(dept);
			return dept;
		}

		public DepartmentDto GetById(int? id)
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
			DepartmentDto DeptDto = _mapper.Map<DepartmentDto>(dept);
			return DeptDto;
		}

		public void Update(DepartmentDto entityDto)
		{
            //var dept  = GetById(entity.Id);
            //if (dept.name == entity.name)
            //{
            //	if (GetAll().Any(x=>x.name == entity.name))
            //	{
            //		throw new Exception("name already exist");
            //	}
            //}
            //dept.name = entity.name;
            //dept.Code = entity.Code;
            //_unitOfWork.departmentRepository.Update(dept);
            //_unitOfWork.Complete();
            Department department = _mapper.Map<Department>(entityDto);

            _unitOfWork.departmentRepository.Update(department);

            _unitOfWork.Complete();

        }
	}
}

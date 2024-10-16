using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Company.Data.Models;
using Company.Repository.Interfaces;
using Company.Service.Dto;
using Company.Service.Helper;
using Company.Service.Interfaces;

namespace Company.Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
			_mapper = mapper;
		}

        public void Add(EmployeeDto entityDto)
        {
            //Console.WriteLine("Adding employee to database");
            //Employee employee = new Employee
            //{
            //    Name = entityDto.Name,
            //    Age = entityDto.Age,
            //    Address = entityDto.Address,
            //    Salary = entityDto.Salary,
            //    PhoneNumber = entityDto.PhoneNumber,
            //    Email = entityDto.Email,
            //    DepartmentId = entityDto.DepartmentId,
            //    HiringDate = entityDto.HiringDate,
            //    ImgUrl = entityDto.ImgUrl,

            //};
            entityDto.ImgUrl = DocumentSettings.UploadFile(entityDto.Img, "Imgs");
            Employee employee = _mapper.Map<Employee>(entityDto);
			_unitOfWork.employeeRepository.Add(employee);
			_unitOfWork.Complete();

		}

		public void Delete(EmployeeDto entityDto)
        {
            //Employee employee = new Employee
            //{
            //	Name = entityDto.Name,
            //	Age = entityDto.Age,
            //	Address = entityDto.Address,
            //	Salary = entityDto.Salary,
            //	PhoneNumber = entityDto.PhoneNumber,
            //	Email = entityDto.Email,
            //	DepartmentId = entityDto.DepartmentId,
            //	HiringDate = entityDto.HiringDate,
            //	ImgUrl = entityDto.ImgUrl,

            //};
            entityDto.ImgUrl = DocumentSettings.UploadFile(entityDto.Img, "Imgs");
			Employee employee = _mapper.Map<Employee>(entityDto);
			_unitOfWork.employeeRepository.Delete(employee);
			_unitOfWork.Complete();

		}

		public IEnumerable<EmployeeDto> GetAll()
        {
            var emp = _unitOfWork.employeeRepository.GetAll()/*.Where(x => x.IsDeleted != true)*/;

            //var MappedEmployee = emp.Select(x => new EmployeeDto
            //{
            //    DepartmentId=x.DepartmentId,
            //    Name = x.Name,
            //    Age = x.Age,
            //    Address = x.Address,
            //    Salary = x.Salary,
            //    PhoneNumber = x.PhoneNumber,
            //    Email = x.Email,
            //    HiringDate= x.HiringDate,
            //    ImgUrl = x.ImgUrl,
            //    CreatedAt = x.CreatedAt,

            //});

            IEnumerable<EmployeeDto> MappedEmployee = _mapper.Map<IEnumerable<EmployeeDto>>(emp);

            return MappedEmployee;
        }

        public EmployeeDto GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            var emp = _unitOfWork.employeeRepository.GetById(id.Value);
            if (emp == null)
            {
                return null;
            }
			//EmployeeDto employeeDto = new EmployeeDto
			//{
			//	Name = emp.Name,
			//	Age = emp.Age,
			//	Address = emp.Address,
			//	Salary = emp.Salary,
			//	PhoneNumber = emp.PhoneNumber,
			//	Email = emp.Email,
			//	DepartmentId = emp.DepartmentId,
			//	HiringDate = emp.HiringDate,
			//	ImgUrl = emp.ImgUrl,

			//};

            EmployeeDto employeeDto = _mapper.Map<EmployeeDto>(emp);

			return employeeDto;
        }

        public IEnumerable<EmployeeDto> GetEmployeeByName(string name)
        {
            var emp = _unitOfWork.employeeRepository.GetEmployeeByName(name);

			//EmployeeDto employeeDto = new EmployeeDto
			//{
			//	Name = emp.Name,
			//	Age = emp.Age,
			//	Address = emp.Address,
			//	Salary = emp.Salary,
			//	PhoneNumber = emp.PhoneNumber,
			//	Email = emp.Email,
			//	DepartmentId = emp.DepartmentId,
			//	HiringDate = emp.HiringDate,
			//	ImgUrl = emp.ImgUrl,

			//};

			IEnumerable<EmployeeDto> MappedEmployee = _mapper.Map<IEnumerable<EmployeeDto>>(emp);
			return MappedEmployee;
		}
        public void Update(EmployeeDto entityDto)
        {
            //var dept = GetById(entity.Id);
            //if (dept.name == entity.name)
            //{
            //    if (GetAll().Any(x => x.name == entity.name))
            //    {
            //        throw new Exception("name already exist");
            //    }
            //}
            //dept.name = entity.name;
            //dept.Code = entity.Code;
            //_unitOfWork.employeeRepository.Update(dept);
            //_unitOfWork.Complete();
            Employee employee = _mapper.Map<Employee>(entityDto);
            _unitOfWork.employeeRepository.Update(employee);
            _unitOfWork.Complete();
        }

    }
}

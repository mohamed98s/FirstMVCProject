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
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Employee entity)
        {
            
            _unitOfWork.employeeRepository.Add(entity);
           
        }

        public void Delete(Employee entity)
        {
            _unitOfWork.employeeRepository.Delete(entity);
        }

        public IEnumerable<Employee> GetAll()
        {
            var dept = _unitOfWork.employeeRepository.GetAll().Where(x => x.IsDeleted != true);
            return dept;
        }

        public Employee GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            var dept = _unitOfWork.employeeRepository.GetById(id.Value);
            if (dept == null)
            {
                return null;
            }
            return dept;
        }

        public IEnumerable<Employee> GetEmployeeByName(string name)
        => _unitOfWork.employeeRepository.GetEmployeeByName(name);

        public void Update(Employee entity)
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
            
            _unitOfWork.employeeRepository.Update(entity);
            _unitOfWork.Complete();
        }

    }
}

using Microsoft.EntityFrameworkCore;
using Route.MVCApp.BLL.DTOs;
using Route.MVCApp.DAL.Models.Dpartments;
using Route.MVCApp.DAL.Persistance.Repositories.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.MVCApp.BLL.Services.Departments
{
    public class DepartmentService : IDepartmentservice
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)//Ask CLR For creating An object From "Department Repository"
        {
            _departmentRepository = departmentRepository;
        }
        public int CreateDepartment(CreatedDepartmentDto departmentDto)
        {
            // CreatedDepartmentDto --> Department
            var ddepartment = new Department()
            {
                Code = departmentDto.Code,
                Name = departmentDto.Name,
                Description = departmentDto.Description,
                CreationDate = departmentDto.CreationDate,
                CreatedBy = 1,
                LastModifiedBy = 1,
                LastModifiedOn = DateTime.Now,
            };
            return _departmentRepository.Add(ddepartment);
        }

        public bool DeleteDepartment(int Id)
        {
            var department = _departmentRepository.Get(Id);
            {
                if (department is { })
                    return _departmentRepository.Delete(department) > 0;
                return false;
            }
        }

        public IEnumerable<DepartmentToReturnDto> GetAllDepartments()
        {
            var departmentss = _departmentRepository.GetAllAsIQuerable().Select(department => new DepartmentToReturnDto()
            //Mapping -->[Department --> DepartmentToReturnDto]
            
               
                {
                    Id = department.Id,
                    Code = department.Code,
                    Name = department.Name,
                    CreationDate = department.CreationDate
                }).ToList();
            return departmentss;
        }

        public DepartmentDetailsDto? GetDepartmentById(int Id)
        {
            var department = _departmentRepository.Get(Id);
            if(department is { })
            
                return new DepartmentDetailsDto()
                {
                    Id = department.Id,
                    Code = department.Code,
                    Name = department.Name,
                    Description = department.Description,
                    CreationDate = department.CreationDate,
                    CreatedBy = department.CreatedBy,
                    CreatedOn = department.CreatedOn,
                    LastModifiedBy = department.LastModifiedBy,
                    LastModifiedOn = department.LastModifiedOn,
                };
                return null;
            
        }

        public int UpdateDepartment(UpdatedDepartmentDto departmentDto)
        {
            var department = new Department()
            {
                Id = departmentDto.Id, 
                Code = departmentDto.Code,
                Name = departmentDto.Name,
                Description = departmentDto.Description,
                CreationDate = departmentDto.CreationDate,
                CreatedBy = 1,
                LastModifiedBy = 1,
                LastModifiedOn = DateTime.Now,
            };
            return _departmentRepository.Update(department);
        }
    }
}

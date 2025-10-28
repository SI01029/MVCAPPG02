using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.MVCApp.BLL.DTOs
{
    public class DepartmentToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? Description { get; set; }
        [Display (Name="Date of Creation")]
        public DateOnly CreationDate { get; set; }
        //public static explicit operator DepartmentToReturnDto(DepartmentDetailsDto department)
        //{
        //    return new DepartmentToReturnDto()
        //    {
        //        Id = department.Id,
        //        Code = department.Code,
        //        Name = department.Name,
        //        CreationDate = department.CreationDate

        //    };
        //}
    }
}

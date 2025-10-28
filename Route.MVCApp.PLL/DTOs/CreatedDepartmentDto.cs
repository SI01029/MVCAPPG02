using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.MVCApp.BLL.DTOs
{
    public class CreatedDepartmentDto
    {
        public string Name { get; set; } = null!;
        [Required(ErrorMessage= "Code is Required Ya Hamada !!")]
        public string Code { get; set; } = null!;
        public string? Description { get; set; }
        [Display(Name = "Date of Creation")]
        public DateOnly CreationDate { get; set; }
    }
}

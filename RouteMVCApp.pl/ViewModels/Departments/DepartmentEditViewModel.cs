using System.ComponentModel.DataAnnotations;

namespace RouteMVCApp.pl.ViewModels.Departments
{
    public class DepartmentEditViewModel
    {
        [Required(ErrorMessage = "Code Is Required Ya Hamada !!")]
        public int Id { get; set; }
        public string Code { get; set; } =null!;
        public string Name { get; set; }=null!;
        public string? Description { get; set; }
        [Display(Name= "Date of Creation")]
        public DateOnly CreationDate { get; set; }
    }
} 

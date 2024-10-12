using System.ComponentModel.DataAnnotations;

namespace MAUI_CoreAPI.Models
{
    public class Employee
    {
        [Key]
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime Joindate { get; set; }
        public int Salary { get; set; }
        public bool IsActive { get; set; }
        public string ImageUrl { get; set; }
    }
}

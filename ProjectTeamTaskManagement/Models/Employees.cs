using System.ComponentModel.DataAnnotations;

namespace ProjectTeamTaskManagement.Models
{
    public class Employees
    {
        [Key]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = "";
        public string Department { get; set; } = "";
        public string Designation { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public bool IsAvailable { get; set; } = true;

        public virtual ICollection<Projects> Projects { get; set; } = new List<Projects>();
        public virtual ICollection<TaskAllocations> TaskAllocations { get; set; } =  new List<TaskAllocations>();

    }
}

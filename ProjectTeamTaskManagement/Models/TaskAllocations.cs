using System.ComponentModel.DataAnnotations;

namespace ProjectTeamTaskManagement.Models
{
    public class TaskAllocations
    {

        [Key]
        public int TaskAllocationId{ get; set; }

        [Display(Name="Task Allocation Date")]
        [DataType(DataType.Date)]
        public DateTime AllocationDate { get; set; }


        [Display(Name ="Task Id")]
        public int TaskId { get; set; } = 0;

        [Display(Name ="Employee Id")]
        public int EmployeeId { get; set; }= 0;


        [Display(Name = "Task Completion Date")]
        [DataType(DataType.Date)]
        public DateTime CompletionDate { get; set; }

        public Employees Employees { get; set; }
        public Tasks Tasks { get; set; }
    }
}

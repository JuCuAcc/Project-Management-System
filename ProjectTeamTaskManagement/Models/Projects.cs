using System.ComponentModel.DataAnnotations;

namespace ProjectTeamTaskManagement.Models
{
    public class Projects
    {

        [Key]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; } = "";

        [Display(Name = "Starting Date")]
        [DataType(DataType.Date)]
        public DateTime StartingDate { get; set; }

        [Required]
        public int NumberOfTasks { get; set; } = 0;


        [Required]
        public int NumberOfEmployee { get; set; } = 0; 


        [Display(Name = "Ending Date")]
        [DataType(DataType.Date)]
        public DateTime EndingDate { get; set; }


        public bool IsActive { get; set; } = false;


        public int EmployeeId { get; set; }


        public Employees Employees { get; set; }

    }
}

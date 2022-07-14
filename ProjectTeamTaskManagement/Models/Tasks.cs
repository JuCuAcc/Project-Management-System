using System.ComponentModel.DataAnnotations;

namespace ProjectTeamTaskManagement.Models
{
    public class Tasks
    {
        [Key]
        public int TaskId { get; set; }

        [Required]
        [Display(Name ="Task Name")]
        [StringLength(255)]
        public string TaskName { get; set; } = "";

        [Display(Name = "Task Description")]
        public string TaskDescription { get; set; } = "";


        [Required]
        [Display(Name ="Task Duration")]
        [StringLength(255)]
        public string TaskDuration { get; set; } = "";

        public virtual ICollection<Projects> Projects { get; set; }= new List<Projects>();
        public virtual ICollection<TaskAllocations> TaskAllocations { get; set; } = new List<TaskAllocations>();
    }
}

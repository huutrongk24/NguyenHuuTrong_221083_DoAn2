namespace QLHieuSuat.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public int Difficulty { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int ProgressPercent { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime? ActualEndDate { get; set; }

        // Foreign Key
        public int ProjectId { get; set; }

        public Project? Project { get; set; }

        public ICollection<TaskAssignment> TaskAssignments { get; set; }

        public string Status { get; set; }

        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}

namespace QLHieuSuat.Models
{
    public class TaskAssignment
    {
        public int Id { get; set; }

        public int TaskItemId { get; set; }
        public TaskItem TaskItem { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public double ContributionPercent { get; set; }
    }
}

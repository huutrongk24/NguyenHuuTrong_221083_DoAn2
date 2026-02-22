using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLHieuSuat.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Họ tên")]
        public string FullName { get; set; } = string.Empty;

        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Display(Name = "Số điện thoại")]
        public string? PhoneNumber { get; set; }

        // ====== THÊM CHO HỆ THỐNG KPI ======

        [Display(Name = "Số năm kinh nghiệm")]
        public int YearsOfExperience { get; set; }

        [Display(Name = "Số dự án đã tham gia")]
        public int ProjectsParticipated { get; set; }

        [Display(Name = "Điểm KPI cá nhân")]
        public double PersonalKPI { get; set; }

        // ====== PHÒNG BAN ======

        [Display(Name = "Phòng ban")]
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public Department? Department { get; set; }

        // ====== Quan hệ TaskAssignment ======
        public ICollection<TaskAssignment>? TaskAssignments { get; set; }

        // LIÊN KẾT USER
        public string? ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }


        public ICollection<TaskItem> TaskItems { get; set; }

    }
}
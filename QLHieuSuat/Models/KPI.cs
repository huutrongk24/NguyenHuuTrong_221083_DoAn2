using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLHieuSuat.Models
{
    public class KPI
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Tên KPI")]
        public string Name { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Display(Name = "Điểm tối đa")]
        public int MaxScore { get; set; }

        // Gán cho phòng ban
        [Display(Name = "Phòng ban")]
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
    }
}
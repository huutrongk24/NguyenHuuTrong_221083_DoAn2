using System.ComponentModel.DataAnnotations;

namespace QLHieuSuat.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên phòng ban không được để trống")]
        [Display(Name = "Tên phòng ban")]
        public string Name { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
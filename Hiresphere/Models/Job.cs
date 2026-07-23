using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Hiresphere.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string? Description { get; set; }

        public decimal Salary { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string JobType { get; set; }

        public string? ExperienceRequired { get; set; }

        public DateTime Deadline { get; set; }

        // Foreign Key for Company/Employer
        public int EmployerId { get; set; }

        [ForeignKey("EmployerId")]
        public Employee? Company { get; set; }

        // Foreign Key for Category
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
    }
}

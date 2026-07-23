using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Hiresphere.Areas.Identity.Data;

namespace Hiresphere.Models
{
    public class EmployeeEdit
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string OwnerName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        public string? Website { get; set; }

        [Required]
        public string Location { get; set; }

        public string? Description { get; set; }

        public string Logo { get; set; }

        public IFormFile path { get; set; }

        // Foreign Key
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationDbContext? User { get; set; }
    }
}

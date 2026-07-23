using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Hiresphere.Areas.Identity.Data;

namespace Hiresphere.Models
{
    public class jobbseekerwithimage
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        public string? Address { get; set; }

        public string? Education { get; set; }

        public string? Experience { get; set; }

        public string? Skills { get; set; }

        // Resume file path
        public IFormFile coverletter { get; set; }

        // Foreign Key
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationDbContext? User { get; set; }
    }
    }


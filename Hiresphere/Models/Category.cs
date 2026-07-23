using System.ComponentModel.DataAnnotations;

namespace Hiresphere.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public string? Description { get; set; }

    }
}

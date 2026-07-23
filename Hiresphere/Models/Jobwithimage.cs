using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hiresphere.Models
{
    public class Jobwithimage
    {
        [Key]
        public int Id { get; set; }

        // Foreign Key for Job
        public int JobId { get; set; }

        [ForeignKey("JobId")]
        public Job? Job { get; set; }
        public string? JobTitle { get; set; }

        // JobSeeker information
        public string? FullName { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public string? Education { get; set; }

        public string? Experience { get; set; }

        public string? Skills { get; set; }

        public string? Resume { get; set; }
        // Foreign Key for Candidate (Job Seeker)
        public int JobSeekerId { get; set; }

        [ForeignKey("JobSeekerId")]
        public Jobseeker? Candidate { get; set; }

        public DateTime AppliedDate { get; set; }

        public string? Status { get; set; }

        [NotMapped]
        public IFormFile? CV { get; set; }

    }
}
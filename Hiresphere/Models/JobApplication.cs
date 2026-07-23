using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hiresphere.Models
{
    public class JobApplication
    {
        [Key]
        public int Id { get; set; }

        // Foreign Key for Job
        public int JobId { get; set; }

        [ForeignKey("JobId")]
        public Job? Job { get; set; }

        // Foreign Key for Candidate (Job Seeker)
        public int JobSeekerId { get; set; }

        [ForeignKey("JobSeekerId")]
        public Jobseeker? Candidate { get; set; }

        public DateTime AppliedDate { get; set; }

        public string? Status { get; set; }

        public string? CoverLetter { get; set; }
    }
}
using System.Security.Claims;
using Hiresphere.Areas.Identity.Data;
using Hiresphere.Migrations;
using Hiresphere.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
namespace Hiresphere.Controllers
{
    public class JobApplicationController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment env;

        public JobApplicationController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            this.context = context;
            this.env = env;
        }

        [Authorize]
        public IActionResult Apply(int id)
        {
            // Get selected job
            var job = context.Job.FirstOrDefault(j => j.Id == id);

            if (job == null)
            {
                return NotFound();
            }

            // Get logged-in user ID
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Get logged-in user's JobSeeker profile
            var jobSeeker = context.Jobseeker
                .FirstOrDefault(x => x.UserId == userId);

            // If profile is not created
            if (jobSeeker == null)
            {
                return RedirectToAction("Create", "JobSeeker");
            }

            // Send job and JobSeeker data to the view
            Jobwithimage model = new Jobwithimage()
            {
                // Job data
                JobId = job.Id,
                JobTitle = job.Title,

                // JobSeeker data
                FullName = jobSeeker.FullName,
                Email = jobSeeker.Email,
                Phone = jobSeeker.Phone,
                Address = jobSeeker.Address,
                Education = jobSeeker.Education,
                Experience = jobSeeker.Experience,
                Skills = jobSeeker.Skills,
                Resume = jobSeeker.Resume
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Apply(Jobwithimage job)
        {
            if (ModelState.IsValid)
            {
                if (job.CV != null)
                {
                    string folder = Path.Combine(env.WebRootPath, "Cv");

                    string fileName = Guid.NewGuid().ToString() + "_" + job.CV.FileName;

                    string filePath = Path.Combine(folder, fileName);
                    job.CV.CopyTo(new FileStream(filePath, FileMode.Create));

                    string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                    var jobSeeker = context.Jobseeker
                        .FirstOrDefault(x => x.UserId == userId);
                    if (jobSeeker == null)
                    {
                        return RedirectToAction("Create", "JobSeeker");
                    }
                    JobApplication application = new JobApplication()
                    {
                        JobId = job.JobId,                  // Hidden field se aayega
                        JobSeekerId = jobSeeker.Id,      // Logged-in user se niklega
                        AppliedDate = DateTime.Now,
                        Status = "Pending",
                        CoverLetter = "/Cv/" + fileName
                    };

                    context.JobApplication.Add(application);
                    context.SaveChanges();

                    return RedirectToAction("Index","home");

                }


            }

            return View(job);
        }



public IActionResult MyApplications()
    {
        string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId == null)
        {
            return RedirectToAction("Login", "Account");
        }

        var jobSeeker = context.Jobseeker
            .FirstOrDefault(x => x.UserId == userId);

        if (jobSeeker == null)
        {
            return RedirectToAction("Create", "JobSeeker");
        }

        var applications = context.JobApplication
            .Include(x => x.Job)
            .Where(x => x.JobSeekerId == jobSeeker.Id)
            .OrderByDescending(x => x.AppliedDate)
            .ToList();

        return View(applications);
    }
}
}
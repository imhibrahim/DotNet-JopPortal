using System.Security.Claims;
using Hiresphere.Areas.Identity.Data;
using Hiresphere.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;



namespace Hiresphere.Controllers
{
    public class JobController : Controller
    {
        private readonly ApplicationDbContext jobcontext;

        public JobController(ApplicationDbContext jobcontext)
        {
            this.jobcontext = jobcontext;
        }
        // GET: JobController/Create
        public IActionResult Create()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var employer = jobcontext.Employee
                .FirstOrDefault(e => e.UserId == userId);

            if (employer == null)
            {
                return NotFound();
            }

            ViewBag.CompanyName = employer.CompanyName;
            ViewBag.EmployerId = employer.Id;

            ViewBag.CategoryId = new SelectList(jobcontext.Category, "Id", "CategoryName");

            return View();
        }

        [HttpPost]
        public IActionResult Create(Job job)
        {
            if (ModelState.IsValid)
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var employer = jobcontext.Employee
                    .FirstOrDefault(e => e.UserId == userId);

                if (employer == null)
                {
                    return NotFound();
                }

                job.EmployerId = employer.Id;

                jobcontext.Job.Add(job);
                jobcontext.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.CompanyName = jobcontext.Employee
                .FirstOrDefault(e => e.Id == job.EmployerId)?.CompanyName;

            ViewBag.CategoryId = new SelectList(jobcontext.Category, "Id", "CategoryName");

            return View(job);
        }

        public IActionResult Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var employer = jobcontext.Employee
                .FirstOrDefault(e => e.UserId == userId);

            if (employer == null)
            {
                return View(new List<Job>());
            }

            var jobs = jobcontext.Job
                .Include(j => j.Company)
                .Include(j => j.Category)
                .Where(j => j.EmployerId == employer.Id)
                .ToList();

            return View(jobs);
        }


        // GET: Job/Delete/5
        public IActionResult Delete(int id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var employer = jobcontext.Employee
                .FirstOrDefault(e => e.UserId == userId);

            if (employer == null)
            {
                return NotFound();
            }

            var job = jobcontext.Job
                .Include(j => j.Company)
                .Include(j => j.Category)
                .FirstOrDefault(j => j.Id == id && j.EmployerId == employer.Id);

            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        [HttpPost, ActionName("Delete")]
    
        public IActionResult DeleteConfirmed(int id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var employer = jobcontext.Employee
                .FirstOrDefault(e => e.UserId == userId);

            if (employer == null)
            {
                return NotFound();
            }

            var job = jobcontext.Job
                .FirstOrDefault(j => j.Id == id && j.EmployerId == employer.Id);

            if (job == null)
            {
                return NotFound();
            }

            jobcontext.Job.Remove(job);
            jobcontext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        // GET: Job/Edit/5
        public IActionResult Edit(int id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var employer = jobcontext.Employee
                .FirstOrDefault(e => e.UserId == userId);

            if (employer == null)
            {
                return NotFound();
            }

            var job = jobcontext.Job
                .FirstOrDefault(j => j.Id == id && j.EmployerId == employer.Id);

            if (job == null)
            {
                return NotFound();
            }

            ViewBag.CompanyName = employer.CompanyName;
            ViewBag.CategoryId = new SelectList(jobcontext.Category, "Id", "CategoryName", job.CategoryId);

            return View(job);
        }

        // POST: Job/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Job job)
        {
            if (id != job.Id)
            {
                return NotFound();
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var employer = jobcontext.Employee
                .FirstOrDefault(e => e.UserId == userId);

            if (employer == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingJob = jobcontext.Job
                    .FirstOrDefault(j => j.Id == id && j.EmployerId == employer.Id);

                if (existingJob == null)
                {
                    return NotFound();
                }

                existingJob.Title = job.Title;
                existingJob.Description = job.Description;
                existingJob.Salary = job.Salary;
                existingJob.Location = job.Location;
                existingJob.JobType = job.JobType;
                existingJob.ExperienceRequired = job.ExperienceRequired;
                existingJob.Deadline = job.Deadline;
                existingJob.CategoryId = job.CategoryId;

                jobcontext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.CompanyName = employer.CompanyName;
            ViewBag.CategoryId = new SelectList(jobcontext.Category, "Id", "CategoryName", job.CategoryId);

            return View(job);
        }

    }
}
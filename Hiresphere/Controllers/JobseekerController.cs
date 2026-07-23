using Hiresphere.Areas.Identity.Data;
using Hiresphere.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Hiresphere.Controllers
{
    public class JobseekerController : Controller
    {
        private readonly ApplicationDbContext jobseekercontext;
        IWebHostEnvironment env;
        public JobseekerController(ApplicationDbContext jobseekercontext, IWebHostEnvironment env)
        {
            this.jobseekercontext = jobseekercontext;
            this.env = env;
        }

        public IActionResult create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult create(jobbseekerwithimage profile)
        {
              if (profile.coverletter != null)
                {
                    string folder = Path.Combine(env.WebRootPath, "picture");

                    string fileName = Guid.NewGuid().ToString() + "_" + profile.coverletter.FileName;

                    string filePath = Path.Combine(folder, fileName);
                    profile.coverletter.CopyTo(new FileStream(filePath, FileMode.Create));

                   Jobseeker jobdata = new Jobseeker()
                    {

                        FullName = profile.FullName,
                        Email = profile.Email,
                        Phone = profile.Phone,
                        Address = profile.Address,
                        Education = profile.Education,
                        Experience = profile.Experience,
                        Skills = profile.Skills,
                        Resume = "/picture/" + fileName,
                        UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
                    };

                    jobseekercontext.Jobseeker.Add(jobdata);
                    jobseekercontext.SaveChanges();

                    return RedirectToAction("Index","Home");

                }


            

            return View(profile);
     
        }


        public IActionResult ViewProfile()
        {
         
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

     
            var profile = jobseekercontext.Jobseeker
                .FirstOrDefault(x => x.UserId == userId);

            if (profile == null)
            {
                return RedirectToAction("Create");
            }

            return View(profile);
        }




public IActionResult CategoryJobs(int id)
    {
        var jobs = jobseekercontext.Job
            .Include(x => x.Company)
            .Include(x => x.Category)
            .Where(x => x.CategoryId == id)
            .ToList();

        ViewBag.Category = jobseekercontext.Category
            .FirstOrDefault(x => x.Id == id)?.CategoryName;

        return View(jobs);
    }



}
}

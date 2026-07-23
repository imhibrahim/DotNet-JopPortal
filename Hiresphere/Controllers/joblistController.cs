using System.Security.Claims;
using Hiresphere.Areas.Identity.Data;
using Hiresphere.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hiresphere.Controllers
{
    public class joblistController : Controller
    {
        private readonly ApplicationDbContext jobcontext;

        public joblistController(ApplicationDbContext jobcontext)
        {
            this.jobcontext = jobcontext;
        }
        public IActionResult JobList()
        {
            var jobs = jobcontext.Job
                .Include(j => j.Company)
                .Include(j => j.Category)
                .ToList();

            return View(jobs);
        }


        public IActionResult jobdetail(int id) {
            var data = jobcontext.Job
          .Include(j => j.Company)
          .Include(j => j.Category)
          .FirstOrDefault(j => j.Id == id);

            if (data == null)
            {
                return NotFound();
            }
            return View(data);
                }
    }
}

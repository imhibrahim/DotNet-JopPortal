using Hiresphere.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hiresphere.Controllers
{
    public class CompanylistController : Controller
    {
        private readonly ApplicationDbContext employeecontext;
        public CompanylistController(ApplicationDbContext employeecontext)
        {
            this.employeecontext = employeecontext;
           
        }
        public ActionResult Index()
        {
            var data = employeecontext.Employee.ToList();

            return View(data);
        }




        public IActionResult Details(int id)
        {
            var company = employeecontext.Employee
                .FirstOrDefault(x => x.Id == id);

            if (company == null)
            {
                return NotFound();
            }

            ViewBag.TotalJobs = employeecontext.Job.Count(x => x.EmployerId == id);

            return View(company);
        }
    }
}

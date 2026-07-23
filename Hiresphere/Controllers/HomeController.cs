using Hiresphere.Areas.Identity.Data;
using Hiresphere.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Hiresphere.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext _context)
        {
            _logger = logger;
            context = _context;
        }

        public IActionResult Index()
        {
            ViewBag.Categories = context.Category.ToList();
            return View();
        }

        //[Authorize(Roles ="Admin")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }




        

public IActionResult SearchJobs(string? title, string? location, int? categoryId)
    {
        var jobs = context.Job
            .Include(x => x.Company)
            .Include(x => x.Category)
            .AsQueryable();

        if (!string.IsNullOrEmpty(title))
        {
            jobs = jobs.Where(x => x.Title.Contains(title));
        }

        if (!string.IsNullOrEmpty(location))
        {
            jobs = jobs.Where(x => x.Location.Contains(location));
        }

        if (categoryId.HasValue)
        {
            jobs = jobs.Where(x => x.CategoryId == categoryId.Value);
        }

        return View(jobs.ToList());
    }



}
}

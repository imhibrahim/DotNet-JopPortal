using Microsoft.AspNetCore.Mvc;

namespace Hiresphere.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult blog()
        {
            return View();
        }
    }
}

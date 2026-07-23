using Microsoft.AspNetCore.Mvc;

namespace Hiresphere.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult dashboard()
        {
            return View();
        }
    }
}

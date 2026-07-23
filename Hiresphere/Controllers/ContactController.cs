using Microsoft.AspNetCore.Mvc;

namespace Hiresphere.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Contact()
        {
            return View();
        }
    }
}

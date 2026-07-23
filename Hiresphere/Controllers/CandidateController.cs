using Microsoft.AspNetCore.Mvc;

namespace Hiresphere.Controllers
{
    public class CandidateController : Controller
    {
        public IActionResult candidate()
        {
            return View();
        }
    }
}

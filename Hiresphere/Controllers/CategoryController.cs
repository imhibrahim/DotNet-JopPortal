using Hiresphere.Areas.Identity.Data;
using Hiresphere.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hiresphere.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext catcontext;

        public CategoryController(ApplicationDbContext catcontext)
        {
            this.catcontext = catcontext;
        }


        // GET: CategoryController
        public ActionResult Index()
        {
            var data = catcontext.Category.ToList();

            return View(data);
        }



        // GET: CategoryController
        public ActionResult userIndex()
        {
            var data = catcontext.Category.ToList();

            return View(data);
        }





        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category cat)
        {
            catcontext.Category.Add(cat);
            catcontext.SaveChanges();
            return RedirectToAction("index");
        }









        public ActionResult edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data =  catcontext.Category.Find(id);
            return View(data);
        }

        [HttpPost]
        public ActionResult edit(int id,Category cat)
        {
            if (id != cat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                catcontext.Category.Update(cat);
                 catcontext.SaveChanges();
                return RedirectToAction("index");
            }
            return View(cat);
        }

        public  IActionResult delete(int? id)
        {
            var data =  catcontext.Category.Find(id);
            if (data != null)
            {
                catcontext.Category.Remove(data);
            }
             catcontext.SaveChanges();

            return RedirectToAction("index");
        }




    }
}

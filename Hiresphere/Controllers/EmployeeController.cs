using System.Runtime.ConstrainedExecution;
using System.Security.Claims;
using System.Text;
using Hiresphere.Areas.Identity.Data;
using Hiresphere.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
namespace Hiresphere.Controllers


{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext employeecontext;
        IWebHostEnvironment env;
        public EmployeeController(ApplicationDbContext employeecontext, IWebHostEnvironment env)
        {
            this.employeecontext = employeecontext;
            this.env = env;
        }

       
       

        // GET: EmployeeController
        public ActionResult Index()
        {
            var data = employeecontext.Employee.ToList();

            return View(data);
        }



        // GET: EmployeeController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        public IActionResult Create(Employeewithimage emp)
        {
            if (ModelState.IsValid)
            {
                if (emp.path != null)
                {
                    string folder = Path.Combine(env.WebRootPath, "images");

                    string fileName = Guid.NewGuid().ToString() + "_" + emp.path.FileName;

                    string filePath = Path.Combine(folder, fileName);
                    emp.path.CopyTo(new FileStream(filePath, FileMode.Create));

                    Employee empdata = new Employee()
                    {

                        OwnerName = emp.OwnerName,
                        Website = emp.Website,    
                        CompanyName = emp.CompanyName,
                        Location = emp.Location,
                        Description = emp.Description,
                        Email = emp.Email,
                        Phone = emp.Phone,
                        Logo = "/images/" + fileName,
                        UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
                    };

                    employeecontext.Employee.Add(empdata);
                    employeecontext.SaveChanges();

                    return RedirectToAction("Index");

                }


        }

            return View(emp);
    }

        public IActionResult Delete(int id)
        {
            var data = employeecontext.Employee.Find(id);

            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int id)
        {
            var data = employeecontext.Employee.Find(id);

            if (data != null)
            {

                employeecontext.Employee.Remove(data);
                employeecontext.SaveChanges();
                     
            }

            return RedirectToAction("Index");
        }


        public IActionResult edit(int id)
        {
            EmployeeEdit emp = new EmployeeEdit();
            var employee = employeecontext.Employee.Find(id);

            if (employee!=null)
            {
                emp.Id = employee.Id;
                emp.UserId =User.FindFirstValue(ClaimTypes.NameIdentifier);
                emp.CompanyName = employee.CompanyName;
                emp.OwnerName = employee.OwnerName;
                emp.Phone = employee.Phone;
                emp.Location = employee.Location;
                emp.Description = employee.Description;
                emp.Email = employee.Email;
                emp.Website = employee.Website;
                emp.Logo = employee.Logo;
      

            }
            return View(emp);

        }


        [HttpPost]
   
        public IActionResult Edit(EmployeeEdit emp)
        {
            string oldfileName = emp.Logo;

            if (emp.path != null)
            {
                string folder = Path.Combine(env.WebRootPath, "images");
                string newFileName = Guid.NewGuid().ToString() + "_" + emp.path.FileName;
                string filePath = Path.Combine(folder, newFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    emp.path.CopyTo(stream);
                }

                oldfileName = "/images/" + newFileName;
            }

            Employee empdata = new Employee()
            {
                Id = emp.Id,
                CompanyName = emp.CompanyName,
                OwnerName = emp.OwnerName,
                Phone = emp.Phone,
                Location = emp.Location,
                Description = emp.Description,
                Email = emp.Email,
                Website = emp.Website,
                Logo = oldfileName,
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
            };

            employeecontext.Employee.Update(empdata);
            
            employeecontext.SaveChanges();

            return RedirectToAction("Index");
        }



    }

}

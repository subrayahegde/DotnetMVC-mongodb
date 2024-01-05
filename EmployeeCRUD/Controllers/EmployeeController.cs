using EmployeeCRUD.Data;
using EmployeeCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using EmployeeCRUD.Interface;

namespace EmployeeCRUD.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployee _context;
        

        public EmployeeController(IEmployee context)
        {
            _context = context;                   
        }
        
         public IActionResult Welcome()
        {
            return View();
        }
/*
        public IActionResult Index()
        {
            IEnumerable<Employee> objCatlist = _context.GetAllEmployees();
            return View(objCatlist);
        }
*/
        public async Task<ActionResult> Index()
        {
            IEnumerable<Employee> objCatlist = await _context.GetAllEmployeesAsync();
            return View(objCatlist);
        }

        public IActionResult Create()
        {
            return View();
        }

/*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee empobj)
        {
          //  if (ModelState.IsValid)
          //  {
                var cdate=DateTime.Now;
                //empobj.RecordCreatedOn = cdate;

                _context.Create(empobj);            
                return RedirectToAction("Index");
          //  }

          //  return View(empobj);
        }
*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Employee empobj)
        {
          //  if (ModelState.IsValid)
          //  {
                var cdate=DateTime.Now;
                //empobj.RecordCreatedOn = cdate;

                await _context.CreateAsync(empobj);            
                return RedirectToAction("Index");
          //  }

          //  return View(empobj);
        }

        public async Task<ActionResult> Edit(string? id)
        {
            if (id == null || id == "")
            {
                return NotFound();
            }
            var empfromdb = await _context.GetEmployeeDetailsAsync(id);

            if (empfromdb == null)
            {
                return NotFound();
            }
            return View(empfromdb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, Employee empobj)
        {
          //  if (ModelState.IsValid)
          //  {
                await _context.UpdateAsync(id, empobj);
                
                
                return RedirectToAction("Index");
          //  }

          //  return View(empobj);
        }

        public async Task<ActionResult> Delete(string? id)
        {
            if (id == null || id == "")
            {
                return NotFound();
            }
            var empfromdb = await _context.GetEmployeeDetailsAsync(id);
         
            if (empfromdb == null)
            {
                return NotFound();
            }
            return View(empfromdb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteEmp(string? _id)
        {
            var deleterecord = await _context.GetEmployeeDetailsAsync(_id);
            if (deleterecord == null)
            {
                return NotFound();
            }
            await _context.DeleteAsync(_id);          
           
            return RedirectToAction("Index");
        }


    }
}

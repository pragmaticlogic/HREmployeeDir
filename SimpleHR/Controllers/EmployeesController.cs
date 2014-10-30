using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SimpleHR.DataAccess;
using SimpleHR.Models;
using PagedList;
using SimpleHR.Filters;

namespace SimpleHR.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        private const int PAGE_SIZE = 5;
        private EmployeeDbContext db = new EmployeeDbContext();
        
        public ActionResult Index(string sortOrder, string filter, string searchString, int? page)
        {            
            ViewBag.LastNameSortParm = String.IsNullOrEmpty(sortOrder) ? "last_name_desc" : "";
            ViewBag.FirstNameSortParm = String.IsNullOrEmpty(sortOrder) ? "first_name_desc" : "";
            ViewBag.CurrentSort = sortOrder;

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = filter;
            }

            ViewBag.CurrentFilter = searchString;

            var employees = db.Employees.Include(e => e.Credential);
            if (!String.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(s => s.Lastname.ToUpper().Contains(searchString.ToUpper())
                               || s.FirstName.ToUpper().Contains(searchString.ToUpper()));
            }

            switch (sortOrder)
            {
                case "last_name_desc":
                    employees = employees.OrderByDescending(s => s.Lastname)
                        .ThenBy(s=> s.FirstName);
                    break;                
                case "first_name_desc":
                    employees = employees.OrderByDescending(s => s.FirstName)
                        .ThenBy(s => s.Lastname);
                    break;                               
                default:
                    employees = employees.OrderBy(s => s.Lastname)
                        .ThenBy(s=>s.FirstName);
                    break;
            }

            int pageNumber = (page ?? 1);
            return View(employees.ToPagedList(pageNumber, PAGE_SIZE));
        }

        // GET: Employees/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        [HRAuthorizeAttribute]
        public ActionResult Create()
        {
            ViewBag.LoginId = new SelectList(db.Credentials, "LoginId", "PasswordHash");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HRAuthorizeAttribute]
        public ActionResult Create([Bind(Include = "EmployeeId,FirstName,Lastname,MiddleName,Address,City,County,State,ZipCode,OfficePhone,CellPhone,Email,LoginId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.EmployeeId = Guid.NewGuid();
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LoginId = new SelectList(db.Credentials, "LoginId", "PasswordHash", employee.LoginId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        [HRAuthorizeAttribute]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.LoginId = new SelectList(db.Credentials, "LoginId", "PasswordHash", employee.LoginId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HRAuthorizeAttribute]
        public ActionResult Edit([Bind(Include = "EmployeeId,FirstName,Lastname,MiddleName,Address,City,County,State,ZipCode,OfficePhone,CellPhone,Email,LoginId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LoginId = new SelectList(db.Credentials, "LoginId", "PasswordHash", employee.LoginId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        [HRAuthorizeAttribute]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [HRAuthorizeAttribute]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

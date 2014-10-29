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

namespace SimpleHR.Controllers
{
    public class EmployeesController : Controller
    {
        private EmployeeDbContext db = new EmployeeDbContext();

        // GET: Employees
        public ActionResult Index(string sortOrder, string searchString)
        {
            //var employees = db.Employees.Include(e => e.Credential);
            //return View(employees.ToList());

            ViewBag.LastNameSortParm = String.IsNullOrEmpty(sortOrder) ? "last_name_desc" : "";
            ViewBag.FirstNameSortParm = String.IsNullOrEmpty(sortOrder) ? "first_name_desc" : "";            

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
            return View(employees.ToList());
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

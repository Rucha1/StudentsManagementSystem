using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentManagementSystem.Models;
using StudentManagementSystem.ViewModels.Home;

namespace StudentManagementSystem.Controllers
{
    public class StudentsController : Controller
    {
        private StudentContext db = new StudentContext();

        // GET: Students
        public ActionResult Index()
        {
            var students = db.students.Include(s => s.division).Include(s => s.standard);
            return View(students.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students students = db.students.Find(id);
            if (students == null)
            {
                return HttpNotFound();
            }
            return View(students);
        }
        //Add students
        public ActionResult AddItem(StudentsViewModel mod)
        {
            if (mod.Id == 0)
            {
                Students task = new Students();
                task.Fname = mod.Fname;
                task.Mname = mod.Mname;
                task.Lname = mod.Lname;
                task.Dob = mod.Dob;
                task.Address = mod.Address;
                task.FatherName = mod.FatherName;
                task.MotherName = mod.MotherName;
                task.Pcn = mod.Pcn;
                task.Scn = mod.Scn;
                task.DivisionId = mod.DivisionId;
                task.StandardId = mod.StandardId;


                db.students.Add(task);
                db.SaveChanges();

                // alert("Entery added to database");
            }
            else
            {
                //Tasks editTask = db.Tasks.SingleOrDefault(x => x.Id == mod.Id);
                Students editTask = db.students.Find(mod.Id);
                //editTask.TaskName = mod.TaskName;
                db.SaveChanges();
            }

            return View();

        }
        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.DivisionId = new SelectList(db.division, "DivisionId", "DName");
            ViewBag.StandardId = new SelectList(db.standard, "StandardId", "Class");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Fname,Mname,Lname,Dob,Address,FatherName,MotherName,Pcn,Scn,DivisionId,StandardId")] Students students)
        {
            if (ModelState.IsValid)
            {
                db.students.Add(students);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DivisionId = new SelectList(db.division, "DivisionId", "DName", students.DivisionId);
            ViewBag.StandardId = new SelectList(db.standard, "StandardId", "Class", students.StandardId);
            return View(students);
        }

        public ActionResult Create()
        {
            ViewBag.SubjectId = new SelectList(db.subjects, "SubjectId", "SubjectNames", marks.SubjectId);
            ViewBag.Id = new SelectList(db.students, "Id", "Class", marks.Id);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMarks([Bind(Include = "Id,Score,SubjectsId,StudentId")] Models.Marks marks)
        {
            if (ModelState.IsValid)
            {
                db.marks.Add(marks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubjectId = new SelectList(db.subjects, "SubjectId", "SubjectNames", marks.SubjectId);
            ViewBag.Id = new SelectList(db.students, "Id", "Class", marks.Id);
            return View(marks);
        }
        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students students = db.students.Find(id);
            if (students == null)
            {
                return HttpNotFound();
            }
            ViewBag.DivisionId = new SelectList(db.division, "DivisionId", "DName", students.DivisionId);
            ViewBag.StandardId = new SelectList(db.standard, "StandardId", "Class", students.StandardId);
            return View(students);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Fname,Mname,Lname,Dob,Address,FatherName,MotherName,Pcn,Scn,DivisionId,StandardId")] Students students)
        {
            if (ModelState.IsValid)
            {
                db.Entry(students).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DivisionId = new SelectList(db.division, "DivisionId", "DName", students.DivisionId);
            ViewBag.StandardId = new SelectList(db.standard, "StandardId", "Class", students.StandardId);
            return View(students);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students students = db.students.Find(id);
            if (students == null)
            {
                return HttpNotFound();
            }
            return View(students);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Students students = db.students.Find(id);
            db.students.Remove(students);
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

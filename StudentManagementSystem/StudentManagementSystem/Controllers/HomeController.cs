using StudentManagementSystem.Models;
using StudentManagementSystem.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        StudentContext db = new StudentContext();
        public ActionResult Index()
        {

            //db.division.Add(new Division { DName = "test" });
            //db.SaveChanges();
            //db.standard.Add(new Standard { Class = "test" });
            //db.SaveChanges();
            //db.subjects.Add(new Subjects { SubjectNames = "test" });
            //db.SaveChanges();

            //db.students.Add(new Students { Fname = "test", Dob = "12-03-2013" });
            //db.SaveChanges();

            //db.marks.Add(new Models.Marks { Score = 10 });
            //db.SaveChanges();
            ViewBag.DivisionList = new SelectList(db.division.ToList(),"DivisionId", "DName");
            ViewBag.StandardList = new SelectList(db.standard.ToList(), "StandardId", "Class");

            return View();

        }
        //[HttpGet]
        //public ActionResult Get()
        //{

        //    return db.division.ToList();
        //}


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
        public ActionResult AddMarks()
        {
            ViewBag.Marks = new SelectList(db.students.ToList(), "Id", "SubjectNames");

            ViewBag.Marks = new SelectList(db.subjects.ToList(), "SubjectId", "SubjectNames"); 

            return View();
        }


        public ActionResult Login()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
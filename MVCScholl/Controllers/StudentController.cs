using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCScholl.Models;
using Schoolmvclib;

namespace MVCScholl.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student

        Schoolmvclib.SchoolDbEntities db=new SchoolDbEntities();

        public ActionResult Index()

        {
            List<Student>students=db.Students.ToList();
            List<Studentmodel>studlist=new List<Studentmodel>();
            foreach (var item in students)
            {
                Studentmodel model=new Studentmodel();
                model.studentid = item.StudentId;
                model.firstname = item.FirstName;
                model.lastname=item.LastName;
                model.gender = item.Gender;
                model.email = item.Email;
                model.phoneno = item.PhoneNumber;
                studlist.Add(model);
            }


            return View(studlist);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)

        {
            Student S = db.Students.Find(id);
            Studentmodel model = new Studentmodel();
            model.studentid= S.StudentId;
            model.firstname = S.FirstName;
            model.lastname = S.LastName;
            model.gender = S.Gender;
            model.email= S.Email;
            model.phoneno= S.PhoneNumber;

            return View(model);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            


            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                Studentmodel model = new Studentmodel();
                model.studentid = Convert.ToInt32(collection["studentid"]);
                model.firstname = collection["firstname"].ToString();
                model.lastname = collection["lastname"].ToString();
                model.gender = collection["gender"].ToString();
                model.email = collection["email"].ToString();
                model.phoneno = collection["phoneno"].ToString();


                Student s=new Student();
                s.StudentId= model.studentid;
                s.FirstName=model.firstname;
                s.LastName=model.lastname;
                s.Gender = model.gender;
                s.Email=model.email;
                s.PhoneNumber = model.phoneno;
                db.Students.Add(s);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)

        {
            Student S = db.Students.Find(id);
            Studentmodel model=new Studentmodel();
            model.firstname = S.FirstName;
            model.lastname = S.LastName;
            model.gender = S.Gender;
            model.email= S.Email;
            model.phoneno = S.PhoneNumber;

            return View(model);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Student S = db.Students.Find(id);
                S.FirstName = collection["firstname"].ToString();
                S.LastName = collection["lastname"].ToString();
                S.Gender = collection["gender"].ToString();
                S.Email = collection["email"].ToString();
                S.PhoneNumber = collection["phoneno"].ToString();
                db.SaveChanges();
      
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            Student S = db.Students.Find(id);
            Studentmodel model = new Studentmodel();
            model.firstname = S.FirstName;
            model.lastname = S.LastName;
            model.gender = S.Gender;
            model.email = S.Email;
            model.phoneno = S.PhoneNumber;

            return View(model);

 
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Student S = db.Students.Find(id);
                db.Students.Remove(S);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

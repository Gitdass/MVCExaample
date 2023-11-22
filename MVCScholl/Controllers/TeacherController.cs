using MVCScholl.Models;
using Schoolmvclib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCScholl.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        Schoolmvclib.SchoolDbEntities db = new SchoolDbEntities();

        public ActionResult Index()
        {
            List<Teacher>Teachers=db.Teachers.ToList();
            List<TeacherModel>Teacherlist=new List<TeacherModel>();
            foreach (var item in Teachers)
            {
                TeacherModel model = new TeacherModel();
                model.teacherid = item.TeacherId;
                model.firstname = item.FirstName;
                model.lastname = item.LastName;
                model.gender = item.Gender;
                model.email = item.Email;
                model.phoneno = item.PhoneNumber;
                Teacherlist.Add(model);
            }


            return View(Teacherlist);

  
        }

        // GET: Teacher/Details/5
        public ActionResult Details(int id)
        {
            Teacher T = db.Teachers.Find(id);
            TeacherModel model = new TeacherModel();
            model.teacherid =T.TeacherId;
            model.firstname = T.FirstName;
            model.lastname = T.LastName;
            model.gender = T.Gender;
            model.email = T.Email;
            model.phoneno = T.PhoneNumber;

            return View(model);

            return View();
        }

        // GET: Teacher/Create
        public ActionResult Create()
        {


            return View();
        }

        // POST: Teacher/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                TeacherModel model = new TeacherModel();
                model.teacherid = Convert.ToInt32(collection["teacherid"]);
                model.firstname = collection["firstname"].ToString();
                model.lastname = collection["lastname"].ToString();
                model.gender = collection["gender"].ToString();
                model.email = collection["email"].ToString();
                model.phoneno = collection["phoneno"].ToString();


                Teacher T = new Teacher();
                T.TeacherId = model.teacherid;
                T.FirstName = model.firstname;
                T.LastName = model.lastname;
                T.Gender = model.gender;
                T.Email = model.email;
                T.PhoneNumber = model.phoneno;
                db.Teachers.Add(T);
                db.SaveChanges();

                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: Teacher/Edit/5
        public ActionResult Edit(int id)
        {

            Teacher T = db.Teachers.Find(id);
            TeacherModel model = new TeacherModel();
            model.firstname = T.FirstName;
            model.lastname = T.LastName;
            model.gender = T.Gender;
            model.email = T.Email;
            model.phoneno = T.PhoneNumber;

            return View(model);
   
        }

        // POST: Teacher/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                Teacher T = db.Teachers.Find(id);
                T.FirstName = collection["firstname"].ToString();
                T.LastName = collection["lastname"].ToString();
                T.Gender = collection["gender"].ToString();
                T.Email = collection["email"].ToString();
                T.PhoneNumber = collection["phoneno"].ToString();
                db.SaveChanges();

                return RedirectToAction("Index");


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Teacher/Delete/5
        public ActionResult Delete(int id)
        {
            Teacher T = db.Teachers.Find(id);
            TeacherModel model = new TeacherModel();
            model.firstname =T.FirstName;
            model.lastname = T.LastName;
            model.gender = T.Gender;
            model.email = T.Email;
            model.phoneno = T.PhoneNumber;

            return View(model);

        }

        // POST: Teacher/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Teacher T = db.Teachers.Find(id);
                db.Teachers.Remove(T);
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

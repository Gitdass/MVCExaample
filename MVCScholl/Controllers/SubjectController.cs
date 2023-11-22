using MVCScholl.Models;
using Schoolmvclib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCScholl.Controllers
{
    public class SubjectController : Controller
    {

        Schoolmvclib.SchoolDbEntities db = new SchoolDbEntities();
        // GET: Subject
        public ActionResult Index()
        {

            List<Subject> sub = db.Subjects.ToList();

            List<SubjectModel> sublist = new List<SubjectModel>();
            foreach (var item in sub)
            {
                SubjectModel model=new SubjectModel();
         
                model.subid = item.SubId;
                model.subname = item.SubName;
                model.subdesc = item.SubDescription;
                sublist.Add(model);
            }


            return View(sublist);

           
        }

        // GET: Subject/Details/5
        public ActionResult Details(int id)
        {


            Subject sj = db.Subjects.Find(id);
            SubjectModel model = new SubjectModel();

            model.subid = sj.SubId;
            model.subname = sj.SubName;
            model.subdesc = sj.SubDescription;

            return View(model);
        }

        // GET: Subject/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Subject/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                SubjectModel model = new SubjectModel();
                model.subid = Convert.ToInt32(collection["subid"]);
                model.subname = collection["subname"].ToString();
                model.subdesc = collection["subdesc"].ToString();
               


                Subject sj = new Subject();
                sj.SubId = model.subid;
                sj.SubName=model.subname;
                sj.SubDescription=model.subdesc;

                db.Subjects.Add(sj);
                db.SaveChanges();




                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Subject/Edit/5
        public ActionResult Edit(int id)
        {
            Subject sj = db.Subjects.Find(id);
            SubjectModel model = new SubjectModel();

            model.subid = sj.SubId;
            model.subname = sj.SubName;
            model.subdesc = sj.SubDescription;

            return View(model);
       
        }

        // POST: Subject/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Subject sj = db.Subjects.Find(id);
               
                sj.SubName = collection["subname"].ToString();
                sj.SubDescription = collection["subdesc"].ToString();
                db.SaveChanges();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Subject/Delete/5
        public ActionResult Delete(int id)
        {
            Subject S = db.Subjects.Find(id);
            SubjectModel model = new SubjectModel();
            model.subname = S.SubName;
            model.subdesc = S.SubDescription;
        
            return View(model);
     
        }

        // POST: Subject/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Subject S = db.Subjects.Find(id);
                db.Subjects.Remove(S);
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

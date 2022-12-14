using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using user_management_1.Models;

namespace user_management_1.Controllers
{
    public class user_detailsController : Controller
    {
        // GET: user_details
        public ActionResult Index()
        {
            using (training_dbEntities dbmodel = new training_dbEntities())
            {
                return View(dbmodel.user_details.ToList());
            }
        }

        // GET: user_details/Details/5
        public ActionResult Details(int id)
        {
            using (training_dbEntities dbModel = new training_dbEntities())
            {
                return View(dbModel.user_details.Where(x => x.UserID == id).FirstOrDefault());
            }
        }

        // GET: user_details/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: user_details/Create
        [HttpPost]
        public ActionResult Create(user_details customer)
        {
            try
            {
                using (training_dbEntities dbModel = new training_dbEntities())
                {
                    dbModel.user_details.Add(customer);
                    dbModel.SaveChanges();
                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Insertion/Edit/5
        public ActionResult Edit(int id)
        {
            using (training_dbEntities dbModel = new training_dbEntities())
            {
                return View(dbModel.user_details.Where(x => x.UserID == id).FirstOrDefault());
            }

        }

        // POST: Insertion/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, user_details customer)
        {
            try
            {
                using (training_dbEntities dbModel = new training_dbEntities())
                {
                    dbModel.Entry(customer).State = EntityState.Modified;
                    dbModel.SaveChanges();
                }
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Insertion/Delete/5
        public ActionResult Delete(int id)
        {
            using (training_dbEntities dbModel = new training_dbEntities())
            {
                return View(dbModel.user_details.Where(x => x.UserID == id).FirstOrDefault());
            }
        }

        // POST: Insertion/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (training_dbEntities dbModel = new training_dbEntities())
                {
                    user_details customer = dbModel.user_details.Where(x => x.UserID == id).FirstOrDefault();
                    dbModel.user_details.Remove(customer);
                    dbModel.SaveChanges();
                }
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

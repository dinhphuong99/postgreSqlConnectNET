﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_EF_CRUD_Postgresql.DataContext;
using MVC_EF_CRUD_Postgresql.Models;

namespace MVC_EF_CRUD_Postgresql.Controllers
{
    public class EmpController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Emp
        public ActionResult Index()
        {
            return View(db.Empobj.ToList());
        }

        // GET: Emp/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpClass empClass = db.Empobj.Find(id);
            if (empClass == null)
            {
                return HttpNotFound();
            }
            return View(empClass);
        }

        // GET: Emp/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Emp/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "empId,empName,email,salary")] EmpClass empClass)
        {
            if (ModelState.IsValid)
            {
                db.Empobj.Add(empClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empClass);
        }

        // GET: Emp/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpClass empClass = db.Empobj.Find(id);
            if (empClass == null)
            {
                return HttpNotFound();
            }
            return View(empClass);
        }

        // POST: Emp/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "empId,empName,email,salary")] EmpClass empClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empClass);
        }

        // GET: Emp/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpClass empClass = db.Empobj.Find(id);
            if (empClass == null)
            {
                return HttpNotFound();
            }
            return View(empClass);
        }

        // POST: Emp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmpClass empClass = db.Empobj.Find(id);
            db.Empobj.Remove(empClass);
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

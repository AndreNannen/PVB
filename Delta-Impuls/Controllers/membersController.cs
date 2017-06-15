using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Delta_Impuls.Models;

namespace Delta_Impuls.Controllers
{
    public class membersController : Controller
    {
        private Entities db = new Entities();

        //Get: license 
        public ActionResult License()
        {
            return View();
        }

        // GET: members
        public ActionResult Index(string searching)
        {
           
            List<Count> count = new List<Count>();


            var members = from s in db.member
                          select s;

            var member = db.member.Include(m => m.category).Include(m => m.lj).Include(m => m.location).Include(m => m.ls);
         
            if (!String.IsNullOrEmpty(searching))
            {
                member = member.Where(s => s.firstname.Contains(searching) || s.lastname.Contains(searching)) ;

            }
            return View(member.ToList());
        }

        
        // GET: members/Create
        public ActionResult Create()
        {
            ViewBag.category_ID = new SelectList(db.category, "ID", "category_name");
            ViewBag.lj_ID = new SelectList(db.lj, "ID", "lj1");
            ViewBag.location_ID = new SelectList(db.location, "ID", "city");
            ViewBag.ls_ID = new SelectList(db.ls, "ID", "ls1");
            return View();
        }

        // POST: members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,bondsnr,cg,para_tt,birthdate,gender,firstname,insertion,lastname,address,zipcode,city,phonenumber,mobilenumber,e_mail,location_ID,category_ID,ls_ID,lj_ID,membersince")] member member)
        {
            if (ModelState.IsValid)
            {
                db.member.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.category_ID = new SelectList(db.category, "ID", "category_name", member.category_ID);
            ViewBag.lj_ID = new SelectList(db.lj, "ID", "lj1", member.lj_ID);
            ViewBag.location_ID = new SelectList(db.location, "ID", "city", member.location_ID);
            ViewBag.ls_ID = new SelectList(db.ls, "ID", "ls1", member.ls_ID);
            return View(member);
        }

        // GET: members/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            member member = db.member.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            ViewBag.category_ID = new SelectList(db.category, "ID", "category_name", member.category_ID);
            ViewBag.lj_ID = new SelectList(db.lj, "ID", "lj1", member.lj_ID);
            ViewBag.location_ID = new SelectList(db.location, "ID", "city", member.location_ID);
            ViewBag.ls_ID = new SelectList(db.ls, "ID", "ls1", member.ls_ID);
            return View(member);
        }

        // POST: members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,bondsnr,cg,para_tt,birthdate,gender,firstname,insertion,lastname,address,zipcode,city,phonenumber,mobilenumber,e_mail,location_ID,category_ID,ls_ID,lj_ID,membersince")] member member)
        {
            if (ModelState.IsValid)
            {
                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.category_ID = new SelectList(db.category, "ID", "category_name", member.category_ID);
            ViewBag.lj_ID = new SelectList(db.lj, "ID", "lj1", member.lj_ID);
            ViewBag.location_ID = new SelectList(db.location, "ID", "city", member.location_ID);
            ViewBag.ls_ID = new SelectList(db.ls, "ID", "ls1", member.ls_ID);
            return View(member);
        }

        // GET: members/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            member member = db.member.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            member member = db.member.Find(id);
            db.member.Remove(member);
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

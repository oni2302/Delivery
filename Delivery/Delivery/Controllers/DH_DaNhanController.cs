using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Delivery.Models;

namespace Delivery.Controllers
{
    public class DH_DaNhanController : Controller
    {
        private DeliveryEntities db = new DeliveryEntities();

        // GET: DH_DaNhan
        public ActionResult Index()
        {
            var dH_DaNhan = db.getDonHang_DaNhan();
            return View(dH_DaNhan.ToList());
        }

        // GET: DH_DaNhan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang dH_DaNhan = db.DonHangs.Find(id);
            if (dH_DaNhan == null)
            {
                return HttpNotFound();
            }
            return View(dH_DaNhan);
        }

        //// GET: DH_DaNhan/Create
        //public ActionResult Create()
        //{
        //    ViewBag.MaDH = new SelectList(db.DonHangs, "MaDH", "MaVanDon");
        //    return View();
        //}

        //// POST: DH_DaNhan/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "MaDH_DaNhan,TrangThai,MaDH")] DH_DaNhan dH_DaNhan)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.DH_DaNhan.Add(dH_DaNhan);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.MaDH = new SelectList(db.DHs, "MaDH", "MaVanDon", dH_DaNhan.MaDH);
        //    return View(dH_DaNhan);
        //}

        //// GET: DH_DaNhan/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    DH_DaNhan dH_DaNhan = db.DH_DaNhan.Find(id);
        //    if (dH_DaNhan == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.MaDH = new SelectList(db.DHs, "MaDH", "MaVanDon", dH_DaNhan.MaDH);
        //    return View(dH_DaNhan);
        //}

        //// POST: DH_DaNhan/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "MaDH_DaNhan,TrangThai,MaDH")] DH_DaNhan dH_DaNhan)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(dH_DaNhan).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.MaDH = new SelectList(db.DHs, "MaDH", "MaVanDon", dH_DaNhan.MaDH);
        //    return View(dH_DaNhan);
        //}

        //// GET: DH_DaNhan/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    DH_DaNhan dH_DaNhan = db.DH_DaNhan.Find(id);
        //    if (dH_DaNhan == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(dH_DaNhan);
        //}

        //// POST: DH_DaNhan/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    DonHang dH_DaNhan = db.DonHangs.Find(id);
        //    db.DonHangs.Remove(dH_DaNhan);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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

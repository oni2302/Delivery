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
    public class DHsController : Controller
    {
        private DeliveryEntities db = new DeliveryEntities();

        // GET: DHs
        public ActionResult Index()
        {
            var listdhcn = db.getDonHang_ChuaNhan().ToList();
            ViewBag.listdhcn = listdhcn;
           
            return View();
        }

        // GET: DHs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang dH = db.DonHangs.Find(id);
            if (dH == null)
            {
                return HttpNotFound();
            }
            return View(dH);
        }

        //// GET: DHs/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: DHs/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "MaDH,MaVanDon,HoTenNG,DiaChiNG,SdtNG,HotenNN,DiaChiNN,SdtNN,TrangThai")] DonHang dH)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.DonHangs.Add(dH);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(dH);
        //}

        public ActionResult NhanDon(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang dH = db.DonHangs.Find(id);
            if (dH == null)
            {
                return HttpNotFound();
            }
            return View(dH);
        }

        [HttpPost]
        public ActionResult NhanDon(int id)
        {
            db.XacNhan_DonHang_ChuaNhan(id);
            db.SaveChanges();
            return RedirectToAction("index");
        }

        //// GET: DHs/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    DonHang dH = db.DonHangs.Find(id);
        //    if (dH == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(dH);
        //}

        //// POST: DHs/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "MaDH,MaVanDon,HoTenNG,DiaChiNG,SdtNG,HotenNN,DiaChiNN,SdtNN,TrangThai")] DonHang dH)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(dH).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(dH);
        //}

        //// GET: DHs/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    DonHang dH = db.DonHangs.Find(id);
        //    if (dH == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(dH);
        //}

        //// POST: DHs/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    DonHang dH = db.DonHangs.Find(id);
        //    db.DonHangs.Remove(dH);
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

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
    public class TaiKhoanController : Controller
    {
        private DeliveryEntities db = new DeliveryEntities();

        // GET: TaiKhoan
        public ActionResult Index(string sortOrder, string TenNVString, string CVString, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            var taiKhoans = db.TaiKhoans.Include(t => t.NhanVien);

            switch (sortOrder)
            {
                case "name_desc":
                    taiKhoans = taiKhoans.OrderByDescending(b => b.TenTaiKhoan);
                    break;

                default:
                    taiKhoans = taiKhoans.OrderBy(b => b.TenTaiKhoan);
                    break;
            }

            ViewBag.KeywordTK = searchString;
            ViewBag.KeywordTenNV = TenNVString;
            ViewBag.KeywordCV = CVString;
            
            if (!String.IsNullOrEmpty(searchString))
                taiKhoans = taiKhoans.Where(b => b.TenTaiKhoan.Contains(searchString));
                       
            if (!String.IsNullOrEmpty(TenNVString))
                taiKhoans = taiKhoans.Where(c => c.NhanVien.TenNhanVien.Contains(TenNVString));

            if (!String.IsNullOrEmpty(CVString))
                taiKhoans = taiKhoans.Where(d => d.NhanVien.ChucVu.TenChucVu.Contains(CVString));

            return View(taiKhoans.ToList());
        }

        // GET: TaiKhoan/Create
        public ActionResult Create()
        {
            ViewBag.MaChucVu = new SelectList(db.ChucVus, "MaChucVu", "TenChucVu");
            ViewBag.MaNhanVien = new SelectList(db.NhanViens.Where(nv => nv.TaiKhoan.NhanVien == null), "MaNhanVien", "TenNhanVien");
            return View();
        }

        // POST: TaiKhoan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNhanVien,TenTaiKhoan,MatKhau")] TaiKhoan taiKhoan)
        {
            if (ModelState.IsValid)
            {
                db.TaiKhoans.Add(taiKhoan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "TenNhanVien", taiKhoan.MaNhanVien);
            return View(taiKhoan);
        }

        // GET: TaiKhoans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            if (taiKhoan == null)
            {
                return HttpNotFound();
            }
            if (!ModelState.IsValid)
            {
                return View(taiKhoan);
            }
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "TenNhanVien", taiKhoan.MaNhanVien);

            return View(taiKhoan);
        }

        // POST: TaiKhoans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNhanVien,TenTaiKhoan,MatKhau")] TaiKhoan taiKhoan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taiKhoan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "TenNhanVien", taiKhoan.MaNhanVien);
            return RedirectToAction("index", "Home");
        }

        // GET: TaiKhoan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            if (taiKhoan == null)
            {
                return HttpNotFound();
            }
            return View(taiKhoan);
        }

        // POST: TaiKhoan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            db.TaiKhoans.Remove(taiKhoan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Reset(int? id, TaiKhoan taiKhoan)
        {
            taiKhoan = db.TaiKhoans.Find(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                taiKhoan.MatKhau = taiKhoan.TenTaiKhoan + "123";
                db.Entry(taiKhoan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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

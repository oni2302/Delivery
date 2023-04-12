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
using GiaoHang.Controllers;

namespace Delivery.Controllers
{
    public class TaiKhoanController : BaseController
    {

        // GET: TaiKhoan
        public ActionResult Index(string sortOrder, string TenNVString, string CVString, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            var taiKhoans = database.TaiKhoans.Include(t => t.NhanVien);

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
                taiKhoans = taiKhoans.Where(d => d.NhanVien.ChucVu1.TenChucVu.Contains(CVString));

            return View(taiKhoans.ToList());
        }

        // GET: TaiKhoan/Create
        public ActionResult Create()
        {
            ViewBag.MaChucVu = new SelectList(database.ChucVus, "MaChucVu", "TenChucVu");
            //ViewBag.MaNhanVien = new SelectList(database.NhanViens.Where(nv =>   == null), "MaNhanVien", "TenNhanVien");
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
                database.TaiKhoans.Add(taiKhoan);
                database.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNhanVien = new SelectList(database.NhanViens, "MaNhanVien", "TenNhanVien", taiKhoan.MaNhanVien);
            return View(taiKhoan);
        }

        // GET: TaiKhoans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan taiKhoan = database.TaiKhoans.Find(id);
            if (taiKhoan == null)
            {
                return HttpNotFound();
            }
            if (!ModelState.IsValid)
            {
                return View(taiKhoan);
            }
            ViewBag.MaNhanVien = new SelectList(database.NhanViens, "MaNhanVien", "TenNhanVien", taiKhoan.MaNhanVien);

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
                database.Entry(taiKhoan).State = EntityState.Modified;
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNhanVien = new SelectList(database.NhanViens, "MaNhanVien", "TenNhanVien", taiKhoan.MaNhanVien);
            return RedirectToAction("index", "Home");
        }

        // GET: TaiKhoan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan taiKhoan = database.TaiKhoans.Find(id);
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
            TaiKhoan taiKhoan = database.TaiKhoans.Find(id);
            database.TaiKhoans.Remove(taiKhoan);
            database.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Reset(int? id, TaiKhoan taiKhoan)
        {
            taiKhoan = database.TaiKhoans.Find(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                
                database.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                database.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

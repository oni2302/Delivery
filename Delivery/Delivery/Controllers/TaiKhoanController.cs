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
using Delivery.Controllers;

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

            ViewBag.DanhSachTaiKhoan = database.TaiKhoan_DanhSach1().ToList();

            return View();
        }

        // GET: TaiKhoan/Create
        public ActionResult Create()
        {
            ViewBag.MaChucVu = new SelectList(database.SelectCV(), "MaChucVu", "TenChucVu");
            ViewBag.MaNhanVien = new SelectList(database.SelectNV(), "MaNhanVien", "TenNhanVien");
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
                database.TaiKhoan_Them(taiKhoan.TenTaiKhoan, taiKhoan.MatKhau,taiKhoan.MaNhanVien);
                return RedirectToAction("Index");
            }

            ViewBag.MaChucVu = new SelectList(database.SelectCV(), "MaChucVu", "TenChucVu");
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
            var tk = database.TaiKhoan_ChiTiet(id).Single();
            if (tk == null)
            {
                return HttpNotFound();
            }
            ViewBag.del = tk;
            return View(tk);
        }

        // POST: TaiKhoan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            database.TaiKhoan_Xoa(id);
            return RedirectToAction("Index");
        }

        public ActionResult Reset(int? id)
        {
            if (id != null)
            {
                database.ResetPass(id);               
                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound();
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

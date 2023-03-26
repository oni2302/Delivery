﻿using System;
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
    public class NhanViensController : Controller
    {
        private DeliveryEntities db = new DeliveryEntities();

        // GET: NhanViens
        public ActionResult Index(string sortOrder, string searchString, int categoryID = 0)
        {
            // 1. Thêm biến NameSortParm để biết trạng thái sắp xếp tăng, giảm ở View
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //2.Tạo câu truy vấn kết 3 bảng Book, Author, Category
            var nhanViens = db.NhanViens.Include(n => n.TaiKhoan).Include(n => n.ChucVu);
            //3. Sắp xếp theo sortOrder
            switch (sortOrder)
            {
                // 3.1 Nếu biến sortOrder sắp giảm thì sắp giảm theo Họ tên NV
                case "name_desc":
                    nhanViens = nhanViens.OrderByDescending(b => b.TenNhanVien);
                    break;
                // 3.2 Mặc định thì sẽ sắp tăng
                default:
                    nhanViens = nhanViens.OrderBy(b => b.TenNhanVien);
                    break;
            }

            // 1.1. Lưu tư khóa tìm kiếm
            ViewBag.Keyword = searchString;
            //1.2 Lưu chủ đề tìm kiếm
           // ViewBag.Subject = categoryID;
            //ViewBag.Id = categoryID;
            //1.2.Tạo câu truy vấn kết 3 bảng Book, Author, Category

            //1.3. Tìm kiếm theo searchString
            if (!String.IsNullOrEmpty(searchString))
                nhanViens = nhanViens.Where(b => b.TenNhanVien.Contains(searchString));

            //1.4. Tìm kiếm theo CategoryID
           // if (!String.IsNullOrEmpty(searchString))
                //nhanViens = nhanViens.Where(b => b.TenNhanVien.Contains(searchString));
           
            //1.5. Tìm kiếm theo CategoryID
           // if (categoryID != 0)
             // nhanViens = nhanViens.Where(c => c.MaNhanVien == categoryID);

            //1.6. Tìm kiếm theo Danh sách chủ đề
            //ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName"); // danh sách Category               


            //Trả kết quả về Views
            return View(nhanViens.ToList());
        }

        // GET: NhanViens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // GET: NhanViens/Create
        public ActionResult Create()
        {
            ViewBag.MaNhanVien = new SelectList(db.TaiKhoans, "MaNhanVien", "TenTaiKhoan");
            ViewBag.MaChucVu = new SelectList(db.ChucVus, "MaChucVu", "TenChucVu");
            return View();
        }

        // POST: NhanViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNhanVien,TenNhanVien,NgaySinh,Email,SoDienThoai")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                db.NhanViens.Add(nhanVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNhanVien = new SelectList(db.TaiKhoans, "MaNhanVien", "TenTaiKhoan", nhanVien.MaNhanVien);
            ViewBag.MaChucVu = new SelectList(db.ChucVus, "MaChucVu", "TenChucVu", nhanVien.MaChucVu);
            return View(nhanVien);
        }

        // GET: NhanViens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNhanVien = new SelectList(db.TaiKhoans, "MaNhanVien", "TenTaiKhoan", nhanVien.MaNhanVien);
            ViewBag.MaChucVu = new SelectList(db.ChucVus, "MaChucVu", "TenChucVu", nhanVien.MaChucVu);
            return View(nhanVien);
        }

        // POST: NhanViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNhanVien,TenNhanVien,MaChucVu,NgaySinh,Email,SoDienThoai,AnhDaiDien")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNhanVien = new SelectList(db.TaiKhoans, "MaNhanVien", "TenTaiKhoan", nhanVien.MaNhanVien);
            ViewBag.MaChucVu = new SelectList(db.ChucVus, "MaChucVu", "TenChucVu", nhanVien.MaChucVu);
            return View(nhanVien);
        }

        // GET: NhanViens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // POST: NhanViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NhanVien nhanVien = db.NhanViens.Find(id);
            db.NhanViens.Remove(nhanVien);
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

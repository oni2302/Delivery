using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Delivery.Common;
using Delivery.Models;

namespace Delivery.Controllers
{
    public class NhanViensController : BaseController
    {
        private GiaoHangEntities db = new GiaoHangEntities();
        // GET: NhanViens
        public ActionResult Index()
        {
            return View(db.NhanVien_DanhSach().ToList());
        }

        //GET: NhanViens/Create
        public ActionResult Create()
        {
            ViewBag.MaKhuVuc = new SelectList(db.NhanVien_KhuVuc(), "MaKhuVuc", "TenKhuVuc");
            return View();
        }

        // POST: NhanViens/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(NhanVien_ChuaTK_Result nhanVien)
        {
            if (ModelState.IsValid)
            {
                db.NhanVien_ThemNhanVien(nhanVien.TenNhanVien, nhanVien.NgaySinh, nhanVien.Email, nhanVien.SoDienThoai, nhanVien.MaKhuVuc);
                return RedirectToAction("Index");
            }
            ViewBag.MaKhuVuc = new SelectList(db.NhanVien_KhuVuc(), "MaKhuVuc", "TenKhuVuc", nhanVien.MaKhuVuc);
            return View(nhanVien);
        }

        // GET: NhanViens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var nhanVien = db.NhanVien_ChiTiet(id).Single();
                ViewBag.XoaNhanVien = nhanVien;
                return View();
            }
        }

        // POST: NhanViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            db.NhanVien_Xoa(id);
            db.SaveChanges();
            return RedirectToAction("Index");
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

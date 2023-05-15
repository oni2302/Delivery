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
    public class TaiKhoanController : BaseController
    {
        private GiaoHangEntities db = new GiaoHangEntities();

        // GET: TaiKhoan
        public ActionResult Index(string tenTK, string hoten, string loaiTK)
        {
            if (!String.IsNullOrEmpty(tenTK))
            {
                var listTKSearch = db.TaiKhoan_TimKiem(tenTK,null, null);
                return View(listTKSearch.ToList());
            }
            else if (!String.IsNullOrEmpty(hoten))
            {
                var listTKSearch = db.TaiKhoan_TimKiem(null, hoten, null);
                return View(listTKSearch.ToList());
            }
            else if (!String.IsNullOrEmpty(loaiTK))
            {
                var listTKSearch = db.TaiKhoan_TimKiem(null, null, loaiTK);
                return View(listTKSearch.ToList());
            }
            var ListTK = db.TaiKhoan_TimKiem(null, null, null);
            return View(ListTK.ToList());
        }

        // GET: TaiKhoan/Create
        public ActionResult Create()
        {
            ViewBag.LoaiTaiKhoan = new SelectList(db.NhanVien_LoaiTK(), "MaLoaiTaiKhoan", "LoaiTaiKhoan");
            ViewBag.MaNhanVien = new SelectList(db.NhanVien_ChuaTK(), "MaNhanVien", "TenNhanVien");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNhanVien,LoaiTaiKhoan,TenTaiKhoan,MatKhau")] NhanVien_ChuaTK_Result taiKhoan )
        {
                var result = db.TaiKhoan_Add(taiKhoan.TenTaiKhoan, taiKhoan.MatKhau, taiKhoan.MaNhanVien, taiKhoan.LoaiTaiKhoan).SingleOrDefault();
                if (result != "Thêm thành công")
                {
                    ModelState.AddModelError("CreateFailed", result);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            ViewBag.LoaiTaiKhoan = new SelectList(db.NhanVien_LoaiTK(), "MaLoaiTaiKhoan", "LoaiTaiKhoan",taiKhoan.LoaiTaiKhoan);
            ViewBag.MaNhanVien = new SelectList(db.NhanVien_ChuaTK(), "MaNhanVien", "TenNhanVien", taiKhoan.MaNhanVien);
            return View(taiKhoan);
        }


        public ActionResult Reset(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                db.TaiKhoan_ResetPass(id);
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

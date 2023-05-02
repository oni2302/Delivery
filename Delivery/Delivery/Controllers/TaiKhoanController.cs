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
        private GiaoHangEntities db = new GiaoHangEntities();

        // GET: TaiKhoan
        public ActionResult Index()
        {
            return View(db.TaiKhoan_DanhSach().ToList());
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
                var result = db.TaiKhoan_Them(taiKhoan.TenTaiKhoan, taiKhoan.MatKhau, taiKhoan.MaNhanVien, taiKhoan.LoaiTaiKhoan);
                if (result != 1)
                {
                    ModelState.AddModelError("CreateFailed", "Tài khoản dã tồn tại");
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

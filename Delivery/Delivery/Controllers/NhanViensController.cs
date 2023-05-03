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

        // get: nhanviens/edit/5
        //public ActionResult edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        id = ((nhanvien)session[commonconstants.nguoi_dung]).manhanvien;
        //    }
        //    nhanvien nhanvien = database.nhanviens.find(id);
        //    if (nhanvien == null)
        //    {
        //        return httpnotfound();
        //    }
        //    //viewbag.machucvu = new selectlist(database.chucvus, "machucvu", "tenchucvu", nhanvien.chucvu1.machucvu);
        //    return View(nhanvien);
        //}

        //// post: nhanviens/edit/5
        //// to protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?linkid=317598.
        //[httppost]
        //[validateantiforgerytoken]
        //public actionresult edit([bind(include = "manhanvien,tennhanvien,machucvu,ngaysinh,email,sodienthoai,anhdaidien")] nhanvien nhanvien)
        //{
        //    if (modelstate.isvalid)
        //    {
        //        database.entry(nhanvien).state = entitystate.modified;
        //        database.savechanges();
        //        return redirecttoaction("edit");
        //    }
        //    //viewbag.machucvu = new selectlist(database.chucvus, "machucvu", "tenchucvu", nhanvien.chucvu1.machucvu);
        //    return view(nhanvien);
        //}
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

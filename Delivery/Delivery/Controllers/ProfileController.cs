using Delivery.Common;
using Delivery.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Delivery.Controllers
{
    public class ProfileController : BaseController
    {
        // GET: Profile
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProfileView()
        {

            var nguoidung = Session[CommonConstants.NGUOI_DUNG] as Account_DangNhap_Result;
            int id = nguoidung.MaNhanVien;
            var ListProduct = database.Profile_Get(id).SingleOrDefault();
            if (ListProduct == null)
            {

                return HttpNotFound();
            }
            ViewBag.sua = ListProduct;

            return View();
        }


        //[HttpPost]
        //public ActionResult ProfileView(HttpPostedFileBase anhdaidien, DateTime ngaysinh)
        //{
        //    var id = int.Parse(Request.Form["id"]);
        //    var name = Request.Form["tennhanvien"];
        //    var email = Request.Form["email"];
        //    string sdt = (string)Request.Form["sodienthoai"];
        //    byte[] buffer = null;
        //    if (anhdaidien != null)
        //    {
        //        MemoryStream memoryStream = new MemoryStream();
        //        anhdaidien.InputStream.CopyTo(memoryStream);
        //        buffer = memoryStream.ToArray();
        //    }


        //    var result = database.Profile_Sua(id, name, ngaysinh, email, sdt);

        //    return Redirect("~/Profile/ProfileView/" + id);
        //}

        public ActionResult DoiMk()
        {
            var nguoidung = Session[CommonConstants.NGUOI_DUNG] as Account_DangNhap_Result;
            int id = nguoidung.MaNhanVien;
            var ListProduct = database.Profile_Get(id).SingleOrDefault();
            if (ListProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.sua = ListProduct;

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DoiMk(int id, string MatKhau)
        {
            //var matkhau = Request.Form["MatKhau"];

            var result = database.TaiKhoan_DoiMK(id, MatKhau).Single();

            return Redirect("~/Profile/ProfileView/" + id);
        }
    }
}
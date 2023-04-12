using Delivery.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
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

        public ActionResult Suaprofile(int? id)
        {

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
        public ActionResult Suaprofile(int id)
        {
            //var name = Request.Form["tennhanvien"];
            //DateTime date = DateTime.Parse(Request.Form["ngaysinh"]);
            //var email = Request.Form["email"];
            //var picture = Request.Form["anhdaidien"];
            //string sdt = (string)Request.Form["sodienthoai"];
            //var result = database.Profile_Sua(id, name, date, email, picture, sdt);

            //database.SaveChanges();

            return View();
        }

        public ActionResult DoiMk(int? id)
        {
            var ListProduct = database.TaiKhoan_Profile(id).SingleOrDefault();
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

            database.TaiKhoan_DoiMK(id, MatKhau);
            return View();
        }

    }
}
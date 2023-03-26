using Delivery.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Delivery.Models;

namespace Delivery.Controllers
{
    public class AccountController : Controller
    {
        string connString = @"Data Source=.;Initial Catalog=""Giao Hàng"";Integrated Security=True";
        SqlConnection conn = null;
        public ActionResult Login(int id = -1)
        {
            if(id==0)
            {
                ViewBag.message = "Tài khoản hoặc mật khẩu không đúng";
            }            
            return View();
        }

        public ActionResult LoginValidation()
        {
            //POST: LOGIN
            string username = Request.Form["username"];
            string password = Request.Form["password"];
            //LOGIN: PROCESSING...

            //
            return null;
        }
        
    }
}
using Delivery.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Delivery.Controllers
{
    public class BaseController : Controller
    {
        
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Kiểm tra phiên đăng nhập trách trường hợp người dùng tự ghi đường dẫn mà chưa đăng nhập
            var session = Session[CommonConstants.PHIEN_DANG_NHAP];
            if (session == null) {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new { controller = "Account", action = "Login", id = UrlParameter.Optional }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
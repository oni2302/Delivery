using Delivery.Common;
using Delivery.Models;
using System.Web.Mvc;
using System.Web.Routing;


namespace Delivery.Controllers
{
    public class BaseController : Controller
    {

       protected GiaoHangEntities database = new GiaoHangEntities();

        //protected override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    //Kiểm tra phiên đăng nhập trách trường hợp người dùng tự ghi đường dẫn mà chưa đăng nhập
        //    var session = Session[CommonConstants.NGUOI_DUNG];
        //    if (session == null)
        //    {
        //        filterContext.Result = new RedirectToRouteResult(
        //            new RouteValueDictionary(
        //                new { controller = "Authentication", action = "Login", id = UrlParameter.Optional }));
        //    }
        //    base.OnActionExecuting(filterContext);
        //}
    }
}
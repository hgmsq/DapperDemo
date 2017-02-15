using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
namespace website.Controllers
{
    public class AdminController : BaseController
    {
        // GET: Admin
        public ActionResult Index()
        {
            Users user = GetCurrentUser();

            if (user != null)
            {
                ViewData["username"] = user.UserName;
                ViewData["TrueName"] = user.TrueName;
            }
            return View();
        }


        
        [HttpPost]
        public ActionResult loginout()
        {
            //http://www.cnblogs.com/mzwhj/archive/2012/10/30/2746494.html
            if (Request.Cookies["CookieUser"] != null)
            {
                //清除cookie
                HttpCookie _cookie = Request.Cookies["CookieUser"];
                _cookie.Expires = DateTime.Now.AddHours(-1);
                Response.Cookies.Add(_cookie);
            }
            Session["userinfo"] = null;
                   // Session.Remove("UserName");
            return Json(new { success = true, msg = "注销成功" });
        }
       
    }
}
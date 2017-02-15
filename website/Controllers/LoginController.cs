using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace website.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        BLL.Users service = new BLL.Users();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username,string password)
        {
            int count = 0;
            try
            { 
                count=service.Count(" where username='"+username+"' and password='"+password+"' ");
                if (count == 0)
                {
                    return Json(new { success = false, msg = "用户名或密码不正确" });
                }
                else
                {
                    Session["userinfo"] = username;
                    HttpCookie _cookie = new HttpCookie("CookieUser");
                    _cookie.Values.Add("UserName", username);
                    _cookie.Values.Add("PassWord", System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5"));
                    _cookie.Expires = DateTime.Now.AddMinutes(30);
                    Response.Cookies.Add(_cookie);
                    return Json(new { success = true, msg = "登陆成功" });
                }
            }

            catch(Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });

            }

        }
    }
}
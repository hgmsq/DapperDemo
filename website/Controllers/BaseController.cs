using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using System.Net.Http;

namespace website.Controllers
{
    public class BaseController : Controller
    {
        BLL.Users service = new BLL.Users();

        protected string hostUrl = "";
        Users currentuser = new Users();


        public ActionResult Layout()
        {
            Users user = GetCurrentUser();
            ViewData["username"] = user.UserName;
            ViewData["TrueName"] = user.TrueName;
            return View("~/Views/Shared/_MyLayout.cshtml");
           // return View();
        }

        /// <summary>
        /// Action执行前判断
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //http://bbs.csdn.net/topics/390448054?page=1
            // url
            this.hostUrl = "http://" + this.Request.Url.Host;
            this.hostUrl += this.Request.Url.Port.ToString() == "80" ? "" : ":" + this.Request.Url.Port;
            this.hostUrl += this.Request.ApplicationPath;

            if (!this.checkLogin())// 判断是否登录
            {
                filterContext.Result = RedirectToRoute("Default", new { Controller = "Login", Action = "Index" });
            }

            base.OnActionExecuting(filterContext);

        }
        
        /// <summary>
        /// 判断是否登录
        /// </summary>
        protected bool checkLogin()
        {
            //HttpCookie _cookie = httpContext.Request.Cookies["CookieUser"];
            if (this.Session["userinfo"] == null)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 返回当前登录用户
        /// </summary>
        /// <returns></returns>
        protected Users GetCurrentUser()
        {            
            if (checkLogin())
            {
                currentuser = service.QueryList(" where username='" + this.Session["userinfo"].ToString() + "'").SingleOrDefault(); 
            }
            return currentuser;
        }

        
    }
}
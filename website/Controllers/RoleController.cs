using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using PagedList;

namespace website.Controllers
{
    public class RoleController : BaseController
    {
        BLL.Users service = new BLL.Users();
        BLL.Role roleservice = new BLL.Role();
        // GET: Role
        public ActionResult Index(int page=1)
        {
            Users user = GetCurrentUser();

            if (user != null)
            {
                ViewData["username"] = user.UserName;
                ViewData["TrueName"] = user.TrueName;
            }            
            var slist = roleservice.QueryList("where 1=1 ").ToPagedList(page, 2);
            return View(slist);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(string rolename, string content)
        {
            try
            {
                Role model = new Role();
                model.Name = rolename;
                model.Instruction = content;
                roleservice.Insert(model);
                return Json(new { success = true, msg = "操作成功" });

            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = "服务器内部错误" });
            }
        }
        [HttpPost]
        public ActionResult DelRole(string id)
        {
            try
            {
                roleservice.Delete(Convert.ToInt32(id));
                return Json(new { success = true, msg = "操作成功" });
            }
            catch
            {
                return Json(new { success = false, msg = "服务器内部错误" });
            }
        }

        public ActionResult Edit(string id)
        {
            Role model = roleservice.QuerySingle(Convert.ToInt32(id));
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(string id,string RoleName, string Instruction)
        {
            try
            {
                Role model = roleservice.QuerySingle(Convert.ToInt32(id));
                model.Name = RoleName;
                model.Instruction = Instruction;
                roleservice.Update(model);
                return Json(new { success = true, msg = "操作成功" });
            }
            catch
            {
                return Json(new { success = false, msg = "服务器内部错误" });
            }
        }
    }
}
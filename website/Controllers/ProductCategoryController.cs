using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using PagedList;
namespace website.Controllers
{
    public class ProductCategoryController :BaseController 
    {
        BLL.ProductCategorys service = new BLL.ProductCategorys();
        // GET: ProductCategory
        public ActionResult Index(int page=1)
        {
            Users user = GetCurrentUser();
            if (user != null)
            {
                ViewData["username"] = user.UserName;
                ViewData["TrueName"] = user.TrueName;
            }
            var slist = service.QueryList("where 1=1 ").ToPagedList(page, 2);
            return View(slist);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(string name,string content)
        {
            return Json(new { success = true, msg = "操作成功" });
        }
        public ActionResult Edit(int id)
        {
            ProductCategorys model = service.QuerySingle(id); 
            return View(model);
        }
    }
}
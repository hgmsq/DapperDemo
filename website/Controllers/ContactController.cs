using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using PagedList;

namespace website.Controllers
{
    public class ContactController : Controller
    {
        BLL.Contacts service = new BLL.Contacts();
        public ActionResult Index(int page=1)
        {
            Contacts model = new Contacts();
            var slist = service.QueryList("where 1=1 ").ToPagedList(page, 5);
            //PagedList<Contacts> slist= service.Page(pageindex, 5).;
            //var slist = service.Page(pageindex, 5);
            return View(slist);
        }
        /// <summary>
        /// 查看详细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Detail(int id)
        {
            Contacts model = new Contacts();
          model= service.QuerySingle(id);
            return View(model);
        }
        /// <summary>
        /// 新增视图
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Contacts con)
        {
            if (ModelState.IsValid)
            {
                if (con.Id==0)
                {
                    service.Insert(con);
               }
                else
                {
                    var cot = service.QuerySingle(con.Id);
                    cot.UserName = con.UserName;
                    cot.Price = con.Price;
                    cot.Tel = con.UserName;
                    cot.Tel1 = con.Tel1;
                    cot.Address = con.Address;
                    service.Update(cot);
                }
                return Json(new { success = true, contact = con });
            }
            else
            {
                return Json(new { success = false, msg ="错误" });

            }

        }
        public ActionResult Edit(int id)
        {
            var contact= service.QuerySingle(id);
            return View("Add",contact);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {      
                service.Delete(id);             
                return Json(new { msg = true });
            }

            catch
            {
                return Json(new { msg = false });

            }

        }
    }
}
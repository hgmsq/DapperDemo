using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
namespace website.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase uploadfile)
        {
            if (uploadfile != null && uploadfile.ContentLength > 0)
            {
                var fileName = Path.GetFileName(uploadfile.FileName);
                var path = Path.Combine(Server.MapPath("~/Uploads"), fileName);
                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);
                uploadfile.SaveAs(path);
            }
            return Content("上传完毕！");
        }
    }
}
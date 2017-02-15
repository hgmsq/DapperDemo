using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using PagedList;

namespace website.Controllers
{
    public class UserController : BaseController
    {
        BLL.Users service = new BLL.Users();
        BLL.Role roleservice = new BLL.Role();
        // GET: User
        public ActionResult Index(int page = 1)
        {
            Users user = GetCurrentUser();
            if (user != null)
            {
                ViewData["username"] = user.UserName;
                ViewData["TrueName"] = user.TrueName;
            }
            List<userView> listnew = new List<userView>();            
            //var slist = service.QueryList("where 1=1 ").ToPagedList(page,2);
            var slist = service.QueryList("where 1=1 ").ToList();

            if (slist != null && slist.Count != 0)
            {
                foreach (var item in slist)
                {
                    userView model = new userView();
                    model.id = item.Id;
                    model.rolename = roleservice.QuerySingle(item.Role).Name;
                    model.username = item.UserName;
                    model.truename = item.TrueName;
                    model.createdate = item.CreateDate;
                    listnew.Add(model);
                }
            }
            
            var slist1 = listnew.ToPagedList(page, 2);
            return View(slist1);           
        }

        public ActionResult AddUser()
        {
            List<Role> list = roleservice.GetAllList().ToList();
            return View(list);
        }
        [HttpPost]
        public ActionResult AddUser(string username, string password, string truename, string role)
        {
            List<Users> list = service.GetAllList().ToList().Where(m => m.UserName == username).ToList();
            try
            {
                if (list.Count == 0)//用户名不存在
                {
                    Users user = new Users();
                    user.UserName = username;
                    user.TrueName = truename;
                    user.Password = password;
                    user.Role = Convert.ToInt32(role);
                    user.CreateDate = DateTime.Now;
                    service.Insert(user);
                    return Json(new { success = true, msg = "操作成功" });
                }
                else
                {
                    return Json(new { success = false, msg = "用户已经存在，操作失败！" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = "服务器内部错误" });
            }
        }
        [HttpPost]
        public ActionResult DelUser(string id)
        {
            try {
                service.Delete(Convert.ToInt32(id));
                return Json(new { success = true, msg = "操作成功" });
            }
            catch
            {
                return Json(new { success = false, msg = "服务器内部错误" });
            }
        }

        public ActionResult Edit(string id)
        {
            Users model = service.QuerySingle(Convert.ToInt32(id));
            List<Role> list = roleservice.GetAllList().ToList();
            string rolestr = "";
            if (list!= null && list.Count != 0)
            {
                foreach (var item in list)
                {
                    if (item.Id == model.Role)
                    {
                        rolestr += "<option selected=\"selected\" value = \"" + item.Id + "\"> " + item.Name + "</option>";
                    }
                    else
                    {
                        rolestr += "<option  value = \"" + item.Id + "\" > " + item.Name + "</option>";
                    }
                }
            }
            ViewData["rolehtml"] = rolestr;
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(string id,string username,string password,string truename,string role)
        {
            try
            {
                Users model = service.QuerySingle(Convert.ToInt32(id));
                if (model != null)
                {
                    model.TrueName = truename;
                    model.UserName = username;
                    model.Password = password;
                    model.Role = Convert.ToInt32(role);
                    model.CreateDate = DateTime.Now;
                    service.Update(model);
                }
                return Json(new { success = true, msg = "操作成功" });
            }
            catch
            {
                return Json(new { success = false, msg = "服务器内部错误" });
            }
            
            
        }

        /// <summary>
        /// 批量导出需要导出的列表
        /// </summary>
        /// <returns></returns>
        public FileResult ExportStu2()
        {
            //获取list数据
            List<userView> listnew = new List<userView>();            
            var slist = service.QueryList("where 1=1 ").ToList();

            if (slist != null && slist.Count != 0)
            {
                foreach (var item in slist)
                {
                    userView model = new userView();
                    model.id = item.Id;
                    model.rolename = roleservice.QuerySingle(item.Role).Name;
                    model.username = item.UserName;
                    model.truename = item.TrueName;
                    model.createdate = item.CreateDate;
                    listnew.Add(model);
                }
            }

            //创建Excel文件的对象
            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
            //添加一个sheet
            NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet("Sheet1");

            //貌似这里可以设置各种样式字体颜色背景等，但是不是很方便，这里就不设置了

            //给sheet1添加第一行的头部标题
            NPOI.SS.UserModel.IRow row1 = sheet1.CreateRow(0);
            row1.CreateCell(0).SetCellValue("用户名");
            row1.CreateCell(1).SetCellValue("真实姓名");
            row1.CreateCell(2).SetCellValue("角色");
            row1.CreateCell(3).SetCellValue("创建日期");
            //....N行

            //将数据逐步写入sheet1各个行
            for (int i = 0; i < listnew.Count; i++)
            {
                NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(i + 1);
                rowtemp.CreateCell(0).SetCellValue(listnew[i].username.ToString());
                rowtemp.CreateCell(1).SetCellValue(listnew[i].truename.ToString());
                rowtemp.CreateCell(2).SetCellValue(listnew[i].rolename.ToString());
                rowtemp.CreateCell(3).SetCellValue(listnew[i].createdate.ToString());
                //....N行
            }
            // 写入到客户端 
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            book.Write(ms);
            ms.Seek(0, System.IO.SeekOrigin.Begin);
            DateTime dt = DateTime.Now;
            string dateTime = dt.ToString("yyMMddHHmmssfff");
            string fileName = "查询结果" + dateTime + ".xls";
            return File(ms, "application/vnd.ms-excel", fileName);
        }
    }
}
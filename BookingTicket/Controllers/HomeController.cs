using BookingTicket.BussinessLogic;
using BookingTicket.BussinessObject;
using BookingTicket.Models;
using BookingTicket.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingTicket.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var objUser = SysUserModels.Current.CurrentUser();
            if (objUser == null || objUser.UserName == null)
                return Redirect("/dang-nhap");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Quản lý nhà xe";

            return View();
        }
        public ActionResult Home()
        {
            var objUser = SysUserModels.Current.CurrentUser();
            if (objUser == null || objUser.UserName == null)
                return Redirect("/dang-nhap");
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Quản lý nhà xe";

            return View();
        }
    }
}
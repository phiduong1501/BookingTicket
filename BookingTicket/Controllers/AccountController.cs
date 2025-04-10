using BookingTicket.BussinessLogic;
using BookingTicket.BussinessObject;
using BookingTicket.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TGDD.Library.Core;

namespace BookingTicket.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult ChangePassword()
        {
            return View();
        }



        [AllowAnonymous]
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.RemoveAll();
            return Redirect("/dang-nhap");
        }

        public ActionResult ComputerRegistry()
        {
            try
            {
                var user = SysUserModels.Current.CurrentUser();
                if (user == null)
                    return Json(new { Success = false, Message = "Vui lòng đăng nhập lại" });

                //tanhk
                HttpCookie myCookie = new HttpCookie("quanlynhaxe1");
                DateTime now = DateTime.Now;
                // Set the cookie value.
                myCookie.Value = "Lkzm0xcl7zvA_W7w99UXRITK3";
                // Set the cookie expiration date.
                myCookie.Expires = now.AddYears(50); // For a cookie to effectively never expire
                // Add the cookie.
                //Response.Cookies.Add(myCookie);
                Response.Cookies.Remove("quanlynhaxe1");
                Response.Cookies.Add(myCookie);
                //Response.Write("<p> The cookie has been written.");
                return Json(new { Success = true, Message = "Ðăng ký thành công!" });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }

        public ActionResult SignIn(string strUserName, string strPassword)
        {
            /*if (strUserName == "trong" || strUserName == "kimtan" || strUserName == "thuyvy" || strUserName == "thuyngoc"
                || strUserName == "camvan" || strUserName == "admin")*/
            {
                SysUserBO objUser = new SysUserBO();
                objUser.UserName = strUserName;
                objUser.Password = Utils.Utils.GetMD5(strPassword);
                if (AccountRepository.Current.SignIn(ref objUser))
                {
                    Session["sysuser"] = objUser;
                    //Session["FirstTime"] = "1";
                    return Json(new { Result = 1, Message = "Ðăng nhập thành công!" });
                }
                return Json(new { Result = -1, Message = "Ðăng nhập thất bại!" });
            }
            /*else
            { 
                //tanhk
                HttpCookie myCookie = Request.Cookies["quanlynhaxe1"];
                // Read the cookie information and display it.
                //Response.Write("<p>" + myCookie.Name + "<p>" + myCookie.Value);
                if (myCookie != null && myCookie.Name.ToString() == "quanlynhaxe1")
                {
                    SysUserBO objUser = new SysUserBO();
                    objUser.UserName = strUserName;
                    objUser.Password = Utils.Utils.GetMD5(strPassword);
                    if (AccountRepository.Current.SignIn(ref objUser))
                    {
                        Session["sysuser"] = objUser;
                        //Session["FirstTime"] = "1";
                        return Json(new { Result = 1, Message = "Ðăng nhập thành công!" });
                    }
                    return Json(new { Result = -1, Message = "Ðăng nhập thất bại!" });
                }
                else
                {
                    //Response.Write("not found");
                    return Json(new { Result = -1, Message = "Ðăng nhập thất bại!" });
                }
            }*/
        }

        public ActionResult UpdatePassword(string strUserName, string strPassword)
        {
            strPassword = Utils.Utils.GetMD5(strPassword);
            return Json(AccountRepository.Current.ChangePassword(strUserName, strPassword));
        }

        public ActionResult GetAllUser()
        {
            try
            {
                var objUser = SysUserModels.Current.CurrentUser();
                DataTable dt = AccountRepository.Current.GetAll(objUser.UserName);
                return Json(new { Success = true, Result = Utils.Utils.ConvertDataTableTojSonString(dt) });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }

        public ActionResult InsertUser(SysUserBO objBO)
        {
            try
            {
                var user = SysUserModels.Current.CurrentUser();
                if (user == null)
                    return Json(new { Success = false, Message = "Vui lòng đăng nhập lại" });

                objBO.Password = Utils.Utils.GetMD5(objBO.Password);
                objBO.CreatedUser = user.UserName;
                AccountRepository.Current.Insert(objBO);
                return Json(new { Success = true });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }

        public ActionResult DeleteUser(SysUserBO objBO)
        {
            try
            {
                var user = SysUserModels.Current.CurrentUser();
                if (user == null)
                    return Json(new { Success = false, Message = "Vui lòng đăng nhập lại" });

                objBO.DeletedUser = user.UserName;
                AccountRepository.Current.Delete(objBO);
                return Json(new { Success = true });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }

        public ActionResult UpdateUser(SysUserBO objBO)
        {
            try
            {
                var user = SysUserModels.Current.CurrentUser();
                if (user == null)
                    return Json(new { Success = false, Message = "Vui lòng đăng nhập lại" });

                if (!string.IsNullOrEmpty(objBO.NewPassword))
                    objBO.Password = Utils.Utils.GetMD5(objBO.NewPassword);

                objBO.UpdatedUser = user.UserName;
                AccountRepository.Current.Update(objBO);
                return Json(new { Success = true });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }

       
    }
}
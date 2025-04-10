using BookingTicket.BussinessLogic;
using BookingTicket.BussinessObject;
using BookingTicket.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingTicket.Controllers
{
    public class CompanyController : Controller
    {
        public ActionResult List()
        {
            return View();
        }
        public ActionResult GetAllCompany()
        {
            try
            {
                DataTable dt = SysCompanyRepository.Current.GetAll();
                return Json(new { Success = true, Result = Utils.Utils.ConvertDataTableTojSonString(dt) });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }
        public ActionResult RegisterCompany(string UserName, string Password, string CompanyName, string Address, string Phone, string ContactPerson, string ContactPhone)
        {
            try
            {
                DataTable dt = AccountRepository.Current.GetAll(UserName);
                if (dt?.Rows?.Count > 0)
                {
                    return Json(new { Success = false, Message = "Tài khoản đã tồn tại!" });
                }
                var objCompany = new SysCompanyBO
                {
                    CompanyName = CompanyName,
                    Address = Address,
                    Phone = Phone,
                    ContactPerson = ContactPerson,
                    ContactPhone = ContactPhone,
                    UserAdmin = UserName,
                    CreatedUser = "Administrator"
                };
                var dt_Company = SysCompanyRepository.Current.Insert(objCompany);
                if (!string.IsNullOrEmpty(dt_Company))
                {    
                    var objUser = new SysUserBO
                    {
                        UserName = UserName,
                        FullName = ContactPerson,
                        Password = Utils.Utils.GetMD5(Password),
                        CompanyID = Convert.ToInt32(dt_Company),
                        StationID = 0,
                        IsAllowBooking = true,
                        IsAllowManager = true,
                        IsAllowRouter = true,
                        CreatedUser = "Administrator"
                    };
                    AccountRepository.Current.Insert(objUser);
                }
                else
                {
                    return Json(new { Success = false, Message = "Lỗi tạo công ty!" });
                }
                return Json(new { Success = true });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }
        public ActionResult InsertUser(SysCompanyBO objBO)
        {
            try
            {
                var user = SysUserModels.Current.CurrentUser();
                if (user == null)
                    return Json(new { Success = false, Message = "Vui lòng đăng nhập lại" });


                objBO.CreatedUser = user.UserName;
                SysCompanyRepository.Current.Insert(objBO);
                return Json(new { Success = true });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }

        public ActionResult DeleteCompany(SysCompanyBO objBO)
        {
            try
            {
                var user = SysUserModels.Current.CurrentUser();
                if (user == null)
                    return Json(new { Success = false, Message = "Vui lòng đăng nhập lại" });

                objBO.DeletedUser = user.UserName;
                SysCompanyRepository.Current.Delete(objBO);
                return Json(new { Success = true });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }

        public ActionResult UpdateCompany(SysCompanyBO objBO)
        {
            try
            {
                var user = SysUserModels.Current.CurrentUser();
                if (user == null)
                    return Json(new { Success = false, Message = "Vui lòng đăng nhập lại" });

                objBO.UpdatedUser = user.UserName;
                SysCompanyRepository.Current.Update(objBO);
                return Json(new { Success = true });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }

        public ActionResult ApproveCompany(SysCompanyBO objBO)
        {
            try
            {
                var user = SysUserModels.Current.CurrentUser();
                if (user == null)
                    return Json(new { Success = false, Message = "Vui lòng đăng nhập lại" });

                objBO.DeletedUser = user.UserName;
                SysCompanyRepository.Current.Approve(objBO);
                return Json(new { Success = true });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }
    }
}
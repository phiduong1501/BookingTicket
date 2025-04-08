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
                var objUser = SysUserModels.Current.CurrentUser();
                DataTable dt = SysCompanyRepository.Current.GetAll(0,20);
                return Json(new { Success = true, Result = Utils.Utils.ConvertDataTableTojSonString(dt) });
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
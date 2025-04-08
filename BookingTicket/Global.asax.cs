using BookingTicket.BussinessObject;
using BookingTicket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BookingTicket
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_PreRequestHandlerExecute(object sender, EventArgs e)
        {

            //HttpApplication application = (HttpApplication)sender;
            //HttpContext context = application.Context;
            //string filePath = context.Request.FilePath;
            //string fileExtention = VirtualPathUtility.GetExtension(filePath);
            //if (context.Session != null)
            //{
            //     var objUser = context.Session["sysuser"] as SysUserBO;

            //    if (objUser == null && !Request.Url.ToString().Contains("dang-nhap") && !Request.Url.ToString().Contains("SignIn"))
            //    {
            //        Session.Clear();
            //        Session.Remove("user");
            //        Response.Redirect("~/dang-nhap", true);
            //    }
            //    else if (objUser != null)
            //    {
            //        if (Request.Url.ToString().Contains("dang-nhap"))
            //            Response.Redirect("~/", true);
            //    }
            //}
        }
    }
}

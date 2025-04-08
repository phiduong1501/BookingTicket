using BookingTicket.BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingTicket.Models
{
    public class SysUserModels
    {
        /// <summary>
        ///
        /// </summary>
        private static SysUserModels _instance;

        /// <summary>
        ///
        /// </summary>
        public static SysUserModels Current
        {
            get { return _instance ?? (_instance = new SysUserModels()); }
        }

        public SysUserBO CurrentUser()
        {
            try
            {
                if (HttpContext.Current != null && HttpContext.Current.Session != null)
                {
                    HttpSessionStateBase session = new HttpSessionStateWrapper(HttpContext.Current.Session);
                    return session["sysuser"] as SysUserBO;
                }
            }
            catch (Exception objEx)
            {

            }
            return null;
        }
    }
}
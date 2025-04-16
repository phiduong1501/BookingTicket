using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BookingTicket.BussinessObject
{
    public class SysUserBO
    {
        
        #region Member Variables

        private int intUserId = int.MinValue;
        private string strUserName = string.Empty;
        private string strPassword = string.Empty;
        private string strNewPassword = string.Empty;
        private string strFullName = string.Empty;
        private bool bolIsDeleted;
        private string strDeletedUser = string.Empty;
        private DateTime dtmDeletedDate = DateTime.MinValue;
        private string strUpdatedUser = string.Empty;
        private DateTime dtmUpdatedDate = DateTime.MinValue;
        private string strCreatedUser = string.Empty;
        private DateTime dtmCreatedDate = DateTime.MinValue;
        private int intStationID = int.MinValue;
        private int intRouteID = int.MinValue;
        private bool bolIsAllowBooking = false;
        private bool bolIsAllowManager = false;
        private bool bolIsAllowRouter = false;
        private int intCompanyID = int.MinValue;
        private string strCompanyName = string.Empty;
        #endregion


        #region Properties 

        public static string CacheKey
        {
            get { return "SysUser_GetAll"; }
        }

        /// <summary>
        /// UserId
        /// 
        /// </summary>
        public int UserId
        {
            get { return intUserId; }
            set { intUserId = value; }
        }

        public int StationID
        {
            get { return intStationID; }
            set { intStationID = value; }
        }

        public int RouteID
        {
            get { return intRouteID; }
            set { intRouteID = value; }
        }

        /// <summary>
        /// UserName
        /// 
        /// </summary>
        public string UserName
        {
            get { return strUserName; }
            set { strUserName = value; }
        }

        /// <summary>
        /// Password
        /// 
        /// </summary>
        public string Password
        {
            get { return strPassword; }
            set { strPassword = value; }
        }

        /// <summary>
        /// Password
        /// 
        /// </summary>
        public string NewPassword
        {
            get { return strNewPassword; }
            set { strNewPassword = value; }
        }

        /// <summary>
        /// FullName
        /// 
        /// </summary>
        public string FullName
        {
            get { return strFullName; }
            set { strFullName = value; }
        }

        /// <summary>
        /// IsDeleted
        /// 
        /// </summary>
        public bool IsDeleted
        {
            get { return bolIsDeleted; }
            set { bolIsDeleted = value; }
        }

        public bool IsAllowBooking
        {
            get { return bolIsAllowBooking; }
            set { bolIsAllowBooking = value; }
        }

        public bool IsAllowManager
        {
            get { return bolIsAllowManager; }
            set { bolIsAllowManager = value; }
        }

        public bool IsAllowRouter
        {
            get { return bolIsAllowRouter; }
            set { bolIsAllowRouter = value; }
        }

        /// <summary>
        /// DeletedUser
        /// 
        /// </summary>
        public string DeletedUser
        {
            get { return strDeletedUser; }
            set { strDeletedUser = value; }
        }

        /// <summary>
        /// DeletedDate
        /// 
        /// </summary>
        public DateTime DeletedDate
        {
            get { return dtmDeletedDate; }
            set { dtmDeletedDate = value; }
        }

        /// <summary>
        /// UpdatedUser
        /// 
        /// </summary>
        public string UpdatedUser
        {
            get { return strUpdatedUser; }
            set { strUpdatedUser = value; }
        }

        /// <summary>
        /// UpdatedDate
        /// 
        /// </summary>
        public DateTime UpdatedDate
        {
            get { return dtmUpdatedDate; }
            set { dtmUpdatedDate = value; }
        }

        /// <summary>
        /// CreatedUser
        /// 
        /// </summary>
        public string CreatedUser
        {
            get { return strCreatedUser; }
            set { strCreatedUser = value; }
        }

        /// <summary>
        /// CreatedDate
        /// 
        /// </summary>
        public DateTime CreatedDate
        {
            get { return dtmCreatedDate; }
            set { dtmCreatedDate = value; }
        }
        public int CompanyID
        {
            get { return intCompanyID; }
            set { intCompanyID = value; }
        }  
        public string CompanyName
        {
            get { return strCompanyName; }
            set { strCompanyName = value; }
        }

        #endregion


        #region Constructor

        public SysUserBO()
        {
        }
        private static SysUserBO _current;
        static SysUserBO()
        {
            _current = new SysUserBO();
        }
        public static SysUserBO Current
        {
            get
            {
                return _current;
            }
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingTicket.BussinessObject
{
    public class SysCompanyBO
    {
        #region Member Variables

        private int intCompanyID = int.MinValue;
        private string strCompanyName = string.Empty;
        private string strAddress = string.Empty;
        private string strPhone = string.Empty;
        private string strContactName = string.Empty;
        private string strContactPhone = string.Empty;
        private bool bolIsDeleted;
        private string strDeletedUser = string.Empty;
        private DateTime dtmDeletedDate = DateTime.MinValue;
        private string strUpdatedUser = string.Empty;
        private DateTime dtmUpdatedDate = DateTime.MinValue;
        private string strCreatedUser = string.Empty;
        private DateTime dtmCreatedDate = DateTime.MinValue;
        private int intStatus = int.MinValue;
        private string strApprovedUser = string.Empty;
        private DateTime dtmApprovedDate = DateTime.MinValue;

        #endregion


        #region Properties 

        public static string CacheKey
        {
            get { return "SysCompany_GetAll"; }
        }

        /// <summary>
        /// CompanyID
        /// 
        /// </summary>
        public int CompanyID
        {
            get { return intCompanyID; }
            set { intCompanyID = value; }
        }
        /// <summary>
        /// CompanyName
        /// 
        /// </summary>
        public string CompanyName
        {
            get { return strCompanyName; }
            set { strCompanyName = value; }
        }
        /// <summary>
        /// Address
        /// 
        /// </summary>
        public string Address
        {
            get { return strAddress; }
            set { strAddress = value; }
        }
        /// <summary>
        /// Phone
        /// 
        /// </summary>
        public string Phone
        {
            get { return strPhone; }
            set { strPhone = value; }
        }
        /// <summary>
        /// ContactName
        /// </summary>
        public string ContactName
        {
            get { return strContactName; }
            set { strContactName = value; }
        }
        /// <summary>
        /// ContactPhone
        /// </summary>
        public string ContactPhone
        {
            get { return strContactPhone; }
            set { strContactPhone = value; }
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
        public int Status
        {
            get { return intStatus; }
            set { intStatus = value; }
        }

        public string ApprovedUser
        {
            get { return strApprovedUser; }
            set { strApprovedUser = value; }
        }

        public DateTime AprrovedDate
        {
            get { return dtmApprovedDate; }
            set { dtmApprovedDate = value; }
        }

        #endregion


        #region Constructor

        public SysCompanyBO()
        {
        }
        private static SysCompanyBO _current;
        static SysCompanyBO()
        {
            _current = new SysCompanyBO();
        }
        public static SysCompanyBO Current
        {
            get
            {
                return _current;
            }
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingTicket.BussinessObject
{
    public class SysTimeBO
    {
        #region Member Variables

        private int intTimeGoID = int.MinValue;
        private string strTimeGo = string.Empty;
        private string strNote = string.Empty;
        private bool bolIsDeleted;
        private string strDeletedUser = string.Empty;
        private DateTime dtmDeletedDate = DateTime.MinValue;
        private string strUpdatedUser = string.Empty;
        private DateTime dtmUpdatedDate = DateTime.MinValue;
        private string strCreatedUser = string.Empty;
        private DateTime dtmCreatedDate = DateTime.MinValue;
       
        #endregion


        #region Properties 

        public static string CacheKey
        {
            get { return "SysGioChay_GetAll"; }
        }
       
        /// <summary>
        /// TimeGoID
        /// 
        /// </summary>
        public int TimeGoID
        {
            get { return intTimeGoID; }
            set { intTimeGoID = value; }
        }

        /// <summary>
        /// TimeGo
        /// 
        /// </summary>
        public string TimeGo
        {
            get { return strTimeGo; }
            set { strTimeGo = value; }
        }

        /// <summary>
        /// Note
        /// 
        /// </summary>
        public string Note
        {
            get { return strNote; }
            set { strNote = value; }
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


        #endregion


        #region Constructor

        public SysTimeBO()
        {
        }
        private static SysTimeBO _current;
        static SysTimeBO()
        {
            _current = new SysTimeBO();
        }
        public static SysTimeBO Current
        {
            get
            {
                return _current;
            }
        }
        #endregion
    }
}

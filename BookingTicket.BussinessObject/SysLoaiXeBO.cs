using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingTicket.BussinessObject
{
    public class SysLoaiXeBO
    {
        #region Member Variables

        private int intCarTypeID = int.MinValue;
        private int intNumberOfSeat = int.MinValue;
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
            get { return "SysLoaiXe_GetAll"; }
        }

        /// <summary>
        /// CarTypeID
        /// 
        /// </summary>
        public int CarTypeID
        {
            get { return intCarTypeID; }
            set { intCarTypeID = value; }
        }
        /// <summary>
        /// NumberOfSeat
        /// 
        /// </summary>
        public int NumberOfSeat
        {
            get { return intNumberOfSeat; }
            set { intNumberOfSeat = value; }
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

        public SysLoaiXeBO()
        {
        }
        private static SysLoaiXeBO _current;
        static SysLoaiXeBO()
        {
            _current = new SysLoaiXeBO();
        }
        public static SysLoaiXeBO Current
        {
            get
            {
                return _current;
            }
        }
        #endregion
    }
}

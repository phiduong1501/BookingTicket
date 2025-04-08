using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingTicket.BussinessObject
{
    public class SysPickupAddressBO
    {
        #region Member Variables
        private int intRouteID = int.MinValue;
        private int intAddressID = int.MinValue;
        private string strAddressName = string.Empty;
        private string strAddress = string.Empty;
        private int intType = int.MinValue;
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
            get { return "SysPickupAddress_GetAll"; }
        }

        /// <summary>
        /// intRouteID
        /// 
        /// </summary>
        public int RouteID
        {
            get { return intRouteID; }
            set { intRouteID = value; }
        }

        /// <summary>
        /// AddressID
        /// 
        /// </summary>
        public int AddressID
        {
            get { return intAddressID; }
            set { intAddressID = value; }
        }

        /// <summary>
        /// AddressName
        /// 
        /// </summary>
        public string AddressName
        {
            get { return strAddressName; }
            set { strAddressName = value; }
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
        /// Type
        /// 1: trung chuyen; 2: don doc duong
        /// </summary>
        public int Type
        {
            get { return intType; }
            set { intType = value; }
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

        public SysPickupAddressBO()
        {
        }
        private static SysPickupAddressBO _current;
        static SysPickupAddressBO()
        {
            _current = new SysPickupAddressBO();
        }
        public static SysPickupAddressBO Current
        {
            get
            {
                return _current;
            }
        }
        #endregion
    }
}

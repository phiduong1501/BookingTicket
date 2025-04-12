using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingTicket.BussinessObject
{
    public class SysRouteBO
    {
        #region Member Variables

        private int intRouteID = int.MinValue;
        private string strRouteName = string.Empty;
        private int intStationFromID = int.MinValue;
        private int intStationToID = int.MinValue;
        private int intPrice = int.MinValue;
        private string strNote = string.Empty;
        private bool bolIsDeleted;
        private string strDeletedUser = string.Empty;
        private DateTime dtmDeletedDate = DateTime.MinValue;
        private string strUpdatedUser = string.Empty;
        private DateTime dtmUpdatedDate = DateTime.MinValue;
        private string strCreatedUser = string.Empty;
        private DateTime dtmCreatedDate = DateTime.MinValue;
        private int intTimeExpect = int.MinValue;

        #endregion


        #region Properties 

        public static string CacheKey
        {
            get { return "SysRoute_GetAll"; }
        }

        /// <summary>
        /// RouteID
        /// 
        /// </summary>
        public int RouteID
        {
            get { return intRouteID; }
            set { intRouteID = value; }
        }
        /// <summary>
        /// TimeExpect
        /// 
        /// </summary>
        public int TimeExpect
        {
            get { return intTimeExpect; }
            set { intTimeExpect = value; }
        }

        /// <summary>
        /// RouteName
        /// 
        /// </summary>
        public string RouteName
        {
            get { return strRouteName; }
            set { strRouteName = value; }
        }

        /// <summary>
        /// StationFrom
        /// 
        /// </summary>
        public int StationFromID
        {
            get { return intStationFromID; }
            set { intStationFromID = value; }
        }

        /// <summary>
        /// StationTo
        /// 
        /// </summary>
        public int StationToID
        {
            get { return intStationToID; }
            set { intStationToID = value; }
        }

        /// <summary>
        /// Price
        /// 
        /// </summary>
        public int Price
        {
            get { return intPrice; }
            set { intPrice = value; }
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

        public SysRouteBO()
        {
        }
        private static SysRouteBO _current;
        static SysRouteBO()
        {
            _current = new SysRouteBO();
        }
        public static SysRouteBO Current
        {
            get
            {
                return _current;
            }
        }
        #endregion
    }
    public class Sys_VehicleTypeBO
    {
        public int VehicleTypeID { get; set; }
        public string VehicleTypeName { get; set; }
        public int NumberOfSeat { get; set; }
        public string Note { get; set; }
        public int CompanyID { get; set; }
        public bool IsDeleted { get; set; }
        public string DeletedUser { get; set; }
        public DateTime DeletedDate { get; set; }
        public string UpdatedUser { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

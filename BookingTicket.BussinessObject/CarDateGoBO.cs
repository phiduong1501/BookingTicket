using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingTicket.BussinessObject
{
    public class CarDateGoBO
    {
        #region Member Variables

        private int intCarDateGoID = int.MinValue;
        private int intTypeID = int.MinValue;
        private int intRouteID = int.MinValue;
        private DateTime dtmGoDate = DateTime.MinValue;
        private string strGoTime = string.Empty;
        private string strDriver = string.Empty;
        private string strCarNumber = string.Empty;
        private int intNumberOfSeat = 34;//mặc định 34
        ////tanhk
        private bool bolIsTransship = false;
        private bool bolIsNewBus = false;
        ////tanhk
        private bool bolIsGo;
        private DateTime dtmRealTimeGo = DateTime.MinValue;
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
            get { return "CarDateGo_GetAll"; }
        }

        /// <summary>
        /// CarDateGoID
        /// 
        /// </summary>
        public int CarDateGoID
        {
            get { return intCarDateGoID; }
            set { intCarDateGoID = value; }
        }

        /// <summary>
        /// TypeID
        /// 1: cố định; 2: tăng cường
        /// </summary>
        public int TypeID
        {
            get { return intTypeID; }
            set { intTypeID = value; }
        }

        /// <summary>
        /// RouteName
        /// Tuyến đường
        /// </summary>
        public int RouteID
        {
            get { return intRouteID; }
            set { intRouteID = value; }
        }

        /// <summary>
        /// GoDate
        /// 
        /// </summary>
        public DateTime GoDate
        {
            get { return dtmGoDate; }
            set { dtmGoDate = value; }
        }

        /// <summary>
        /// GoTime
        /// 
        /// </summary>
        public string GoTime
        {
            get { return strGoTime; }
            set { strGoTime = value; }
        }

        /// <summary>
        /// Driver
        /// 
        /// </summary>
        public string Driver
        {
            get { return strDriver; }
            set { strDriver = value; }
        }

        /// <summary>
        /// CarNumber
        /// 
        /// </summary>
        public string CarNumber
        {
            get { return strCarNumber; }
            set { strCarNumber = value; }
        }
        
        public int NumberOfSeat
        {
            get { return intNumberOfSeat; }
            set { intNumberOfSeat = value; }
        }

        /// <summary>
        /// IsTransship
        /// 
        /// </summary>
        public bool IsTransship
        {
            get { return bolIsTransship; }
            set { bolIsTransship = value; }
        }

        /// <summary>
        /// IsNewBus
        /// 
        /// </summary>
        public bool IsNewBus
        {
            get { return bolIsNewBus; }
            set { bolIsNewBus = value; }
        }

        /// <summary>
        /// IsGo
        /// 
        /// </summary>
        public bool IsGo
        {
            get { return bolIsGo; }
            set { bolIsGo = value; }
        }

        /// <summary>
        /// RealTimeGo
        /// 
        /// </summary>
        public DateTime RealTimeGo
        {
            get { return dtmRealTimeGo; }
            set { dtmRealTimeGo = value; }
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

        public CarDateGoBO()
        {
        }
        private static CarDateGoBO _current;
        static CarDateGoBO()
        {
            _current = new CarDateGoBO();
        }
        public static CarDateGoBO Current
        {
            get
            {
                return _current;
            }
        }
        #endregion
    }
}

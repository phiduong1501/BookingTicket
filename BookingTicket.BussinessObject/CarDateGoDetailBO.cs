using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingTicket.BussinessObject
{
    public class CarDateGoDetailBO
    {

        #region Member Variables
        private int intRouteID;
        private long logCarDateGoDetailID;
        private int intCarDateGoID = int.MinValue;
        private int intSeatNumber = int.MinValue;
        private string strDescription = string.Empty;
        private int intSeatStatusID = int.MinValue;
        private bool bolIsPickUp;
        private bool bolIsTransit;
        private string strPassengerName = string.Empty;
        private string strMobile = string.Empty;
        private string strAddress = string.Empty;
        private int intCreatedStationID = int.MinValue;
        private string strNote = string.Empty;
        private bool bolIsDeleted;
        private string strDeletedUser = string.Empty;
        private DateTime dtmDeletedDate = DateTime.MinValue;
        private string strUpdatedUser = string.Empty;
        private DateTime dtmUpdatedDate = DateTime.MinValue;
        private string strCreatedUser = string.Empty;
        private DateTime dtmCreatedDate = DateTime.MinValue;
        private int intPaymentStatusID = int.MinValue;
        private string strGoTime = string.Empty;
        private DateTime dtGoDate = DateTime.MinValue;
        #endregion


        #region Properties 

        public static string CacheKey
        {
            get { return "CarDateGoDetail_GetAll"; }
        }
        /// <summary>
        /// RouteID
        /// </summary>
        public DateTime GoDate
        {
            get { return dtGoDate; }
            set { dtGoDate = value; }
        }
        /// <summary>
        /// RouteID
        /// </summary>
        public string GoTime
        {
            get { return strGoTime; }
            set { strGoTime = value; }
        }
        /// <summary>
        /// RouteID
        /// </summary>
        public int RouteID
        {
            get { return intRouteID; }
            set { intRouteID = value; }
        }

        /// <summary>
        /// CarDateGoDetailID
        /// 
        /// </summary>
        public long CarDateGoDetailID
        {
            get { return logCarDateGoDetailID; }
            set { logCarDateGoDetailID = value; }
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
        /// CarDateGoID
        /// 
        /// </summary>
        public int PaymentStatusID
        {
            get { return intPaymentStatusID; }
            set { intPaymentStatusID = value; }
        }

        /// <summary>
        /// SeatNumber
        /// 
        /// </summary>
        public int SeatNumber
        {
            get { return intSeatNumber; }
            set { intSeatNumber = value; }
        }

        /// <summary>
        /// Description
        /// 
        /// </summary>
        public string Description
        {
            get { return strDescription; }
            set { strDescription = value; }
        }

        /// <summary>
        /// Status
        /// -1: ghế khóa; 0: trống; 1: đặt chổ không thông tin; 2: đặt chổ có thông tin
        /// </summary>
        public int SeatStatusID
        {
            get { return intSeatStatusID; }
            set { intSeatStatusID = value; }
        }

        /// <summary>
        /// IsPickUp
        /// Đón khách
        /// </summary>
        public bool IsPickUp
        {
            get { return bolIsPickUp; }
            set { bolIsPickUp = value; }
        }

        /// <summary>
        /// IsTransit
        /// Trung chuyển
        /// </summary>
        public bool IsTransit
        {
            get { return bolIsTransit; }
            set { bolIsTransit = value; }
        }

        /// <summary>
        /// PassengerName
        /// 
        /// </summary>
        public string PassengerName
        {
            get { return strPassengerName; }
            set { strPassengerName = value; }
        }

        /// <summary>
        /// Mobile
        /// 
        /// </summary>
        public string Mobile
        {
            get { return strMobile; }
            set { strMobile = value; }
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
        /// CreatedStation
        /// 
        /// </summary>
        public int CreatedStationID
        {
            get { return intCreatedStationID; }
            set { intCreatedStationID = value; }
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

        public string ListID { get; set; }
        public int StationToID { get; set; }
        public int StationFromID { get; set; }
        #endregion


        #region Constructor

        public CarDateGoDetailBO()
        {
        }
        private static CarDateGoDetailBO _current;
        static CarDateGoDetailBO()
        {
            _current = new CarDateGoDetailBO();
        }
        public static CarDateGoDetailBO Current
        {
            get
            {
                return _current;
            }
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingTicket.BussinessObject
{
    public class SysStationBO
    {
        #region Member Variables

        private int intStationID = int.MinValue;
        private string strStationName = string.Empty;
        private string strStationShortName = string.Empty;
        private int intOrderIndex = int.MinValue;
        private string strDeletedUser = string.Empty;
        private string strCreatedUser = string.Empty;

        #endregion


        #region Properties 

        public static string CacheKey
        {
            get { return "SysStation_GetAll"; }
        }
        /// <summary>
        /// StationID
        /// 
        /// </summary>
        public int StationID
        {
            get { return intStationID; }
            set { intStationID = value; }
        }

        public int OrderIndex
        {
            get { return intOrderIndex; }
            set { intOrderIndex = value; }
        }

        /// <summary>
        /// StationName
        /// 
        /// </summary>
        public string StationName
        {
            get { return strStationName; }
            set { strStationName = value; }
        }

        /// <summary>
        /// StationShortName
        /// 
        /// </summary>
        public string StationShortName
        {
            get { return strStationShortName; }
            set { strStationShortName = value; }
        }

        public string DeletedUser
        {
            get { return strDeletedUser; }
            set { strDeletedUser = value; }
        }

        public string CreatedUser
        {
            get { return strCreatedUser; }
            set { strCreatedUser = value; }
        }


        #endregion


        #region Constructor

        public SysStationBO()
        {
        }
        private static SysStationBO _current;
        static SysStationBO()
        {
            _current = new SysStationBO();
        }
        public static SysStationBO Current
        {
            get
            {
                return _current;
            }
        }
        #endregion
    }
}

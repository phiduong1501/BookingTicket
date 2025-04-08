using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingTicket.BussinessObject
{
    public class CarDateGoDetailLogBO
    {
        #region Member Variables

        private long logCarDateGoDetailLogID;
        private long logCarDateGoDetailID;
        private string strNoteChange = string.Empty;
        private string strUpdatedUser = string.Empty;
        private DateTime dtmUpdatedDate = DateTime.MinValue;
        #endregion


        #region Properties 

        public static string CacheKey
        {
            get { return "CarDateGoDetailLog_GetAll"; }
        }
        /// <summary>
        /// CarDateGoDetailLogID
        /// 
        /// </summary>
        public long CarDateGoDetailLogID
        {
            get { return logCarDateGoDetailLogID; }
            set { logCarDateGoDetailLogID = value; }
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
        /// NoteChange
        /// 
        /// </summary>
        public string NoteChange
        {
            get { return strNoteChange; }
            set { strNoteChange = value; }
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


        #endregion


        #region Constructor

        public CarDateGoDetailLogBO()
        {
        }
        private static CarDateGoDetailLogBO _current;
        static CarDateGoDetailLogBO()
        {
            _current = new CarDateGoDetailLogBO();
        }
        public static CarDateGoDetailLogBO Current
        {
            get
            {
                return _current;
            }
        }
        #endregion
    }
}

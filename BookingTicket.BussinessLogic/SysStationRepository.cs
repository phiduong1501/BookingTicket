using BookingTicket.BussinessObject;
using BookingTicket.DataObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingTicket.BussinessLogic
{
   public class SysStationRepository
    {
        #region Variable

        private SysStationDAO objStation = new SysStationDAO();

        private static SysStationRepository objStationRepository = new SysStationRepository();

        public static SysStationRepository Current
        {
            get { return objStationRepository; }
            set { objStationRepository = value; }
        }
        #endregion


        #region Method
        public DataTable GetAllStation(int intSortDesc, string strUserName)
        {
            try
            {
                return objStation.GetAll(intSortDesc, strUserName);
            }
            catch (Exception objEx)
            {
                throw objEx;
            }
        }
        public object Insert(SysStationBO objBO,string strUserName)
        {
            try
            {
                return objStation.Insert(objBO, strUserName);
            }
            catch (Exception objEx)
            {

                throw objEx;
            }
        }
        public object Update(SysStationBO objBO, string strUserName)
        {
            try
            {
                return objStation.Update(objBO, strUserName);
            }
            catch (Exception objEx)
            {

                throw objEx;
            }
        }
        public object Delete(SysStationBO objBO)
        {
            try
            {
                return objStation.Delete(objBO);
            }
            catch (Exception objEx)
            {

                throw objEx;
            }
        }
        #endregion
    }
}

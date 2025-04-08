using BookingTicket.DataObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using BookingTicket.BussinessObject;

namespace BookingTicket.BussinessLogic
{
    public class SysRouteRepository
    {
        #region Variable
        private SysRouteDAO objRouteDao = new SysRouteDAO();
        private static SysRouteRepository objSysRouteRepository = new SysRouteRepository();

        public static SysRouteRepository Current
        {
            get { return objSysRouteRepository; }
            set { objSysRouteRepository = value; }
        }
        #endregion

        public DataTable getRouteAll(string strUserName)
        {
            //try
            //{
            //    return objRouteDao.GetAll();
            //}
            //catch (Exception objEx)
            //{
            //    throw objEx;
            //}

            DataTable dtRoute = new DataTable(); //tanhk new
            try
            {
                string key = "GetRouteAll_"+strUserName;
                if (HttpRuntime.Cache[key] != null) //tanhk new
                    dtRoute = (DataTable)HttpRuntime.Cache[key]; //tanhk new
                else //tanhk new
                {
                    dtRoute = objRouteDao.GetAll(strUserName); //tanhk new
                    HttpRuntime.Cache.Insert(key, dtRoute, null, DateTime.Now.AddHours(4), TimeSpan.FromMinutes(0)); //tanhk new
                }
                //return objAddress.GetAll(type, routeID);
            }
            catch (Exception objEx)
            {
                throw objEx;
            }
            return dtRoute; //tanhk new
        }

        /// <summary>
        /// Lấy route theo station 
        /// </summary>
        /// <param name="intStationFrom"></param>
        /// <param name="intStationTo"></param>
        /// <returns></returns>
        public DataTable GetRouteByStation(int intStationFrom, int intStationTo, string strUserName)
        {
            try
            {
                return objRouteDao.GetRouteByStation(intStationFrom, intStationTo, strUserName);
            }
            catch (Exception objEx)
            {

                throw objEx;
            }
        }

        public object Insert(SysRouteBO objBO)
        {
            try
            {
                string key = "GetRouteAll_" + objBO.CreatedUser;
                HttpRuntime.Cache.Remove(key);
                return objRouteDao.Insert(objBO);
            }
            catch (Exception objEx)
            {

                throw objEx;
            }
        }
        public object Update(SysRouteBO objBO)
        {
            try
            {
                string key = "GetRouteAll_" + objBO.UpdatedUser;
                HttpRuntime.Cache.Remove(key);
                return objRouteDao.Update(objBO);
            }
            catch (Exception objEx)
            {

                throw objEx;
            }
        }
        public object Delete(SysRouteBO objBO)
        {
            try
            {
                string key = "GetRouteAll_" + objBO.DeletedUser;
                HttpRuntime.Cache.Remove(key);
                return objRouteDao.Delete(objBO);
            }
            catch (Exception objEx)
            {

                throw objEx;
            }
        }
    }
}

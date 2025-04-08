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
    public class SysTimeRepository
    {

        #region Variable
        private SysTimeDAO objDao = new SysTimeDAO();
        private static SysTimeRepository objSysTimeRepository = new SysTimeRepository();

        public static SysTimeRepository Current
        {
            get { return objSysTimeRepository; }
            set { objSysTimeRepository = value; }
        }
        #endregion
        public DataTable GetTimeAll(string strUserName)
        {
            //try
            //{
            //    return objDao.GetAll();
            //}
            //catch (Exception objEx)
            //{
            //    throw objEx;
            //}

            DataTable dtTimeAll = new DataTable(); //tanhk new
            try
            {
                string key = "GetTimeAll_" + strUserName;
                if (HttpRuntime.Cache[key] != null) //tanhk new
                    dtTimeAll = (DataTable)HttpRuntime.Cache[key]; //tanhk new
                else //tanhk new
                {
                    dtTimeAll = objDao.GetAll(strUserName); //tanhk new
                    HttpRuntime.Cache.Insert(key, dtTimeAll, null, DateTime.Now.AddHours(4), TimeSpan.FromMinutes(0)); //tanhk new
                }
                //return objAddress.GetAll(type, routeID);
            }
            catch (Exception objEx)
            {
                throw objEx;
            }
            return dtTimeAll; //tanhk new
        }
        public object Insert(SysTimeBO objBO)
        {
            try
            {
                string key = "GetTimeAll_" + objBO.CreatedUser;
                HttpRuntime.Cache.Remove(key);
                return objDao.Insert(objBO);
            }
            catch (Exception objEx)
            {

                throw objEx;
            }
        }
        public object Update(SysTimeBO objBO)
        {
            try
            {
                string key = "GetTimeAll_" + objBO.UpdatedUser;
                HttpRuntime.Cache.Remove(key);
                return objDao.Update(objBO);
            }
            catch (Exception objEx)
            {

                throw objEx;
            }
        }
        public object Delete(SysTimeBO objBO)
        {
            try
            {
                string key = "GetTimeAll_" + objBO.DeletedUser;
                HttpRuntime.Cache.Remove(key);
                return objDao.Delete(objBO.TimeGoID, objBO.DeletedUser);
            }
            catch (Exception objEx)
            {

                throw objEx;
            }
        }
    }
}

using BookingTicket.BussinessObject;
using BookingTicket.DataObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;

namespace BookingTicket.BussinessLogic
{
    public class SysPickupAdressReposoitory
    {
        #region Variable

        private SysPickupAddressDAO objAddress = new SysPickupAddressDAO();

        private static SysPickupAdressReposoitory objPickupAddressRepository = new SysPickupAdressReposoitory();

        public static SysPickupAdressReposoitory Current
        {
            get { return objPickupAddressRepository; }
            set { objPickupAddressRepository = value; }
        }
        #endregion


        #region Method
        /// <summary>
        /// Lấy các điểm gợi ý
        /// </summary>
        /// <param name="type">
        /// 1: Pickup
        /// 2: Transit
        /// </param>
        /// <returns></returns>
        public DataTable GetAllPickupAddress(int type, int routeID, string strUserName)
        {
            //try
            //{
            //    return objAddress.GetAll(type, routeID);
            //}
            //catch (Exception objEx)
            //{
            //    throw objEx;
            //}

            DataTable dtAddress = new DataTable(); //tanhk new
            try
            {
                string key = "GetAllPickupAddress" + type.ToString() + routeID.ToString(); 
                //if (type == 1)
                //{
                //    key = "GetAllPickupAddress1" ;
                //}
                //else
                //{
                //    key = "GetAllPickupAddress2";
                //}
                if (HttpRuntime.Cache[key] != null) //tanhk new
                    dtAddress = (DataTable)HttpRuntime.Cache[key]; //tanhk new
                else //tanhk new
                {
                    dtAddress = objAddress.GetAll(type, routeID, strUserName); //tanhk new
                    HttpRuntime.Cache.Insert(key, dtAddress, null, DateTime.Now.AddHours(4), TimeSpan.FromMinutes(0)); //tanhk new
                }
                //return objAddress.GetAll(type, routeID);
            }
            catch (Exception objEx)
            {
                throw objEx;
            }
            return dtAddress; //tanhk new
        }

        /// <summary>
        /// Thêm điểm đón
        /// </summary>
        /// <param name="objBO"></param>
        /// <returns></returns>
        public object Insert(SysPickupAddressBO objBO)
        {
            try
            {
                return objAddress.Insert(objBO);
            }
            catch (Exception objEx)
            {

                throw objEx;
            }
        }

        /// <summary>
        /// Cập nhật điểm đón
        /// </summary>
        /// <param name="objBO"></param>
        /// <returns></returns>
        public object Update(SysPickupAddressBO objBO)
        {
            try
            {
                return objAddress.Update(objBO);
            }
            catch (Exception objEx)
            {
                throw objEx;
            }
        }

        /// <summary>
        /// Xóa điểm đón
        /// </summary>
        /// <param name="objBO"></param>
        /// <returns></returns>
        public int Delete(SysPickupAddressBO objBO)
        {
            try
            {
                return objAddress.Delete(objBO);
            }
            catch (Exception objEx)
            {
                throw objEx;
            }
        }
        #endregion
    }
}

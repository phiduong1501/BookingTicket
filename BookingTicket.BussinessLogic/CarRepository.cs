using BookingTicket.BussinessObject;
using BookingTicket.DataObject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingTicket.BussinessLogic
{
    public class CarRepository
    {
        #region Variable
        private CarDateGoDAO objDateGo = new CarDateGoDAO();
        private CarDateGoDetailDAO objDateGoDetail = new CarDateGoDetailDAO();
        private CarDateGoDetailLogDAO objDateGoDetailLog = new CarDateGoDetailLogDAO();

        private static CarRepository objCarRepository = new CarRepository();
        private SysLoaiXeDAO objLoaiXe = new SysLoaiXeDAO();

        public static CarRepository Current
        {
            get { return objCarRepository; }
            set { objCarRepository = value; }
        }
        #endregion

        #region Method

        public object Insert(CarDateGoBO objBO)
        {
            try
            {
                return objDateGo.Insert(objBO);
            }
            catch (Exception objEx)
            {
                throw objEx;
            }
        }
        /// <summary>
        /// Lấy tất cả khung giờ của ngày được chọn
        /// </summary>
        /// <param name="dtDateGo"></param>
        /// <returns></returns>
        public DataTable GetTimeGoOfDateGo(DateTime dtDateGo, int routeID, string strUserName)
        {
            try
            {
                return objDateGo.GetTimeGoOfDateGo(dtDateGo, routeID, strUserName);
            }
            catch (Exception objEx)
            {
                throw objEx;
            }
        }

        /// <summary>
        /// Lấy tất cả ghế của khung giờ được chọn
        /// </summary>
        /// <param name="intDateGoID"></param>
        /// <returns></returns>
        public DataTable GetAllSeatOfTimeGo(int intDateGoID, int intStationID, string strUsername, int intRouteID)
        {
            try
            {
                return objDateGoDetail.GetAllSeatOfTimeGo(intDateGoID, intStationID, strUsername, intRouteID);
            }
            catch (Exception objEx)
            {
                throw objEx;
            }
        }

        public DataTable GetAllSeatCancelOfTimeGo(int intDateGoID, int intStationID, string strUsername)
        {
            try
            {
                return objDateGoDetail.GetAllSeatCancelOfTimeGo(intDateGoID, intStationID, strUsername);
            }
            catch (Exception objEx)
            {
                throw objEx;
            }
        }

        public string UpdateStatusSeat(CarDateGoDetailBO objBO)
        {
            try
            {
                return objDateGoDetail.UpdateStatusSeat(objBO);
            }
            catch (Exception objEx)
            {
                throw objEx;
            }
        }

        public string UpdateStatusPayment(CarDateGoDetailBO objBO)
        {
            try
            {
                return objDateGoDetail.UpdateStatusPayment(objBO);
            }
            catch (Exception objEx)
            {
                throw objEx;
            }
        }

        public bool PrintTicket(DataTable dtTicket)
        {
            printservice.PrintSevice objPrintSevice = new printservice.PrintSevice();
            objPrintSevice.Url = ConfigurationManager.AppSettings["printserviceURL"];
            objPrintSevice.Print(dtTicket);
            return true;
        }

        /// <summary>
        /// Lấy chi tiết ghế
        /// </summary>
        /// <param name="intSeatID"></param>
        /// <returns></returns>
        public DataTable GetSeatByID(string listSeatID, string strUserName)
        {
            try
            {
                return objDateGoDetail.GetSeatByID(listSeatID, strUserName);
            }
            catch (Exception objEx)
            {
                throw objEx;
            }
        }

        ///<summary>
        /// Update : Car_DateGoDetail
        /// Cap nhap thong tin
        ///</summary>
        public bool UpdateSeat(CarDateGoDetailBO objBO)
        {
            try
            {
                if (objBO.CarDateGoDetailID == 0 || objBO.CarDateGoDetailID == -1)
                    return false;

                var result = (string)objDateGoDetail.UpdateSeat(objBO);
                if (!string.IsNullOrEmpty(result))
                    return true;
                return false;
            }
            catch (Exception objEx)
            {

                throw objEx;
            }
        }

        public bool UpdateSeatCancel(string strCarDateGoDetailID, string strCarDateGoDetailCancelID, string strUserName)
        {
            try
            {
                var result = (string)objDateGoDetail.UpdateSeatCancel(strCarDateGoDetailID, strCarDateGoDetailCancelID, strUserName);
                if (!string.IsNullOrEmpty(result))
                    return true;
                return false;
            }
            catch (Exception objEx)
            {

                throw objEx;
            }
        }

        public int CarIsGo(int intCarID, string strUserName)
        {
            try
            {
                return objDateGo.CarIsGo(intCarID, strUserName);
            }
            catch (Exception obj)
            {

                throw obj;
            }
        }

        /// <summary>
        /// Di chuyển vé 
        /// </summary>
        /// <param name="intDateGoDetailIDFrom"></param>
        /// <param name="intDateGoDetailIDTo"></param>
        /// <param name="strUpdateUser"></param>
        /// <returns></returns>
        public bool MoveSeat(int intDateGoDetailIDFrom, int intDateGoDetailIDTo, string strUpdateUser)
        {
            try
            {
                var result = (string)objDateGoDetail.MoveSeat(intDateGoDetailIDFrom, intDateGoDetailIDTo, strUpdateUser);
                if (result == "1")
                    return true;
                return false;
            }
            catch (Exception objExx)
            {
                throw objExx;
            }
        }

        public bool DeleteTicket(string lstCarDateGoDetailID, string strUpdateUser, string strNoteChange)
        {
            try
            {
                List<string> lstDetailID = lstCarDateGoDetailID.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                foreach (string ID in lstDetailID)
                {
                    CarDateGoDetailBO objBO = new CarDateGoDetailBO();
                    objBO.CarDateGoDetailID = long.Parse(ID);
                    objBO.SeatStatusID = 0;
                    objBO.PaymentStatusID = 0;
                    objBO.RouteID = 0;
                    objBO.UpdatedUser = strUpdateUser;
                    var result = (string)objDateGoDetail.UpdateSeat(objBO);

                    WriteLog(strUpdateUser, strNoteChange, ID);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void WriteLog(string strUpdateUser, string strNoteChange, string CarDateGoDetailID)
        {
            CarDateGoDetailLogBO objCarDateGoDetailLogBO = new CarDateGoDetailLogBO();
            objCarDateGoDetailLogBO.UpdatedUser = strUpdateUser;
            objCarDateGoDetailLogBO.CarDateGoDetailID = long.Parse(CarDateGoDetailID);
            objCarDateGoDetailLogBO.NoteChange = strNoteChange;
            new CarDateGoDetailLogDAO().Insert(objCarDateGoDetailLogBO);
        }


        /// <summary>
        /// Lấy lịch sử thao tác với ghế
        /// </summary>
        /// <param name="intDateGoDetailID"></param>
        /// <returns></returns>
        public DataTable GetLogByDateGoDetailID(int intDateGoDetailID, string strUserName)
        {
            try
            {
                return objDateGoDetailLog.GetLogByDateGoDetailID(intDateGoDetailID, strUserName);
            }
            catch (Exception objEx)
            {
                throw objEx;
            }
        }

        public DataTable GetLogCustomerByDateGoDetailID(string strPhone, string strUserName)
        {
            try
            {
                return objDateGoDetailLog.GetLogCustomerByDateGoDetailID(strPhone, strUserName);
            }
            catch (Exception objEx)
            {
                throw objEx;
            }
        }

        /// <summary>
        /// Lấy thông tin các ghế đã hủy trong 1 khung thời gian
        /// </summary>
        /// <param name="intCarDateGoID"></param>
        /// <returns></returns>
        public DataTable GetAllSeatCancel(int intCarDateGoID, string strUserName)
        {
            try
            {
                return objDateGoDetailLog.GetAllSeatCancel(intCarDateGoID, strUserName);
            }
            catch (Exception objEx)
            {
                throw objEx;
            }
        }

        /// <summary>
        /// Hàm lấy danh sách các ghế đón trả
        /// </summary>
        /// <param name="intCarDateGoID"></param>
        /// <param name="intStationID"></param>
        /// <returns></returns>
        public DataTable GetListPickup(int intCarDateGoID, string strUserName)
        {
            try
            {
                return objDateGoDetail.GetListPickup(intCarDateGoID, strUserName);
            }
            catch (Exception objEx)
            {
                throw objEx;
            }
        }

        /// <summary>
        /// Hàm lấy danh sách các ghế trung chuyển
        /// </summary>
        /// <param name="intCarDateGoID"></param>
        /// <param name="intStationID"></param>
        /// <returns></returns>
        public DataTable GetListTransit(int intCarDateGoID, string strUserName)
        {
            try
            {
                return objDateGoDetail.GetListTransit(intCarDateGoID, strUserName);
            }
            catch (Exception objEx)
            {
                throw objEx;
            }
        }
        /// <summary>
        /// Update Order của những khách hàng luân chuyển
        /// </summary>
        /// <param name="strPhone"></param>
        /// <param name="intIndex"></param>
        /// <returns></returns>
        public bool UpdateOrderTransit(string strID, int intIndex, string strUserName)
        {
            try
            {
                if (string.IsNullOrEmpty(strID))
                    return false;

                var result = (int)objDateGoDetail.UpdateOrderTransit(strID, intIndex, strUserName);
                if (result > 0)
                    return true;
                return false;
            }
            catch (Exception objEx)
            {
                throw objEx;
            }
        }

        /// <summary>
        /// Update order của những khách hàng đón trả
        /// </summary>
        /// <param name="strPhone"></param>
        /// <param name="intIndex"></param>
        /// <returns></returns>
        public bool UpdateOrderPickup(string strID, int intIndex, string strUserName)
        {
            try
            {
                if (string.IsNullOrEmpty(strID))
                    return false;

                var result = (int)objDateGoDetail.UpdateOrderPickup(strID, intIndex, strUserName);
                if (result > 0)
                    return true;
                return false;
            }
            catch (Exception objEx)
            {
                throw objEx;
            }
        }

        /// <summary>
        /// Tìm ghế 
        /// </summary>
        /// <param name="strKeyword"></param>
        /// <returns></returns>
        public DataTable SearchSeats(string strKeyword, string strUsername)
        {
            try
            {
                return objDateGoDetail.SearchSeats(strKeyword, strUsername);
            }
            catch (Exception objEx)
            {
                throw objEx;
            }
        }

        /// <summary>
        /// Lấy thông tin xe
        /// </summary>
        /// <param name="intCarDateGoID"></param>
        /// <returns></returns>
        public DataTable GetCarByID(int intCarDateGoID, string strUserName)
        {
            try
            {
                return objDateGo.GetCarByID(intCarDateGoID, strUserName);
            }
            catch (Exception objEx)
            {
                throw objEx;
            }
        }

        public int UpdateCarDateGo(int intCarID, string strGoTime, string strDriver, string strCarNumber, int bolTransship, int bolNewBus, string strUsername)
        {
            try
            {
                return objDateGo.UpdateCarDateGo(intCarID, strGoTime, strDriver, strCarNumber, bolTransship, bolNewBus, strUsername);
            }
            catch (Exception objEx)
            {
                throw objEx;
            }
        }

        public int DeleteCar(int intCarDateGoID, string strUsername)
        {
            try
            {
                return objDateGo.Delete(intCarDateGoID, strUsername);
            }
            catch (Exception objEx)
            {
                throw objEx;
            }
        }
        ///// <summary>
        ///// Lấy tất cả loại xe(xe mấy chổ) đã khai báo
        ///// </summary>
        ///// <returns></returns>
        //public DataTable SelectLoaiXe()
        //{
        //    try
        //    {
        //        return objLoaiXe.GetAll();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        #endregion
    }

}

using BookingTicket.BussinessObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGDD.Library.Data;

namespace BookingTicket.DataObject
{
    public class CarDateGoDetailDAO
    {
        #region Methods	
        ///<summary>
        /// Insert : Car_DateGoDetail
        /// Them moi du lieu
        ///</summary>
        public object Insert(CarDateGoDetailBO objBO)
        {
            IData objData = Data.CreateData();
            object objTemp = null;
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Car_DateGoDetail_Insert");
                if (objBO.CarDateGoDetailID != long.MinValue) objData.AddParameter("@CarDateGoDetailID", objBO.CarDateGoDetailID);
                if (objBO.CarDateGoID != int.MinValue) objData.AddParameter("@CarDateGoID", objBO.CarDateGoID);
                if (objBO.SeatNumber != int.MinValue) objData.AddParameter("@SeatNumber", objBO.SeatNumber);
                objData.AddParameter("@Description", objBO.Description);
                if (objBO.SeatStatusID != int.MinValue) objData.AddParameter("@SeatStatusID", objBO.SeatStatusID);
                if (objBO.PaymentStatusID != int.MinValue) objData.AddParameter("@PaymentStatusID", objBO.PaymentStatusID);
                objData.AddParameter("@IsPickUp", objBO.IsPickUp);
                objData.AddParameter("@IsTransit", objBO.IsTransit);
                objData.AddParameter("@PassengerName", objBO.PassengerName);
                objData.AddParameter("@Mobile", objBO.Mobile);
                objData.AddParameter("@Address", objBO.Address);
                objData.AddParameter("@CreatedStation", objBO.CreatedStationID);
                objData.AddParameter("@Note", objBO.Note);
                objData.AddParameter("@CreatedUser", objBO.CreatedUser);
                objTemp = objData.ExecStoreToString();
            }
            catch (Exception objEx)
            {
                throw new Exception("Insert() Error   " + objEx.Message.ToString());
            }
            finally
            {

                objData.Disconnect();
            }
            return objTemp;
        }


        ///<summary>
        /// Update : Car_DateGoDetail
        /// Cap nhap thong tin
        ///</summary>
        public object Update(CarDateGoDetailBO objBO)
        {
            IData objData = Data.CreateData();
            object objTemp = null;
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Car_DateGoDetail_Update");
                if (objBO.CarDateGoDetailID != long.MinValue) objData.AddParameter("@CarDateGoDetailID", objBO.CarDateGoDetailID);
                else objData.AddParameter("@CarDateGoDetailID", DBNull.Value);
                if (objBO.CarDateGoID != int.MinValue) objData.AddParameter("@CarDateGoID", objBO.CarDateGoID);
                else objData.AddParameter("@CarDateGoID", DBNull.Value);
                if (objBO.SeatNumber != int.MinValue) objData.AddParameter("@SeatNumber", objBO.SeatNumber);
                else objData.AddParameter("@SeatNumber", DBNull.Value);
                objData.AddParameter("@Description", objBO.Description);
                if (objBO.SeatStatusID != int.MinValue) objData.AddParameter("@SeatStatusID", objBO.SeatStatusID);
                else objData.AddParameter("@SeatStatusID", DBNull.Value);

                if (objBO.PaymentStatusID != int.MinValue) objData.AddParameter("@PaymentStatusID", objBO.PaymentStatusID);
                else objData.AddParameter("@PaymentStatusID", DBNull.Value);

                objData.AddParameter("@IsPickUp", objBO.IsPickUp);
                objData.AddParameter("@IsTransit", objBO.IsTransit);
                objData.AddParameter("@PassengerName", objBO.PassengerName);
                objData.AddParameter("@Mobile", objBO.Mobile);
                objData.AddParameter("@Address", objBO.Address);
                objData.AddParameter("@CreatedStation", objBO.CreatedStationID);
                objData.AddParameter("@Note", objBO.Note);
                objData.AddParameter("@UpdatedUser", objBO.UpdatedUser);
                objTemp = objData.ExecNonQuery();
            }
            catch (Exception objEx)
            {
                throw new Exception("Update() Error   " + objEx.Message.ToString());
            }
            finally
            {

                objData.Disconnect();
            }
            return objTemp;
        }


        ///<summary>
        /// Delete : Car_DateGoDetail
        ///
        ///</summary>
        public int Delete(CarDateGoDetailBO objBO)
        {
            IData objData = Data.CreateData();
            int intTemp = 0;
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Car_DateGoDetail_Delete");
                objData.AddParameter("@CarDateGoDetailID", objBO.CarDateGoDetailID);
                objData.AddParameter("@DeletedUser", objBO.DeletedUser);
                intTemp = objData.ExecNonQuery();
            }
            catch (Exception objEx)
            {
                throw new Exception("Delete() Error   " + objEx.Message.ToString());
            }
            finally
            {

                objData.Disconnect();
            }
            return intTemp;
        }


        ///<summary>
        /// Get all : Car_DateGoDetail
        ///
        ///</summary>
        public DataTable GetAll(string strUserName)
        {
            IData objData = Data.CreateData();
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Car_DateGoDetail_SelectAll");
                objData.AddParameter("@Username", strUserName);
                return objData.ExecStoreToDataTable();
            }
            catch (Exception objEx)
            {
                throw new Exception("GetAll() Error   " + objEx.Message.ToString());
            }
            finally
            {

                objData.Disconnect();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="intDateGoID"></param>
        /// <returns></returns>
        public DataTable GetAllSeatOfTimeGo(int intDateGoID, int intStationID, string strUsername, int intRouteID)
        {
            IData objData = Data.CreateData();
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Car_DateGoDetail_Select");
                objData.AddParameter("@CarDateGoID", intDateGoID);
                objData.AddParameter("@StationID", intStationID);
                objData.AddParameter("@RouteID", intRouteID);
                objData.AddParameter("@Username", strUsername);
                return objData.ExecStoreToDataTable();
            }
            catch (Exception objEx)
            {
                throw new Exception("GetAllSeatOfTimeGo() Error   " + objEx.Message.ToString());
            }
            finally
            {
                objData.Disconnect();
            }
        }

        public DataTable GetAllSeatCancelOfTimeGo(int intDateGoID, int intStationID, string strUsername)
        {
            IData objData = Data.CreateData();
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Car_DateGoDetailCancel_Select");
                objData.AddParameter("@CarDateGoID", intDateGoID);
                objData.AddParameter("@StationID", intStationID);
                objData.AddParameter("@Username", strUsername);
                return objData.ExecStoreToDataTable();
            }
            catch (Exception objEx)
            {
                throw new Exception("GetAllSeatCancelOfTimeGo() Error   " + objEx.Message.ToString());
            }
            finally
            {
                objData.Disconnect();
            }
        }


        public DataTable GetSeatByID(string listSeatID, string strUserName)
        {
            IData objData = Data.CreateData();
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Car_DateGoDetail_SelectByID");
                objData.AddParameter("@CarDateGoDetailID", listSeatID);
                objData.AddParameter("@Username", strUserName);
                return objData.ExecStoreToDataTable();
            }
            catch (Exception objEx)
            {
                throw new Exception("GetSeatByID() Error   " + objEx.Message.ToString());
            }
            finally
            {
                objData.Disconnect();
            }
        }

        ///<summary>
        /// Update : Car_DateGoDetail
        /// Cap nhap thong tin
        ///</summary>
        public string UpdateSeat(CarDateGoDetailBO objBO)
        {
            IData objData = Data.CreateData();
            string objTemp = string.Empty;
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Car_DateGoDetail_Update_SeatInfo");
                objData.AddParameter("@CarDateGoDetailID", objBO.CarDateGoDetailID);
                objData.AddParameter("@SeatStatusID", objBO.SeatStatusID);
                objData.AddParameter("@IsPickUp", objBO.IsPickUp);
                objData.AddParameter("@IsTransit", objBO.IsTransit);
                objData.AddParameter("@PassengerName", objBO.PassengerName);
                objData.AddParameter("@Mobile", objBO.Mobile);
                objData.AddParameter("@Address", objBO.Address);
                objData.AddParameter("@StationID", objBO.CreatedStationID);
                objData.AddParameter("@Note", objBO.Note);
                objData.AddParameter("@RouteID", objBO.RouteID);
                objData.AddParameter("@UpdateUser", objBO.UpdatedUser);
                objData.AddParameter("@PaymentStatusID", objBO.PaymentStatusID);
                objTemp = objData.ExecStoreToString();
            }
            catch (Exception objEx)
            {
                throw new Exception("UpdateSeat() Error   " + objEx.Message.ToString());
            }
            finally
            {

                objData.Disconnect();
            }
            return objTemp;
        }

        public string UpdateSeatCancel(string strCarDateGoDetailID, string strCarDateGoDetailCancelID, string strUserName)
        {
            IData objData = Data.CreateData();
            string objTemp = string.Empty;
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Car_DateGoDetail_Update_FromCancel");
                objData.AddParameter("@CarDateGoDetailID", strCarDateGoDetailID);
                objData.AddParameter("@CarDateGoDetailCancelID", strCarDateGoDetailCancelID);
                objData.AddParameter("@Username", strUserName);
                objTemp = objData.ExecStoreToString();
            }
            catch (Exception objEx)
            {
                throw new Exception("UpdateSeatCancel() Error   " + objEx.Message.ToString());
            }
            finally
            {

                objData.Disconnect();
            }
            return objTemp;
        }

        public string UpdateStatusSeat(CarDateGoDetailBO objBO)
        {
            IData objData = Data.CreateData();
            string objTemp = string.Empty;
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Car_DateGoDetail_Update_Status");
                objData.AddParameter("@CarDateGoDetailID", objBO.CarDateGoDetailID);
                objData.AddParameter("@SeatStatusID", objBO.SeatStatusID);
                objData.AddParameter("@UpdateUser", objBO.UpdatedUser);
                objTemp = objData.ExecStoreToString();
            }
            catch (Exception objEx)
            {
                throw new Exception("UpdateStatusSeat() Error   " + objEx.Message.ToString());
            }
            finally
            {

                objData.Disconnect();
            }
            return objTemp;
        }

        public string UpdateStatusPayment(CarDateGoDetailBO objBO)
        {
            IData objData = Data.CreateData();
            string objTemp = string.Empty;
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Car_DateGoDetail_Update_Payment_Status");
                objData.AddParameter("@CarDateGoDetailID", objBO.CarDateGoDetailID);
                objData.AddParameter("@PaymentStatusID", objBO.PaymentStatusID);
                objData.AddParameter("@UpdateUser", objBO.UpdatedUser);
                objData.AddParameter("@RouteID", objBO.RouteID);
                objData.AddParameter("@Mobile", objBO.Mobile);
                objTemp = objData.ExecStoreToString();
            }
            catch (Exception objEx)
            {
                throw new Exception("UpdateStatusPayment() Error   " + objEx.Message.ToString());
            }
            finally
            {

                objData.Disconnect();
            }
            return objTemp;
        }

        public string MoveSeat(int intDateGoDetailIDFrom, int intDateGoDetailIDTo, string strUpdateUser)
        {
            IData objData = Data.CreateData();
            string objTemp = string.Empty;
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Car_DateGoDetail_Move");
                objData.AddParameter("@DateGoDetailIDFrom", intDateGoDetailIDFrom);
                objData.AddParameter("@DateGoDetailIDTo", intDateGoDetailIDTo);
                objData.AddParameter("@UpdateUser", strUpdateUser);
                objTemp = objData.ExecStoreToString();

            }
            catch (Exception objEx)
            {
                throw new Exception("MoveSeat() Error   " + objEx.Message.ToString());
            }
            finally
            {
                objData.Disconnect();
            }
            return objTemp;
        }

        /// <summary>
        /// Search seat
        /// </summary>
        /// <param name="strKeyword"></param>
        /// <returns></returns>
        public DataTable SearchSeats(string strKeyword, string strUsername)
        {
            IData objData = Data.CreateData();
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Car_DateGoDetail_Search");
                objData.AddParameter("@Keyword", strKeyword);
                objData.AddParameter("@Username", strUsername);
                return objData.ExecStoreToDataTable();
            }
            catch (Exception objEx)
            {
                throw new Exception("SearchSeats() Error   " + objEx.Message.ToString());
            }
            finally
            {
                objData.Disconnect();
            }
        }
        /// <summary>
        /// Lấy thông tin khách hàng đón trả
        /// </summary>
        /// <param name="intCarDateGoID"></param>
        /// <returns></returns>
        public DataTable GetListPickup(int intCarDateGoID, string strUserName)
        {
            IData objData = Data.CreateData();
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Car_DateGoDetail_PickUp_Select");
                objData.AddParameter("@CarDateGoID", intCarDateGoID);
                objData.AddParameter("@Username", strUserName);
                return objData.ExecStoreToDataTable();
            }
            catch (Exception objEx)
            {
                throw new Exception("GetListPickup() Error   " + objEx.Message.ToString());
            }
            finally
            {
                objData.Disconnect();
            }
        }

        /// <summary>
        /// Lấy thông tin những khách hàng trung chuyển
        /// </summary>
        /// <param name="intCarDateGoID"></param>
        /// <returns></returns>
        public DataTable GetListTransit(int intCarDateGoID, string strUserName)
        {
            IData objData = Data.CreateData();
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Car_DateGoDetail_Transit_Select");
                objData.AddParameter("@CarDateGoID", intCarDateGoID);
                objData.AddParameter("@Username", strUserName);
                return objData.ExecStoreToDataTable();
            }
            catch (Exception objEx)
            {
                throw new Exception("GetListTransit() Error   " + objEx.Message.ToString());
            }
            finally
            {
                objData.Disconnect();
            }
        }

        /// <summary>
        /// Update Order của những khách hàng luân chuyển
        /// </summary>
        /// <param name="strPhone"></param>
        /// <param name="intIndex"></param>
        /// <returns></returns>
        public object UpdateOrderTransit(string strID, int intIndex, string strUserName)
        {
            IData objData = Data.CreateData();
            object objTemp = null;
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Car_DateGoDetail_Update_OrderTransit");
                objData.AddParameter("@ListCarDateGoDetail", strID);
                objData.AddParameter("@Index", intIndex);
                objData.AddParameter("@Username", strUserName);
                objTemp = objData.ExecNonQuery();
            }
            catch (Exception objEx)
            {
                throw new Exception("UpdateOrderTransit() Error   " + objEx.Message.ToString());
            }
            finally
            {
                objData.Disconnect();
            }
            return objTemp;
        }

        /// <summary>
        /// Update order của những khách hàng đón trả
        /// </summary>
        /// <param name="strPhone"></param>
        /// <param name="intIndex"></param>
        /// <returns></returns>
        public object UpdateOrderPickup(string strID, int intIndex, string strUserName)
        {
            IData objData = Data.CreateData();
            object objTemp = null;
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Car_DateGoDetail_Update_OrderPickup");
                objData.AddParameter("@ListCarDateGoDetail", strID);
                objData.AddParameter("@Index", intIndex);
                objData.AddParameter("@Username", strUserName);
                objTemp = objData.ExecNonQuery();
            }
            catch (Exception objEx)
            {
                throw new Exception("UpdateOrderPickup() Error   " + objEx.Message.ToString());
            }
            finally
            {
                objData.Disconnect();
            }
            return objTemp;
        }

        #endregion


        /// <summary>
        /// Check Data IsDBNull 
        /// </summary>
        /// <param name="objObject"> Object Value</param>
        /// <returns>Null : true ? false </returns>
        private bool IsDBNull(object objObject)
        {
            return Convert.IsDBNull(objObject);
        }


        /******************************************************
		 	Car_DateGoDetail objCar_DateGoDetail = new Car_DateGoDetail();
			objCarDateGoDetail.CarDateGoDetailID = txtCarDateGoDetailID.Text;
			objCarDateGoDetail.CarDateGoID = txtCarDateGoID.Text;
			objCarDateGoDetail.SeatNumber = txtSeatNumber.Text;
			objCarDateGoDetail.Description = txtDescription.Text;
			objCarDateGoDetail.Status = txtStatus.Text;
			objCarDateGoDetail.IsPickUp = txtIsPickUp.Text;
			objCarDateGoDetail.IsTransit = txtIsTransit.Text;
			objCarDateGoDetail.PassengerName = txtPassengerName.Text;
			objCarDateGoDetail.Mobile = txtMobile.Text;
			objCarDateGoDetail.Address = txtAddress.Text;
			objCarDateGoDetail.CreatedStation = txtCreatedStation.Text;
			objCarDateGoDetail.Note = txtNote.Text;
			objCarDateGoDetail.IsDeleted = txtIsDeleted.Text;
			objCarDateGoDetail.DeletedUser = txtDeletedUser.Text;
			objCarDateGoDetail.DeletedDate = txtDeletedDate.Text;
			objCarDateGoDetail.UpdatedUser = txtUpdatedUser.Text;
			objCarDateGoDetail.UpdatedDate = txtUpdatedDate.Text;
			objCarDateGoDetail.CreatedUser = txtCreatedUser.Text;
			objCarDateGoDetail.CreatedDate = txtCreatedDate.Text;

		 
		 ******************************************************
		 
		 			txtCarDateGoDetailID.Text = objCarDateGoDetail.CarDateGoDetailID;
			txtCarDateGoID.Text = objCarDateGoDetail.CarDateGoID;
			txtSeatNumber.Text = objCarDateGoDetail.SeatNumber;
			txtDescription.Text = objCarDateGoDetail.Description;
			txtStatus.Text = objCarDateGoDetail.Status;
			txtIsPickUp.Text = objCarDateGoDetail.IsPickUp;
			txtIsTransit.Text = objCarDateGoDetail.IsTransit;
			txtPassengerName.Text = objCarDateGoDetail.PassengerName;
			txtMobile.Text = objCarDateGoDetail.Mobile;
			txtAddress.Text = objCarDateGoDetail.Address;
			txtCreatedStation.Text = objCarDateGoDetail.CreatedStation;
			txtNote.Text = objCarDateGoDetail.Note;
			txtIsDeleted.Text = objCarDateGoDetail.IsDeleted;
			txtDeletedUser.Text = objCarDateGoDetail.DeletedUser;
			txtDeletedDate.Text = objCarDateGoDetail.DeletedDate;
			txtUpdatedUser.Text = objCarDateGoDetail.UpdatedUser;
			txtUpdatedDate.Text = objCarDateGoDetail.UpdatedDate;
			txtCreatedUser.Text = objCarDateGoDetail.CreatedUser;
			txtCreatedDate.Text = objCarDateGoDetail.CreatedDate;

		 
		*******************************************************/
    }
}

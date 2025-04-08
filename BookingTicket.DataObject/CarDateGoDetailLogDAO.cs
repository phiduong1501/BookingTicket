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
    public class CarDateGoDetailLogDAO
    {
        public int CarDateGoDetailID { get; set; }
        public string NoteChange { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedUser { get; set; }

        #region Methods
        ///<summary>
        /// Insert : Car_DateGoDetailLog
        /// Them moi du lieu
        ///</summary>
        public object Insert(CarDateGoDetailLogBO objBO)
        {
            IData objData = Data.CreateData();
            object objTemp = null;
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Car_DateGoDetailLog_Insert");
                if (objBO.CarDateGoDetailID != long.MinValue) objData.AddParameter("@CarDateGoDetailID", objBO.CarDateGoDetailID);
                objData.AddParameter("@NoteChange", objBO.NoteChange);
                objData.AddParameter("@UpdatedUser", objBO.UpdatedUser);
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
        /// Update : Car_DateGoDetailLog
        /// Cap nhap thong tin
        ///</summary>
        public object Update(CarDateGoDetailLogBO objBO)
        {
            IData objData = Data.CreateData();
            object objTemp = null;
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Car_DateGoDetailLog_Update");
                if (objBO.CarDateGoDetailLogID != long.MinValue) objData.AddParameter("@CarDateGoDetailLogID", objBO.CarDateGoDetailLogID);
                else objData.AddParameter("@CarDateGoDetailLogID", DBNull.Value);
                if (objBO.CarDateGoDetailID != long.MinValue) objData.AddParameter("@CarDateGoDetailID", objBO.CarDateGoDetailID);
                else objData.AddParameter("@CarDateGoDetailID", DBNull.Value);
                objData.AddParameter("@NoteChange", objBO.NoteChange);
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
        /// Delete : Car_DateGoDetailLog
        ///
        ///</summary>
        public int Delete(int intLogID, string strUserName)
        {

            IData objData = Data.CreateData();
            int intTemp = 0;
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Car_DateGoDetailLog_Delete");
                objData.AddParameter("@CarDateGoDetailLogID", intLogID);
                objData.AddParameter("@Username", strUserName);
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
        /// Get all : Car_DateGoDetailLog
        ///
        ///</summary>
        public DataTable GetAll(string strUserName)
        {

            IData objData = Data.CreateData();
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Car_DateGoDetailLog_SelectAll");
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

        public DataTable GetAllSeatCancel(int intCarDateGoID, string strUserName)
        {

            IData objData = Data.CreateData();
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Car_DateGoDetailLog_All_Cancel");
                objData.AddParameter("@CarDateGoID", intCarDateGoID);
                objData.AddParameter("@Username", strUserName);
                return objData.ExecStoreToDataTable();
            }
            catch (Exception objEx)
            {
                throw new Exception("GetAllSeatCancel() Error   " + objEx.Message.ToString());
            }
            finally
            {
                objData.Disconnect();
            }
        }

        public DataTable GetLogByDateGoDetailID(int intDateGoDetailID, string strUserName)
        {

            IData objData = Data.CreateData();
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Car_DateGoDetailLog_Select");
                objData.AddParameter("@CarDateGoDetailID",intDateGoDetailID);
                objData.AddParameter("@Username", strUserName);
                return objData.ExecStoreToDataTable();
            }
            catch (Exception objEx)
            {
                throw new Exception("GetLogByDateGoDetailID() Error   " + objEx.Message.ToString());
            }
            finally
            {
                objData.Disconnect();
            }
        }

        public DataTable GetLogCustomerByDateGoDetailID(string strPhone, string strUserName)
        {

            IData objData = Data.CreateData();
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Car_DateGoDetailLogCustomer_Select");
                objData.AddParameter("@phone", strPhone);
                objData.AddParameter("@Username", strUserName);
                return objData.ExecStoreToDataTable();
            }
            catch (Exception objEx)
            {
                throw new Exception("GetLogCustomerByDateGoDetailID() Error   " + objEx.Message.ToString());
            }
            finally
            {
                objData.Disconnect();
            }
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
		 	Car_DateGoDetailLog objCar_DateGoDetailLog = new Car_DateGoDetailLog();
			objCarDateGoDetailLog.CarDateGoDetailLogID = txtCarDateGoDetailLogID.Text;
			objCarDateGoDetailLog.CarDateGoDetailID = txtCarDateGoDetailID.Text;
			objCarDateGoDetailLog.NoteChange = txtNoteChange.Text;
			objCarDateGoDetailLog.UpdatedUser = txtUpdatedUser.Text;
			objCarDateGoDetailLog.UpdatedDate = txtUpdatedDate.Text;

		 
		 ******************************************************
		 
		 			txtCarDateGoDetailLogID.Text = objCarDateGoDetailLog.CarDateGoDetailLogID;
			txtCarDateGoDetailID.Text = objCarDateGoDetailLog.CarDateGoDetailID;
			txtNoteChange.Text = objCarDateGoDetailLog.NoteChange;
			txtUpdatedUser.Text = objCarDateGoDetailLog.UpdatedUser;
			txtUpdatedDate.Text = objCarDateGoDetailLog.UpdatedDate;

		 
		*******************************************************/
    }
}

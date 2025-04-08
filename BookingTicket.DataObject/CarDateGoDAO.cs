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
    public class CarDateGoDAO
    {
        #region Methods	
        
        ///<summary>
        /// Insert : Car_DateGo
        /// Them moi du lieu
        ///</summary>
        public object Insert(CarDateGoBO objBO)
        {
            IData objData = Data.CreateData();
            object objTemp = null;
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Car_DateGo_Insert");
                if (objBO.TypeID != int.MinValue) objData.AddParameter("@TypeID", objBO.TypeID);
                objData.AddParameter("@RouteID", objBO.RouteID);
                if (objBO.GoDate != DateTime.MinValue) objData.AddParameter("@GoDate", objBO.GoDate);
                objData.AddParameter("@GoTime", objBO.GoTime);
                objData.AddParameter("@Note", objBO.Note);
                objData.AddParameter("@CreatedUser", objBO.CreatedUser);
                objData.AddParameter("@CarNumber", objBO.CarNumber);
                objData.AddParameter("@Driver", objBO.Driver);
                objData.AddParameter("NumberOfSeat", objBO.NumberOfSeat);
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
        /// Update : Car_DateGo
        /// Cap nhap thong tin
        ///</summary>
        public object Update(CarDateGoBO objBO)
        {
            IData objData = Data.CreateData();
            object objTemp = null;
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Car_DateGo_Update");
                if (objBO.CarDateGoID != int.MinValue) objData.AddParameter("@CarDateGoID", objBO.CarDateGoID);
                else objData.AddParameter("@CarDateGoID", DBNull.Value);
                if (objBO.TypeID != int.MinValue) objData.AddParameter("@TypeID", objBO.TypeID);
                else objData.AddParameter("@TypeID", DBNull.Value);
                objData.AddParameter("@RouteID", objBO.RouteID);
                if (objBO.GoDate != DateTime.MinValue) objData.AddParameter("@GoDate", objBO.GoDate);
                else objData.AddParameter("@GoDate", DBNull.Value);
                objData.AddParameter("@GoTime", objBO.GoTime);
                objData.AddParameter("@Driver", objBO.Driver);
                objData.AddParameter("@CarNumber", objBO.CarNumber);
                objData.AddParameter("@IsGo", objBO.IsGo);
                if (objBO.RealTimeGo != DateTime.MinValue) objData.AddParameter("@RealTimeGo", objBO.RealTimeGo);
                else objData.AddParameter("@RealTimeGo", DBNull.Value);
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
        /// Delete : Car_DateGo
        ///
        ///</summary>
        public int Delete(int intCarDateGoID, string strUsername)
        {
            IData objData = Data.CreateData();
            int intTemp = 0;
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Car_DateGo_Delete");
                objData.AddParameter("@CarDateGoID", intCarDateGoID);
                objData.AddParameter("@Username", strUsername);
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
        /// Get all : Car_DateGo
        ///
        ///</summary>
        public DataTable GetAll(string strUserName)
        {
            IData objData = Data.CreateData();
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Car_DateGo_SelectAll");
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
        /// Lấy thông tin chi tiết xe
        /// </summary>
        /// <param name="intCarDateGoID"></param>
        /// <returns></returns>
        public DataTable GetCarByID(int intCarDateGoID, string strUserName)
        {
            IData objData = Data.CreateData();
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Car_DateGo_SelectByID");
                objData.AddParameter("@CarDateGoID", intCarDateGoID);
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
        /// Get all : Car_DateGo
        /// </summary>
        /// <param name="dtDateGo">
        /// DateTime format dd/MM/yyyy
        /// </param>
        /// <returns></returns>
        public DataTable GetTimeGoOfDateGo(DateTime dtDateGo, int routeID, string strUserName)
        {
            IData objData = Data.CreateData();
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Car_DateGo_Select_By_DateTime");
                objData.AddParameter("@DATAGO",dtDateGo);
                objData.AddParameter("@ROUTEID", routeID);
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
        public int CarIsGo(int intCarID, string strUserName)
        {
            IData objData = Data.CreateData();
            int intTemp = 0;
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Car_DateGo_Go");
                objData.AddParameter("@CarDateGoID", intCarID);
                objData.AddParameter("@Username", strUserName);
                intTemp = objData.ExecNonQuery();
            }
            catch (Exception objEx)
            {
                throw new Exception("CarIsGo() Error   " + objEx.Message.ToString());
            }
            finally
            {

                objData.Disconnect();
            }
            return intTemp;
        }

        public int UpdateCarDateGo(int intCarID, string strGoTime, string strDriver, string strCarNumber, int bolTransship, int bolNewBus, string strUsername)
        {
            IData objData = Data.CreateData();
            int intTemp = 0;
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Car_DateGo_Edit");
                objData.AddParameter("@CarDateGoID", intCarID);
                objData.AddParameter("@GoTime", strGoTime);
                objData.AddParameter("@Driver", strDriver);
                objData.AddParameter("@CarNumber", strCarNumber);
                objData.AddParameter("@Username", strUsername);
                objData.AddParameter("@Transship", bolTransship);
                objData.AddParameter("@NewBus", bolNewBus);

                intTemp = objData.ExecNonQuery();
            }
            catch (Exception objEx)
            {
                throw new Exception("UpdateCarDateGo() Error   " + objEx.Message.ToString());
            }
            finally
            {

                objData.Disconnect();
            }
            return intTemp;
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
		 	Car_DateGo objCar_DateGo = new Car_DateGo();
			objCarDateGo.CarDateGoID = txtCarDateGoID.Text;
			objCarDateGo.TypeID = txtTypeID.Text;
			objCarDateGo.RouteName = txtRouteName.Text;
			objCarDateGo.GoDate = txtGoDate.Text;
			objCarDateGo.GoTime = txtGoTime.Text;
			objCarDateGo.Driver = txtDriver.Text;
			objCarDateGo.CarNumber = txtCarNumber.Text;
			objCarDateGo.IsGo = txtIsGo.Text;
			objCarDateGo.RealTimeGo = txtRealTimeGo.Text;
			objCarDateGo.Note = txtNote.Text;
			objCarDateGo.IsDeleted = txtIsDeleted.Text;
			objCarDateGo.DeletedUser = txtDeletedUser.Text;
			objCarDateGo.DeletedDate = txtDeletedDate.Text;
			objCarDateGo.UpdatedUser = txtUpdatedUser.Text;
			objCarDateGo.UpdatedDate = txtUpdatedDate.Text;
			objCarDateGo.CreatedUser = txtCreatedUser.Text;
			objCarDateGo.CreatedDate = txtCreatedDate.Text;

		 
		 ******************************************************
		 
		 			txtCarDateGoID.Text = objCarDateGo.CarDateGoID;
			txtTypeID.Text = objCarDateGo.TypeID;
			txtRouteName.Text = objCarDateGo.RouteName;
			txtGoDate.Text = objCarDateGo.GoDate;
			txtGoTime.Text = objCarDateGo.GoTime;
			txtDriver.Text = objCarDateGo.Driver;
			txtCarNumber.Text = objCarDateGo.CarNumber;
			txtIsGo.Text = objCarDateGo.IsGo;
			txtRealTimeGo.Text = objCarDateGo.RealTimeGo;
			txtNote.Text = objCarDateGo.Note;
			txtIsDeleted.Text = objCarDateGo.IsDeleted;
			txtDeletedUser.Text = objCarDateGo.DeletedUser;
			txtDeletedDate.Text = objCarDateGo.DeletedDate;
			txtUpdatedUser.Text = objCarDateGo.UpdatedUser;
			txtUpdatedDate.Text = objCarDateGo.UpdatedDate;
			txtCreatedUser.Text = objCarDateGo.CreatedUser;
			txtCreatedDate.Text = objCarDateGo.CreatedDate;

		 
		*******************************************************/
    }
}

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
    public class SysStationDAO
    {
        #region Methods	
        ///<summary>
        /// Insert : Sys_Station
        /// Them moi du lieu
        ///</summary>
        public object Insert(SysStationBO objBO, string strUserName)
        {
            IData objData = Data.CreateData();
            object objTemp = null;
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Sys_Station_Insert");
                if (objBO.StationID != int.MinValue) objData.AddParameter("@StationID", objBO.StationID);
                objData.AddParameter("@StationName", objBO.StationName);
                objData.AddParameter("@StationShortName", objBO.StationShortName);
                objData.AddParameter("@OrderIndex", objBO.OrderIndex);
                objData.AddParameter("@Username", strUserName);
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
        /// Update : Sys_Station
        /// Cap nhap thong tin
        ///</summary>
        public object Update(SysStationBO objBO, string strUserName)
        {
            IData objData = Data.CreateData();
            object objTemp = null;
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Sys_Station_Update");
                if (objBO.StationID != int.MinValue) objData.AddParameter("@StationID", objBO.StationID);
                else objData.AddParameter("@StationID", DBNull.Value);
                objData.AddParameter("@StationName", objBO.StationName);
                objData.AddParameter("@StationShortName", objBO.StationShortName);
                objData.AddParameter("@OrderIndex", objBO.OrderIndex);
                objData.AddParameter("@Username", strUserName);
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
        /// Delete : Sys_Station
        ///
        ///</summary>
        public int Delete(SysStationBO objBO)
        {
            IData objData = Data.CreateData();
            int intTemp = 0;
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Sys_Station_Delete");
                objData.AddParameter("@StationID", objBO.StationID);
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
        /// Get all : Sys_Station
        ///
        ///</summary>
        public DataTable GetAll(int intSortDesc, string strUserName)
        {
            IData objData = Data.CreateData();
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Sys_Station_SelectAll");
                objData.AddParameter("@IsSortDesc", intSortDesc);
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
		 	Sys_Station objSys_Station = new Sys_Station();
			objSysStation.StationID = txtStationID.Text;
			objSysStation.StationName = txtStationName.Text;
			objSysStation.StationShortName = txtStationShortName.Text;

		 
		 ******************************************************
		 
		 			txtStationID.Text = objSysStation.StationID;
			txtStationName.Text = objSysStation.StationName;
			txtStationShortName.Text = objSysStation.StationShortName;

		 
		*******************************************************/
    }
}

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
    public class SysRouteDAO
    {
        #region Methods	
        ///<summary>
        /// Kiểm tra xem đối tượng có dữ liệu hay không
        ///</summary>
        /// <returns>true ? Có : False ? Không</returns>
        public bool LoadByPrimaryKeys(SysRouteBO objBO, string strUserName)
        {
            IData objData = Data.CreateData();
            bool bolOK = false;
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Sys_Route_Select");
                objData.AddParameter("@RouteID", objBO.RouteID);
                objData.AddParameter("@Username", strUserName);
                IDataReader reader = objData.ExecStoreToDataReader();
                if (reader.Read())
                {
                    if (!this.IsDBNull(reader["RouteID"])) objBO.RouteID = Convert.ToInt32(reader["RouteID"]);
                    if (!this.IsDBNull(reader["RouteName"])) objBO.RouteName = Convert.ToString(reader["RouteName"]);
                    if (!this.IsDBNull(reader["StationFromID"])) objBO.StationFromID = Convert.ToInt32(reader["StationFromID"]);
                    if (!this.IsDBNull(reader["StationToID"])) objBO.StationToID = Convert.ToInt32(reader["StationToID"]);
                    if (!this.IsDBNull(reader["Price"])) objBO.Price = Convert.ToInt32(reader["Price"]);
                    if (!this.IsDBNull(reader["Note"])) objBO.Note = Convert.ToString(reader["Note"]);
                    if (!this.IsDBNull(reader["IsDeleted"])) objBO.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
                    if (!this.IsDBNull(reader["DeletedUser"])) objBO.DeletedUser = Convert.ToString(reader["DeletedUser"]);
                    if (!this.IsDBNull(reader["DeletedDate"])) objBO.DeletedDate = Convert.ToDateTime(reader["DeletedDate"]);
                    if (!this.IsDBNull(reader["UpdatedUser"])) objBO.UpdatedUser = Convert.ToString(reader["UpdatedUser"]);
                    if (!this.IsDBNull(reader["UpdatedDate"])) objBO.UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"]);
                    if (!this.IsDBNull(reader["CreatedUser"])) objBO.CreatedUser = Convert.ToString(reader["CreatedUser"]);
                    if (!this.IsDBNull(reader["CreatedDate"])) objBO.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                    bolOK = true;
                }
                reader.Close();
            }
            catch (Exception objEx)
            {
                throw new Exception("LoadByPrimaryKeys() Error   " + objEx.Message.ToString());
            }
            finally
            {
                objData.Disconnect();
            }
            return bolOK;
        }

        ///<summary>
        /// Insert : Sys_Route
        /// Them moi du lieu
        ///</summary>
        public object Insert(SysRouteBO objBO)
        {
            IData objData = Data.CreateData();
            object objTemp = null;
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Sys_Route_Insert");
                if (objBO.RouteID != int.MinValue) objData.AddParameter("@RouteID", objBO.RouteID);
                objData.AddParameter("@RouteName", objBO.RouteName);
                objData.AddParameter("@StationFrom", objBO.StationFromID);
                objData.AddParameter("@StationTo", objBO.StationToID);
                if (objBO.Price != int.MinValue) objData.AddParameter("@Price", objBO.Price);
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
        /// Update : Sys_Route
        /// Cap nhap thong tin
        ///</summary>
        public object Update(SysRouteBO objBO)
        {
            IData objData = Data.CreateData();
            object objTemp = null;
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Sys_Route_Update");
                if (objBO.RouteID != int.MinValue) objData.AddParameter("@RouteID", objBO.RouteID);
                else objData.AddParameter("@RouteID", DBNull.Value);
                objData.AddParameter("@RouteName", objBO.RouteName);
                objData.AddParameter("@StationFrom", objBO.StationFromID);
                objData.AddParameter("@StationTo", objBO.StationToID);
                if (objBO.Price != int.MinValue) objData.AddParameter("@Price", objBO.Price);
                else objData.AddParameter("@Price", DBNull.Value);
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
        /// Delete : Sys_Route
        ///
        ///</summary>
        public int Delete(SysRouteBO objBO)
        {
            IData objData = Data.CreateData();
            int intTemp = 0;
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Sys_Route_Delete");
                objData.AddParameter("@RouteID", objBO.RouteID);
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
        /// Get all : Sys_Route
        ///
        ///</summary>
        public DataTable GetAll(string strUserName)
        {
            IData objData = Data.CreateData();
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Sys_Route_SelectAll");
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
        /// Lấy route theo station 
        /// </summary>
        /// <param name="intStationFrom"></param>
        /// <param name="intStationTo"></param>
        /// <returns></returns>
        public DataTable GetRouteByStation(int intStationFrom, int intStationTo, string strUserName)
        {
            IData objData = Data.CreateData();
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Sys_Route_SelectByStation");
                objData.AddParameter("@StationFrom",intStationFrom);
                objData.AddParameter("@StationTo", intStationTo);
                objData.AddParameter("@Username", strUserName);
                return objData.ExecStoreToDataTable();
            }
            catch (Exception objEx)
            {
                throw new Exception("GetRouteByStation() Error   " + objEx.Message.ToString());
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
		 	Sys_Route objSys_Route = new Sys_Route();
			objSysRoute.RouteID = txtRouteID.Text;
			objSysRoute.RouteName = txtRouteName.Text;
			objSysRoute.StationFrom = txtStationFrom.Text;
			objSysRoute.StationTo = txtStationTo.Text;
			objSysRoute.Price = txtPrice.Text;
			objSysRoute.Note = txtNote.Text;
			objSysRoute.IsDeleted = txtIsDeleted.Text;
			objSysRoute.DeletedUser = txtDeletedUser.Text;
			objSysRoute.DeletedDate = txtDeletedDate.Text;
			objSysRoute.UpdatedUser = txtUpdatedUser.Text;
			objSysRoute.UpdatedDate = txtUpdatedDate.Text;
			objSysRoute.CreatedUser = txtCreatedUser.Text;
			objSysRoute.CreatedDate = txtCreatedDate.Text;

		 
		 ******************************************************
		 
		 			txtRouteID.Text = objSysRoute.RouteID;
			txtRouteName.Text = objSysRoute.RouteName;
			txtStationFrom.Text = objSysRoute.StationFrom;
			txtStationTo.Text = objSysRoute.StationTo;
			txtPrice.Text = objSysRoute.Price;
			txtNote.Text = objSysRoute.Note;
			txtIsDeleted.Text = objSysRoute.IsDeleted;
			txtDeletedUser.Text = objSysRoute.DeletedUser;
			txtDeletedDate.Text = objSysRoute.DeletedDate;
			txtUpdatedUser.Text = objSysRoute.UpdatedUser;
			txtUpdatedDate.Text = objSysRoute.UpdatedDate;
			txtCreatedUser.Text = objSysRoute.CreatedUser;
			txtCreatedDate.Text = objSysRoute.CreatedDate;

		 
		*******************************************************/
    }
}

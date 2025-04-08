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
    public class SysPickupAddressDAO
    {
        #region Methods	

        ///<summary>
        /// Insert : Sys_PickupAddress
        /// Them moi du lieu
        ///</summary>
        public object Insert(SysPickupAddressBO objBO)
        {
            IData objData = Data.CreateData();
            object objTemp = null;
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Sys_PickupAddress_Insert");
                if (objBO.AddressID != int.MinValue) objData.AddParameter("@AddressID", objBO.AddressID);
                //objData.AddParameter("@AddressName", objBO.AddressName);
                objData.AddParameter("@Address", objBO.Address);
                if (objBO.Type != int.MinValue) objData.AddParameter("@Type", objBO.Type);
                objData.AddParameter("@Note", objBO.Note);
                objData.AddParameter("@CreatedUser", objBO.CreatedUser);
                objData.AddParameter("@RouteID", objBO.RouteID);
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
        /// Update : Sys_PickupAddress
        /// Cap nhap thong tin
        ///</summary>
        public object Update(SysPickupAddressBO objBO)
        {
            IData objData = Data.CreateData();
            object objTemp = null;
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Sys_PickupAddress_Update");
                if (objBO.AddressID != int.MinValue) objData.AddParameter("@AddressID", objBO.AddressID);
                else objData.AddParameter("@AddressID", DBNull.Value);
                //objData.AddParameter("@AddressName", objBO.AddressName);
                objData.AddParameter("@Address", objBO.Address);
                if (objBO.Type != int.MinValue) objData.AddParameter("@Type", objBO.Type);
                else objData.AddParameter("@Type", DBNull.Value);
                objData.AddParameter("@Note", objBO.Note);
                objData.AddParameter("@UpdatedUser", objBO.UpdatedUser);
                objData.AddParameter("@RouteID", objBO.RouteID);
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
        /// Delete : Sys_PickupAddress
        ///
        ///</summary>
        public int Delete(SysPickupAddressBO objBO)
        {
            IData objData = Data.CreateData();
            int intTemp = 0;
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Sys_PickupAddress_Delete");
                objData.AddParameter("@AddressID", objBO.AddressID);
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
        /// Get all : Sys_PickupAddress
        ///
        ///</summary>
        public DataTable GetAll(int type, int routeID, string strUserName)
        {

            IData objData = Data.CreateData();
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Sys_PickupAddress_SelectAll");
                objData.AddParameter("@Type", type);
                objData.AddParameter("@RouteID", routeID);
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
		 	Sys_PickupAddress objSys_PickupAddress = new Sys_PickupAddress();
			objSysPickupAddress.AddressID = txtAddressID.Text;
			objSysPickupAddress.AddressName = txtAddressName.Text;
			objSysPickupAddress.Address = txtAddress.Text;
			objSysPickupAddress.Type = txtType.Text;
			objSysPickupAddress.Note = txtNote.Text;
			objSysPickupAddress.IsDeleted = txtIsDeleted.Text;
			objSysPickupAddress.DeletedUser = txtDeletedUser.Text;
			objSysPickupAddress.DeletedDate = txtDeletedDate.Text;
			objSysPickupAddress.UpdatedUser = txtUpdatedUser.Text;
			objSysPickupAddress.UpdatedDate = txtUpdatedDate.Text;
			objSysPickupAddress.CreatedUser = txtCreatedUser.Text;
			objSysPickupAddress.CreatedDate = txtCreatedDate.Text;

		 
		 ******************************************************
		 
		 			txtAddressID.Text = objSysPickupAddress.AddressID;
			txtAddressName.Text = objSysPickupAddress.AddressName;
			txtAddress.Text = objSysPickupAddress.Address;
			txtType.Text = objSysPickupAddress.Type;
			txtNote.Text = objSysPickupAddress.Note;
			txtIsDeleted.Text = objSysPickupAddress.IsDeleted;
			txtDeletedUser.Text = objSysPickupAddress.DeletedUser;
			txtDeletedDate.Text = objSysPickupAddress.DeletedDate;
			txtUpdatedUser.Text = objSysPickupAddress.UpdatedUser;
			txtUpdatedDate.Text = objSysPickupAddress.UpdatedDate;
			txtCreatedUser.Text = objSysPickupAddress.CreatedUser;
			txtCreatedDate.Text = objSysPickupAddress.CreatedDate;

		 
		*******************************************************/
    }
}

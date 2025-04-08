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
    public class SysTimeDAO
    {
        #region Methods	

        ///<summary>
        /// Insert : Sys_GioChay
        /// Them moi du lieu
        ///</summary>
        public object Insert(SysTimeBO objBO)
        {
            IData objData = Data.CreateData();
            object objTemp = null;
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Sys_GioChay_Insert");
                if (objBO.TimeGoID != int.MinValue) objData.AddParameter("@TimeGoID", objBO.TimeGoID);
                objData.AddParameter("@TimeGo", objBO.TimeGo);
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
        /// Update : Sys_GioChay
        /// Cap nhap thong tin
        ///</summary>
        public object Update(SysTimeBO objBO)
        {
            IData objData = Data.CreateData();
            object objTemp = null;
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Sys_GioChay_Update");
                if (objBO.TimeGoID != int.MinValue) objData.AddParameter("@TimeGoID", objBO.TimeGoID);
                else objData.AddParameter("@TimeGoID", DBNull.Value);
                objData.AddParameter("@TimeGo", objBO.TimeGo);
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
        /// Delete : Sys_GioChay
        ///
        ///</summary>
        public int Delete(int intTimeID, string strUserDelete)
        {

            IData objData = Data.CreateData();
            int intTemp = 0;
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Sys_GioChay_Delete");
                objData.AddParameter("@TimeGoID", intTimeID);
                objData.AddParameter("@DeletedUser", strUserDelete);
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
        /// Get all : Sys_GioChay
        ///
        ///</summary>
        public DataTable GetAll(string strUserName)
        {

            IData objData = Data.CreateData();
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Sys_GioChay_SelectAll");
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
		 	Sys_GioChay objSys_GioChay = new Sys_GioChay();
			objSysGioChay.TimeGoID = txtTimeGoID.Text;
			objSysGioChay.TimeGo = txtTimeGo.Text;
			objSysGioChay.Note = txtNote.Text;
			objSysGioChay.IsDeleted = txtIsDeleted.Text;
			objSysGioChay.DeletedUser = txtDeletedUser.Text;
			objSysGioChay.DeletedDate = txtDeletedDate.Text;
			objSysGioChay.UpdatedUser = txtUpdatedUser.Text;
			objSysGioChay.UpdatedDate = txtUpdatedDate.Text;
			objSysGioChay.CreatedUser = txtCreatedUser.Text;
			objSysGioChay.CreatedDate = txtCreatedDate.Text;

		 
		 ******************************************************
		 
		 			txtTimeGoID.Text = objSysGioChay.TimeGoID;
			txtTimeGo.Text = objSysGioChay.TimeGo;
			txtNote.Text = objSysGioChay.Note;
			txtIsDeleted.Text = objSysGioChay.IsDeleted;
			txtDeletedUser.Text = objSysGioChay.DeletedUser;
			txtDeletedDate.Text = objSysGioChay.DeletedDate;
			txtUpdatedUser.Text = objSysGioChay.UpdatedUser;
			txtUpdatedDate.Text = objSysGioChay.UpdatedDate;
			txtCreatedUser.Text = objSysGioChay.CreatedUser;
			txtCreatedDate.Text = objSysGioChay.CreatedDate;

		 
		*******************************************************/
    }
}

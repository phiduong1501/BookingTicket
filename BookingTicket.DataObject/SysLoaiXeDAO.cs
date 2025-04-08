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
    public class SysLoaiXeDAO
    {
        #region Methods
        ///<summary>
        /// Insert : Sys_LoaiXe
        /// Them moi du lieu
        ///</summary>
        public object Insert(SysLoaiXeBO objBO)
        {
            IData objData = Data.CreateData();
            object objTemp = null;
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Sys_LoaiXe_Insert");
                objData.AddParameter("@CarTypeID", objBO.CarTypeID);
                objData.AddParameter("@NumberOfSeat", objBO.NumberOfSeat);
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
        /// Update : Sys_LoaiXe
        /// Cap nhap thong tin
        ///</summary>
        public object Update(SysLoaiXeBO objBO)
        {
            IData objData = Data.CreateData();
            object objTemp = null;
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Sys_LoaiXe_Update");
                if (objBO.CarTypeID != int.MinValue) objData.AddParameter("@CarTypeID", objBO.CarTypeID);
                else objData.AddParameter("@CarTypeID", DBNull.Value);
                objData.AddParameter("@NumberOfSeat", objBO.NumberOfSeat);
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
        /// Delete : Sys_LoaiXe
        ///
        ///</summary>
        public int Delete(SysUserBO objBO)
        {

            IData objData = Data.CreateData();
            int intTemp = 0;
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Sys_LoaiXe_Delete");
                objData.AddParameter("@UserId", objBO.UserId);
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
        /// Get all : Sys_LoaiXe
        ///
        ///</summary>
        public DataTable GetAll()
        {
            IData objData = Data.CreateData();
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Sys_LoaiXe_SelectAll");
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



    }
}

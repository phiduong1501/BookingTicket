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
    public class SysCompanyDAO
    {
        #region Methods
        ///<summary>
        /// Insert : Sys_Company
        /// Them moi du lieu
        ///</summary>
        public string Insert(SysCompanyBO objBO)
        {
            IData objData = Data.CreateData();
            string objTemp = string.Empty;
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Sys_Company_Insert");               
                objData.AddParameter("@CompanyName", objBO.CompanyName);
                objData.AddParameter("@Address", objBO.Address);
                objData.AddParameter("@Phone", objBO.Phone);
                objData.AddParameter("@ContactPerson", objBO.ContactPerson);
                objData.AddParameter("@ContactPhone", objBO.ContactPhone);
                objData.AddParameter("@UserAdmin", objBO.UserAdmin);
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
        /// Update : Sys_Company
        /// Cap nhap thong tin
        ///</summary>
        public object Update(SysCompanyBO objBO)
        {
            IData objData = Data.CreateData();
            object objTemp = null;
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Sys_Company_Update");
                objData.AddParameter("@CompanyID", objBO.CompanyID);
                objData.AddParameter("@CompanyName", objBO.CompanyName);
                objData.AddParameter("@Address", objBO.Address);
                objData.AddParameter("@Phone", objBO.Phone);
                objData.AddParameter("@ContactPerson", objBO.ContactPerson);
                objData.AddParameter("@ContactPhone", objBO.ContactPhone);
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
        /// Delete : Sys_Company
        ///
        ///</summary>
        public int Delete(SysCompanyBO objBO)
        {

            IData objData = Data.CreateData();
            int intTemp = 0;
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Sys_Company_Delete");
                objData.AddParameter("@CompanyID", objBO.CompanyID);
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

        public int Approve(SysCompanyBO objBO)
        {

            IData objData = Data.CreateData();
            int intTemp = 0;
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Sys_Company_Approve");
                objData.AddParameter("@CompanyID", objBO.CompanyID);
                objData.AddParameter("@Status", objBO.CompanyID);
                objData.AddParameter("@ApprovedUser", objBO.DeletedUser);
                intTemp = objData.ExecNonQuery();
            }
            catch (Exception objEx)
            {
                throw new Exception("Approve() Error   " + objEx.Message.ToString());
            }
            finally
            {
                objData.Disconnect();
            }
            return intTemp;
        }


        ///<summary>
        /// Get all : Sys_Company
        ///
        ///</summary>
        public DataTable GetAll()
        {
            IData objData = Data.CreateData();
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Sys_Company_SelectAll");
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

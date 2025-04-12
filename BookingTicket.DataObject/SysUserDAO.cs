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
    public class SysUserDAO
    {
        #region Methods
        ///<summary>
        /// Insert : Sys_User
        /// Them moi du lieu
        ///</summary>
        public object Insert(SysUserBO objBO)
        {
            IData objData = Data.CreateData();
            object objTemp = null;
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Sys_User_Insert");               
                objData.AddParameter("@UserName", objBO.UserName);
                objData.AddParameter("@Password", objBO.Password);
                objData.AddParameter("@FullName", objBO.FullName);
                objData.AddParameter("@CompanyID", objBO.CompanyID);
                objData.AddParameter("@StationID", objBO.StationID);
                objData.AddParameter("@IsAllowBooking", objBO.IsAllowBooking);
                objData.AddParameter("@IsAllowManager", objBO.IsAllowManager);
                objData.AddParameter("@IsAllowRouter", objBO.IsAllowRouter);
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
        /// Update : Sys_User
        /// Cap nhap thong tin
        ///</summary>
        public object Update(SysUserBO objBO)
        {
            IData objData = Data.CreateData();
            object objTemp = null;
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Sys_User_Update");
                if (objBO.UserId != int.MinValue) objData.AddParameter("@UserId", objBO.UserId);
                else objData.AddParameter("@UserId", DBNull.Value);
                objData.AddParameter("@UserName", objBO.UserName);
                objData.AddParameter("@Password", objBO.Password);
                objData.AddParameter("@FullName", objBO.FullName);
                objData.AddParameter("@UpdatedUser", objBO.UpdatedUser);
                objData.AddParameter("@StationID", objBO.StationID);
                objData.AddParameter("@IsAllowBooking", objBO.IsAllowBooking);
                objData.AddParameter("@IsAllowManager", objBO.IsAllowManager);
                objData.AddParameter("@IsAllowRouter", objBO.IsAllowRouter);

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

        public object ChangePassword(string strUserName, string strPassword)
        {
            IData objData = Data.CreateData();
            object objTemp = null;
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Sys_User_ChangePass");
                objData.AddParameter("@UserName", strUserName);
                objData.AddParameter("@Password", strPassword);

                objTemp = objData.ExecNonQuery();
            }
            catch (Exception objEx)
            {
                throw new Exception("ChangePassword() Error   " + objEx.Message.ToString());
            }
            finally
            {
                objData.Disconnect();
            }
            return objTemp;
        }
        
        ///<summary>
        /// Delete : Sys_User
        ///
        ///</summary>
        public int Delete(SysUserBO objBO)
        {

            IData objData = Data.CreateData();
            int intTemp = 0;
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Sys_User_Delete");
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
        /// Get all : Sys_User
        ///
        ///</summary>
        public DataTable GetAll(string strUserName)
        {
            IData objData = Data.CreateData();
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Sys_User_SelectAll");
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

        public bool SignIn(ref SysUserBO objUser)
        {
            IData objData = Data.CreateData();
            IDataReader reader = null;

            bool bolOK = false;
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Sys_User_Login");
                objData.AddParameter("@Username", objUser.UserName);
                objData.AddParameter("@Password", objUser.Password);
                reader = objData.ExecStoreToDataReader("o_Result");
                if (reader.Read())
                {
                    if (!this.IsDBNull(reader["Username"])) objUser.UserName = (string)reader["Username"];
                    if (!this.IsDBNull(reader["Fullname"])) objUser.FullName = (string)reader["Fullname"];
                    if (!this.IsDBNull(reader["StationID"])) objUser.StationID = (int)reader["StationID"];
                    if (!this.IsDBNull(reader["RouteID"])) objUser.RouteID = (int)reader["RouteID"];
                    if (!this.IsDBNull(reader["IsAllowBooking"])) objUser.IsAllowBooking = (bool)reader["IsAllowBooking"];
                    if (!this.IsDBNull(reader["IsAllowManager"])) objUser.IsAllowManager = (bool)reader["IsAllowManager"];
                    if (!this.IsDBNull(reader["IsAllowRouter"])) objUser.IsAllowRouter = (bool)reader["IsAllowRouter"];
                    if (!this.IsDBNull(reader["CompanyID"])) objUser.CompanyID = (int)reader["CompanyID"];

                    objUser.Password = "";
                    bolOK = true;
                }
                reader.Close();
            }
            catch (Exception objEx)
            {
                throw new Exception("SignIn() Error   " + objEx.Message.ToString());
            }
            finally
            {
                objData.Disconnect();
            }
            return bolOK;
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

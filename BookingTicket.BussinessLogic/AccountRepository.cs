using BookingTicket.BussinessObject;
using BookingTicket.DataObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BookingTicket.BussinessLogic
{
    public class AccountRepository
    {
        #region staticMember
        /// <summary>
        /// 
        /// </summary>
        private static AccountRepository _instance;
        /// <summary>
        /// 
        /// </summary>
        public static AccountRepository Current
        {
            get { return _instance == null ? _instance = new AccountRepository() : _instance; }
        }
        #endregion


        #region Method
        /// <summary>
        /// Login
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public bool SignIn(ref SysUserBO objUser)
        {
            try
            {
                return new SysUserDAO().SignIn(ref objUser);
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        /// <summary>
        /// Thêm nhân viên mới
        /// </summary>
        /// <param name="objBO"></param>
        /// <returns></returns>
        public object Insert(SysUserBO objBO)
        {
            try
            {
                return new SysUserDAO().Insert(objBO);
            }
            catch (Exception objEx)
            {
                throw objEx;
            }
        }

        /// <summary>
        /// Lấy tất cả nhân vieenn 
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll(string strUserName)
        {
            try
            {
                return new SysUserDAO().GetAll(strUserName);
            }
            catch (Exception objEx)
            {
                throw objEx;
            }
        }

        /// <summary>
        /// Xóa nhân viên
        /// </summary>
        /// <param name="objBO"></param>
        /// <returns></returns>
        public int Delete(SysUserBO objBO)
        {
            try
            {
                return new SysUserDAO().Delete(objBO);
            }
            catch (Exception objEx)
            {
                throw objEx;
            }
        }
        public object Update(SysUserBO objBO)
        {
            try
            {
                string key = "GetRouteAll_" + objBO.UserName;
                HttpRuntime.Cache.Remove(key);
                return new SysUserDAO().Update(objBO);
            }
            catch (Exception objEx)
            {
                throw objEx;
            }
        }

        /// <summary>
        /// Thay đổi pass, fullname của nhân viên
        /// </summary>
        /// <param name="strUserName"></param>
        /// <param name="strPassword"></param>
        /// <param name="strFullName"></param>
        /// <returns></returns>
        public int ChangePassword(string strUserName, string strPassword)
        {
            try
            {
                new SysUserDAO().ChangePassword(strUserName, strPassword);
                return 1;
            }
            catch (Exception objEx)
            {
                return 0;
            }
        }
        #endregion


    }
}

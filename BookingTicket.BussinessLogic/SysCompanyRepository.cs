using BookingTicket.BussinessObject;
using BookingTicket.DataObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingTicket.BussinessLogic
{
   public class SysCompanyRepository
    {
        #region Variable

        private SysCompanyDAO objCompany = new SysCompanyDAO();

        private static SysCompanyRepository objCompanyRepository = new SysCompanyRepository();

        public static SysCompanyRepository Current
        {
            get { return objCompanyRepository; }
            set { objCompanyRepository = value; }
        }
        #endregion


        #region Method
        public DataTable GetAll()
        {
            try
            {
                return objCompany.GetAll();
            }
            catch (Exception objEx)
            {
                throw objEx;
            }
        }
        public string Insert(SysCompanyBO objBO)
        {
            try
            {
                return objCompany.Insert(objBO);
            }
            catch (Exception objEx)
            {

                throw objEx;
            }
        }
        public object Update(SysCompanyBO objBO)
        {
            try
            {
                return objCompany.Update(objBO);
            }
            catch (Exception objEx)
            {

                throw objEx;
            }
        }
        public object Delete(SysCompanyBO objBO)
        {
            try
            {
                return objCompany.Delete(objBO);
            }
            catch (Exception objEx)
            {

                throw objEx;
            }
        }
        public object Approve(SysCompanyBO objBO)
        {
            try
            {
                return objCompany.Approve(objBO);
            }
            catch (Exception objEx)
            {

                throw objEx;
            }
        }
        #endregion
    }
}

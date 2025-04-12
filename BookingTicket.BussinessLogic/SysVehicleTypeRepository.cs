using BookingTicket.DataObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using BookingTicket.BussinessObject;

namespace BookingTicket.BussinessLogic
{
    public class SysVehicleTypeRepository
    {
        #region Variable
        private SysVehicleTypeDAO objSysVehicleTypeDAO = new SysVehicleTypeDAO();
        private static SysVehicleTypeRepository objSysVehicleTypeRepository = new SysVehicleTypeRepository();

        public static SysVehicleTypeRepository Current
        {
            get { return objSysVehicleTypeRepository; }
            set { objSysVehicleTypeRepository = value; }
        }
        #endregion

        public DataTable VehicleType_GetAll(int CompanyID)
        {

            DataTable dtRoute = new DataTable();
            try
            {
                dtRoute = objSysVehicleTypeDAO.GetAll(CompanyID);
            }
            catch (Exception objEx)
            {
                throw objEx;
            }
            return dtRoute;
        }
        public object Insert(Sys_VehicleTypeBO objBO)
        {
            try
            {
                return objSysVehicleTypeDAO.Insert(objBO);
            }
            catch (Exception objEx)
            {

                throw objEx;
            }
        }
        public object Update(Sys_VehicleTypeBO objBO)
        {
            try
            {
                return objSysVehicleTypeDAO.Update(objBO);
            }
            catch (Exception objEx)
            {

                throw objEx;
            }
        }
        public object Delete(Sys_VehicleTypeBO objBO)
        {
            try
            {
                return objSysVehicleTypeDAO.Delete(objBO);
            }
            catch (Exception objEx)
            {

                throw objEx;
            }
        }
    }
}

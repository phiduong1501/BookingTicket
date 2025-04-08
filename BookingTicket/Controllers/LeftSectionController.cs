using BookingTicket.BussinessLogic;
using BookingTicket.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingTicket.Controllers
{
    public class LeftSectionController : Controller
    {
        // GET: LeftSection
        public string GetRouteAll()
        {
            var objUser = SysUserModels.Current.CurrentUser();

            DataTable dt = SysRouteRepository.Current.getRouteAll(objUser.UserName);

            return Utils.Utils.ConvertDataTableTojSonString(dt);
        }

        public string GetTimeGoOfDateGo(DateTime dtGo, int routeID)
        {
            var objUser = SysUserModels.Current.CurrentUser();
            DataTable dt = CarRepository.Current.GetTimeGoOfDateGo(dtGo, routeID, objUser.UserName);
            return Utils.Utils.ConvertDataTableTojSonString(dt);
        }

        public string GetAllSeatOfTimeGo(int intDateGoID, int intStationID, int intRouteID)
        {
            var objUser = SysUserModels.Current.CurrentUser();
            DataTable dt = CarRepository.Current.GetAllSeatOfTimeGo(intDateGoID, intStationID, objUser.UserName, intRouteID);

            return Utils.Utils.ConvertDataTableTojSonString(dt);
        }

        public string GetAllSeatCancelOfTimeGo(int intDateGoID, int intStationID)
        {
            var objUser = SysUserModels.Current.CurrentUser();
            DataTable dt = CarRepository.Current.GetAllSeatCancelOfTimeGo(intDateGoID, intStationID, objUser.UserName);

            return Utils.Utils.ConvertDataTableTojSonString(dt);
        }

        public string SearchSeats(string strKeyword)
        {
            if (strKeyword == null)
                return null;
            //tanhk
            var objUser = SysUserModels.Current.CurrentUser();
            //tanhk
            var dtb = CarRepository.Current.SearchSeats(strKeyword, objUser.UserName);

            if (dtb != null && dtb.Rows.Count > 0)
            {
                dtb.Columns.Add("TextData");

                foreach (DataRow item in dtb.Rows)
                {
                    item["TextData"] = string.Format("{0} ({1}) - Đã đặt 1 vé {2} / {3}đ / {4} / ngày {5} / lúc {6}", item["PassengerName"].ToString(),
                        item["Mobile"].ToString(), item["Description"].ToString(), item["Price"].ToString(),
                        item["RouteName"].ToString(), item["GoDate"].ToString(), item["GoTime"].ToString());
                }
                return Utils.Utils.ConvertDataTableTojSonString(dtb);
            }

            return null;
        }
    }

    public class DataSearch
    {
        public int CarDateGoID { get; set; }
        public string TextData { get; set; }
    }
}
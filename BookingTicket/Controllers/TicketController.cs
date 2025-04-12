using BookingTicket.BussinessLogic;
using BookingTicket.BussinessObject;
using BookingTicket.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookingTicket.Utils;
using System.Text;
using BookingTicket.DataObject;

namespace BookingTicket.Controllers
{
    public class TicketController : Controller
    {
        // GET: Ticket
        public ActionResult TicketListOfRoute()
        {
            var objUser = SysUserModels.Current.CurrentUser();
            if (objUser == null || objUser.UserName == null)
                return Redirect("/dang-nhap");
            return View();
        }
        public ActionResult Booking()
        {
            var objUser = SysUserModels.Current.CurrentUser();
            if (objUser == null || objUser.UserName == null)
                return Redirect("/dang-nhap");
            return View();
        }

        public ActionResult PayBack()
        {
            var objUser = SysUserModels.Current.CurrentUser();
            if (objUser == null || objUser.UserName == null)
                return Redirect("/dang-nhap");
            return View();
        }
        public ActionResult Transit()
        {
            var objUser = SysUserModels.Current.CurrentUser();
            if (objUser == null || objUser.UserName == null)
                return Redirect("/dang-nhap");
            return View();
        }

        public ActionResult PrinterTicket()
        {
            var objUser = SysUserModels.Current.CurrentUser();
            if (objUser == null || objUser.UserName == null)
                return Redirect("/dang-nhap");
            string CarDateGoDetailID = this.Request.QueryString["lstCarDateGoDetailID"];
            DataTable dtSeat = CarRepository.Current.GetSeatByID(CarDateGoDetailID, objUser.UserName);
            ViewBag.dtSeat = dtSeat;
            return View();
        }

        public ActionResult ManagementCar()
        {
            var objUser = SysUserModels.Current.CurrentUser();
            if (objUser == null || objUser.UserName == null)
                return Redirect("/dang-nhap");
            return View();
        }

        public ActionResult ManagementPickup()
        {
            var objUser = SysUserModels.Current.CurrentUser();
            if (objUser == null || objUser.UserName == null)
                return Redirect("/dang-nhap");
            return View();
        }

        public ActionResult PrintTicket()
        {
            var objUser = SysUserModels.Current.CurrentUser();
            if (objUser == null || objUser.UserName == null)
                return Redirect("/dang-nhap");
            string CarDateGoDetailID = this.Request.QueryString["CarDateGoDetailID"];
            DataTable dtSeat = CarRepository.Current.GetSeatByID(CarDateGoDetailID, objUser.UserName);
            ViewBag.dtSeat = dtSeat;
            return View();
        }

        public ActionResult PrintTicketList()
        {
            var objUser = SysUserModels.Current.CurrentUser();
            if (objUser == null || objUser.UserName == null)
                return Redirect("/dang-nhap");
            int intDateGoID = Convert.ToInt32(this.Request.QueryString["intDateGoID"]);
            int intStationID = Convert.ToInt32(this.Request.QueryString["stationFromID"]);
            int intRouteID = Convert.ToInt32(this.Request.QueryString["intRouteID"]);
            DataTable dtSeatOfTimeGo = CarRepository.Current.GetAllSeatOfTimeGo(intDateGoID, intStationID, objUser.UserName, intRouteID);

            DataTable dtResult = dtSeatOfTimeGo.Clone();
            foreach (DataRow row in dtSeatOfTimeGo.Rows)
            {
                if (row["Mobile"].ToString() != "")
                {
                    DataRow[] dr = dtResult.Select("Mobile = '" + row["Mobile"] + "'");
                    if (!dr.Any())
                    {
                        DataRow[] drTemp = dtSeatOfTimeGo.Select("Mobile = '" + row["Mobile"] + "'");
                        var lstSeat = "";
                        if (drTemp.Any())
                        {
                            foreach (DataRow r in drTemp)
                            {
                                lstSeat += r["Description"].ToString() + ",";
                            }
                        }

                        row["Description"] = drTemp.Count() + "Ch(" + lstSeat.Trim(',') + ")";
                        dtResult.ImportRow(row);
                    }
                }
                else
                {
                    row["Description"] = "1Ch(" + row["Description"].ToString() + ")";
                    dtResult.ImportRow(row);
                }
            }

            ViewBag.dtSeatOfTimeGo = dtResult;
            return View();
        }

        public int CountSeat(DataTable dtSeatOfTimeGo, string Phone)
        {
            int iCount = 0;
            foreach (DataRow row in dtSeatOfTimeGo.Rows)
            {
                if (row["SeatStatusID"].ToString() == "2" && row["Mobile"].ToString() == Phone && Phone != "")
                    iCount++;
            }
            return iCount;
        }

        public ActionResult PrintSeatDiagram()
        {
            var objUser = SysUserModels.Current.CurrentUser();
            if (objUser == null || objUser.UserName == null)
                return Redirect("/dang-nhap");
            int intDateGoID = Convert.ToInt32(this.Request.QueryString["intDateGoID"]);
            int intStationID = Convert.ToInt32(this.Request.QueryString["stationFromID"]);
            int intRouteID = Convert.ToInt32(this.Request.QueryString["intRouteID"]);
            DataTable dtSeatOfTimeGo = CarRepository.Current.GetAllSeatOfTimeGo(intDateGoID, intStationID, objUser.UserName, intRouteID);
            dtSeatOfTimeGo.Columns.Add("COUNT");

            foreach (DataRow row in dtSeatOfTimeGo.Rows)
            {
                row["COUNT"] = CountSeat(dtSeatOfTimeGo, row["Mobile"].ToString());
            }

            ViewBag.dtSeatOfTimeGo = dtSeatOfTimeGo;
            return View();
        }

        public ActionResult PrintPayback()
        {
            var objUser = SysUserModels.Current.CurrentUser();
            if (objUser == null || objUser.UserName == null)
                return Redirect("/dang-nhap");
            int intDateGoID = Convert.ToInt32(this.Request.QueryString["intDateGoID"]);
            DataTable dtPayBack = CarRepository.Current.GetListPickup(intDateGoID, objUser.UserName);
            DataTable dtResult = dtPayBack.Clone();
            foreach (DataRow row in dtPayBack.Rows)
            {
                //if (row["Mobile"].ToString() != "")
                //{
                //    DataRow[] dr = dtResult.Select("Mobile = '" + row["Mobile"] + "'");
                //    if (!dr.Any())
                //    {
                //        DataRow[] drTemp = dtPayBack.Select("Mobile = '" + row["Mobile"] + "'");

                //        row["Descriptions"] = drTemp.Count() + " Ch(" + row["Descriptions"].ToString() + ")";
                //        dtResult.ImportRow(row);
                //    }
                //}
                //else
                //{
                //    row["Descriptions"] = "1Ch(" + row["Descriptions"].ToString() + ")";
                //    dtResult.ImportRow(row);
                //}
                dtResult.ImportRow(row);
            }
            ViewBag.dtPayBack = dtResult;
            return View();
        }

        public ActionResult PrintTransit()
        {
            var objUser = SysUserModels.Current.CurrentUser();
            if (objUser == null || objUser.UserName == null)
                return Redirect("/dang-nhap");
            int intDateGoID = Convert.ToInt32(this.Request.QueryString["intDateGoID"]);
            DataTable dtTransit = CarRepository.Current.GetListTransit(intDateGoID, objUser.UserName);

            DataTable dtResult = dtTransit.Clone();
            foreach (DataRow row in dtTransit.Rows)
            {
                //if (row["Mobile"].ToString() != "")
                //{
                //    DataRow[] dr = dtResult.Select("Mobile = '" + row["Mobile"] + "'");
                //    if (!dr.Any())
                //    {
                //        DataRow[] drTemp = dtTransit.Select("Mobile = '" + row["Mobile"] + "'");

                //        row["Descriptions"] = drTemp.Count() + "Ch(" + row["Descriptions"].ToString() + ")";
                //        dtResult.ImportRow(row);
                //    }
                //}
                //else
                //{
                //    row["Descriptions"] = "1Ch(" + row["Descriptions"].ToString() + ")";
                //    dtResult.ImportRow(row);
                //}
                dtResult.ImportRow(row);
            }

            ViewBag.dtTransit = dtResult;
            return View();
        }

        public ActionResult ManagementAccount()
        {
            var objUser = SysUserModels.Current.CurrentUser();
            if (objUser == null || objUser.UserName == null)
                return Redirect("/dang-nhap");
            return View();
        }

        public ActionResult ManagementStation()
        {
            var objUser = SysUserModels.Current.CurrentUser();
            if (objUser == null || objUser.UserName == null)
                return Redirect("/dang-nhap");
            return View();
        }

        public ActionResult ManagementTime()
        {
            var objUser = SysUserModels.Current.CurrentUser();
            if (objUser == null || objUser.UserName == null)
                return Redirect("/dang-nhap");
            return View();
        }

        public ActionResult ManagementRoute()
        {
            var objUser = SysUserModels.Current.CurrentUser();
            if (objUser == null || objUser.UserName == null)
                return Redirect("/dang-nhap");
            return View();
        }
        public ActionResult ManagementVehicleType()
        {
            var objUser = SysUserModels.Current.CurrentUser();
            if (objUser == null || objUser.UserName == null)
                return Redirect("/dang-nhap");
            return View();
        }

        public JsonResult GetAllStation(int intSortDesc)
        {
            try
            {
                var objUser = SysUserModels.Current.CurrentUser();
                DataTable dt = SysStationRepository.Current.GetAllStation(intSortDesc, objUser.UserName);

                List<SysStationBO> lst = dt.ToList<SysStationBO>();

                return Json(new { Success = true, Result = lst });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }

        public JsonResult CarIsGo(int intCarID)
        {
            try
            {
                var objUser = SysUserModels.Current.CurrentUser();
                var a = CarRepository.Current.CarIsGo(intCarID, objUser.UserName);
                if (a > 0)
                    return Json(new { Success = true, Result = a });
                return Json(new { Success = false, Message = "Không xuất bến được" });
            }
            catch (Exception obj)
            {
                return Json(new { Success = false, Message = obj.Message });
            }
        }


        public JsonResult GetAllPickupAddress(int type, int routeID)
        {
            try
            {
                var objUser = SysUserModels.Current.CurrentUser();
                DataTable dt = SysPickupAdressReposoitory.Current.GetAllPickupAddress(type, routeID, objUser.UserName);

                List<SysPickupAddressBO> lst = dt.ToList<SysPickupAddressBO>();

                return Json(new { Success = true, Result = lst });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }

        public JsonResult BookingTicket(string listSeatID)
        {
            try
            {
                var user = SysUserModels.Current.CurrentUser();
                if (user == null)
                    return Json(new { Success = false, Message = "Vui lòng đăng nhập lại" });

                DataTable dtSeat = CarRepository.Current.GetSeatByID(listSeatID, user.UserName);

                if (dtSeat != null && dtSeat.Rows.Count > 0)
                {
                    var seats = dtSeat.ToList<CarDateGoDetailBO>();

                    foreach (var seat in seats)
                    {
                        if (seat.SeatStatusID == 0)
                        {
                            seat.SeatStatusID = 1;
                            seat.PaymentStatusID = 0;//tanhk 2017-12-29
                            seat.UpdatedUser = user.UserName;
                            CarRepository.Current.UpdateSeat(seat);

                            CarRepository.Current.WriteLog(user.UserName, "Đặt vé<br/>Người đặt: " + user.UserName + "<br/>", seat.CarDateGoDetailID.ToString());
                        }
                        else
                        {
                            return Json(new { Success = false, Message = "LƯU Ý: GHẾ ĐÃ CÓ NGƯỜI KHÁC ĐẶT. VUI LÒNG CHỌN LẠI GHẾ KHÁC" });
                        }
                    }
                }

                return Json(new { Success = true });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }

        public JsonResult Update(CarDateGoDetailBO model)
        {
            try
            {
                var user = SysUserModels.Current.CurrentUser();
                if (user == null)
                    return Json(new { Success = false, Message = "Vui lòng đăng nhập lại" });

                DataTable dtSeat = CarRepository.Current.GetSeatByID(model.ListID, user.UserName);

                if (dtSeat != null && dtSeat.Rows.Count > 0)
                {
                    //tanhk
                    var seatstemp = dtSeat.ToList<CarDateGoDetailBO>();
                    var count = 0;
                    var isPass = true;
                    var tempPhone = "";
                    foreach (var seattemp in seatstemp)
                    {
                        if (seattemp.SeatStatusID == 2 || seattemp.SeatStatusID == 1 )
                        {
                            count++;
                            if (count == 1)
                                { tempPhone = seattemp.Mobile; }
                            else
                            {
                                if (tempPhone != seattemp.Mobile)
                                    { isPass = false; }
                            }
                        }
                    }

                    if (count > 1 && !isPass) {
                        return Json(new { Success = false, Message = "Chỉ được chọn 1 ghế có thông tin." });
                    }
                    //tanhk

                    var seats = dtSeat.ToList<CarDateGoDetailBO>();

                    foreach (var seat in seats)
                    {
                        if (seat.SeatStatusID != -1 && seat.SeatStatusID != 3 && seat.SeatStatusID != 6)
                        {
                            StringBuilder log = new StringBuilder();

                            if (seat.SeatStatusID == 2)
                            {
                                log.Append("Cập nhật<br/>");

                                if (seat.PassengerName != model.PassengerName)
                                    log.Append("Thay đổi tên từ " + seat.PassengerName + " -> " + model.PassengerName + "<br/>");
                                if (seat.Mobile != model.Mobile)
                                    log.Append("Thay đổi số điện thoại từ " + seat.Mobile + " -> " + model.Mobile + "<br/>");
                                if (seat.Address != model.Address)
                                    log.Append("Thay đổi địa chỉ từ " + seat.Address + " -> " + model.Address + "<br/>");
                                if (seat.Note != model.Note)
                                    log.Append("Thay đổi ghi chú từ " + seat.Note + " -> " + model.Note + "<br/>");
                                if (seat.IsPickUp != model.IsPickUp)
                                    log.Append("Thay đổi đón " + (seat.IsPickUp ? "Có" : "Không") + " -> " + (model.IsPickUp ? "Có" : "Không") + "<br/>");
                                if (seat.IsTransit != model.IsTransit)
                                    log.Append("Thay đổi trung chuyển " + (seat.IsTransit ? "Có" : "Không") + " -> " + (model.IsTransit ? "Có" : "Không") + "<br/>");
                            }
                            else if (seat.SeatStatusID == 0 || seat.SeatStatusID == 1)
                            {
                                log.Append("Đặt vé có thông tin<br/>");
                                log.Append("Tên: " + model.PassengerName + "<br/>");
                                log.Append("Số điện thoại: " + model.Mobile + "<br/>");
                                log.Append("Địa chỉ: " + model.Address + "<br/>");
                                log.Append("Ghi chú: " + model.Note + "<br/>");
                                log.Append("Đón: " + (model.IsPickUp ? "Có" : "Không") + "<br/>");
                                log.Append("Trung chuyển: " + (model.IsTransit ? "Có" : "Không") + "<br/>");
                            }

                            log.Append("Người cập nhật: " + user.UserName + "<br/>");

                            seat.SeatStatusID = 2;
                            seat.IsPickUp = model.IsPickUp;
                            seat.IsTransit = model.IsTransit;
                            seat.PassengerName = model.PassengerName;
                            seat.Mobile = model.Mobile;
                            seat.Address = model.Address;
                            seat.Note = model.Note;
                            seat.RouteID = model.RouteID;
                            seat.CreatedStationID = model.StationFromID;
                            seat.UpdatedUser = user.UserName;
                            seat.PaymentStatusID = model.PaymentStatusID;
                            //seat.CarDateGoDetailID = model.CarDateGoDetailID;

                            CarRepository.Current.UpdateSeat(seat);

                            CarRepository.Current.WriteLog(user.UserName, log.ToString(), seat.CarDateGoDetailID.ToString());
                        }
                    }
                }

                return Json(new { Success = true });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }

        public JsonResult UpdateSeatsCancel(CarDateGoDetailBO model, string strCarDateGoDetailID)
        {
            try
            {
                var user = SysUserModels.Current.CurrentUser();
                if (user == null)
                    return Json(new { Success = false, Message = "Vui lòng đăng nhập lại" });

                DataTable dtSeat = CarRepository.Current.GetSeatByID(strCarDateGoDetailID, user.UserName);

                if (dtSeat != null && dtSeat.Rows.Count > 0)
                {
                    var seats = dtSeat.ToList<CarDateGoDetailBO>();

                    foreach (var seat in seats)
                    {
                        if(seat.SeatStatusID != 0)
                        {
                            return Json(new { Success = false, Message = "Ghế đã có người đặt" });
                        }

                        StringBuilder log = new StringBuilder();

                        log.Append("Đặt vé có thông tin<br/>");
                        log.Append("Tên: " + model.PassengerName + "<br/>");
                        log.Append("Số điện thoại: " + model.Mobile + "<br/>");
                        log.Append("Địa chỉ: " + model.Address + "<br/>");
                        log.Append("Ghi chú: " + model.Note + "<br/>");
                        log.Append("Đón: " + (model.IsPickUp ? "Có" : "Không") + "<br/>");
                        log.Append("Trung chuyển: " + (model.IsTransit ? "Có" : "Không") + "<br/>");

                        log.Append("Người cập nhật: " + user.UserName + "<br/>");

                        CarRepository.Current.UpdateSeatCancel(strCarDateGoDetailID, model.CarDateGoDetailID.ToString(), user.UserName);

                        CarRepository.Current.WriteLog(user.UserName, log.ToString(), model.CarDateGoDetailID.ToString());

                    }
                    return Json(new { Success = true });
                }
                else
                {
                    return Json(new { Success = false, Message = "Khôngn tìm thấy thông tin ghế muốn chuyển" });
                }
               
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }

        public JsonResult UpdateStatusPayment(string lstCarDateGoDetailID, int iStatusID, int RouteID)
        {
            int intTemp = 1;
            string tmpMobile = "";
            var user = SysUserModels.Current.CurrentUser();
            if (user == null)
                return Json(new { Success = false, Message = "Vui lòng đăng nhập lại" });
            try
            {

                List<string> lstDetailID = lstCarDateGoDetailID.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                foreach (string ID in lstDetailID)
                {
                    CarDateGoDetailBO objCarDateGoDetailBO = new CarDateGoDetailBO();
                    objCarDateGoDetailBO.UpdatedDate = DateTime.Now;
                    objCarDateGoDetailBO.UpdatedUser = user.UserName;
                    objCarDateGoDetailBO.CarDateGoDetailID = long.Parse(ID);
                    objCarDateGoDetailBO.PaymentStatusID = iStatusID;
                    objCarDateGoDetailBO.RouteID = RouteID;

                    if (intTemp == 1 && lstDetailID.Count > 1)
                    {
                        tmpMobile = ID;
                    }
                    objCarDateGoDetailBO.Mobile = tmpMobile;

                    CarRepository.Current.UpdateStatusPayment(objCarDateGoDetailBO);
                    intTemp = 2;

                    string status = iStatusID == 1 ? "Đã thanh toán" : (iStatusID == 0 ? "Chưa thanh toán" : (iStatusID == 2 ? "Không thu tiền" : "Đặt cọc"));

                    CarRepository.Current.WriteLog(user.UserName, "Cập nhật thanh toán: " + status + "<br/>Người cập nhật: " + user.UserName + "<br/>", ID);
                }
                DataTable dtSeat = CarRepository.Current.GetSeatByID(lstCarDateGoDetailID, user.UserName);
                return Json(new { Success = true, Data = Utils.Utils.ConvertDataTableTojSonString(dtSeat) });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = "Có lỗi khi cập nhật" });
            }
        }


        public JsonResult DeleteTicket(string lstCarDateGoDetailID, string strNoteChange)
        {
            var user = SysUserModels.Current.CurrentUser();
            if (user == null)
                return Json(new { Success = false, Message = "Vui lòng đăng nhập lại" });
            var bResult = CarRepository.Current.DeleteTicket(lstCarDateGoDetailID, user.UserName, strNoteChange);
            if (!bResult)
                return Json(new { Success = false, Message = "Có lỗi khi cập nhật" });

            var ids = lstCarDateGoDetailID.Split(',');
            foreach (var id in ids)
            {
                CarRepository.Current.WriteLog(user.UserName, "Hủy ghế<br/>Người hủy: " + user.UserName + "<br/>", id);
            }

            return Json(new { Success = true });
        }

        public JsonResult GetLogByDateGoDetailID(int intDateGoDetailID)
        {
            var objUser = SysUserModels.Current.CurrentUser();
            DataTable dt = CarRepository.Current.GetLogByDateGoDetailID(intDateGoDetailID, objUser.UserName);

            var list = dt.ToList<CarDateGoDetailLogDAO>();
            return Json(new { Success = true, Result = list });
        }

        public JsonResult GetLogCustomerByDateGoDetailID(string strPhone)
        {
            var objUser = SysUserModels.Current.CurrentUser();
            DataTable dt = CarRepository.Current.GetLogCustomerByDateGoDetailID(strPhone, objUser.UserName);

            var list = dt.ToList<CarDateGoDetailLogDAO>();
            return Json(new { Success = true, Result = list });
        }

        public JsonResult MoveSeat(int intDateGoDetailIDFrom, int intDateGoDetailIDTo)
        {
            try
            {
                var user = SysUserModels.Current.CurrentUser();
                if (user == null)
                    return Json(new { Success = false, Message = "Vui lòng đăng nhập lại" });

                //DataTable dtSeat = CarRepository.Current.GetSeatByID(intDateGoDetailIDFrom + "," + intDateGoDetailIDTo);
                //var seats = dtSeat.ToList<CarDateGoDetailBO>();

                DataTable dtSeat1 = CarRepository.Current.GetSeatByID(intDateGoDetailIDFrom.ToString(), user.UserName);
                var seats1 = dtSeat1.ToList<CarDateGoDetailBO>();

                DataTable dtSeat2 = CarRepository.Current.GetSeatByID(intDateGoDetailIDTo.ToString(), user.UserName);
                var seats2 = dtSeat2.ToList<CarDateGoDetailBO>();

                //string log1 = "Ghế được đổi từ ghế " + seats[1].Description + " chuyến " + seats[1].GoTime + " ngày " + seats[1].GoDate.ToString("dd/MM/yyyy") + "<br/>Người đổi: " + user.UserName + "<br/>";
                //string log2 = "Ghế được đổi từ ghế " + seats[0].Description + " chuyến " + seats[0].GoTime + " ngày " + seats[0].GoDate.ToString("dd/MM/yyyy") + "<br/>Người đổi: " + user.UserName + "<br/>";

                string log1 = "Ghế được đổi từ ghế " + seats2[0].Description + " chuyến " + seats2[0].GoTime + " ngày " + seats2[0].GoDate.ToString("dd/MM/yyyy") + "<br/>Người đổi: " + user.UserName + "<br/>";
                string log2 = "Ghế được đổi từ ghế " + seats1[0].Description + " chuyến " + seats1[0].GoTime + " ngày " + seats1[0].GoDate.ToString("dd/MM/yyyy") + "<br/>Người đổi: " + user.UserName + "<br/>";
                var result = CarRepository.Current.MoveSeat(intDateGoDetailIDFrom, intDateGoDetailIDTo, user.UserName);
                if (result)
                {
                    CarRepository.Current.WriteLog(user.UserName, log1, intDateGoDetailIDFrom.ToString());
                    CarRepository.Current.WriteLog(user.UserName, log2, intDateGoDetailIDTo.ToString());
                    return Json(new { Success = true });
                }
                else
                {
                    return Json(new { Success = false, Message = "Ghế đã có người đặt" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }

        public JsonResult GetListPickup(int intCarDateGoID)
        {
            try
            {
                var objUser = SysUserModels.Current.CurrentUser();
                DataTable dt = CarRepository.Current.GetListPickup(intCarDateGoID, objUser.UserName);

                return Json(new { Success = true, Result = Utils.Utils.ConvertDataTableTojSonString(dt) });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }

        public JsonResult GetListTransit(int intCarDateGoID)
        {
            try
            {
                var objUser = SysUserModels.Current.CurrentUser();
                DataTable dt = CarRepository.Current.GetListTransit(intCarDateGoID, objUser.UserName);

                return Json(new { Success = true, Result = Utils.Utils.ConvertDataTableTojSonString(dt) });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }

        public JsonResult GetTimeAll()
        {
            try
            {
                var objUser = SysUserModels.Current.CurrentUser();
                DataTable dt = SysTimeRepository.Current.GetTimeAll(objUser.UserName);

                return Json(new { Success = true, Result = Utils.Utils.ConvertDataTableTojSonString(dt) });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }

        public JsonResult InsertCarDateGo(CarDateGoBO objBO)
        {
            try
            {
                var user = SysUserModels.Current.CurrentUser();
                if (user == null)
                    return Json(new { Success = false, Message = "Vui lòng đăng nhập lại" });

                objBO.CreatedUser = user.UserName;

                CarRepository.Current.Insert(objBO);

                return Json(new { Success = true });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }

        public JsonResult InsertPickup(SysPickupAddressBO objBO)
        {
            try
            {
                var user = SysUserModels.Current.CurrentUser();
                if (user == null)
                    return Json(new { Success = false, Message = "Vui lòng đăng nhập lại" });

                objBO.CreatedUser = user.UserName;

                SysPickupAdressReposoitory.Current.Insert(objBO);

                return Json(new { Success = true });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }

        public JsonResult UpdatePickup(SysPickupAddressBO objBO)
        {
            try
            {
                var user = SysUserModels.Current.CurrentUser();
                if (user == null)
                    return Json(new { Success = false, Message = "Vui lòng đăng nhập lại" });

                objBO.UpdatedUser = user.UserName;

                SysPickupAdressReposoitory.Current.Update(objBO);

                return Json(new { Success = true });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }

        public JsonResult DeletePickup(SysPickupAddressBO objBO)
        {
            try
            {
                var user = SysUserModels.Current.CurrentUser();
                if (user == null)
                    return Json(new { Success = false, Message = "Vui lòng đăng nhập lại" });

                objBO.DeletedUser = user.UserName;

                SysPickupAdressReposoitory.Current.Delete(objBO);

                return Json(new { Success = true });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }

        public JsonResult UpdateOrderTransit(string strID, int intIndex)
        {
            try
            {
                var objUser = SysUserModels.Current.CurrentUser();
                bool result = CarRepository.Current.UpdateOrderTransit(strID, intIndex, objUser.UserName);
                return Json(new { Success = result });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }

        public JsonResult UpdateOrderPickup(string strID, int intIndex)
        {
            try
            {
                var objUser = SysUserModels.Current.CurrentUser();
                bool result = CarRepository.Current.UpdateOrderPickup(strID, intIndex, objUser.UserName);
                return Json(new { Success = result });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }

        public JsonResult GetCarByID(int intCarDateGoID)
        {
            try
            {
                var objUser = SysUserModels.Current.CurrentUser();
                DataTable dt = CarRepository.Current.GetCarByID(intCarDateGoID, objUser.UserName);

                return Json(new { Success = true, Result = Utils.Utils.ConvertDataTableTojSonString(dt) });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }

        public JsonResult GetRouteByStation(int intStationFrom, int intStationTo)
        {
            try
            {
                var objUser = SysUserModels.Current.CurrentUser();
                DataTable dt = SysRouteRepository.Current.GetRouteByStation(intStationFrom, intStationTo, objUser.UserName);

                return Json(new { Success = true, Result = Utils.Utils.ConvertDataTableTojSonString(dt) });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }

        public JsonResult UpdateCarDateGo(int intCarID, string strGoTime, string strDriver, string strCarNumber, int bolTransship, int bolNewBus)
        {
            try
            {
                var user = SysUserModels.Current.CurrentUser();
                if (user == null)
                    return Json(new { Success = false, Message = "Vui lòng đăng nhập lại" });

                var result = CarRepository.Current.UpdateCarDateGo(intCarID, strGoTime, strDriver, strCarNumber, bolTransship, bolNewBus, user.UserName);
                return Json(new { Success = true, Result = result });
            }
            catch (Exception obj)
            {
                return Json(new { Success = false, Message = obj.Message });
            }
        }


        public JsonResult DeleteCar(int intCarDateGoID)
        {
            try
            {
                var user = SysUserModels.Current.CurrentUser();
                if (user == null)
                    return Json(new { Success = false, Message = "Vui lòng đăng nhập lại" });

                var result = CarRepository.Current.DeleteCar(intCarDateGoID, user.UserName);
                return Json(new { Success = true, Result = result });
            }
            catch (Exception obj)
            {
                return Json(new { Success = false, Message = obj.Message });
            }
        }

        //public JsonResult SelectLoaiXe()
        //{
        //    try
        //    {
        //        var user = SysUserModels.Current.CurrentUser();
        //        if (user == null)
        //            return Json(new { Success = false, Message = "Vui lòng đăng nhập lại" });

        //        var result = CarRepository.Current.SelectLoaiXe();
        //        return Json(Utils.Utils.ConvertDataTableTojSonString(result), JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception obj)
        //    {
        //        return Json(new { Success = false, Message = obj.Message });
        //    }
        //}
        #region station
        public JsonResult DeleteStation(SysStationBO objStation)
        {
            try
            {
                var user = SysUserModels.Current.CurrentUser();
                if (user == null)
                    return Json(new { Success = false, Message = "Vui lòng đăng nhập lại" });
                objStation.DeletedUser = user.UserName;
                var result = SysStationRepository.Current.Delete(objStation);
                return Json(new { Success = true, Result = result });
            }
            catch (Exception obj)
            {
                return Json(new { Success = false, Message = obj.Message });
            }
        }

        public JsonResult UpdateStation(SysStationBO objStation)
        {
            try
            {
                var user = SysUserModels.Current.CurrentUser();
                if (user == null)
                    return Json(new { Success = false, Message = "Vui lòng đăng nhập lại" });
                var result = SysStationRepository.Current.Update(objStation, user.UserName);
                return Json(new { Success = true, Result = result });
            }
            catch (Exception obj)
            {
                return Json(new { Success = false, Message = obj.Message });
            }
        }

        public JsonResult InsertStation(SysStationBO objStation)
        {
            try
            {
                var user = SysUserModels.Current.CurrentUser();
                if (user == null)
                    return Json(new { Success = false, Message = "Vui lòng đăng nhập lại" });
                var result = SysStationRepository.Current.Insert(objStation, user.UserName);
                return Json(new { Success = true, Result = result });
            }
            catch (Exception obj)
            {
                return Json(new { Success = false, Message = obj.Message });
            }
        }
        #endregion

        #region time
        public JsonResult DeleteTime(SysTimeBO objTime)
        {
            try
            {
                var user = SysUserModels.Current.CurrentUser();
                if (user == null)
                    return Json(new { Success = false, Message = "Vui lòng đăng nhập lại" });
                objTime.DeletedUser = user.UserName;
                var result = SysTimeRepository.Current.Delete(objTime);
                return Json(new { Success = true, Result = result });
            }
            catch (Exception obj)
            {
                return Json(new { Success = false, Message = obj.Message });
            }
        }

        public JsonResult UpdateTime(SysTimeBO objTime)
        {
            try
            {
                var user = SysUserModels.Current.CurrentUser();
                if (user == null)
                    return Json(new { Success = false, Message = "Vui lòng đăng nhập lại" });
                objTime.UpdatedUser = user.UserName;
                var result = SysTimeRepository.Current.Update(objTime);
                return Json(new { Success = true, Result = result });
            }
            catch (Exception obj)
            {
                return Json(new { Success = false, Message = obj.Message });
            }
        }

        public JsonResult InsertTime(SysTimeBO objTime)
        {
            try
            {
                var user = SysUserModels.Current.CurrentUser();
                if (user == null)
                    return Json(new { Success = false, Message = "Vui lòng đăng nhập lại" });
                objTime.CreatedUser = user.UserName;
                var result = SysTimeRepository.Current.Insert(objTime);
                return Json(new { Success = true, Result = result });
            }
            catch (Exception obj)
            {
                return Json(new { Success = false, Message = obj.Message });
            }
        }
        #endregion

        #region route
        public JsonResult DeleteRoute(SysRouteBO objRoute)
        {
            try
            {
                var user = SysUserModels.Current.CurrentUser();
                if (user == null)
                    return Json(new { Success = false, Message = "Vui lòng đăng nhập lại" });
                objRoute.DeletedUser = user.UserName;
                var result = SysRouteRepository.Current.Delete(objRoute);
                return Json(new { Success = true, Result = result });
            }
            catch (Exception obj)
            {
                return Json(new { Success = false, Message = obj.Message });
            }
        }

        public JsonResult UpdateRoute(SysRouteBO objRoute)
        {
            try
            {
                var user = SysUserModels.Current.CurrentUser();
                if (user == null)
                    return Json(new { Success = false, Message = "Vui lòng đăng nhập lại" });
                objRoute.UpdatedUser = user.UserName;
                var result = SysRouteRepository.Current.Update(objRoute);
                return Json(new { Success = true, Result = result });
            }
            catch (Exception obj)
            {
                return Json(new { Success = false, Message = obj.Message });
            }
        }

        public JsonResult InsertRoute(SysRouteBO objRoute)
        {
            try
            {
                var user = SysUserModels.Current.CurrentUser();
                if (user == null)
                    return Json(new { Success = false, Message = "Vui lòng đăng nhập lại" });
                objRoute.CreatedUser = user.UserName;
                var result = SysRouteRepository.Current.Insert(objRoute);
                return Json(new { Success = true, Result = result });
            }
            catch (Exception obj)
            {
                return Json(new { Success = false, Message = obj.Message });
            }
        }
        #endregion

        #region Vehicle Type
        public JsonResult VehicleType_Insert(Sys_VehicleTypeBO Model)
        {
            try
            {
                var user = SysUserModels.Current.CurrentUser();
                if (user == null)
                    return Json(new { Success = false, Message = "Vui lòng đăng nhập lại" });
                Model.CreatedUser = user.UserName;
                Model.CompanyID = user.CompanyID;
                var result = SysVehicleTypeRepository.Current.Insert(Model);
                return Json(new { Success = true, Result = result });
            }
            catch (Exception obj)
            {
                return Json(new { Success = false, Message = obj.Message });
            }
        }    
        public JsonResult VehicleType_GetAll()
        {
            try
            {
                var user = SysUserModels.Current.CurrentUser();
                if (user == null)
                    return Json(new { Success = false, Message = "Vui lòng đăng nhập lại" });
                var result = SysVehicleTypeRepository.Current.VehicleType_GetAll(user.CompanyID);
                return Json(new { Success = true, Result = Utils.Utils.ConvertDataTableTojSonString(result) });
            }
            catch (Exception obj)
            {
                return Json(new { Success = false, Message = obj.Message });
            }
        }
        public JsonResult VehicleType_Update(Sys_VehicleTypeBO Model)
        {
            try
            {
                var user = SysUserModels.Current.CurrentUser();
                if (user == null)
                    return Json(new { Success = false, Message = "Vui lòng đăng nhập lại" });
                Model.UpdatedUser = user.UserName;
                var result = SysVehicleTypeRepository.Current.Update(Model);
                return Json(new { Success = true, Result = result });
            }
            catch (Exception obj)
            {
                return Json(new { Success = false, Message = obj.Message });
            }
        }

        public JsonResult VehicleType_Delete(Sys_VehicleTypeBO Model)
        {
            try
            {
                var user = SysUserModels.Current.CurrentUser();
                if (user == null)
                    return Json(new { Success = false, Message = "Vui lòng đăng nhập lại" });
                Model.DeletedUser = user.UserName;
                var result = SysVehicleTypeRepository.Current.Delete(Model);
                return Json(new { Success = true, Result = result });
            }
            catch (Exception obj)
            {
                return Json(new { Success = false, Message = obj.Message });
            }
        }
        #endregion
    }
}
(function () {
    app.controller('BookingController', ['$http', '$scope', 'BookingFactory', 'CommonFactory', '$routeParams', '$timeout', '$location', '$rootScope', '$route',
        function ($http, $scope, BookingFactory, CommonFactory, $routeParams, $timeout, $location, $rootScope, $route) {
            $scope.controls = {
                lvSeat: {},
                PaymentStatus: {}
            };

            $scope.payments = [
                {
                    PaymentName: 'Đã thanh toán',
                    PaymentID: 1
                },
                {
                    PaymentName: 'Chưa thanh toán',
                    PaymentID: 0
                },
                {
                    PaymentName: 'Không thu tiền',
                    PaymentID: 2
                },
                {
                    PaymentName: 'Đặt cọc',
                    PaymentID: 3
                }
            ];

            $scope.reasonDeletes = [
                {
                    ReasonDeleteName: 'Khách hàng hủy',
                    ReasonDeleteID: 1
                },
                {
                    ReasonDeleteName: 'Nhà xe hủy',
                    ReasonDeleteID: 2
                },
                {
                    ReasonDeleteName: 'Đại lý hủy',
                    ReasonDeleteID: 3
                },
                {
                    ReasonDeleteName: 'Khác',
                    ReasonDeleteID: 4
                }
            ];
            debugger;

            $scope.intDateGoID = $routeParams.intDateGoID;
            $scope.stationFromID = $routeParams.stationFromID;
            $scope.isLoading = true;
            $scope.model = {};
            $scope.model.UserNoteDelete = "";
            $scope.model.CustomerNoteDelete = "";
            $scope.lstseats = [];
            $scope.CarModel = {};
            $scope.lstPayment = [];
            $scope.totalSeat = 0;
            $scope.totalSeatEmpty = 0;
            $scope.totalSeatPayment = 0;
            $scope.lstSelectStation = [];
            $scope.lastID;
            $scope.Init = function () {
                if ($rootScope.first ) {
                    $scope.GetAllPickupAddress();
                }
                if (!$rootScope.first && $rootScope.GetAllPickupAddress_count == 0) {
                    $scope.GetAllPickupAddress();
                    $rootScope.GetAllPickupAddress_count = 1;
                }

                $scope.GetAllSeatOfTimeGo();
                //$scope.GetAllPickupAddress();
                //$scope.GetCarByID();
                $scope.GetAllSeatCancelOfTimeGo();
            }

            $scope.GetAllPickupAddress = function () {
                BookingFactory.GetAllPickupAddress(1, $rootScope.RouteID, function (response) {
                    //$scope.pickups = response.Result;
                    $rootScope.pickups = response.Result;
                });

                BookingFactory.GetAllPickupAddress(2, $rootScope.RouteID, function (response) {
                    //$scope.transits = response.Result;
                    $rootScope.transits = response.Result;
                });
            }

            $scope.stationChange = function (station) {
                if ($scope.lstSelectStation.length == 2) {
                    var exist = false;
                    for (var i = 0; i < $scope.lstSelectStation.length; i++) {
                        if ($scope.lstSelectStation[i].StationID == station.StationID) {
                            exist = true;
                            break;
                        }
                    }

                    if (!exist) {
                        $scope.lstSelectStation = [];
                        $scope.lstSelectStation.push(station);
                        $scope.defaultSelectStation.from = station.StationID;
                        $scope.defaultSelectStation.to = '';
                    }
                    else {
                        $scope.lstSelectStation = [];
                        $scope.defaultSelectStation.from = '';
                        $scope.defaultSelectStation.to = '';
                    }
                }
                else if ($scope.lstSelectStation.length == 1) {
                    if ($scope.lstSelectStation[0].StationID != station.StationID) {
                        $scope.lstSelectStation.push(station);

                        if ($scope.stationFromID == 1) {
                            if ($scope.lstSelectStation[0].OrderIndex < $scope.lstSelectStation[1].OrderIndex) {
                                $scope.defaultSelectStation.from = $scope.lstSelectStation[0].StationID;
                                $scope.defaultSelectStation.to = $scope.lstSelectStation[1].StationID;
                            }
                            else {
                                $scope.defaultSelectStation.from = $scope.lstSelectStation[1].StationID;
                                $scope.defaultSelectStation.to = $scope.lstSelectStation[0].StationID;
                            }
                        }
                        else {
                            if ($scope.lstSelectStation[0].OrderIndex < $scope.lstSelectStation[1].OrderIndex) {
                                $scope.defaultSelectStation.from = $scope.lstSelectStation[1].StationID;
                                $scope.defaultSelectStation.to = $scope.lstSelectStation[0].StationID;
                            }
                            else {
                                $scope.defaultSelectStation.from = $scope.lstSelectStation[0].StationID;
                                $scope.defaultSelectStation.to = $scope.lstSelectStation[1].StationID;
                            }
                        }

                        $scope.GetRouteByStation();
                    }
                    else {
                        $scope.lstSelectStation = [];
                    }
                }
                else {
                    $scope.lstSelectStation.push(station);
                    $scope.defaultSelectStation.from = station.StationID;
                }
            }

            $scope.GetRouteByStation = function () {
                BookingFactory.GetRouteByStation($scope.defaultSelectStation.from, $scope.defaultSelectStation.to, function (response) {
                    if (response.Success) {
                        var data = JSON.parse(response.Result);
                        if (data.length > 0) {
                            $scope.route = data[0];
                            $scope.model.Price = data[0].Price;
                            $scope.model.StationFromID = data[0].StationFromID;
                            $scope.model.StationToID = data[0].StationToID;
                            $scope.model.RouteID = data[0].RouteID;
                            $scope.$apply();
                            // CommonFactory.logSuccess('Tìm được tuyến: ' + data[0].RouteName);
                        }
                        else {
                            $scope.route = null;
                            $scope.lstSelectStation = [];
                            $scope.defaultSelectStation.from = '';
                            $scope.defaultSelectStation.to = '';
                            $scope.$apply();
                            CommonFactory.logWarning('Không tìm được tuyến.');
                        }
                    }
                });
            }

            $scope.GetAllStation = function () {
                var intSortDesc = 0;
                if ($scope.stationFromID != "1")
                    intSortDesc = 1;

                BookingFactory.GetAllStation(intSortDesc, function (response) {
                    $timeout(function () {
                        $scope.defaultSelectStation = {
                            from: -1,
                            to: -1,
                            SortDesc: -1,
                            OrderIndex: -1,
                            isCheck: 0
                        }
                        $scope.stations = response.Result;
                        // if ($scope.model.SeatStatusID == 2) {
                        $scope.defaultSelectStation.from = $scope.model.StationFromID;
                        $scope.defaultSelectStation.to = $scope.model.StationToID;
                        // }
                        //else if ($rootScope.currentUser.StationID == 1) {
                        //    // Nếu user ở hồ chí minh
                        //    $scope.defaultSelectStation.from = 1;
                        //    $scope.defaultSelectStation.to = 2;
                        //}
                        //else if ($rootScope.currentUser.StationID == 2) {
                        //    // Nếu user ở bến tre
                        //    $scope.defaultSelectStation.from = 2;
                        //    $scope.defaultSelectStation.to = 1;
                        //} else if ($rootScope.currentUser.StationID == 3) {
                        //    // Nếu user ở ngả 4 huyện
                        //    $scope.defaultSelectStation.from = 3;
                        //    $scope.defaultSelectStation.to = 1;
                        //} else {
                        //    // Nếu user ở tiền giang
                        //    $scope.defaultSelectStation.from = 4;
                        //    $scope.defaultSelectStation.to = 1;
                        //}

                        $scope.lstSelectStation = [];
                        $scope.lstSelectStation.push({ StationID: $scope.defaultSelectStation.from });
                        $scope.lstSelectStation.push({ StationID: $scope.defaultSelectStation.to });
                        $scope.GetRouteByStation();

                        for (var i = 0; i < $scope.stations.length ; i++) {
                            if ($scope.stations[i].StationID == $rootScope.currentUser.StationID) {
                                $scope.defaultSelectStation.SortDesc = intSortDesc;
                                $scope.defaultSelectStation.OrderIndex = $scope.stations[i].OrderIndex;
                                break;
                            }
                        }
                    }, 0);
                });
            }

            var CountSeatByPhone = function (data, phone) {
                var result = 0;
                for (var i = 0; i < data.length; i++) {
                    if (data[i].Mobile == phone && phone != "")
                        result++;
                }
                return result;
            }

            $scope.reUpdateSeat = function (seatID) {
                if ($scope.modelCancel) {
                    $scope.updateCancel(seatID);
                }
            }

            $scope.updateCancel = function (seatID) {
                BookingFactory.UpdateSeatsCancel($scope.modelCancel, seatID, function (response) {
                    if (response.Success) {
                        $scope.modelCancel = {};
                        $scope.GetAllSeatOfTimeGo();
                        $scope.GetAllSeatCancelOfTimeGo();
                        $rootScope.GetTimeGoOfDateGo();
                        $scope.controls.wndReSelect.center().close();
                        CommonFactory.logSuccess('cập nhật thành công.');
                    }
                    else {
                        CommonFactory.logError(response.Message);
                    }
                });
            }

            //$scope.GetAllSeatOfTimeGo = function () {
            //    $scope.totalSeat = 0;
            //    $scope.totalSeatEmpty = 0;
            //    $scope.totalSeatPayment = 0;

            //    BookingFactory.GetAllSeatOfTimeGo($scope.intDateGoID, $scope.stationFromID, $rootScope.RouteID, function (response) {
            //        $timeout(function () {
            //            for (var i = 0; i < response.length; i++) {
            //                response[i].QuantitySeat = 0;
            //                if (response[i].SeatStatusID > 0) {
            //                    $scope.totalSeat++;
            //                    if (response[i].SeatStatusID > 1)
            //                        response[i].QuantitySeat = CountSeatByPhone(response, response[i].Mobile)
            //                }
            //                else if (response[i].SeatStatusID == 0)
            //                    $scope.totalSeatEmpty++;

            //                if (response[i].PaymentStatusID == 1)
            //                    $scope.totalSeatPayment++;
            //            }

            //            $scope.lstseats = response;
            //            if ($scope.controls.lvSeat && $scope.controls.lvSeat.dataSource != undefined)
            //                $scope.controls.lvSeat.dataSource.data(response);

            //            if ($scope.lastID) {
            //                var data = $scope.controls.lvSeat.dataSource.data();
            //                for (var i = 0; i < data.length; i++) {
            //                    if ($scope.lastID.indexOf(data[i].CarDateGoDetailID) >= 0) {
            //                        $scope.controls.lvSeat.select($scope.controls.lvSeat.items()[i]);
            //                    }
            //                }
            //            }
            //        }, 10)
            //    });
            //}

            $scope.GetAllSeatOfTimeGo = function () {
                BookingFactory.GetAllSeatOfTimeGo($scope.intDateGoID, $scope.stationFromID, $rootScope.RouteID, function (response) {
                    $timeout(function () {
                        $scope.totalSeat = 0;
                        $scope.totalSeatEmpty = 0;
                        $scope.totalSeatPayment = 0;
                        for (var i = 0; i < response.length; i++) {
                            response[i].QuantitySeat = 0;
                            if (response[i].SeatStatusID > 0) {
                                $scope.totalSeat++;
                                if (response[i].SeatStatusID > 1)
                                    response[i].QuantitySeat = CountSeatByPhone(response, response[i].Mobile)
                            }
                            else if (response[i].SeatStatusID == 0)
                                $scope.totalSeatEmpty++;

                            if (response[i].PaymentStatusID == 1)
                                $scope.totalSeatPayment++;
                        }
                        $scope.lstseats = response;
                        if ($scope.controls.lvSeat && $scope.controls.lvSeat.dataSource != undefined)
                            $scope.controls.lvSeat.dataSource.data(response);

                        if ($scope.lastID) {
                            var data = $scope.controls.lvSeat.dataSource.data();
                            for (var i = 0; i < data.length; i++) {
                                if ($scope.lastID.indexOf(data[i].CarDateGoDetailID) >= 0) {
                                    $scope.controls.lvSeat.select($scope.controls.lvSeat.items()[i]);
                                }
                            }
                        }
                    }, 10)
                });
            }

            $scope.GetAllSeatCancelOfTimeGo = function () {
                $scope.totalSeat = 0;
                $scope.totalSeatEmpty = 0;
                $scope.totalSeatPayment = 0;

                BookingFactory.GetAllSeatCancelOfTimeGo($scope.intDateGoID, $scope.stationFromID, function (response) {
                    $timeout(function () {
                        $scope.lstseatscancel = response;
                        if ($scope.controls.lvSeatCancel && $scope.controls.lvSeatCancel.dataSource != undefined)
                            $scope.controls.lvSeatCancel.dataSource.data(response);
                    }, 10)
                });
            }

            $scope.GetCarByID = function () {
                BookingFactory.GetCarByID($scope.intDateGoID, function (response) {
                    if (response.Success) {
                        $timeout(function () {
                            $scope.CarModel = JSON.parse(response.Result)[0];
                        }, 10)
                    }
                });
            }

            $scope.booking = function (id) {
                if ($rootScope.isMoving) {
                    CommonFactory.logWarning('Bạn đang trong trạng thái di chuyển ghế. Không thể thực hiện chức năng khác.');
                    return;
                }

                if (!$scope.model.CarDateGoDetailID) {
                    $scope.model = {};
                    //CommonFactory.logWarning('Chọn 1 ghế trước khi tiến hành đặt vé.');
                    $rootScope.action = 1;//booking
                    return;
                }

                if (($scope.model.ListID.indexOf(id) < 0 && id)) {
                    $rootScope.action = 1; // booking
                    return;
                }

                $scope.lastID = $scope.model.ListID;
                var count = 0;
                var countFail = 0;
                var seat;
                var phone;
                var isPass = false;
                var tempPhone;
                for (var i = 0; i < $scope.selecteds.length; i++) {
                    if ($scope.selecteds[i].SeatStatusID == 2 && (!phone || phone != $scope.selecteds[i].Mobile)) {
                        count++;
                        seat = $scope.selecteds[i];

                        if (!tempPhone || ($scope.selecteds[i].Mobile == tempPhone)) {
                            if (countFail == 0) { isPass = true; }
                            //isPass = true;
                            tempPhone = $scope.selecteds[i].Mobile;
                        }
                        else {
                            isPass = false;
                            countFail = 1;
                        }
                    }
                }

                if (count > 1 && !isPass) {
                    CommonFactory.logWarning('Chỉ được chọn 1 ghế có thông tin.');
                    return;
                }
                else if (count == 1 || isPass)//có 1 ghế có thông tin, hoac cac ghe co cung sdt
                {
                    $scope.model.IsPickUp = seat.IsPickUp;
                    $scope.model.IsTransit = seat.IsTransit;
                    $scope.model.PassengerName = seat.PassengerName;
                    $scope.model.Mobile = seat.Mobile;
                    $scope.model.Address = seat.Address;
                    $scope.model.Note = seat.Note;
                    $scope.model.CreatedStationID = seat.CreatedStationID;
                    $scope.model.PaymentStatusID = seat.PaymentStatusID;
                    $scope.update();
                }
                else if (count == 0)// không có ghế nào có thông tin
                {

                    if ($scope.model.SeatStatusID == 1) {
                        CommonFactory.logError('Không thể copy ghế không có thông tin.');
                        $scope.lastID = '';
                        return;
                    }


                    BookingFactory.Booking($scope.model.ListID, function (response) {
                        if (response.Success) {
                            $scope.GetAllSeatOfTimeGo();
                            $rootScope.GetTimeGoOfDateGo();
                            CommonFactory.logSuccess('Đặt vé thành công.');
                        }
                        else {
                            alert(response.Message);
                            $scope.GetAllSeatOfTimeGo();
                            //CommonFactory.logError(response.Message);
                        }
                        $scope.model = {};
                    });
                }
            }

            $rootScope.isSeachByMobile = true;
            $scope.onSelected = function () {
                debugger;

                if ($scope.notRunEvent)
                    return;

                if (!$scope.model)
                    $rootScope.action = '';

                var select = $scope.controls.lvSeat.select();
                var data = $scope.controls.lvSeat.dataSource.view();

                $scope.model = $scope.controls.lvSeat.dataSource.view()[select.index()];

                var ids = $.map(select, function (item) {
                    if (data[$(item).index()].SeatStatusID != -1)
                        return data[$(item).index()].CarDateGoDetailID;
                });

                $scope.selecteds = $.map(select, function (item) {
                    if (data[$(item).index()].SeatStatusID != -1)
                        return data[$(item).index()];
                });

                if ($scope.model && $scope.model.Mobile) {
                    for (var i = 0; i < data.length; i++) {
                        $scope.notRunEvent = true;
                        if ($scope.model.Mobile == data[i].Mobile && $scope.model.CarDateGoDetailID != data[i].CarDateGoDetailID) {

                            if ($rootScope.isSeachByMobile) {
                                $scope.controls.lvSeat.select($scope.controls.lvSeat.items()[i]);
                                if (!ids)
                                    ids = [];
                                ids.push(data[i].CarDateGoDetailID);

                                if (!$scope.selecteds)
                                    $scope.selecteds = [];
                                $scope.selecteds.push(data[i]);
                            }
                        }
                        $scope.notRunEvent = false;
                    }
                }

                $scope.model.ListID = ids.join(',');

                //$scope.ListTempID = $scope.model.ListID;
                if (!$rootScope.isMoving) {
                    $rootScope.itemMove = [];
                    for (var i = 0; i < $scope.selecteds.length; i++) {
                        if ($scope.selecteds[i].SeatStatusID == 2 || $scope.selecteds[i].SeatStatusID == 1) {
                            if (!checkExist($scope.selecteds[i].CarDateGoDetailID))
                                $rootScope.itemMove.push($scope.selecteds[i]);
                        }
                    }
                }
                else {
                    if ($rootScope.itemMove && $rootScope.itemMove.length > 0 && $scope.selecteds && $scope.selecteds.length > 0) {
                        if ($rootScope.itemMove[0].CarDateGoDetailID != $scope.selecteds[0].CarDateGoDetailID) {
                            if ($scope.selecteds[0].SeatStatusID == 1 || $scope.selecteds[0].SeatStatusID == 2) {
                                if (!$rootScope.isSeachByMobile)
                                    CommonFactory.logWarning('Không thể đổi với ghế đã đặt.');
                                return;
                            }

                            BookingFactory.MoveSeat($rootScope.itemMove[0].CarDateGoDetailID, $scope.selecteds[0].CarDateGoDetailID, function (response) {
                                if (response.Success) {
                                    $rootScope.itemMove.splice(0, 1);

                                    if ($rootScope.itemMove.length == 0) {
                                        $rootScope.isMoving = false;
                                        $rootScope.action = '';
                                        $rootScope.isSeachByMobile = true;
                                    }

                                    $scope.GetAllSeatOfTimeGo();
                                    CommonFactory.logSuccess('Đổi ghế thành công.');
                                }
                                else {
                                    CommonFactory.logError(response.Message);
                                }
                            });
                        }
                    }
                }

                //debugger;

                if ($rootScope.action == 1)//booking
                {
                    $rootScope.action = '';
                    $scope.booking();
                }
                else if ($rootScope.action == 2) {
                    if ($scope.model.IsPickUp) {
                        $scope.pickup = $scope.model.Address;
                    }
                    else if ($scope.model.IsTransit) {
                        $scope.transit = $scope.model.Address;
                    }
                    else {
                        $scope.pickup = $scope.model.Address;
                        $scope.transit = $scope.model.Address;
                    }

                    $scope.GetLogByDateGoDetailID();
                    $scope.GetLogCustomerByDateGoDetailID();
                    //  $scope.action = '';
                }
                else if ($rootScope.action == 3) {
                    $scope.lastID = '';
                    if ($rootScope.itemMove && $rootScope.itemMove.length > 0)
                        $scope.moving();
                    else $rootScope.action = '';
                }
                else if ($rootScope.action == 4) {
                    $rootScope.action = '';
                    $scope.UpdateStatusPayment();
                }
            }

            $scope.onSelectedCancel = function () {
                var select = $scope.controls.lvSeatCancel.select();
                var data = $scope.controls.lvSeatCancel.dataSource.view();

                $scope.modelCancel = $scope.controls.lvSeatCancel.dataSource.view()[select.index()];
            }

            var checkExist = function (id) {
                var exist = false;

                if ($rootScope.itemMove && $rootScope.itemMove.length > 0) {

                    for (var i = 0; i < $rootScope.itemMove.length; i++) {
                        if ($rootScope.itemMove[i].CarDateGoDetailID == id) {
                            exist = true;
                            break;
                        }
                    }
                }

                return exist;
            }

            $scope.moving = function (id) {
                //debugger;
                //if (!$rootScope.itemMove || $rootScope.itemMove.length == 0) {
                //    CommonFactory.logWarning('Chọn 1 ghế trước khi đổi ghế.');
                //    return;
                //}

                if (!$rootScope.isMoving && $rootScope.action == 3)
                    $rootScope.action = '';

                if (!$scope.model.CarDateGoDetailID) {
                    $rootScope.action = 3;
                    return;
                }

                if (id && !checkExist(id)) {
                    $rootScope.action = 3;
                    return;
                }

                $rootScope.isMoving = true;
                if ($rootScope.itemMove.length > 1) {
                    $rootScope.isSeachByMobile = true;
                    $scope.lastID = '';
                }
                else
                    $rootScope.isSeachByMobile = false;
            }

            $scope.GetLogByDateGoDetailID = function () {
                BookingFactory.GetLogByDateGoDetailID($scope.model.CarDateGoDetailID, function (response) {
                    //debugger;
                    $timeout(function () {
                        $scope.logs = response.Result;
                        $scope.$apply();
                    }, 10);
                });
            }

            $scope.GetLogCustomerByDateGoDetailID = function () {
                if ($scope.model.Mobile) {
                    BookingFactory.GetLogCustomerByDateGoDetailID($scope.model.Mobile, function (response) {
                        $timeout(function () {
                            $scope.logCustomers = response.Result;
                            $scope.$apply();
                        }, 10);
                    });
                }
            }

            $scope.openWndUpdate = function (id) {
                //debugger;
                if ($rootScope.isMoving) {
                    CommonFactory.logWarning('Bạn đang trong trạng thái di chuyển ghế. Không thể thực hiện chức năng khác.');
                    return;
                }

                //if (!$scope.model.CarDateGoDetailID) {
                //    CommonFactory.logWarning('Chọn 1 ghế trước khi cập nhật thông tin.');
                //    return;
                //}

                if ($scope.model.ListID && $scope.model.ListID.indexOf(id) < 0) {
                    $scope.model.ListID = null;
                }

                $scope.GetAllStation();
                $scope.pickup = '';
                $scope.transit = '';
                // $scope.onPaymentChange();

                $scope.ListTempID = $scope.model.ListID;
                $rootScope.action = 2;
                $scope.controls.wndUpdate.center().open();

            }

            $scope.openWndReSelect = function (id) {
                $scope.controls.wndReSelect.center().open();
            }

            $scope.onClosePopup = function () {
                $scope.GetAllSeatOfTimeGo();
                $rootScope.action = '';
                //$scope.model = '';
                $scope.model = {};
            }
            $scope.ClosePopup = function () {
                $scope.controls.wndUpdate.center().close();
                $scope.controls.wndPay.center().close();
                $scope.controls.wndDelete.center().close();
                $rootScope.action = '';
            }
            $scope.onClosePopupCancel = function () {
            }
            $scope.ClosePopupCancel = function () {
                $scope.controls.wndReSelect.center().close();
            }

            $scope.openWndPay = function () {

                if ($rootScope.isMoving) {
                    CommonFactory.logWarning('Bạn đang trong trạng thái di chuyển ghế. Không thể thực hiện chức năng khác.');
                    return;
                }

                //if (!$scope.model.CarDateGoDetailID) {
                //    CommonFactory.logWarning('Chọn 1 ghế trước khi tiến hành thanh toán.');
                //    return;
                //}



                $scope.GetAllStation();
                $scope.ListTempID = $scope.model.ListID;
                $scope.controls.wndPay.center().open();
            }

            $scope.openWndDelete = function () {

                $scope.controls.wndDelete.center().open();
            }

            $scope.updateTicket = function () {
                if (!$scope.route) {
                    CommonFactory.logWarning('Chưa chọn tuyến đi.');
                    return;
                }

                if ($scope.pickup) {
                    $scope.model.Address = $scope.pickup;
                    $scope.model.IsPickUp = true;
                    $scope.model.IsTransit = false;
                }
                else if ($scope.transit) {
                    $scope.model.Address = $scope.transit;
                    $scope.model.IsPickUp = false;
                    $scope.model.IsTransit = true;
                }

                $scope.model.PaymentStatusID = $scope.controls.ddlPayment.dataItem().PaymentID;

                $scope.model.ListID = $scope.ListTempID ? $scope.ListTempID : $scope.model.ListID;

                $scope.lastID = $scope.model.ListID;

                //tanhk
                $scope.update();

                //var count = 0;
                //var countFail = 0;
                //var isPass = false;
                //var tempPhone;

                //debugger;
                //for (var i = 0; i < $scope.selecteds.length; i++) {
                //    if ($scope.selecteds[i].SeatStatusID == 2) {
                //        count++;
                //        if (!tempPhone || ($scope.selecteds[i].Mobile == tempPhone)) {
                //            if (countFail == 0) { isPass = true; }
                //            tempPhone = $scope.selecteds[i].Mobile;
                //        }
                //        else {
                //            isPass = false;
                //            countFail = 1;
                //        }
                //    }
                //}
                //CommonFactory.logWarning('count: ' + count + '. isPass: ' + isPass);

                //if (count > 1 && !isPass) {
                //    CommonFactory.logWarning('Chỉ được chọn 1 ghế có thông tin.');
                //    return;
                //}
                //else //có 1 ghế có thông tin, hoac cac ghe co cung sdt
                //{
                //    $scope.update();
                //}
                //tanhk
            }

            $scope.update = function () {
                BookingFactory.Update($scope.model, function (response) {
                    debugger;
                    if (response.Success) {
                        $scope.model = {};
                        $scope.GetAllSeatOfTimeGo();
                        $scope.controls.wndUpdate.center().close();
                        CommonFactory.logSuccess('cập nhật thành công.');
                    }
                    else {
                        CommonFactory.logError(response.Message);
                    }
                });
            }

            $scope.UpdateStatusPayment = function (id) {
                if ($rootScope.isMoving) {
                    CommonFactory.logWarning('Bạn đang trong trạng thái di chuyển ghế. Không thể thực hiện chức năng khác.');
                    return;
                }


                if (!$scope.model.CarDateGoDetailID) {
                    $scope.model = {};
                    //CommonFactory.logWarning('Chọn 1 ghế trước khi tiến hành đặt vé.');
                    $rootScope.action = 4;//booking
                    return;
                }

                if (($scope.model.ListID.indexOf(id) < 0 && id)) {
                    $rootScope.action = 4; // booking
                    return;
                }

                debugger;
                //$scope.lastID = $scope.model.ListID;
                //tanhk
                if ($scope.model.PaymentStatusID == 1)
                    {
                        var result = confirm("Ghế này đã in. Bạn muốn in lại ghế này ?");
                        if (!result) {
                            return;
                        }
                    }
                //tanhk

                $scope.model.PaymentStatusID = $scope.controls.ddlPayment.dataItem() ? $scope.controls.ddlPayment.dataItem().PaymentID : 0;
                BookingFactory.UpdateStatusPayment(/*$scope.ListTempID $scope.model.ListID*/$scope.model.ListID, 1, $scope.model.RouteID, function (response) {
                    if (response.Success) {
                        $scope.model = {};
                        $scope.GetAllSeatOfTimeGo();
                        CommonFactory.logSuccess('Thanh toán thành công.');
                        var lstSeat = JSON.parse(response.Data);
                        for (var i = 0; i < lstSeat.length; i++) {
                            var objTicket = {};
                            objTicket.StationFromName = lstSeat[i].StationFromName;
                            objTicket.StationToName = lstSeat[i].StationToName;
                            objTicket.GoDate = lstSeat[i].GoDated;
                            objTicket.GoTime = lstSeat[i].GoTime;
                            objTicket.Description = lstSeat[i].Description;
                            objTicket.FullName = $rootScope.currentUser.FullName;
                            objTicket.Driver = lstSeat[i].Driver;
                            objTicket.CarNumber = lstSeat[i].CarNumber;
                            BookingFactory.SendRequestToPrintSvc(objTicket, function (respone) {
                            });
                        }
                    }
                    else {
                        CommonFactory.logError(response.Message);
                    }
                });
            }

            $scope.DeleteTicket = function () {


                if ($scope.controls.ddlReasonDelete.dataItem() == null || $scope.controls.ddlReasonDelete.dataItem().ReasonDeleteName == null) {
                    CommonFactory.logError("Chưa chọn lí do hủy");
                    return;
                }
                var strNoteChange = "Lí do hủy: " + $scope.controls.ddlReasonDelete.dataItem().ReasonDeleteName;
                if ($scope.model.UserNoteDelete != "")
                    strNoteChange += " - Ghi chú nhân viên: " + $scope.model.UserNoteDelete != 'undefined' ? $scope.model.UserNoteDelete : '';
                if ($scope.model.CustomerNoteDelete != "")
                    strNoteChange += " - Ghi chú khách hàng: " + $scope.model.CustomerNoteDelete != 'undefined' ? $scope.model.CustomerNoteDelete : '';
                BookingFactory.DeleteTicket(/*$scope.ListTempID $scope.model.ListID*/$scope.ListTempID ? $scope.ListTempID : $scope.model.ListID, strNoteChange, function (response) {

                    if (response.Success) {
                        $scope.model = {};
                        CommonFactory.logSuccess('Hủy vé thành công.');
                        $scope.GetAllSeatOfTimeGo();
                        $scope.GetAllSeatCancelOfTimeGo();
                        $rootScope.GetTimeGoOfDateGo();
                        $scope.controls.wndUpdate.center().close();
                        $scope.controls.wndDelete.center().close();
                    }
                    else {
                        CommonFactory.logError(response.Message);
                    }
                });
            }

            $scope.DeleteTicket2 = function () {
                var result = confirm("Bạn muốn hủy ghế này ?");
                if (result) {
                            BookingFactory.DeleteTicket($scope.ListTempID ? $scope.ListTempID : $scope.model.ListID, 'Hủy vé', function (response) {
                                if (response.Success) {
                                    $scope.model = {};
                                    CommonFactory.logSuccess('Hủy vé thành công.');
                                    $scope.GetAllSeatOfTimeGo();
                                    $scope.GetAllSeatCancelOfTimeGo();
                                    $rootScope.GetTimeGoOfDateGo();
                                    $scope.controls.wndUpdate.center().close();
                                }
                                else {
                                    CommonFactory.logError(response.Message);
                                }
                            });
                }

            }

            $scope.PrintTicket = function () {
                var WinPrint = window.open("/Ticket/PrintTicket?CarDateGoDetailID=" + $scope.model.ListID, "MsgWindow", "width=800,height=600,rigth=100");
                WinPrint.focus();
                WinPrint.onload = function () {
                    WinPrint.print();
                    //WinPrint.onfocus = function () { WinPrint.close(); }
                }
            }

            $scope.PrintTicketList = function () {
                var WinPrint = window.open("/Ticket/PrintTicketList?intDateGoID=" + $scope.intDateGoID + "&&stationFromID=" + $scope.stationFromID + "&&intRouteID=" + $rootScope.RouteID, "MsgWindow", "width=800,height=600,rigth=100");
                WinPrint.focus();
                WinPrint.onload = function () {
                    WinPrint.print();
                    //WinPrint.onfocus = function () { WinPrint.close(); }
                }
            }

            $scope.PrintSeatDiagram = function () {
                var WinPrint = window.open("/Ticket/PrintSeatDiagram?intDateGoID=" + $scope.intDateGoID + "&&stationFromID=" + $scope.stationFromID + "&&intRouteID=" + $rootScope.RouteID, "MsgWindow", "width=800,height=600,rigth=100");
                WinPrint.focus();
                WinPrint.onload = function () {
                    WinPrint.print();
                    //WinPrint.onfocus = function () { WinPrint.close(); }
                }
            }




            $scope.getTotal = function () {
                var total = 0;
                if ($scope.lstseats && $scope.lstseats.length > 0) {
                    for (var i = 0; i < $scope.lstseats.length ; i++) {
                        if ($scope.lstseats[i].SeatStatusID > 0)
                            total = total + $scope.lstseats[i].Price;
                    }
                }

                return total;
            }
        }])

})();

(function () {
    app.controller('ActionTicketController', ['$scope', '$location', '$rootScope', '$route', 'BookingFactory', 'CommonFactory', 'ManagementCarFactory', '$timeout',
    function ($scope, $location, $rootScope, $route, BookingFactory, CommonFactory, ManagementCarFactory, $timeout ) {
            $scope.RefreshPage = function () {
                $route.reload();
            }
            
            //$scope.RouteID = $rootScope.currentUser.StationID == 1 ? 2 : 1;
            $scope.RouteID = $rootScope.currentUser.RouteID;
            $scope.CarModel = {};

            $scope.BookTicketViewGrid = function () {
                $location.url('ticketlist/' + $scope.intDateGoID + '/' + $scope.stationFromID);
            }

            $scope.BookTicketViewList = function () {
                debugger;
                $location.url('booking/' + $scope.intDateGoID + '/' + $scope.stationFromID);
            }

            $scope.PayBackRedirect = function () {
                $location.url('payback/' + $scope.intDateGoID + '/' + $scope.stationFromID);
            }

            $scope.TransitRedirect = function () {
                $location.url('transit/' + $scope.intDateGoID + '/' + $scope.stationFromID);
            }

            $scope.HomeRedirect = function () {
                $location.url('/');
            }

            $scope.CarIsGo = function () {
                var result = confirm("Bạn muốn xuất bến xe " + $rootScope.GoTime + "?");
                if (result) {
                    BookingFactory.CarIsGo($scope.intDateGoID, function (respo) {
                        if (respo && respo.Success == 1) {
                            $rootScope.GetTimeGoOfDateGo();
                            CommonFactory.logSuccess('Xuất bến thành công');
                        }
                        else CommonFactory.logError('Xuất bến không thành công. ' + respo.Message);
                    });
                }
            }
            
        // Thêm mới chuyến xe
            $scope.openWndCarDateGo = function () {
                $scope.model = {};
                $scope.controls.wndCarDateGo.center().open();
            }

            $scope.InsertCarDateGo = function () {
                debugger;
                //CommonFactory.logError('Chưa chọn giờ');

                if (!$scope.car.GoTime) {
                    CommonFactory.logError('Chưa chọn giờ');
                    return;
                }

                var model = {
                    TypeID: 2,
                    RouteID: $scope.RouteID,
                    GoDate: $scope.endDate,
                    GoTime: $scope.car.GoTime,
                    Driver: $scope.car.Driver,
                    CarNumber: $scope.car.CarNumber,
                    NumberOfSeat: $scope.car.NumberOfSeat,
                    Note: 'Chuyến tăng cường'
                };

                ManagementCarFactory.InsertCarDateGo(model, function (response) {
                    if (response.Success) {
                        $scope.GetTimeGoOfDateGo();
                        $scope.controls.wndCarDateGo.center().close();
                        CommonFactory.logSuccess('Thêm chuyến tăng cường thành công.');
                    }
                    else
                        CommonFactory.logError('Thêm thất bại: ' + response.Message);
                });
            }

            $scope.Init = function () {
                //$scope.GetRouteAll();
                //$scope.GetTimeAll();

                if ($rootScope.first ) {
                    $scope.GetTimeAll();
                }

                if (!$rootScope.first && $rootScope.GetTimeAll_count == 0)
                {
                    $scope.GetTimeAll();
                    $rootScope.GetTimeAll_count = 1;
                }
                $scope.SelectLoaiXe();

            }

            $scope.GetTimeAll = function () {
                ManagementCarFactory.GetTimeAll(function (response) {
                    //$scope.timeAll = JSON.parse(response.Result);

                    $rootScope.timeAll = JSON.parse(response.Result);
                });
            }

            $scope.GetRouteAll = function () {
                LeftSectionFactory.GetRouteAll(function (response) {
                    $scope.routes = response;
                    $scope.controls.cbRoute.dataSource.data($scope.routes);
                    $scope.GetTimeGoOfDateGo();
                });
        }

        $scope.SelectLoaiXe = function () {
            ManagementCarFactory.SelectLoaiXe(function (response) {
                if (response) {
                    $scope.LoaiXe = JSON.parse(response);
                    $scope.$apply();
                } else {
                    CommonFactory.logError('Lấy thông tin loại xe không thành công: ' + resp.Message);
                }
            });

        }

        // Cập nhật số xe - tài xế
            $scope.openWndCarDateGoUpdate = function () {
                debugger;
                $scope.model = {};
                $scope.car = {};

                //$scope.car.DriverUpdate = "999";
                //$scope.car.CarNumberUpdate = $rootScope.CarModel.CarNumber;
                BookingFactory.GetCarByID($rootScope.CarDateGoID, function (response) {
                    if (response.Success) {
                        $timeout(function () {
                            debugger;
                            $scope.CarModel = JSON.parse(response.Result)[0];
                            $scope.car.DriverUpdate = $scope.CarModel.Driver;
                            $scope.car.CarNumberUpdate = $scope.CarModel.CarNumber;
                            ////tanhk
                            $scope.car.IsTransship = $scope.CarModel.IsTransship;
                            $scope.car.IsNewBus = $scope.CarModel.IsNewBus;
                            ////tanhk
                        }, 10)
                    }
                });

                $scope.CarModel = {};
                $scope.controls.wndCarDateGoUpdate.center().open();
                
            }

            $scope.UpdateCarDateGo = function () {
                debugger;
                if (!$scope.car) {
                    alert("Không xác định được xe")
                    return;
                }
                debugger;
                ManagementCarFactory.UpdateCarDateGo($rootScope.CarDateGoID, 'NoChange', $scope.car.DriverUpdate, $scope.car.CarNumberUpdate, $scope.car.IsTransship, $scope.car.IsNewBus, function (resp) {
                    if (resp && resp.Result == 1) {
                        $route.reload();
                        $scope.controls.wndCarDateGoUpdate.center().close();
                        CommonFactory.logSuccess('Cập nhật thành công.');
                    } else {
                        CommonFactory.logError('Cập nhật thất bại');
                    }
                });
            }

        }])

})();

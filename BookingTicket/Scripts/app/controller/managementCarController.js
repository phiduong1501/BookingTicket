(function () {
    app.controller('ManagementCarController', ['$http', '$scope', 'ManagementCarFactory', 'CommonFactory', '$timeout', '$location', '$rootScope', 'LeftSectionFactory',
        function ($http, $scope, ManagementCarFactory, CommonFactory, $timeout, $location, $rootScope, LeftSectionFactory) {
            $scope.controls = {

            };
            //$scope.RouteID = $rootScope.currentUser.StationID == 1 ? 2 : 1;
            $scope.RouteID = $rootScope.currentUser.RouteID;
            $scope.NumberOfSeat = '28';
            $scope.endDate = new Date();

            $scope.Init = function () {
                $scope.GetRouteAll();
                $scope.GetTimeAll();
                $scope.SelectLoaiXe();
                //$scope.GetTimeGoOfDateGo();
            }

            $scope.GetTimeAll = function () {
                ManagementCarFactory.GetTimeAll(function (response) {
                    $scope.timeAll = JSON.parse(response.Result);
                });
            }

            $scope.GetRouteAll = function () {
                LeftSectionFactory.GetRouteAll(function (response) {
                    $scope.routes = response;
                    $scope.controls.cbRoute.dataSource.data($scope.routes);
                    $scope.GetTimeGoOfDateGo();
                });
            }

            $scope.onChangeRoute = function () {
                $scope.GetTimeGoOfDateGo();
            }


            $scope.UpdateCarDateGo = function () {
                if (!$scope.car) {
                    alert("Không xác định được xe")
                    return;
                }

                var model = {
                    TypeID: $scope.car.TypeID,
                    RouteID: $scope.RouteID,
                    GoDate: $scope.endDate,
                    GoTime: $scope.car.GoTime,
                    Driver: $scope.car.Driver,
                    CarNumber: $scope.car.CarNumber,
                    Note: ''
                };

                ManagementCarFactory.UpdateCarDateGo($scope.car.CarDateGoID, $scope.car.GoTime, $scope.car.Driver, $scope.car.CarNumber, function (resp) {
                    if (resp && resp.Result == 1) {
                        CommonFactory.logSuccess('Cập nhật thành công.');
                        $scope.Init();
                    } else {
                        CommonFactory.logError('Cập nhật thất bại');
                    }
                });
            }

            $scope.onChangeDate = function () {
                $scope.GetTimeGoOfDateGo();
            }

            $scope.GetTimeGoOfDateGo = function () {
                var route = $scope.controls.cbRoute.dataItem();
                if (route != undefined)
                    $scope.RouteID = route.RouteID;
                else
                    //$scope.RouteID = $rootScope.currentUser.StationID == 1 ? 2 : 1;
                    $scope.RouteID = $rootScope.currentUser.RouteID;

                if (!$scope.endDate)
                    return;

                LeftSectionFactory.GetTimeGoOfDateGo($scope.endDate, $scope.RouteID, function (response) {
                    $scope.times = response;
                    $scope.$apply();
                });
            }


            $scope.IsChangeOrInsert = function () {
                if ($scope.isUpdate == true) {
                    $scope.UpdateCarDateGo();
                } else {
                    $scope.InsertCarDateGo();
                }
            }

            $scope.DeleteCar = function () {

                // Không cho xóa chuyên cố định
                if ($scope.car.TypeID == 1) {
                    alert("Bạn không được xóa chuyến cố định. Chỉ được xóa chuyến tăng cường");
                    return;
                }


                var a = confirm("Bạn có muốn xóa chuyến này?");
                if (a) {
                    ManagementCarFactory.DeleteCar($scope.car.CarDateGoID, function (resp) {
                        if (resp && resp.Result == 1) {
                            CommonFactory.logSuccess('Xóa xe thành công.');
                            $scope.isUpdate = false;
                            $scope.car.GoTime = '';
                            $scope.car.Driver = '';
                            $scope.car.CarNumber = '';
                            $scope.GetTimeGoOfDateGo();
                        } else {
                            CommonFactory.logError('Xóa xe không thành công: ' + resp.Message);
                        }
                    });
                }
            }

            $scope.CancelUpdate = function () {
                $scope.isUpdate = false;
                $scope.car.GoTime = '';
                $scope.car.Driver = '';
                $scope.car.CarNumber = '';
                $scope.$apply();
            }

            $scope.InsertCarDateGo = function () {
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
                    Note: 'Chuyến tăng cường.'
                };

                ManagementCarFactory.InsertCarDateGo(model, function (response) {
                    if (response.Success) {
                        $scope.GetTimeGoOfDateGo();
                        CommonFactory.logSuccess('Thêm chuyến tăng cường thành công.');
                    }
                    else
                        CommonFactory.logError('Thêm thất bại: ' + response.Message);
                });
            }

            $scope.CarDateGoIDTemp;
            $scope.LoadCarDateGoInfo = function (item) {
                $scope.CarDateGoIDTemp = item.CarDateGoID;
                $scope.isUpdate = true;
                $scope.car = angular.copy(item);
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

        }])

})();

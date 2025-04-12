(function () {
    app.controller('ManagementVehicleTypeController', ['$http', '$scope', 'ManagementRouteFactory', 'CommonFactory', '$timeout', '$location', '$rootScope', 'BookingFactory',
        function ($http, $scope, ManagementRouteFactory, CommonFactory, $timeout, $location, $rootScope, BookingFactory) {
            $scope.controls = {

            };
            $scope.Init = function () {
                $scope.GetAll();
            }
            $scope.GetAll = function () {
                $scope.lstVehicleType = [];
                ManagementRouteFactory.CallServer("VehicleType_GetAll", $scope.model, function (response) {
                    if (response) {
                        $scope.lstVehicleType = JSON.parse(response.Result);
                    } else {
                        CommonFactory.logError('Lỗi lấy dữ liệu khai báo xe' + response.Message);
                    }
                });
            }

            $scope.Submit = function () {
                if (!$scope.model.VehicleTypeName || $scope.model.VehicleTypeName == '' || $scope.model.VehicleTypeName == undefined) {
                    CommonFactory.logWarning('Chưa nhập tên loại xe');
                    return;
                }
                if (
                    $scope.model.NumberOfSeat === undefined ||
                    $scope.model.NumberOfSeat === null ||
                    $scope.model.NumberOfSeat === '' ||
                    isNaN($scope.model.NumberOfSeat) ||
                    !Number.isInteger(Number($scope.model.NumberOfSeat))
                ) {
                    CommonFactory.logWarning('Số chỗ ngồi phải là số nguyên hợp lệ');
                    return;
                }

                if (!$scope.model.Note || $scope.model.Note == '' || $scope.model.Note == undefined) {
                    $scope.model.Note = '';
                }
                if (!$scope.model.VehicleTypeID)
                    $scope.VehicleType_Insert();
                else
                    $scope.VehicleType_Update();
            }

            $scope.VehicleType_Insert = function () {
                var model = $scope.model;
                ManagementRouteFactory.CallServer("VehicleType_Insert", model, function (response) {
                    if (response) {
                        CommonFactory.logSuccess('Thêm mới thành công.');
                        $scope.GetAll();
                        $scope.controls.wndAccount.center().close();
                    } else {
                        CommonFactory.logError('Thêm mới thất bại: ' + response.Message);
                    }
                });
            }
            $scope.VehicleType_Update = function () {
                var model = $scope.model;
                ManagementRouteFactory.CallServer("VehicleType_Update", model, function (response) {
                    if (response) {
                        CommonFactory.logSuccess('Cập nhật thành công.');
                        $scope.GetAll();
                        $scope.controls.wndAccount.center().close();
                    } else {
                        CommonFactory.logError('Cập nhật thất bại: ' + response.Message);
                    }
                });
            }
            $scope.VehicleType_Delete = function (model) {

                var a = confirm("Bạn có muốn xóa tuyến này?");
                if (a) {
                    ManagementRouteFactory.CallServer("VehicleType_Delete", model, function (response) {
                        if (response) {
                            CommonFactory.logSuccess('Xóa thành công.');
                            $scope.GetAll();
                            $scope.controls.wndAccount.center().close();
                        } else {
                            CommonFactory.logError('Xóa thất bại: ' + response.Message);
                        }
                    });
                }
            }
            $scope.openWndAccount = function (model) {
                if (model) {
                    $scope.model = model;
                }
                else {
                    $scope.model = {};
                }
                $scope.controls.wndAccount.center().open();
            }
        }])

})();

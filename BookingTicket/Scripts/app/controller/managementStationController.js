(function () {
    app.controller('managementStationController', ['$http', '$scope', 'ManagementStationFactory', 'CommonFactory', '$timeout', '$location', '$rootScope', 'LeftSectionFactory',
        function ($http, $scope, ManagementStationFactory, CommonFactory, $timeout, $location, $rootScope, LeftSectionFactory) {
            $scope.controls = {

            };
            

            $scope.Init = function () {
                $scope.GetAll();
                //$scope.GetTimeGoOfDateGo();
            }

            $scope.GetAll = function () {
                $scope.lstStation = [];
                var intSortDesc = 0;
                if ($scope.stationFromID != "1")
                    intSortDesc = 1;
                ManagementStationFactory.GetAll(intSortDesc, function (response) {
                    $scope.lstStation = response.Result;
                    $scope.$apply();
                });
            }



            $scope.Submit = function () {
                if (!$scope.model.StationName || $scope.model.StationName == '' || $scope.model.StationName == undefined) {
                    CommonFactory.logWarning('Chưa nhập tên văn phòng/trạm');
                    return;
                }
                if (!$scope.model.OrderIndex || $scope.model.OrderIndex == '' || $scope.model.OrderIndex == undefined) {
                    CommonFactory.logWarning('Chưa nhập vị trí');
                    return;
                }
                if (!$scope.model.StationID)
                    $scope.InsertStation();
                else
                    $scope.UpdateStation();
            }

            $scope.InsertStation = function () {
                var model = $scope.model;

                ManagementStationFactory.InsertStation(model, function (response) {
                    if (response.Success) {
                        $scope.GetAll();
                        $scope.controls.wndAccount.center().close();
                        CommonFactory.logSuccess('Thêm văn phòng/trạm thành công.');
                    }
                    else {
                        CommonFactory.logError('Thêm văn phòng/trạm thất bại: ' + response.Message);
                    }
                });
            }

            $scope.UpdateStation = function () {
                debugger
                var model = $scope.model;

                ManagementStationFactory.UpdateStation(model, function (response) {
                    if (response.Success) {
                        $scope.GetAll();
                        $scope.controls.wndAccount.center().close();
                        CommonFactory.logSuccess('Cập nhật văn phòng/trạm thành công.');
                    }
                    else {
                        CommonFactory.logError('Cập nhật văn phòng/trạm thất bại: ' + response.Message);
                    }
                });
            }

            $scope.DeleteStation = function (model) {

                var a = confirm("Bạn có muốn xóa văn phòng/trạm này?");
                if (a) {
                    ManagementStationFactory.DeleteStation(model, function (resp) {
                        if (resp && resp.Success) {
                            CommonFactory.logSuccess('Xóa văn phòng/trạm thành công.');
                            $scope.isUpdate = false;
                            $scope.GetAll();
                        } else {
                            CommonFactory.logError('Xóa văn phòng/trạm không thành công: ' + resp.Message);
                        }
                    });
                }
            }

            $scope.openWndAccount = function (model) {
                if (model) {
                    $scope.model = model;
                }
                else
                    $scope.model = {};

                $scope.controls.wndAccount.center().open();
            }

        }])

})();

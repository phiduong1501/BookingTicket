(function () {
    app.controller('managementTimeController', ['$http', '$scope', 'ManagementTimeFactory', 'CommonFactory', '$timeout', '$location', '$rootScope', 'LeftSectionFactory',
        function ($http, $scope, ManagementTimeFactory, CommonFactory, $timeout, $location, $rootScope, LeftSectionFactory) {
            $scope.controls = {

            };
            

            $scope.Init = function () {
                $scope.GetAll();
                //$scope.GetTimeGoOfDateGo();
            }

            $scope.GetAll = function () {
                $scope.lstTime = [];
                ManagementTimeFactory.GetAll(function (response) {
                    $scope.lstTime = JSON.parse(response.Result);;
                    $scope.$apply();
                });
            }



            $scope.Submit = function () {
                if (!$scope.model.TimeGo || $scope.model.TimeGo == '' || $scope.model.TimeGo == undefined) {
                    CommonFactory.logWarning('Chưa nhập giờ chạy');
                    return;
                }
                if (!$scope.model.TimeGoID)
                    $scope.InsertTime();
                else
                    $scope.UpdateTime();
            }

            $scope.InsertTime = function () {
                var model = $scope.model;

                ManagementTimeFactory.InsertTime(model, function (response) {
                    if (response.Success) {
                        $scope.GetAll();
                        $scope.controls.wndAccount.center().close();
                        CommonFactory.logSuccess('Thêm giờ chạy thành công.');
                    }
                    else {
                        CommonFactory.logError('Thêm giờ chạy thất bại: ' + response.Message);
                    }
                });
            }

            $scope.UpdateTime = function () {
                debugger
                var model = $scope.model;

                ManagementTimeFactory.UpdateTime(model, function (response) {
                    if (response.Success) {
                        $scope.GetAll();
                        $scope.controls.wndAccount.center().close();
                        CommonFactory.logSuccess('Cập nhật giờ chạy thành công.');
                    }
                    else {
                        CommonFactory.logError('Cập nhật giờ chạy thất bại: ' + response.Message);
                    }
                });
            }

            $scope.DeleteTime = function (model) {

                var a = confirm("Bạn có muốn xóa giờ chạy này?");
                if (a) {
                    ManagementTimeFactory.DeleteTime(model, function (resp) {
                        if (resp && resp.Success) {
                            CommonFactory.logSuccess('Xóa giờ chạy thành công.');
                            $scope.isUpdate = false;
                            $scope.GetAll();
                        } else {
                            CommonFactory.logError('Xóa văn giờ chạy không thành công: ' + resp.Message);
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

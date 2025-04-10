(function () {
    app.controller('managementRouteController', ['$http', '$scope', 'ManagementRouteFactory', 'CommonFactory', '$timeout', '$location', '$rootScope', 'BookingFactory',
        function ($http, $scope, ManagementRouteFactory, CommonFactory, $timeout, $location, $rootScope, BookingFactory) {
            $scope.controls = {

            };
            
            var routeNameFrom = '';
            var routeNameTo = '';
            $scope.Init = function () {
                $scope.GetAll();
                $scope.GetAllStation();
            }

            $scope.GetAll = function () {
                $scope.lstRoute = [];
                ManagementRouteFactory.GetAll(function (response) {
                    $scope.lstRoute = response;
                    $scope.$apply();
                });
            }

            $scope.GetAllStation = function () {
                BookingFactory.GetAllStation(1, function (response) {
                    $scope.stations = response.Result;
                });
            }

            $scope.$watch('model.StationFromID', function () {
                if ($scope.model.StationFromID) {
                    
                    for (var i = 0; i < $scope.stations.length; i++) {
                        if ($scope.model.StationFromID == $scope.stations[i].StationID) {
                            routeNameFrom = $scope.stations[i].StationName;
                        }
                    }
                    $scope.model.RouteName = routeNameFrom + " - " + routeNameTo;
                }
            });

            $scope.$watch('model.StationToID', function () {
                if ($scope.model.StationToID) {
                    for (var i = 0; i < $scope.stations.length; i++) {
                        if ($scope.model.StationToID == $scope.stations[i].StationID) {
                            routeNameTo = $scope.stations[i].StationName;
                        }
                    }
                    $scope.model.RouteName = routeNameFrom + " - " + routeNameTo;
                }
            });

            $scope.Submit = function () {
                if (!$scope.model.StationFromID || $scope.model.StationFromID == '' || $scope.model.StationFromID == undefined) {
                    CommonFactory.logWarning('Chưa chọn điểm đi');
                    return;
                }
                if (!$scope.model.StationToID || $scope.model.StationToID == '' || $scope.model.StationToID == undefined) {
                    CommonFactory.logWarning('Chưa chọn điểm đến');
                    return;
                }
                if (!$scope.model.Price || $scope.model.Price == '' || $scope.model.Price == undefined) {
                    CommonFactory.logWarning('Chưa nhập giá');
                    return;
                }
                if (!$scope.model.RouteID)
                    $scope.InsertRoute();
                else
                    $scope.UpdateRoute();
            }

            $scope.InsertRoute = function () {
                var model = $scope.model;

                ManagementRouteFactory.InsertRoute(model, function (response) {
                    if (response.Success) {
                        $scope.GetAll();
                        $scope.controls.wndAccount.center().close();
                        CommonFactory.logSuccess('Thêm tuyến thành công.');
                    }
                    else {
                        CommonFactory.logError('Thêm tuyến thất bại: ' + response.Message);
                    }
                });
            }

            $scope.UpdateRoute = function () {

                var model = $scope.model;

                ManagementRouteFactory.UpdateRoute(model, function (response) {
                    if (response.Success) {
                        $scope.GetAll();
                        $scope.controls.wndAccount.center().close();
                        CommonFactory.logSuccess('Cập nhật tuyến thành công.');
                    }
                    else {
                        CommonFactory.logError('Cập nhật tuyến thất bại: ' + response.Message);
                    }
                });
            }

            $scope.DeleteRoute = function (model) {

                var a = confirm("Bạn có muốn xóa tuyến này?");
                if (a) {
                    ManagementRouteFactory.DeleteRoute(model, function (resp) {
                        if (resp && resp.Success) {
                            CommonFactory.logSuccess('Xóa tuyến thành công.');
                            $scope.isUpdate = false;
                            $scope.GetAll();
                        } else {
                            CommonFactory.logError('Xóa tuyến không thành công: ' + resp.Message);
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

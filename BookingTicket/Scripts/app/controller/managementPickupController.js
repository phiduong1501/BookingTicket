(function () {
    app.controller('ManagementPickupController', ['$scope', 'CommonFactory', '$timeout', '$rootScope', 'LeftSectionFactory', 'BookingFactory', 'ManagementPickupFactory',
        function ($scope, CommonFactory, $timeout, $rootScope, LeftSectionFactory, BookingFactory, ManagementPickupFactory) {
            $scope.controls = {

            };

            $scope.Init = function () {
                $scope.GetRouteAll();
                $scope.GetAllPickupAddress();
                $scope.model = {};
                $scope.model.RouteID = $rootScope.RouteID;
            }

            $scope.GetRouteAll = function () {
                LeftSectionFactory.GetRouteAll(function (response) {
                    $scope.routes = response;
                    $scope.controls.cbRoute.dataSource.data($scope.routes);
                });
            }

            $scope.GetAllPickupAddress = function () {
                BookingFactory.GetAllPickupAddress(1, $rootScope.RouteID, function (response) {
                    $scope.pickups = response.Result;
                    $scope.$apply();
                });

                BookingFactory.GetAllPickupAddress(2, $rootScope.RouteID, function (response) {
                    $scope.transits = response.Result;
                    $scope.$apply();
                });
            }

            $scope.ClearPickup = function () {
                $scope.model = {};
                $scope.model.RouteID = $rootScope.RouteID;
            }

            $scope.InsertPickup = function () {
                var model = $scope.model;
                if (!model.RouteID)
                    model.RouteID = $rootScope.RouteID;
                if (!model.AddressID) {
                    ManagementPickupFactory.InsertPickup(model, function (response) {
                        if (response.Success) {
                            $scope.GetAllPickupAddress();
                            $scope.model = {};
                            $scope.model.RouteID = $rootScope.RouteID;
                            CommonFactory.logSuccess('Thêm thành công.');
                        }
                        else {
                            CommonFactory.logError('Thêm thất bại: ' + response.Message);
                        }
                    });
                }
                else {
                    ManagementPickupFactory.UpdatePickup(model, function (response) {
                        if (response.Success) {
                            $scope.GetAllPickupAddress();
                            $scope.model = {};
                            $scope.model.RouteID = $rootScope.RouteID;
                            CommonFactory.logSuccess('Cập nhật thành công.');
                        }
                        else {
                            CommonFactory.logError('Cập nhật thất bại: ' + response.Message);
                        }
                    });
                }
            }

            $scope.EditPickup = function (item) {
                $scope.model = item;
            }

            $scope.DeletePickup = function (item) {
                if (confirm('Bạn muốn xóa điểm này?')) {
                    
                    ManagementPickupFactory.DeletePickup(item, function (response) {
                        if (response.Success) {
                            $scope.GetAllPickupAddress();
                            $scope.model = {};
                            $scope.model.RouteID = $rootScope.RouteID;
                            CommonFactory.logSuccess('Xóa thành công.');
                        }
                        else {
                            CommonFactory.logError('Xóa thất bại: ' + response.Message);
                        }
                    });
                }
            }

            $scope.onChangeRoute = function () {

            }

        }])

})();

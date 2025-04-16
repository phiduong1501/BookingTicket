(function () {
    app.controller('LeftSectionController', ['$scope', '$filter', 'LeftSectionFactory', 'CommonFactory', '$location', '$rootScope',
        function ($scope, $filter, LeftSectionFactory, CommonFactory, $location, $rootScope) {
            $scope.controls = {
            };
            

            $scope.Init = function () {
                if ($rootScope.first ) {
                    if ($rootScope.currentUser.RouteID < 0) {
                        CommonFactory.logWarning('Cần khai báo tuyến để có thể đặt vé');
                    }
                    $rootScope.RouteID = $rootScope.currentUser.RouteID;
                    $rootScope.endDate = new Date();
                    $rootScope.StationFromID = $rootScope.currentUser.StationID;
                    if ($rootScope.currentUser.StationID < 0) {
                        CommonFactory.logWarning('Cần khai báo văn phòng để có thể đặt vé');
                    }
                    $rootScope.isSeatsActive = true;

                    $rootScope.GetRouteAll_count = 0;
                    $rootScope.GetAllPickupAddress_count = 0;
                    $rootScope.GetTimeAll_count = 0;

                    //$scope.GetRouteAll();

                }

                //if (!$rootScope.first && $rootScope.GetRouteAll_count == 0)
                //{
                //    $scope.GetRouteAll();
                //    $rootScope.GetRouteAll_count = 1;
                //}

                $scope.GetRouteAll();
                //tanhk
                //
                //$scope.controls.cbRoute.dataSource.data($rootScope.routes);
                $rootScope.GetTimeGoOfDateGo();
                
            }

            $scope.GetRouteAll = function () {
                LeftSectionFactory.GetRouteAll(function (response) {                    
                    $rootScope.routes = response;
                    $scope.routes = $rootScope.routes;
                    $scope.controls.cbRoute.dataSource.data($rootScope.routes);
                });
            }

            $scope.onChangeRoute = function () {
                var route = $scope.controls.cbRoute.dataItem();
                $rootScope.RouteID = route.RouteID;
                // Khong thay doi theo route. chi dua vao station cua user dang nhap
                $rootScope.StationFromID = route.StationFromID;
                //$rootScope.GetTimeGoOfDateGo();
                $location.url('booking/' + $rootScope.CarDateGoID + '/' + $rootScope.StationFromID);

            }

            $rootScope.GetTimeGoOfDateGo = function () {
                if (!$rootScope.RouteID)
                    return;

                if (!$rootScope.endDate)
                    return;

                LeftSectionFactory.GetTimeGoOfDateGo($rootScope.endDate, $rootScope.RouteID, function (response) {
                    $scope.times = response;
                    $scope.controls.lvTime.dataSource.data($scope.times);

                    if ($rootScope.first) {
                        $rootScope.first = !$rootScope.first;
                        $scope.controls.lvTime.items()[0].click();
                    }

                    //if ($rootScope.CarDateGoID)
                    //{
                    //    var data = $scope.controls.lvTime.dataSource.data();
                    //    for (var i = 0; i < data.length; i++) {
                    //        if ($rootScope.CarDateGoID == data[i].CarDateGoID) {
                    //            $rootScope.CarDateGoID = '';
                    //            $scope.controls.lvTime.select($scope.controls.lvTime.items()[i]);
                    //        }
                    //    }
                    //}
                });
            }

            $scope.changeDate = function () {
                $rootScope.endDate = $scope.controls.calendar.current();
                var temp = new Date();
                temp = temp.addDays(-2);
                $rootScope.isSeatsActive = $rootScope.endDate >= temp ? true : false;
                $rootScope.first = true;
                $rootScope.GetTimeGoOfDateGo();
            }
            //
            $scope.onSelected = function () {
                
                var select = $scope.controls.lvTime.select();
                $scope.model = $scope.controls.lvTime.dataSource.view()[select.index()];
                $rootScope.CarDateGoID = $scope.model.CarDateGoID;
                $rootScope.GoTime = $scope.model.GoTime;
                //$location.url('booking/' + $rootScope.CarDateGoID + '/' + $rootScope.StationFromID);
                $scope.onChangeRoute();
            }

        }])

})();

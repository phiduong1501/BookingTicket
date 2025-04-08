(function () {
    app.controller('AppController', ['$scope', '$location', '$rootScope', '$route','$timeout', 'AccountFactory', 'CommonFactory',
        function ($scope, $location, $rootScope, $route, $timeout, AccountFactory, CommonFactory) {

            $rootScope.first = true;
            $rootScope.currentUser = JSON.parse($('#currentUser').val());
            $scope.controls = {};
            $scope.itemTemplate = $('#template').html();
            $scope.ManagementCarRedirect = function () {
                $location.url('managementcar');
            }

            $scope.ManagementPickupRedirect = function () {
                $location.url('managementpickup');
            }


            $scope.ManagementHomeRedirect = function () {
                $location.url('booking/' + $rootScope.CarDateGoID + '/' + $rootScope.StationFromID);
            }

            $scope.ManagementAccountRedirect = function () {
                $location.url('managementaccount');
            }

            $scope.ManagementCompanyRedirect = function () {
                $location.url('managementcompany');
            }

            $scope.ManagementStationRedirect = function () {
                $location.url('managementstation');
            }

            $scope.ManagementTimeRedirect = function () {
                $location.url('managementtime');
            }

            $scope.ManagementRouteRedirect = function () {
                $location.url('managementroute');
            }

            $scope.ComputerRegistry = function () {
                var result = confirm("Bạn muốn đăng ký máy tính này ?");
                if (result) {
                    AccountFactory.ComputerRegistry( function (respo) {
                        debugger;
                        if (respo && respo.Success == 1) {
                            //$rootScope.GetTimeGoOfDateGo();
                            CommonFactory.logSuccess('Đăng ký thành công');
                        }
                        else CommonFactory.logError('Đăng ký không thành công. ' + respo.Message);
                    });
                    //$location.url('ComputerRegistry');
                }
            }

            $scope.productsDataSource = {
                type: "odata",
                serverFiltering: true,
                schema: {
                    data: function (data) {
                        return data;
                    },
                    total: function (data) {
                        return data.length;
                    }
                },
                transport: {
                    read: {
                        url: "LeftSection/SearchSeats",
                        contentType: "application/json",
                        dataType: "json",
                        data: function (abc) {
                            if (abc.filter.filters[0]) {
                                var a = abc.filter.filters[0].value;
                                //return kendo.antiForgeryTokens();
                                return { strKeyword: a }
                            }
                        }
                    }
                }
            };

            $scope.viewInfo = function (item) {
                $scope.model = item;
                $scope.controls.wndUpdate.center().open();
            }

            $scope.searchOnChange = function () {
                var item = $scope.controls.cbSearch.dataItem();
                $rootScope.searchID = item.CarDateGoDetailID;
                debugger;
                $location.url('booking/' + item.CarDateGoID + '/' + item.StationFromID);
                var a = item.GoDate.split('/');
                $rootScope.endDate = new Date(a[2], a[1] - 1, a[0]);
                $rootScope.CarDateGoID = item.CarDateGoID;
            }

            $scope.onClose = function () {
                $scope.controls.cbSearch.text('')
            }

            document.addEventListener("keydown", keyDownTextField, false);
            document.addEventListener("keyup", keyUpTextField, false);
            function keyDownTextField(e) {
                var keyCode = e.keyCode;
                if (keyCode == 27) {
                    debugger;
                    if ($rootScope.isMoving) {
                        $timeout(function () {
                            $rootScope.isMoving = !$rootScope.isMoving;
                            $rootScope.action = '';
                            $scope.$apply();
                            $rootScope.isSeachByMobile = true;
                        }, 0);
                    }
                } else if (keyCode == 17) {
                    $rootScope.isSeachByMobile = false;
                }
                
            }

            function keyUpTextField(e) {
                var keyCode = e.keyCode;
                if (keyCode == 17) {
                    $rootScope.isSeachByMobile = true;
                }

            }
        }])

})();

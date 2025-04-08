(function () {
    app.controller('PayBackController', ['$http', '$scope', 'BookingFactory', 'CommonFactory', '$routeParams', '$timeout', '$location', '$rootScope', '$route',
        function ($http, $scope, BookingFactory, CommonFactory, $routeParams, $timeout, $location, $rootScope, $route) {
            $scope.controls = {

            };
            $scope.TotalPrice = 0;
            $scope.intDateGoID = $routeParams.intDateGoID;
            $scope.stationFromID = $routeParams.stationFromID;
            $scope.totalSeat = 0;
            $scope.totalSeatEmpty = 0;
            $scope.totalSeatPayment = 0;

            $scope.Init = function () {
                $scope.GetListPickup();


            }

            $scope.GetListPickup = function () {
                BookingFactory.GetListPickup($scope.intDateGoID, function (response) {
                    if (response.Success) {
                        $scope.listPickUp = JSON.parse(response.Result);

                        for (var i = 0; i < $scope.listPickUp.length; i++) {
                            $scope.TotalPrice += $scope.listPickUp[i].SumPrice;
                        }

                        $scope.$apply();
                    }
                    else
                        $scope.listPickUp = [];
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
                $scope.GetAllSeatOfTimeGo();
            }

            $scope.GetAllSeatOfTimeGo = function () {
                BookingFactory.GetAllSeatOfTimeGo($scope.intDateGoID, $scope.stationFromID, function (response) {
                    $timeout(function () {
                        $scope.lstseats = response;
                        for (var i = 0; i < response.length; i++) {
                            if (response[i].SeatStatusID > 0)
                                $scope.totalSeat++;
                            else if (response[i].SeatStatusID == 0)
                                $scope.totalSeatEmpty++;

                            if (response[i].PaymentStatusID == 1)
                                $scope.totalSeatPayment++;
                        }
                    }, 10)
                    if ($scope.controls.lvSeat && $scope.controls.lvSeat.dataSource != undefined)
                        $scope.controls.lvSeat.dataSource.data(response);


                });
            }

            $scope.PrintPayback = function () {
                var WinPrint = window.open("/Ticket/PrintPayback?intDateGoID=" + $scope.intDateGoID, "MsgWindow", "width=800,height=600,rigth=100");
                WinPrint.focus();
                WinPrint.onload = function () {
                    WinPrint.print();
                    //WinPrint.onfocus = function () { WinPrint.close(); }
                }
            }

            $scope.SaveOrderIndex = function () {
                if ($scope.listPickUp && $scope.listPickUp.length > 0) {

                    for (var i = 0; i < $scope.listPickUp.length; i++) {
                        var item = $scope.listPickUp[i];
                        BookingFactory.UpdateOrderPickup(item.CarDateGoDetailID, item.OrderPickup, function (response) {
                        });
                    }

                    $timeout(function () {
                        $scope.GetListPickup();
                    }, 1000);
                }
            }
        }])

})();

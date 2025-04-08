(function () {
    app.controller('TransitController', ['$http', '$scope', 'BookingFactory', 'CommonFactory', '$routeParams', '$timeout', '$location', '$rootScope', '$route',
        function ($http, $scope, BookingFactory, CommonFactory, $routeParams, $timeout, $location, $rootScope, $route) {
            $scope.controls = {

            };

            $scope.intDateGoID = $routeParams.intDateGoID;
            $scope.stationFromID = $routeParams.stationFromID;
            $scope.totalSeat = 0;
            $scope.totalSeatEmpty = 0;
            $scope.totalSeatPayment = 0;

            $scope.Init = function () {
                $scope.GetListTransit();
            }

            $scope.GetListTransit = function () {
                BookingFactory.GetListTransit($scope.intDateGoID, function (response) {
                    if (response.Success)
                    {
                        $scope.listTransit = JSON.parse(response.Result);
                        $scope.$apply();
                    }
                    else
                        $scope.listTransit = [];
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

            $scope.PrintTransit = function () {
                var WinPrint = window.open("/Ticket/PrintTransit?intDateGoID=" + $scope.intDateGoID, "MsgWindow", "width=800,height=600,rigth=100");
                WinPrint.focus();
                WinPrint.onload = function () {
                    WinPrint.print();
                    //WinPrint.onfocus = function () { WinPrint.close(); }
                }
            }

            $scope.SaveOrderIndex = function () {                
                if ($scope.listTransit && $scope.listTransit.length > 0) {

                    for (var i = 0; i < $scope.listTransit.length; i++) {
                        var item = $scope.listTransit[i];
                        BookingFactory.UpdateOrderTransit(item.CarDateGoDetailID, item.OrderTransit, function (response) {
                        });
                    }

                    $timeout(function () {
                        $scope.GetListTransit();
                    }, 1000);
                }
            }
        }])

})();

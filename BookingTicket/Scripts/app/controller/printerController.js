(function () {
    app.controller('printerController', ['$http', '$scope', 'BookingFactory', 'CommonFactory', '$routeParams', '$timeout', '$location', '$rootScope', '$route',
        function ($http, $scope, BookingFactory, CommonFactory, $routeParams, $timeout, $location, $rootScope, $route) {
  
            $scope.PrintTransit = function () {
                var WinPrint = window.open("/Ticket/PrintTransit?intDateGoID=" + $scope.intDateGoID, "MsgWindow", "width=800,height=600,rigth=100");
                WinPrint.focus();
                WinPrint.onload = function () {
                    WinPrint.print();
                    //WinPrint.onfocus = function () { WinPrint.close(); }
                }
            }
        }])

})();

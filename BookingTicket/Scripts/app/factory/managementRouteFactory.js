(function () {

    app.factory('ManagementRouteFactory', ['$http', 'CommonFactory', '$timeout', function ($http, CommonFactory, $timeout) {
        var service = {};
        var URL = "/Ticket/";
        service.CallServer = function (funtionname, param, callback) {
            var dataSend = JSON.stringify(param);
            CommonFactory.PostDataAjax(URL + funtionname, dataSend,
                function () { },
                function (response) {
                    $timeout(function () {
                        if (response != "error") {
                            callback(response);
                        } else {
                            callback(null);
                        }
                    }, 10);
                },
                function () {
                    $timeout(function () {
                        callback(null);
                    }, 10);
                });
        };
        service.GetAll = function (callback) {
            var datasend = JSON.stringify({
            });

            CommonFactory.PostDataAjax("/LeftSection/GetRouteAll", null,
                function (err) {

                },
                function (response) {
                    callback(response);
                },

                function (error) {
                    callback(error);
                });
        }

        service.InsertRoute = function (model, callback) {
            var datasend = JSON.stringify(model);

            CommonFactory.PostDataAjax("/Ticket/InsertRoute", datasend,
                function (err) {

                },
                function (response) {
                    callback(response);
                },

                function (error) {
                    callback(error);
                });
        }
        
        service.DeleteRoute = function (model, callback) {
            var datasend = JSON.stringify({
                objRoute: model
            });

            CommonFactory.PostDataAjax("/Ticket/DeleteRoute", datasend,
                function (err) {

                },
                function (response) {
                    callback(response);
                },

                function (error) {
                    callback(error);
                });
        }

        service.UpdateRoute = function (model, callback) {
            var datasend = JSON.stringify({
                objRoute: model
            });

            CommonFactory.PostDataAjax("/Ticket/UpdateRoute", datasend,
                function (err) {
                },
                function (response) {
                    callback(response);
                },

                function (error) {
                    callback(error);
                });
        }

        return service;
    }])
})();
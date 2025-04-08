(function () {

    app.factory('ManagementRouteFactory', ['$http', 'CommonFactory', function ($http, CommonFactory) {
        var service = {};
        
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
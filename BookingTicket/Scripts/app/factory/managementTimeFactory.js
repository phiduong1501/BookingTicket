(function () {

    app.factory('ManagementTimeFactory', ['$http', 'CommonFactory', function ($http, CommonFactory) {
        var service = {};
        
        service.GetAll = function (callback) {
            var datasend = JSON.stringify({
            });

            CommonFactory.PostDataAjax("/Ticket/GetTimeAll", null,
                function (err) {

                },
                function (response) {
                    callback(response);
                },

                function (error) {
                    callback(error);
                });
        }

        service.InsertTime = function (model, callback) {
            var datasend = JSON.stringify(model);

            CommonFactory.PostDataAjax("/Ticket/InsertTime", datasend,
                function (err) {

                },
                function (response) {
                    callback(response);
                },

                function (error) {
                    callback(error);
                });
        }
        
        service.DeleteTime = function (model, callback) {
            var datasend = JSON.stringify({
                objTime: model
            });

            CommonFactory.PostDataAjax("/Ticket/DeleteTime", datasend,
                function (err) {

                },
                function (response) {
                    callback(response);
                },

                function (error) {
                    callback(error);
                });
        }

        service.UpdateTime = function (model, callback) {
            var datasend = JSON.stringify({
                objTime: model
            });

            CommonFactory.PostDataAjax("/Ticket/UpdateTime", datasend,
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
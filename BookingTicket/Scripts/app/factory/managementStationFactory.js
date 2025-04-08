(function () {

    app.factory('ManagementStationFactory', ['$http', 'CommonFactory', function ($http, CommonFactory) {
        var service = {};
        
        service.GetAll = function (intSortDesc, callback) {
            var datasend = JSON.stringify({
                intSortDesc: intSortDesc
            });

            CommonFactory.PostDataAjax("/Ticket/GetAllStation", datasend,
                function (err) {

                },
                function (response) {
                    callback(response);
                },

                function (error) {
                    callback(error);
                });
        }

        service.InsertStation = function (model, callback) {
            var datasend = JSON.stringify(model);

            CommonFactory.PostDataAjax("/Ticket/InsertStation", datasend,
                function (err) {

                },
                function (response) {
                    callback(response);
                },

                function (error) {
                    callback(error);
                });
        }
        
        service.DeleteStation = function (model, callback) {
            var datasend = JSON.stringify({
                objStation: model
            });

            CommonFactory.PostDataAjax("/Ticket/DeleteStation", datasend,
                function (err) {

                },
                function (response) {
                    callback(response);
                },

                function (error) {
                    callback(error);
                });
        }

        service.UpdateStation = function (model, callback) {
            var datasend = JSON.stringify({
                objStation: model
            });

            CommonFactory.PostDataAjax("/Ticket/UpdateStation", datasend,
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
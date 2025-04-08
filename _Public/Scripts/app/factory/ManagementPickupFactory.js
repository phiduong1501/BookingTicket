(function () {

    app.factory('ManagementPickupFactory', ['$http', 'CommonFactory', function ($http, CommonFactory) {
        var service = {};

        service.InsertPickup = function (model, callback) {
            var datasend = JSON.stringify(model);

            CommonFactory.PostDataAjax("/Ticket/InsertPickup", datasend,
                function (err) {

                },
                function (response) {
                    callback(response);
                },

                function (error) {
                    callback(error);
                });
        }

        service.UpdatePickup = function (model, callback) {
            var datasend = JSON.stringify(model);

            CommonFactory.PostDataAjax("/Ticket/UpdatePickup", datasend,
                function (err) {

                },
                function (response) {
                    callback(response);
                },

                function (error) {
                    callback(error);
                });
        }

        service.DeletePickup = function (model, callback) {
            var datasend = JSON.stringify(model);

            CommonFactory.PostDataAjax("/Ticket/DeletePickup", datasend,
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
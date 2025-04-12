(function () {

    app.factory('ManagementCarFactory', ['$http', 'CommonFactory', function ($http, CommonFactory) {
        var service = {};
        
        service.GetTimeAll = function (callback) {
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

        service.InsertCarDateGo = function (model, callback) {
            var datasend = JSON.stringify(model);

            CommonFactory.PostDataAjax("/Ticket/InsertCarDateGo", datasend,
                function (err) {

                },
                function (response) {
                    callback(response);
                },

                function (error) {
                    callback(error);
                });
        }

        service.UpdateCarDateGo = function (intCarID, strGoTime, strDriver, strCarNumber, bolTransship, bolNewBus, callback) {
            var datasend = JSON.stringify({
                intCarID: intCarID,
                strGoTime: strGoTime,
                strDriver: strDriver,
                strCarNumber: strCarNumber,
                bolTransship: bolTransship,
                bolNewBus: bolNewBus
            });

            CommonFactory.PostDataAjax("/Ticket/UpdateCarDateGo", datasend,
                function (err) {

                },
                function (response) {
                    callback(response);
                },

                function (error) {
                    callback(error);
                });
        }
        
        service.DeleteCar = function (intCarDateGoID, callback) {
            var datasend = JSON.stringify({
                intCarDateGoID: intCarDateGoID
            });

            CommonFactory.PostDataAjax("/Ticket/DeleteCar", datasend,
                function (err) {

                },
                function (response) {
                    callback(response);
                },

                function (error) {
                    callback(error);
                });
        }

        service.SelectCar = function (intCarDateGoID, callback) {
            var datasend = JSON.stringify({
                intCarDateGoID: intCarDateGoID
            });

            CommonFactory.PostDataAjax("/Ticket/SelectCar", datasend,
                function (err) {
                },
                function (response) {
                    callback(response);
                },

                function (error) {
                    callback(error);
                });
        }

        //service.SelectLoaiXe = function (callback) {
        //    var datasend = JSON.stringify({
                
        //    });

        //    CommonFactory.PostDataAjax("/Ticket/SelectLoaiXe", datasend,
        //        function (err) {
        //        },
        //        function (response) {
        //            callback(response);
        //        },

        //        function (error) {
        //            callback(error);
        //        });
        //}

        return service;
    }])
})();
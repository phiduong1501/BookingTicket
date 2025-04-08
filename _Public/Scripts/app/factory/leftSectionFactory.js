(function () {
    app.factory('LeftSectionFactory', ['$http', 'CommonFactory', function ($http, CommonFactory) {
        var factory = {};
        var URL = "/LeftSection/";

        factory.GetRouteAll = function (callback) {
            var datasend = JSON.stringify({
            });

            CommonFactory.PostDataAjax(URL + "GetRouteAll", null,
                function (err) {
                    
                },
                function (response) {
                    callback(response);
                },

                function (error) {
                    
                    callback(error);
                });
        }

        factory.GetTimeGoOfDateGo = function (dtGo, routeID, callback) {

            var datasend = JSON.stringify({
                dtGo: dtGo,
                routeID: routeID
            });

            CommonFactory.PostDataAjax(URL + "GetTimeGoOfDateGo", datasend,
                function (err) {
                    
                },
                function (response) {
                    callback(response);
                },

                function (error) {
                    
                    callback(error);
                });
        }
        

        return factory;
    }])

})();

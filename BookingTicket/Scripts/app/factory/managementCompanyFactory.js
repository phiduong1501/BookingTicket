(function () {

    app.factory('ManagementCompanyFactory', ['$http', 'CommonFactory', '$timeout', function ($http, CommonFactory, $timeout) {
        var service = {};
        var URL = "/Company/";
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
        service.GetCompanyAll = function (callback) {
            var datasend = JSON.stringify({
            });

            CommonFactory.PostDataAjax("/Company/GetAllCompany", null,
                function (err) {

                },
                function (response) {
                    callback(response);
                },

                function (error) {
                    callback(error);
                });
        }

        service.ApproveCompany = function (company, callback) {
            var datasend = JSON.stringify({
                
                objBO: company
            });

            CommonFactory.PostDataAjax("/Company/ApproveCompany", datasend,
                function (err) {

                },
                function (response) {
                    callback(response);
                },

                function (error) {
                    callback(error);
                });
        }
        
        service.DeleteCompany = function (company, callback) {
            var datasend = JSON.stringify({
                objBO: company
            });

            CommonFactory.PostDataAjax("/Company/DeleteCompany", datasend,
                function (err) {

                },
                function (response) {
                    callback(response);
                },

                function (error) {
                    callback(error);
                });
        }

        service.UpdateCompany = function (company, callback) {
            var datasend = JSON.stringify({
                objBO: company
            });

            CommonFactory.PostDataAjax("/Company/UpdateCompany", datasend,
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
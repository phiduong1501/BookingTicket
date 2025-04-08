(function () {

    app.factory('ManagementCompanyFactory', ['$http', 'CommonFactory', function ($http, CommonFactory) {
        var service = {};
        
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
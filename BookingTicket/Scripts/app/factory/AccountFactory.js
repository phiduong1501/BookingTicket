(function () {

    app.factory('AccountFactory', ['$http', 'CommonFactory', function ($http, CommonFactory) {
        var service = {};

        var URL = "Account/";
        service.Login = function (strUserName, strPassword, callback) {
            var datasend = JSON.stringify({
                strUserName: strUserName,
                strPassword: strPassword
            });

            CommonFactory.PostDataAjax(URL + "SignIn", datasend,
                function (err) {},
                function (response) {
                    callback(response);
                },
                function (error) {
                    callback(error);
                });
        }

        service.Register = function (strUserName, strPassword, strCompanyName, strPhone, strAddress, strContactName, strContactPhone, callback) {
            var datasend = JSON.stringify({
                strUserName: strUserName,
                strPassword: strPassword,
                strCompanyName: strCompanyName,
                strPhone: strPhone,
                strAddress: strAddress,
                strContactName: strContactName,
                strContactPhone: strContactPhone
            });

            CommonFactory.PostDataAjax(URL + "RegisterCompany", datasend,
                function (err) { },
                function (response) {
                    callback(response);
                },
                function (error) {
                    callback(error);
                });
        }

        service.GetAllUser = function (callback) {
            var datasend = JSON.stringify({
            });

            CommonFactory.PostDataAjax(URL + "GetAllUser", null,
                function (err) { },
                function (response) {
                    callback(response);
                },
                function (error) {
                    callback(error);
                });
        }

        service.InsertUser = function (model, callback) {
            var datasend = JSON.stringify(model);

            CommonFactory.PostDataAjax(URL + "InsertUser", datasend,
                function (err) { },
                function (response) {
                    callback(response);
                },
                function (error) {
                    callback(error);
                });
        }

        

        service.ChangePassword = function (strUserName, strPassword, callback) {
            var datasend = JSON.stringify({
                strUserName: strUserName,
                strPassword: strPassword
            });

            CommonFactory.PostDataAjax(URL + "UpdatePassword", datasend,
                function (err) { },
                function (response) {
                    callback(response);
                },
                function (error) {
                    callback(error);
                });
        }

        service.UpdateUser = function (model, callback) {
            var datasend = JSON.stringify(model);

            CommonFactory.PostDataAjax(URL + "UpdateUser", datasend,
                function (err) { },
                function (response) {
                    callback(response);
                },
                function (error) {
                    callback(error);
                });
        }

        service.DeleteUser = function (model, callback) {
            var datasend = JSON.stringify(model);

            CommonFactory.PostDataAjax(URL + "DeleteUser", datasend,
                function (err) { },
                function (response) {
                    callback(response);
                },
                function (error) {
                    callback(error);
                });
        }

        service.ComputerRegistry = function (callback) {
            
            var datasend = JSON.stringify({
            });

            CommonFactory.PostDataAjax(URL + "ComputerRegistry", null,
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
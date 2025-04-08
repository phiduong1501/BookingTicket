(function () {
    app.factory('CommonFactory', ['$http', '$rootScope', '$location', function ($http, $rootScope, $location) {
        var service = {};

        service.showLoading = function () {
            $('#loadingWrapper').show();
        }

        service.hideLoading = function () {
            $('#loadingWrapper').hide();
        }

       


        service.PostDataAjax = function (url, data, beforeSend, success, errorFunction, timeout) {
            service.showLoading();
            if (!timeout) {
                timeout = 60000;
            }

            $.ajax({
                url: url,
                type: "POST",
                timeout: timeout,
                cache: true,
                crossDomain: true,
                contentType: "application/json; charset=utf-8;",
                dataType: "json",
                data: data,
                processData: true,
                beforeSend: beforeSend,
                async: true,
                tryCount: 0,
                retryLimit: 3,
                success: function (response) {
                    success(response);
                    service.hideLoading();
                },
                error: function (error) {
                    service.hideLoading();
                },
                complete: function (complete) {
                    service.hideLoading();
                }
            });
        }

        service.PostDataAjaxSync = function (url, data, beforeSend, success, errorFunction, timeout) {
            if (!timeout) {
                timeout = 60000;
            }



            $.ajax({
                url: url,
                type: "POST",
                timeout: timeout,
                cache: true,
                crossDomain: true,
                contentType: "application/json; charset=utf-8;",
                dataType: "json",
                data: data,
                processData: true,
                beforeSend: beforeSend,
                async: false,
                success: function (response) {
                    success(response);
                },
                error: function (error) {

                },
                complete: function (complete) {

                }
            });
        }

        toastr.options = {
            closeButton: true,
            positionClass: "toast-bottom-right",
            timeOut: 3000
        };

        var logIt = function (message, logType) {
            //if (!util.IsEmpty(message))
            return toastr[logType](message);
        };

        service.log = function (message) {
            logIt(message, 'info');
        }

        service.logWarning = function (message) {
            logIt(message, 'warning');
        }

        service.logSuccess = function (message) {
            logIt(message, 'success');
            return true;
        }

        service.logError = function (message, includeSave) {
            logIt(message, 'error');
            return false;
        }

        return service;
    }])
})();
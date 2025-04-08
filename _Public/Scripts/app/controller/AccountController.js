(function () {
    app.controller('AccountController', ['$http', '$scope', 'AccountFactory', '$timeout', 'CommonFactory', '$location', 'BookingFactory', '$rootScope',
        function ($http, $scope, AccountFactory, $timeout, CommonFactory, $location, BookingFactory, $rootScope) {
            $scope.Title = "Đăng nhập";
            $scope.UserName = "";
            $scope.Password = "";
            $scope.isLoading = false;
            $scope.iSLoginFail = false;
            $scope.controls = {};

            $scope.Login = function () {
                try {
                    $scope.isLoading = true;
                    
                    AccountFactory.Login($scope.UserName, $scope.Password, function (response) {
                        if (response.Result == 1) {
                            window.location.href = '/';
                            //window.location.href = 'http://localhost:1495';
                        } else {
                            $timeout(function () {
                                //$scope.iSLoginFail = true;
                                CommonFactory.logWarning('Sai tên truy cập hoặc mật khẩu.');
                            }, 10);

                        }
                        $timeout(function () {
                            $scope.isLoading = false;
                        }, 10);
                    });
                } catch (e) {
                    $timeout(function () {
                        $scope.iSLoginFail = true;
                        $scope.isLoading = false;
                    }, 10);
                }
            }

            $scope.Init = function () {
                $scope.GetAllUser();
                $scope.GetAllStation();
            }

            $scope.GetAllUser = function () {
                AccountFactory.GetAllUser(function (response) {
                    $scope.lstUser = JSON.parse(response.Result);
                    $scope.$apply();
                });
            }

            $scope.openWndAccount = function (user) {
                if (user) {
                    $scope.model = user;
                }
                else
                    $scope.model = {};

                $scope.Password = '';

                $scope.controls.wndAccount.center().open();
            }

            $scope.GetAllStation = function () {
                BookingFactory.GetAllStation(1, function (response) {
                    $scope.stations = response.Result;
                });
            }

            $scope.Submit = function () {
                if (!$scope.model.UserId)
                    $scope.InsertUser();
                else
                    $scope.UpdateUser();
            }

            $scope.InsertUser = function () {
                var model = $scope.model;

                model.Password = $scope.Password;
                model.StationID = $scope.controls.ddlStation.dataItem().StationID;

                AccountFactory.InsertUser(model, function (response) {
                    if (response.Success) {
                        $scope.GetAllUser();
                        $scope.controls.wndAccount.center().close();
                        CommonFactory.logSuccess('Thêm tài khoản thành công.');
                    }
                    else {
                        CommonFactory.logError('Thêm tài khoản thất bại: ' + response.Message);
                    }
                });
            }

            $scope.UpdateUser = function () {
                debugger
                var model = $scope.model;

                if ($scope.Password)
                    model.NewPassword = $scope.Password;

                model.StationID = $scope.controls.ddlStation.dataItem().StationID;

                AccountFactory.UpdateUser(model, function (response) {
                    if (response.Success) {
                        $scope.GetAllUser();
                        $scope.controls.wndAccount.center().close();
                        CommonFactory.logSuccess('Cập nhật tài khoản thành công.');
                    }
                    else {
                        CommonFactory.logError('Cập nhật tài khoản thất bại: ' + response.Message);
                    }
                });
            }

            $scope.DeleteUser = function (model) {
                debugger
                AccountFactory.DeleteUser(model, function (response) {
                    if (response.Success) {
                        $scope.GetAllUser();
                        CommonFactory.logSuccess('Xóa tài khoản thành công.');
                    }
                    else {
                        CommonFactory.logError('Xóa tài khoản thất bại: ' + response.Message);
                    }
                });
            }
            $scope.OldPassword = "";
            $scope.NewPassword = "";
            $scope.NewPasswordConfirm = "";
            $scope.Changepassword = function () {
                if ($scope.OldPassword == "") {
                    CommonFactory.logError('Chưa nhập mật khẩu hiện tại');
                    return;
                }
                else if ($scope.NewPassword == "") {
                    CommonFactory.logError('Chưa nhập mật khẩu mới');
                    return;
                }
                else if ($scope.NewPassword != $scope.NewPasswordConfirm) {
                    CommonFactory.logError('Xác nhận mật khẩu không đúng');
                    return;
                }
                $scope.isLoading = true;
                AccountFactory.Login($rootScope.currentUser.UserName, $scope.OldPassword, function (response) {
                    debugger;
                    if (response.Result == 1) {
                        AccountFactory.ChangePassword($rootScope.currentUser.UserName, $scope.NewPassword, function (response) {
                            debugger;
                            if (response == 1) {
                                alert('Đổi mật khẩu thành công.');
                                window.location.href = '/';
                            }
                            $timeout(function () {
                                $scope.isLoading = false;
                            }, 10);
                        });
                    } else {
                        $timeout(function () {
                            CommonFactory.logWarning('Mật khẩu cũ không đúng');
                        }, 10);
                        $timeout(function () {
                            $scope.isLoading = false;
                        }, 10);

                    }

                });
            }
        }])

})();
(function () {
    app.controller('AccountController', ['$http', '$scope', 'AccountFactory', '$timeout', 'CommonFactory', 'LeftSectionFactory', 'BookingFactory', '$rootScope',
        function ($http, $scope, AccountFactory, $timeout, CommonFactory, LeftSectionFactory, BookingFactory, $rootScope) {
            $scope.Title = "Đăng nhập";
            $scope.TitleRegister = "Đăng ký mới";
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
                $scope.GetAllRoute();
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

            $scope.GetAllRoute = function () {
                $scope.GetRouteAll = function () {
                    LeftSectionFactory.GetRouteAll(function (response) {
                        $scope.routes = response;
                    });
                }
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
                        if (model.UserName == $rootScope.currentUser.UserName) {// nếu admin tự update thì cần đăng xuất đăng nhập lại
                            window.location.href = '/Account/Logout';
                        }
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

            $scope.Register = function () {
                debugger
                try {
                    if ($scope.Password == "" || $scope.Password == undefined) {
                        CommonFactory.logError('Chưa nhập mật khẩu');
                        return;
                    }
                    else if ($scope.Password != $scope.PasswordConfirm) {
                        CommonFactory.logError('Xác nhận mật khẩu không đúng');
                        return;
                    }
                    else if ($scope.UserName == "" || $scope.UserName == undefined) {
                        CommonFactory.logError('Chưa nhập tên đăng nhập');
                        return;
                    }
                    else if ($scope.CompanyName == "" || $scope.CompanyName == undefined) {
                        CommonFactory.logError('Chưa nhập tên nhà xe');
                        return;
                    }
                    else if ($scope.Phone == "" || $scope.Phone == undefined) {
                        CommonFactory.logError('Chưa nhập SĐT');
                        return;
                    }
                    else if ($scope.Address == "" || $scope.Address == undefined) {
                        CommonFactory.logError('Chưa nhập địa chỉ');
                        return;
                    }
                    else if ($scope.ContactName == "" || $scope.ContactName == undefined) {
                        CommonFactory.logError('Chưa nhập tên liên hệ');
                        return;
                    }
                    else if ($scope.ContactPhone == "" || $scope.ContactPhone == undefined) {
                        CommonFactory.logError('Chưa nhập SĐT liên hệ');
                        return;
                    }
                    $scope.isLoading = true;

                    AccountFactory.Register($scope.UserName, $scope.Password, $scope.CompanyName, $scope.Phone, $scope.Address, $scope.ContactName, $scope.ContactPhone, function (response) {
                        if (response.Success) {
                            CommonFactory.logSuccess('Đăng ký tài khoản thành công.');
                            $timeout(function () {
                                window.location.href = '/';
                            }, 100);
                        } else {
                            $timeout(function () {
                                //$scope.iSLoginFail = true;
                                CommonFactory.logWarning('Lỗi khi đăng ký tài khoản');
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
        }])

})();
(function () {
    app.controller('managementCompanyController', ['$http', '$scope', 'ManagementCompanyFactory', 'CommonFactory', '$timeout', '$location', '$rootScope', 'LeftSectionFactory',
        function ($http, $scope, ManagementCompanyFactory, CommonFactory, $timeout, $location, $rootScope, LeftSectionFactory) {
            $scope.controls = {
            };
            $scope.Init = function () {
                $scope.GetCompanyAll();
            }

            $scope.GetCompanyAll = function () {
                $scope.companyAll = [];
                ManagementCompanyFactory.GetCompanyAll(function (response) {
                    $scope.companyAll = JSON.parse(response.Result);
                    $scope.$apply();
                });
            }
            $scope.Submit_Update = function () {
                if ($scope.model.Address == '' || $scope.model.Address == undefined || $scope.model.Address == null) {
                    CommonFactory.logWarning('Chưa nhập địa chỉ');
                    return;
                }
                if ($scope.model.Phone == '' || $scope.model.Phone == undefined || $scope.model.Phone == null) {
                    CommonFactory.logWarning('Chưa nhập địa chỉ');
                    return;
                }
                if ($scope.model.CompanyName == '' || $scope.model.CompanyName == undefined || $scope.model.CompanyName == null) {
                    CommonFactory.logWarning('Chưa nhập tên nhà xe');
                    return;
                }
                if ($scope.model.ContactPerson == '' || $scope.model.ContactPerson == undefined || $scope.model.ContactPerson == null) {
                    CommonFactory.logWarning('Chưa nhập tên người liên hệ');
                    return;
                }
                if ($scope.model.ContactPhone == '' || $scope.model.ContactPhone == undefined || $scope.model.ContactPhone == null) {
                    CommonFactory.logWarning('Chưa nhập sđt người liên hệ');
                    return;
                }
                ManagementCompanyFactory.CallServer("UpdateCompany", $scope.model, function (resp) {
                    if (resp && resp.Success == 1) {
                        CommonFactory.logSuccess('Cập nhật thành công!');
                        $scope.Init();
                        $scope.controls.wndAccount.center().close();
                    } else {
                        CommonFactory.logError('Thêm mới thất bại');
                    }
                });
            }
            $scope.Submit_Create = function () {
                if ($scope.model.Address == '' || $scope.model.Address == undefined || $scope.model.Address == null) {
                    CommonFactory.logWarning('Chưa nhập địa chỉ');
                    return;
                }
                if ($scope.model.Phone == '' || $scope.model.Phone == undefined || $scope.model.Phone == null) {
                    CommonFactory.logWarning('Chưa nhập địa chỉ');
                    return;
                }
                if ($scope.model.CompanyName == '' || $scope.model.CompanyName == undefined || $scope.model.CompanyName == null) {
                    CommonFactory.logWarning('Chưa nhập tên nhà xe');
                    return;
                }
                if ($scope.model.ContactPerson == '' || $scope.model.ContactPerson == undefined || $scope.model.ContactPerson == null) {
                    CommonFactory.logWarning('Chưa nhập tên người liên hệ');
                    return;
                }
                if ($scope.model.ContactPhone == '' || $scope.model.ContactPhone == undefined || $scope.model.ContactPhone == null) {
                    CommonFactory.logWarning('Chưa nhập sđt người liên hệ');
                    return;
                }
                if (!$scope.model.Password) {
                    CommonFactory.logWarning('Chưa nhập tên tài khoản');
                    return;
                }
                if (!$scope.model.Password) {
                    CommonFactory.logWarning('Chưa nhập mật khẩu');
                    return;
                }
                ManagementCompanyFactory.CallServer("RegisterCompany", $scope.model, function (resp) {
                    if (resp && resp.Success == 1) {
                        CommonFactory.logSuccess('Thêm mới thành công!');
                        $scope.Init();
                        $scope.controls.wndAccount.center().close();
                    } else {
                        CommonFactory.logError('Thêm mới thất bại' + resp.Message);
                    }
                });
            }
            $scope.DeleteCompany = function (company) {

                var a = confirm("Bạn có muốn xóa nhà xe này?");
                if (a) {
                    ManagementCompanyFactory.DeleteCompany(company, function (resp) {
                        if (resp && resp.Success) {
                            CommonFactory.logSuccess('Xóa nhà xe thành công.');
                            $scope.isUpdate = false;
                            $scope.GetCompanyAll();
                        } else {
                            CommonFactory.logError('Xóa nhà xe không thành công: ' + resp.Message);
                        }
                    });
                }
            }

            //$scope.ApproveCompany = function (company) {

            //    var a = confirm("Bạn có muốn duyệt nhà xe này?");
            //    if (a) {
            //        ManagementCompanyFactory.ApproveCompany(company, function (resp) {
            //            if (resp && resp.Success) {
            //                CommonFactory.logSuccess('Duyệt nhà xe thành công.');
            //                $scope.isUpdate = false;
            //                $scope.GetCompanyAll();
            //            } else {
            //                CommonFactory.logError('Duyệt nhà xe không thành công: ' + resp.Message);
            //            }
            //        });
            //    }
            //}

            $scope.openWndAccount = function (company) {
                if (company) {
                    $scope.model = company;
                    $scope.model.IsCreate = false;
                }
                else {
                    $scope.model = {};
                    $scope.model.IsCreate = true;
                }
                $scope.controls.wndAccount.center().open();
            }
        }])

})();

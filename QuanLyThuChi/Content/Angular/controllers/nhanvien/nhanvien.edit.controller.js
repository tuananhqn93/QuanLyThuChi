﻿app.controller("editNhanVienCtrl", function ($scope, angularService, $http, $stateParams,$state) {
    var getData = angularService.getNhanVienById($stateParams.id);
    getData.then(function (item) {
            $scope.Ten = item.data.Ten;
            $scope.SoDienThoai = item.data.SoDienThoai;
            $scope.Email = item.data.Email;
            $scope.DiaChi = item.data.DiaChi;
        },
        function (err) {
            console.log(err);
        });
        
       // $scope.model.Id = $stateParams.id;
        $scope.save = function () {
            $http({
                method: "POST",
                url: "/Home/SuaNhanVien",
                data: {
                    Id: $stateParams.id,
                    Ten: $scope.Ten,
                    DiaChi : $scope.DiaChi,
                    SoDienThoai: $scope.SoDienThoai,
                    Email:$scope.Email
                }
            }).success(function (data) {
                $state.go('NhanVien');
            }).error(function (err) {
                console.log(err);
            });
        }
        $scope.cancel = function () {
            alert(" Khong thanh cong ! ");
            $state.go('NhanVien');
        }
});
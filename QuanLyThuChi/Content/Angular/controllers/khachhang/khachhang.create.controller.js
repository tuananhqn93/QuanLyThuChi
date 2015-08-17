app.controller("taoKhachHangCtrl", function ($scope, $http,$state) {
    $scope.model = {};
    $scope.create = function () {
        $http({
            method: "POST",
            url: "/Home/TaoKhachHang",
            data: $scope.model
        }).success(function (data) {
            $state.go('KhachHang');
        }).error(function (err) {
            console.log(err);
        });
    }
    $scope.cancel = function () {
        alert(" Khong thanh cong ! ");
    }
});
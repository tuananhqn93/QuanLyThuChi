app.controller("taoNhanVienCtrl", function ($scope, $http,$state) {
    $scope.model = {};
    $scope.create = function () {
        $http({
            method: "POST",
            url: "/Home/TaoNhanVien",
            data: $scope.model
        }).success(function (data) {
            $state.go('NhanVien');
        }).error(function (err) {
            console.log(err);
        });
    }
    $scope.cancel = function () {
        alert(" Khong thanh cong ! ");
    }
});
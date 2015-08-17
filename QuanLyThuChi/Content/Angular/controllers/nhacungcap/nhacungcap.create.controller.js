app.controller("taoNhaCungCapCtrl", function ($scope, $http, $state) {
    $scope.model = {};
    $scope.create = function () {
        $http({
            method: "POST",
            url: "/Home/TaoNhaCungCap",
            data: $scope.model
        }).success(function (data) {
            $state.go('NhaCungCap');
        }).error(function (err) {
            console.log(err);
        });
    }
    $scope.cancel = function () {
        alert(" Khong thanh cong ! ");
    }
});
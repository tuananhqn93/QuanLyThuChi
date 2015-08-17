app.controller("taoKhacCtrl", function ($scope, $http,$state) {
    $scope.model = {};
    $scope.create = function () {
        $http({
            method: "POST",
            url: "/Home/TaoKhac",
            data: $scope.model
        }).success(function (data) {
            $state.go('Khac');
        }).error(function (err) {
            console.log(err);
        });
    }
    $scope.cancel = function () {
        alert(" Khong thanh cong ! ");
    }
});
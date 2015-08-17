app.controller("editThuCtrl", function ($scope, angularService, $http, $stateParams,$state) {
    var getData = angularService.getPhieuThuById($stateParams.id);
        getData.then(function (item) {
            console.log(item.data);
            $scope.MaPhieuThu = item.data.MaPhieuThu;
            $scope.ThoiGianThu = parseDate(item.data.ThoiGianThu);
            $scope.LoaiPhieu_id = item.data.LoaiPhieu_id;
            $scope.IdLoaiNguoiDung = item.data.IdLoaiNguoiDung;
            $scope.GiaTri = item.data.GiaTri;
            $scope.GhiChu = item.data.GhiChu;
        },
        function (err) {
            console.log(err);
        });
        var parseDate = function (value) {
            if (value) {
                return new Date(parseInt(value.replace("/Date(", "").replace(")/", "")));
            }
            return null;
        }
        $scope.save = function () {
            $http({
                method: "POST",
                url: "/Home/SuaPhieuThu",
                data: {
                    MaPhieuThu: $scope.MaPhieuThu,
                    ThoiGianThu: $scope.ThoiGianThu,
                    LoaiPhieu_id: $scope.LoaiPhieu_id,
                    IdLoaiNguoiDung: $scope.IdLoaiNguoiDung,
                    GiaTri: $scope.GiaTri,
                    GhiChu: $scope.GhiChu
                }
            }).success(function (data) {
                $state.go('thu');
            }).error(function (err) {
                console.log(err);
            });
        }
        $scope.cancel = function () {
            alert(" Khong thanh cong ! ");
            $state.go('thu');
        }
});
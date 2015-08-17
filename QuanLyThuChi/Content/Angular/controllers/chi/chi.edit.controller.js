app.controller("editChiCtrl", function ($scope, angularService, $http, $stateParams,$state) {
    $scope.callForm = true;
    var getData = angularService.getPhieuChiById($stateParams.id);
    getData.then(function (item) {
            console.log(item.data);
            $scope.model.MaPhieuChi = item.data.MaPhieuChi;
            console.log($scope.model.MaPhieuChi);
            $scope.model.ThoiGianChi = parseDate(item.data.ThoiGianChi);
            $scope.model.LoaiPhieu_id = item.data.LoaiPhieu_id;
            $scope.model.LoaiNguoiTaoPhieuId = item.data.LoaiNguoiTaoPhieuId;
            $scope.model.NTP = item.data.NguoiTaoPhieuId;
            $scope.model.GiaTri = item.data.GiaTri;
            $scope.model.GhiChu = item.data.GhiChu;
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
                url: "/Home/SuaPhieuChi",
                data: {
                    MaPhieuChi: $scope.model.MaPhieuChi,
                    ThoiGianChi: $scope.model.ThoiGianChi,
                    LoaiPhieu_id: $scope.model.LoaiPhieu_id,
                    NguoiTaoPhieuId: $scope.model.NTP,
                    GiaTri: $scope.model.GiaTri,
                    GhiChu: $scope.model.GhiChu
                }
            }).success(function (data) {
                $state.go('chi');
            }).error(function (err) {
                console.log(err);
            });
        }
        $scope.cancel = function () {
            alert(" Khong thanh cong ! ");
            $state.go('chi');
        }
});
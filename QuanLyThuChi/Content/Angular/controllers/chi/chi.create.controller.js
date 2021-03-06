﻿app.controller("taoPhieuChiCtrl", function ($scope, $http,$state) {
    $scope.model = {};
    $scope.change = function () {
        $scope.callForm = true;
        $http.get("/Home/getNguoiTaoPhieuByLoaiNguoiDung?LoaiNguoiTaoPhieuId=" + parseInt($scope.model.LoaiNguoiTaoPhieuId))
       .success(function (data) {
           $scope.nguois = data;
       }).error(function (err) {
           console.log(err);
       });

    }
    $scope.changeId = function () {
        console.log($scope.model.NguoiTaoPhieuId);
        $http.get("/Home/getDanhSachNguoiDung?Id=" + $scope.model.NTP)
       .success(function (data) {
           console.log('1');
           $scope.nguoitp = data;
       }).error(function (err) {
           console.log(err);
       });
    }

    
    $scope.create = function () {
        $http({
            method: "POST",
            url: "/Home/TaoPhieuChi",
            data: {
                MaPhieuChi: $scope.model.MaPhieuChi,
                ThoiGianChi: $scope.model.ThoiGianChi,
                LoaiPhieu_id: $scope.model.LoaiPhieu_id,
                LoaiNguoiTaoPhieuId: $scope.model.LoaiNguoiTaoPhieuId,
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
    }
  

    
    // Datetime Picker
    //Start Datetime Picker

    $scope.today = function () {
        $scope.dt = new Date();
    };
    $scope.today();

    $scope.clear = function () {
        $scope.dt = null;
    };

    // Disable weekend selection
    $scope.disabled = function (date, mode) {
        return (mode === 'day' && (date.getDay() === 0 || date.getDay() === 6));
    };

    $scope.toggleMin = function () {
        $scope.minDate = $scope.minDate ? null : new Date();
    };
    $scope.toggleMin();

    $scope.open = function ($event) {
        $scope.status.opened = true;
    };

    $scope.dateOptions = {
        formatYear: 'yy',
        startingDay: 1
    };

    $scope.formats = ['dd-MMMM-yyyy', 'yyyy/MM/dd', 'dd.MM.yyyy', 'shortDate'];
    $scope.format = $scope.formats[0];

    $scope.status = {
        opened: false
    };

    var tomorrow = new Date();
    tomorrow.setDate(tomorrow.getDate() + 1);
    var afterTomorrow = new Date();
    afterTomorrow.setDate(tomorrow.getDate() + 2);
    $scope.events =
      [
        {
            date: tomorrow,
            status: 'full'
        },
        {
            date: afterTomorrow,
            status: 'partially'
        }
      ];

    $scope.getDayClass = function (date, mode) {
        if (mode === 'day') {
            var dayToCheck = new Date(date).setHours(0, 0, 0, 0);

            for (var i = 0; i < $scope.events.length; i++) {
                var currentDay = new Date($scope.events[i].date).setHours(0, 0, 0, 0);

                if (dayToCheck === currentDay) {
                    return $scope.events[i].status;
                }
            }
        }

        return '';
    };
});
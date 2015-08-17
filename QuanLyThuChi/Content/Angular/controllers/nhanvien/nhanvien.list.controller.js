
app.controller("listNhanVienCtrl", function ($scope, angularService, $http, $state) {
		var getData = angularService.DanhSachNhanVien(1);
		getData.then(function (nhanvien) {
		    $scope.dsNhanViens = nhanvien.data.items;
		    $scope.pageCount = nhanvien.data.pageCount;
			$scope.currentPage = 1;
		}, function () {
			console.log("Không tồn tại bản ghi");
		});

	$scope.selectPage = function (page) {
		angularService.DanhSachNhanVien(page).success(function (data) {
			$scope.dsNhanViens = data.items;
			$scope.currentPage = page;
		})
	}

	$scope.xoaNhanVien = function (nhanvien) {
	    var getData = angularService.XoaKhac(nhanvien.Id);
		getData.then(function (msg) {
		    location.reload();
		},
        function () {
        	alert('Loi');
        })
	}

	$scope.getNhanVienById = function () {
	    var getData = angularService.getNhanVienById(nhanvien.Id);
		getData.then(function (nv) {
			$scope.NhanVien = nv.data;
		}, function () {
			alear('Loi');
		})
	}
});

app.controller("listKhachHangCtrl", function ($scope, angularService, $http, $state) {
		var getData = angularService.DanhSachKhachHang(1);
		getData.then(function (khachhang) {
		    $scope.dsKhachHangs = khachhang.data.items;
		    $scope.pageCount = khachhang.data.pageCount;
			$scope.currentPage = 1;
		}, function () {
			console.log("Không tồn tại bản ghi");
		});

	$scope.selectPage = function (page) {
		angularService.DanhSachKhachHang(page).success(function (data) {
			$scope.dsKhachHangs = data.items;
			$scope.currentPage = page;
		})
	}

	$scope.xoaKhachHang = function (khachhang) {
	    var getData = angularService.XoaKhachHang(khachhang.Id);
		getData.then(function (msg) {
		    location.reload();
		},
        function () {
        	alert('Loi');
        })
	}

	$scope.getKhacHangById = function () {
		var getData = angularService.getKhachHangById(khachhang.Id);
		getData.then(function (kh) {
			$scope.KhachHang = kh.data;
		}, function () {
			alear('Loi');
		})
	}
});
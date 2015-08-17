//app = angular.module("myApp");

app.controller("listThuCtrl", function ($scope, angularService, $http,$state) {
	dsPhieuThu1();
	function dsPhieuThu1() {
		var getData = angularService.DanhSachPhieuThu(1);
		getData.then(function (thu) {
			angular.forEach(thu.data.items, function (item) {
				item.ThoiGianThu = parseDate(item.ThoiGianThu);
			})
			$scope.dsPhieuThus = thu.data.items;
			$scope.pageCount = thu.data.pageCount;
			$scope.currentPage = 1;
		}, function () {
			console.log("Không tồn tại bản ghi");
		});
	}

	$scope.createThu = function ()
	{
	    $state.go('createThu');
	}

	$scope.selectPage = function (page) {
		angularService.DanhSachPhieuThu(page).success(function (data) {
			angular.forEach(data.items, function (item) {
				item.ThoiGianThu = parseDate(item.ThoiGianThu);
			})
			$scope.dsPhieuThus = data.items;
			$scope.currentPage = page;
		})
	}

	$scope.xoaPhieuThu = function (phieuthu) {
		console.log(phieuthu.MaPhieuThu);
		var getData = angularService.XoaPhieuThu(phieuthu.MaPhieuThu);
		getData.then(function (msg) {
		    location.reload();
		},
        function () {
        	alert('Loi');
        })
	}

	$scope.getPhieuThuById = function () {
		console.log(phieuthu.MaPhieuThu);
		var getData = angularService.getPhieuThuById(phieuthu.MaPhieuThu);
		getData.then(function (pt) {
			$scope.PhieuThu = pt.data;
		}, function () {
			alear('Loi');
		})
	}

	var parseDate = function (value) {
		if (value) {
			return new Date(parseInt(value.replace("/Date(", "").replace(")/", "")));
		}
		return null;
	}
});

app.controller("listChiCtrl", function ($scope, angularService, $http, $state) {
		var getData = angularService.DanhSachPhieuChi(1);
		getData.then(function (chi) {
			angular.forEach(chi.data.items, function (item) {
				item.ThoiGianChi = parseDate(item.ThoiGianChi);
			})
			$scope.dsPhieuChis = chi.data.items;
			$scope.pageCount = chi.data.pageCount;
			$scope.currentPage = 1;
		}, function () {
			console.log("Không tồn tại bản ghi");
		});

	$scope.selectPage = function (page) {
		angularService.DanhSachPhieuChi(page).success(function (data) {
			angular.forEach(data.items, function (item) {
				item.ThoiGianChi = parseDate(item.ThoiGianChi);
			})
			$scope.dsPhieuChis = data.items;
			$scope.currentPage = page;
		})
	}

	$scope.xoaPhieuChi = function (phieuChi) {
		console.log(phieuChi.MaPhieuChi);
		var getData = angularService.XoaPhieuChi(phieuChi.MaPhieuChi);
		getData.then(function (msg) {
		    location.reload();
		},
        function () {
        	alert('Loi');
        })
	}

	$scope.getPhieuChiById = function () {
		console.log(phieuchi.MaPhieuChi);
		var getData = angularService.getPhieuChiById(phieuchi.MaPhieuChi);
		getData.then(function (pc) {
			$scope.PhieuChi = pc.data;
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
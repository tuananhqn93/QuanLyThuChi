
app.controller("listKhacCtrl", function ($scope, angularService, $http, $state) {
		var getData = angularService.DanhSachKhac(1);
		getData.then(function (khac) {
		    $scope.dsKhacs = khac.data.items;
		    $scope.pageCount = khac.data.pageCount;
			$scope.currentPage = 1;
		}, function () {
			console.log("Không tồn tại bản ghi");
		});

	$scope.selectPage = function (page) {
		angularService.DanhSachKhac(page).success(function (data) {
			$scope.dsKhacs = data.items;
			$scope.currentPage = page;
		})
	}

	$scope.xoaKhac = function (khac) {
	    console.log(khac.Id);
	    console.log('2');
	    var getData = angularService.XoaKhac(khac.Id);
		getData.then(function (msg) {
		    location.reload();
		},
        function () {
        	alert('Loi');
        })
	}

	$scope.getKhacById = function () {
		var getData = angularService.getKhacById(khac.Id);
		getData.then(function (kc) {
			$scope.Khac = kc.data;
		}, function () {
			alear('Loi');
		})
	}
});
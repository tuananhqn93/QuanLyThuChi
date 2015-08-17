
app.controller("listNhaCungCapCtrl", function ($scope, angularService, $http, $state) {
		var getData = angularService.DanhSachNhaCungCap(1);
		getData.then(function (nhacungcap) {
		    $scope.dsNhaCungCaps = nhacungcap.data.items;
		    $scope.pageCount = nhacungcap.data.pageCount;
			$scope.currentPage = 1;
		}, function () {
			console.log("Không tồn tại bản ghi");
		});

	$scope.selectPage = function (page) {
	    angularService.DanhSachNhaCungCap(page).success(function (data) {
			$scope.dsNhaCungCaps = data.items;
			$scope.currentPage = page;
		})
	}

	$scope.xoaNhaCungCap = function (nhacungcap) {
	    var getData = angularService.xoaNhaCungCap(nhacungcap.Id);
		getData.then(function (msg) {
		    location.reload();
		},
        function () {
        	alert('Loi');
        })
	}

	$scope.getNhaCungCapById = function () {
	    var getData = angularService.getNhaCungCapById(nhacungcap.Id);
		getData.then(function (ncc) {
			$scope.NhaCungCap = ncc.data;
		}, function () {
			alear('Loi');
		})
	}
});
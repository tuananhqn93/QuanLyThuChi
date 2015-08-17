var app = angular.module("myApp", ["ui.router"]);

app.config(function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise("/");
    $stateProvider
        .state('home', {
            url: "/",
            template: '<h1>This is home page</h1>'
        })
        .state('thu', {
            url: '/thu',
            templateUrl: 'Content/Angular/views/thu/list.html',
            controller: 'listThuCtrl'
        })
        .state('chi', {
            url: '/chi',
            templateUrl: 'Content/Angular/views/chi/list.html',
            controller: 'listChiCtrl'
        })
        .state('Khac', {
            url: '/khac',
            templateUrl: 'Content/Angular/views/khac/list.html',
            controller: 'listKhacCtrl'
        })
        .state('createKhac', {
            url: '/Khac/createKhac',
            templateUrl: 'Content/Angular/views/khac/create.html'
        })
        .state('editKhac', {
            url: '/Khac/:id',
            templateUrl: 'Content/Angular/views/khac/edit.html',
            controller: 'editKhacCtrl'
        })
        .state('KhachHang', {
            url: '/khachhang',
            templateUrl: 'Content/Angular/views/khachhang/list.html',
            controller: 'listKhachHangCtrl'
        })
        .state('createKhachHang', {
            url: '/KhachHang/createKhachHang',
            templateUrl: 'Content/Angular/views/khachhang/create.html'
        })
        .state('editKhachHang', {
            url: '/KhachHang/:id',
            templateUrl: 'Content/Angular/views/khachhang/edit.html',
            controller: 'editKhachHangCtrl'
        })
        .state('NhanVien', {
            url: '/nhanvien',
            templateUrl: 'Content/Angular/views/nhanvien/list.html',
            controller: 'listNhanVienCtrl'
        })
        .state('createNhanVien', {
            url: '/NhanVien/createNhanVien',
            templateUrl: 'Content/Angular/views/nhanvien/create.html'
        })
        .state('editNhanVien', {
            url: '/NhanVien/:id',
            templateUrl: 'Content/Angular/views/nhanvien/edit.html',
            controller: 'editNhanVienCtrl'
        })
        .state('NhaCungCap', {
            url: '/nhacungcap',
            templateUrl: 'Content/Angular/views/nhacungcap/list.html',
            controller: 'listNhaCungCapCtrl'
        })
        .state('createNhaCungCap', {
            url: '/NhaCungCap/createNhaCungCap',
            templateUrl: 'Content/Angular/views/nhacungcap/create.html'
        })
        .state('editNhaCungCap', {
            url: '/NhaCungCap/:id',
            templateUrl: 'Content/Angular/views/nhacungcap/edit.html',
            controller: 'editNhaCungCapCtrl'
        })
        .state('createChi', {
            url: '/chi/createChi',
            templateUrl: 'Content/Angular/views/chi/create.html'
        })
        .state('editChi', {
            url: '/chi/:id',
            templateUrl: 'Content/Angular/views/chi/edit.html',
            controller: 'editChiCtrl'
        })
        .state('createThu', {
            url: '/thu/createThu',
            templateUrl: 'Content/Angular/views/thu/create.html'
        })
        .state('editThu', {
            url: '/thu/:id',
            templateUrl: 'Content/Angular/views/thu/edit.html',
            controller: 'editThuCtrl'
        });
        
});

app.service("angularService", function ($http) {
    //Lay danh sach phieu thu
    this.DanhSachPhieuThu = function (page) {
        return $http.get("/Home/DanhSachPhieuThu?page=" + page)
    };

    //Lay phieu thu theo Id
    this.getPhieuThuById = function (MaPhieuThu) {
        var response = $http({
            method: "post",
            url: "/Home/getPhieuThuById?MaPhieuThu=" + MaPhieuThu,
            dataType: "json"
        });
        return response;
    }

    //Sua phieu thu
    this.SuaPhieuThu = function (MaPhieuThu) {
        var response = $http({
            method: "post",
            url: "/Home/SuaPhieuThu",
            data: { MaPhieuThu: MaPhieuThu },
            dataType: "json"
        });
        return response;
    }

    //Xoa phieu thu
    this.XoaPhieuThu = function (MaPhieuThu) {
        console.log(MaPhieuThu);
        var response = $http({
            method: "post",
            url: "/Home/XoaPhieuThu",
            data: { MaPhieuChi: MaPhieuThu },
            dataType: "json"
        });
        return response;
    }
    //Lay danh sach phieu chi
    this.DanhSachPhieuChi = function (page) {
        return $http.get("/Home/DanhSachPhieuChi?page=" + page)
    };

    //Lay phieu chi theo Id
    this.getPhieuChiById = function (MaPhieuChi) {
        var response = $http({
            method: "post",
            url: "/Home/getPhieuChiById?MaPhieuChi=" + MaPhieuChi,
            dataType: "json"
        });
        return response;
    }

    //Sua phieu chi
    this.SuaPhieuChi = function (MaPhieuChi) {
        var response = $http({
            method: "post",
            url: "/Home/SuaPhieuChi",
            data: { MaPhieuChi: MaPhieuChi },
            dataType: "json"
        });
        return response;
    }

    //Xoa phieu chi
    this.XoaPhieuChi = function (MaPhieuChi) {
        console.log(MaPhieuChi);
        var response = $http({
            method: "post",
            url: "/Home/XoaPhieuChi",
            data: { MaPhieuChi: MaPhieuChi },
            dataType: "json"
        });
        return response;
    }
    //Lay danh sach khac
    this.DanhSachKhac = function (page) {
        return $http.get("/Home/DanhSachKhac?page=" + page)
    };

    //Lay khac theo Id
    this.getKhacById = function (Id) {
        var response = $http({
            method: "post",
            url: "/Home/getKhacById?Id=" + Id,
            dataType: "json"
        });
        return response;
    }

    //Xoa khac
    this.XoaKhac = function (Id) {
        console.log(Id);
        var response = $http({
            method: "post",
            url: "/Home/XoaKhac",
            data: { Id: Id },
            dataType: "json"
        });
        return response;
    }

    //Lay danh sach khach hang
    this.DanhSachKhachHang = function (page) {
        return $http.get("/Home/DanhSachKhachHang?page=" + page)
    };

    //Lay khach hang theo Id
    this.getKhachHangById = function (Id) {
        var response = $http({
            method: "post",
            url: "/Home/getKhachHangById?Id=" + Id,
            dataType: "json"
        });
        return response;
    }

    //Xoa khach hang
    this.XoaKhachHang = function (Id) {
        var response = $http({
            method: "post",
            url: "/Home/XoaKhachHang",
            data: { Id: Id },
            dataType: "json"
        });
        return response;
    }

    //Lay danh sach nhan vien
    this.DanhSachNhanVien = function (page) {
        return $http.get("/Home/DanhSachNhanVien?page=" + page)
    };

    //Lay nhan vien theo Id
    this.getNhanVienById = function (Id) {
        var response = $http({
            method: "post",
            url: "/Home/getNhanVienById?Id=" + Id,
            dataType: "json"
        });
        return response;
    }

    //Xoa nhan vien
    this.XoaNhanVien= function (Id) {
        var response = $http({
            method: "post",
            url: "/Home/XoaNhanVien",
            data: { Id: Id },
            dataType: "json"
        });
        return response;
    }

    //Lay danh sach nha cung cap
    this.DanhSachNhaCungCap = function (page) {
        return $http.get("/Home/DanhSachNhaCungCap?page=" + page)
    };

    //Lay nha cung cap theo Id
    this.getNhaCungCapById = function (Id) {
        var response = $http({
            method: "post",
            url: "/Home/getNhaCungCapById?Id=" + Id,
            dataType: "json"
        });
        return response;
    }

    //Xoa nha cung cap
    this.XoaNhaCungCap = function (Id) {
        var response = $http({
            method: "post",
            url: "/Home/XoaNhaCungCap",
            data: { Id: Id },
            dataType: "json"
        });
        return response;
    }
});

    
using QuanLyThuChi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace QuanLyThuChi.Controllers
{
    public class HomeController : Controller
    {
        private ThuChiDbContext ThuChiobj = new ThuChiDbContext();
        public ActionResult Index()
        {
            return View();
        }

        #region Phiếu thu
        public ActionResult DanhSachPhieuThu(int page)
        {
            int pageSize = 5;
            var dsPhieuThu = ThuChiobj.PhieuThus.ToList();
            int totalCount = dsPhieuThu.Count();
            int pageCount = (int)Math.Ceiling((double)totalCount / (double)pageSize);
            var data = dsPhieuThu.Select(gd => new { MaPhieuThu = gd.MaPhieuThu, ThoiGianThu = gd.ThoiGianThu, GiaTri = gd.GiaTri, GhiChu = gd.GhiChu, NguoiTaoPhieuId = gd.NguoiTaoPhieuId, LoaiPhieu = gd.LoaiPhieu_id }).ToList();
            return Json(new { pageCount = pageCount, totalItem = totalCount, items = data.Skip((page - 1) * pageSize).Take(pageSize) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getPhieuThuById(string MaPhieuThu)
        {
            PhieuThu pt = ThuChiobj.PhieuThus.Find(MaPhieuThu);
            var data = ThuChiobj.PhieuThus.Where(g => g.MaPhieuThu == pt.MaPhieuThu).Select(thu => new { MaPhieuThu = thu.MaPhieuThu, ThoiGianThu = thu.ThoiGianThu, LoaiPhieu_id = thu.LoaiPhieu_id, NguoiTaoPhieuId = thu.NguoiTaoPhieuId, GiaTri = thu.GiaTri, GhiChu = thu.GhiChu }).FirstOrDefault();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public string TaoPhieuThu(PhieuThu phieuthu)
        {
            if (ModelState.IsValid)
            {
                ThuChiobj.PhieuThus.Add(phieuthu);
                ThuChiobj.SaveChanges();
                return "Thanh cong";
            }
            return "Khong thanh cong";
        }

        public string XoaPhieuThu(string MaPhieuThu)
        {
            PhieuThu pt = ThuChiobj.PhieuThus.Find(MaPhieuThu);
            if (pt != null)
            {
                ThuChiobj.PhieuThus.Remove(pt);
                ThuChiobj.SaveChanges();
                return "a";
            }
            else
            {
                return "c";
            }
            return "b";
        }

        [HttpPost]
        public string SuaPhieuThu(PhieuThu phieuthu, string MaPhieuThu)
        {
            PhieuThu pt = ThuChiobj.PhieuThus.Find(MaPhieuThu);
            if (ModelState.IsValid)
            {
                pt.ThoiGianThu = phieuthu.ThoiGianThu;
                pt.LoaiPhieu_id = phieuthu.LoaiPhieu_id;
                pt.NguoiTaoPhieuId = phieuthu.NguoiTaoPhieuId;
                pt.GiaTri = phieuthu.GiaTri;
                pt.GhiChu = phieuthu.GhiChu;
                ThuChiobj.Entry(pt).State = EntityState.Modified;
                ThuChiobj.SaveChanges();
                return "A";
            }
            else
            {
                return "B";
            }
            return "C";
        }

        #endregion
        #region Đối tượng khác
        // Đối tượng khác
        public ActionResult DanhSachKhac(int page)
        {
            int pageSize = 5;
            var dsKhac = ThuChiobj.NguoiTaoPhieus.Where(d => d.LoaiNguoiTaoPhieuId == 4).ToList();
            int totalCount = dsKhac.Count();
            int pageCount = (int)Math.Ceiling((double)totalCount / (double)pageSize);
            var data = dsKhac.Select(gd => new { Id=gd.Id, Ten = gd.Ten, SoDienThoai = gd.SoDienThoai, Email = gd.Email, DiaChi = gd.DiaChi }).ToList();
            return Json(new { pageCount = pageCount, totalItem = totalCount, items = data.Skip((page - 1) * pageSize).Take(pageSize) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getKhacById(int Id)
        {
            NguoiTaoPhieu pt = ThuChiobj.NguoiTaoPhieus.Find(Id);
            var data = ThuChiobj.NguoiTaoPhieus.Where(g => g.Id == pt.Id && g.LoaiNguoiTaoPhieuId == 4).Select(gd => new { Id = gd.Id, Ten = gd.Ten, SoDienThoai = gd.SoDienThoai, Email = gd.Email, DiaChi = gd.DiaChi }).FirstOrDefault();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public string TaoKhac(NguoiTaoPhieu khac)
        {
            if (ModelState.IsValid)
            {
                khac.LoaiNguoiTaoPhieuId = 4;
                ThuChiobj.NguoiTaoPhieus.Add(khac);
                ThuChiobj.SaveChanges();
                return "Thanh cong";
            }
            return "Khong thanh cong";
        }

        public string XoaKhac(int Id)
        {
            NguoiTaoPhieu khac = ThuChiobj.NguoiTaoPhieus.Find(Id);
            if (khac != null)
            {
                ThuChiobj.NguoiTaoPhieus.Remove(khac);
                ThuChiobj.SaveChanges();
                return "a";
            }
            else
            {
                return "c";
            }
            return "b";
        }

        [HttpPost]
        public string SuaKhac(NguoiTaoPhieu khac, int Id)
        {
            NguoiTaoPhieu kc = ThuChiobj.NguoiTaoPhieus.Find(Id);
            if( ModelState.IsValid)
            {
                kc.LoaiNguoiTaoPhieuId = 4;
                kc.Ten = khac.Ten;
                kc.SoDienThoai = khac.SoDienThoai;
                kc.Email = khac.Email;
                kc.DiaChi = khac.DiaChi;
                ThuChiobj.Entry(kc).State = EntityState.Modified;
                ThuChiobj.SaveChanges();
                return "A";
            }
            return "B";
        }

        #endregion
        #region Khách hàng
        //Khách hàng
        public ActionResult DanhSachKhachHang(int page)
        {
            int pageSize = 5;
            var dsKhachHang = ThuChiobj.NguoiTaoPhieus.Where(d => d.LoaiNguoiTaoPhieuId == 2).ToList();
            int totalCount = dsKhachHang.Count();
            int pageCount = (int)Math.Ceiling((double)totalCount / (double)pageSize);
            var data = dsKhachHang.Select(gd => new { Id = gd.Id, Ten = gd.Ten, SoDienThoai = gd.SoDienThoai, Email = gd.Email, DiaChi = gd.DiaChi }).ToList();
            return Json(new { pageCount = pageCount, totalItem = totalCount, items = data.Skip((page - 1) * pageSize).Take(pageSize) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getKhachHangById(int Id)
        {
            NguoiTaoPhieu pt = ThuChiobj.NguoiTaoPhieus.Find(Id);
            var data = ThuChiobj.NguoiTaoPhieus.Where(g => g.Id == pt.Id && g.LoaiNguoiTaoPhieuId == 2).Select(gd => new { Id = gd.Id, Ten = gd.Ten, SoDienThoai = gd.SoDienThoai, Email = gd.Email, DiaChi = gd.DiaChi }).FirstOrDefault();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public string TaoKhachHang(NguoiTaoPhieu khachhang)
        {
            if (ModelState.IsValid)
            {
                khachhang.LoaiNguoiTaoPhieuId = 2;
                ThuChiobj.NguoiTaoPhieus.Add(khachhang);
                ThuChiobj.SaveChanges();
                return "Thanh cong";
            }
            return "Khong thanh cong";
        }

        public string XoaKhachHang(int Id)
        {
            NguoiTaoPhieu khachhang = ThuChiobj.NguoiTaoPhieus.Find(Id);
            if (khachhang != null)
            {
                ThuChiobj.NguoiTaoPhieus.Remove(khachhang);
                ThuChiobj.SaveChanges();
                return "a";
            }
            else
            {
                return "c";
            }
            return "b";
        }

        [HttpPost]
        public string SuaKhachHang(NguoiTaoPhieu khachhang, int Id)
        {
            NguoiTaoPhieu kh = ThuChiobj.NguoiTaoPhieus.Find(Id);
            if (ModelState.IsValid)
            {
                kh.LoaiNguoiTaoPhieuId = 2;
                kh.Ten = khachhang.Ten;
                kh.SoDienThoai = khachhang.SoDienThoai;
                kh.Email = khachhang.Email;
                kh.DiaChi = khachhang.DiaChi;
                ThuChiobj.Entry(kh).State = EntityState.Modified;
                ThuChiobj.SaveChanges();
                return "A";
            }
            return "B";
        }

        #endregion
        #region Nhân viên
        //Nhân viên
        public ActionResult DanhSachNhanVien(int page)
        {
            int pageSize = 5;
            var dsNhanVien = ThuChiobj.NguoiTaoPhieus.Where(d => d.LoaiNguoiTaoPhieuId == 1).ToList();
            int totalCount = dsNhanVien.Count();
            int pageCount = (int)Math.Ceiling((double)totalCount / (double)pageSize);
            var data = dsNhanVien.Select(gd => new { Id = gd.Id, Ten = gd.Ten, SoDienThoai = gd.SoDienThoai, Email = gd.Email, DiaChi = gd.DiaChi }).ToList();
            return Json(new { pageCount = pageCount, totalItem = totalCount, items = data.Skip((page - 1) * pageSize).Take(pageSize) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getNhanVienById(int Id)
        {
            NguoiTaoPhieu pt = ThuChiobj.NguoiTaoPhieus.Find(Id);
            var data = ThuChiobj.NguoiTaoPhieus.Where(g => g.Id == pt.Id && g.LoaiNguoiTaoPhieuId == 1).Select(gd => new { Id = gd.Id, Ten = gd.Ten, SoDienThoai = gd.SoDienThoai, Email = gd.Email, DiaChi = gd.DiaChi }).FirstOrDefault();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public string TaoNhanVien(NguoiTaoPhieu nhanvien)
        {
            if (ModelState.IsValid)
            {
                nhanvien.LoaiNguoiTaoPhieuId = 1;
                ThuChiobj.NguoiTaoPhieus.Add(nhanvien);
                ThuChiobj.SaveChanges();
                return "Thanh cong";
            }
            return "Khong thanh cong";
        }
        public string XoaNhanVien(int Id)
        {
            NguoiTaoPhieu nhanvien = ThuChiobj.NguoiTaoPhieus.Find(Id);
            if (nhanvien != null)
            {
                ThuChiobj.NguoiTaoPhieus.Remove(nhanvien);
                ThuChiobj.SaveChanges();
                return "a";
            }
            else
            {
                return "c";
            }
            return "b";
        }

        [HttpPost]
        public string SuaNhanVien(NguoiTaoPhieu nhanvien, int Id)
        {
            NguoiTaoPhieu nv = ThuChiobj.NguoiTaoPhieus.Find(Id);
            if (ModelState.IsValid)
            {
                nv.LoaiNguoiTaoPhieuId = 1;
                nv.Ten = nhanvien.Ten;
                nv.SoDienThoai = nhanvien.SoDienThoai;
                nv.Email = nhanvien.Email;
                nv.DiaChi = nhanvien.DiaChi;
                ThuChiobj.Entry(nv).State = EntityState.Modified;
                ThuChiobj.SaveChanges();
                return "A";
            }
            return "B";
        }
        #endregion
        #region Nhà cung cấp
        //Nhà cung cấp
        public ActionResult DanhSachNhaCungCap(int page)
        {
            int pageSize = 5;
            var dsNhaCungCap = ThuChiobj.NguoiTaoPhieus.Where(d => d.LoaiNguoiTaoPhieuId == 3).ToList();
            int totalCount = dsNhaCungCap.Count();
            int pageCount = (int)Math.Ceiling((double)totalCount / (double)pageSize);
            var data = dsNhaCungCap.Select(gd => new { Id = gd.Id, Ten = gd.Ten, SoDienThoai = gd.SoDienThoai, Email = gd.Email, DiaChi = gd.DiaChi }).ToList();
            return Json(new { pageCount = pageCount, totalItem = totalCount, items = data.Skip((page - 1) * pageSize).Take(pageSize) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getNhaCungCapById(int Id)
        {
            NguoiTaoPhieu ncc = ThuChiobj.NguoiTaoPhieus.Find(Id);
            var data = ThuChiobj.NguoiTaoPhieus.Where(g => g.Id == ncc.Id && g.LoaiNguoiTaoPhieuId == 1).Select(gd => new { Id = gd.Id, Ten = gd.Ten, SoDienThoai = gd.SoDienThoai, Email = gd.Email, DiaChi = gd.DiaChi }).FirstOrDefault();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public string TaoNhaCungCap(NguoiTaoPhieu nhacungcap)
        {
            if (ModelState.IsValid)
            {
                nhacungcap.LoaiNguoiTaoPhieuId = 3;
                ThuChiobj.NguoiTaoPhieus.Add(nhacungcap);
                ThuChiobj.SaveChanges();
                return "Thanh cong";
            }
            return "Khong thanh cong";
        }
        public string XoaNhaCungCap(int Id)
        {
            NguoiTaoPhieu nhacungcap = ThuChiobj.NguoiTaoPhieus.Find(Id);
            if (nhacungcap != null)
            {
                ThuChiobj.NguoiTaoPhieus.Remove(nhacungcap);
                ThuChiobj.SaveChanges();
                return "a";
            }
            else
            {
                return "c";
            }
            return "b";
        }

        [HttpPost]
        public string SuaNhaCungCap(NguoiTaoPhieu nhacungcap, int Id)
        {
            NguoiTaoPhieu ncc = ThuChiobj.NguoiTaoPhieus.Find(Id);
            if (ModelState.IsValid)
            {
                ncc.LoaiNguoiTaoPhieuId = 1;
                ncc.Ten = nhacungcap.Ten;
                ncc.SoDienThoai = nhacungcap.SoDienThoai;
                ncc.Email = nhacungcap.Email;
                ncc.DiaChi = nhacungcap.DiaChi;
                ThuChiobj.Entry(ncc).State = EntityState.Modified;
                ThuChiobj.SaveChanges();
                return "A";
            }
            return "B";
        }
        #endregion
        #region Phiếu chi
        //Phiếu chi
        public ActionResult DanhSachPhieuChi(int page)
        {
            int pageSize = 5;
            var dsPhieuChi = ThuChiobj.PhieuChis.ToList();
            int totalCount = dsPhieuChi.Count();
            int pageCount = (int)Math.Ceiling((double)totalCount / (double)pageSize);
            var data = dsPhieuChi.Select(gd => new { MaPhieuChi = gd.MaPhieuChi, ThoiGianChi = gd.ThoiGianChi, GiaTri = gd.GiaTri, GhiChu = gd.GhiChu, NguoiTaoPhieuId = gd.NguoiTaoPhieuId, LoaiPhieu = gd.LoaiPhieu_id }).ToList(); ;
            return Json(new { pageCount = pageCount, totalItem = totalCount, items = data.Skip((page - 1) * pageSize).Take(pageSize) }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public string TaoPhieuChi(PhieuChi phieuchi)
        {
            if(ModelState.IsValid)
            
            {
                PhieuChi pc = new PhieuChi();
                pc.MaPhieuChi = phieuchi.MaPhieuChi;
                pc.ThoiGianChi = phieuchi.ThoiGianChi;
                pc.LoaiPhieu_id = phieuchi.LoaiPhieu_id;
                pc.LoaiNguoiTaoPhieuId = phieuchi.LoaiNguoiTaoPhieuId;
                pc.NguoiTaoPhieuId = phieuchi.NguoiTaoPhieuId;
                pc.GiaTri = phieuchi.GiaTri;
                pc.GhiChu = phieuchi.GhiChu;
                ThuChiobj.PhieuChis.Add(phieuchi);
                ThuChiobj.SaveChanges();
                return "Thanh cong";
            }
            return "Khong thanh cong";
        }

        [HttpPost]
        public string SuaPhieuChi(PhieuChi phieuchi, string MaPhieuChi)
        {
            PhieuChi pc = ThuChiobj.PhieuChis.Find(MaPhieuChi);
            if (ModelState.IsValid)
            {
                pc.ThoiGianChi = phieuchi.ThoiGianChi;
                pc.LoaiPhieu_id = phieuchi.LoaiPhieu_id;
                pc.NguoiTaoPhieuId = phieuchi.NguoiTaoPhieuId;
                pc.LoaiNguoiTaoPhieuId = phieuchi.LoaiNguoiTaoPhieuId;
                pc.GiaTri = phieuchi.GiaTri;
                pc.GhiChu = phieuchi.GhiChu;
                ThuChiobj.Entry(pc).State = EntityState.Modified;
                ThuChiobj.SaveChanges();
                return "A";
            }
            else
            {
                return "B";
            }
            return "C";
        }

        
        public string XoaPhieuChi(string MaPhieuChi)
        {
            PhieuChi pc = ThuChiobj.PhieuChis.Find(MaPhieuChi);
            if(pc != null)
            {
                ThuChiobj.PhieuChis.Remove(pc);
                ThuChiobj.SaveChanges();
                return "a";
            }
            else
            {
                return "c";
            }
            return "b";
        }

        public ActionResult getPhieuChiById(string MaPhieuChi)
        {
            PhieuChi pc = ThuChiobj.PhieuChis.Find(MaPhieuChi);
            var data = ThuChiobj.PhieuChis.Where(g => g.MaPhieuChi == pc.MaPhieuChi).Select(chi => new { MaPhieuChi = chi.MaPhieuChi, ThoiGianChi = chi.ThoiGianChi, LoaiPhieu_id = chi.LoaiPhieu_id,LoaiNguoiTaoPhieuId = chi.LoaiNguoiTaoPhieuId, NguoiTaoPhieuId = chi.NguoiTaoPhieuId, GiaTri = chi.GiaTri, GhiChu = chi.GhiChu }).FirstOrDefault();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getNguoiTaoPhieuByLoaiNguoiDung(int LoaiNguoiTaoPhieuId)
        {
            var data = ThuChiobj.NguoiTaoPhieus.Where(g => g.LoaiNguoiTaoPhieuId == LoaiNguoiTaoPhieuId).Select(c => new { Id = c.Id }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getDanhSachNguoiDung(NguoiTaoPhieu nguoitaophieu)
        {
            var data = ThuChiobj.NguoiTaoPhieus.Where(g => g.Id == nguoitaophieu.Id).Select(c => new { Id = c.Id, Ten = c.Ten, DiaChi = c.DiaChi, Email = c.Email, SoDienThoai = c.SoDienThoai, LoaiNguoiTaoPhieuId = c.LoaiNguoiTaoPhieuId }).FirstOrDefault();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        #endregion

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ThuChiobj.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
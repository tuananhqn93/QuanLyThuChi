using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;


namespace QuanLyThuChi.Models
{
    public class PhieuThu
    {
        [Key]
        public string MaPhieuThu { get; set; }
        public DateTime ThoiGianThu { get; set; }
        public int GiaTri { get; set; }
        public string GhiChu { get; set; }
        [ForeignKey("NguoiTaoPhieu")]
        public int NguoiTaoPhieuId { get; set; }
        [ForeignKey("LoaiPhieu")]
        public string LoaiPhieu_id { get; set; }
        public int LoaiNguoiTaoPhieuId { get; set; }
        public virtual NguoiTaoPhieu NguoiTaoPhieu { get; set; }
        public virtual LoaiPhieu LoaiPhieu { get; set; }
    }
    public class PhieuChi
    {
        [Key]
        public string MaPhieuChi { get; set; }
        public DateTime ThoiGianChi { get; set; }
        public int GiaTri { get; set; }
        public string GhiChu { get; set; }
        [ForeignKey("NguoiTaoPhieu")]
        public int NguoiTaoPhieuId { get; set; }
        [ForeignKey("LoaiPhieu")]
        public string LoaiPhieu_id { get; set; }
        public int LoaiNguoiTaoPhieuId { get; set; }
        public virtual NguoiTaoPhieu NguoiTaoPhieu { get; set; }
        public virtual LoaiPhieu LoaiPhieu { get; set; }
    }

    public class NguoiTaoPhieu
    {
        [Key]
        public int Id { get; set; }
        public string Ten { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        [ForeignKey("LoaiNguoiDung")]
        public int LoaiNguoiTaoPhieuId { get; set; }
        public virtual ICollection<PhieuChi> PhieuChi { get; set; }
        public virtual ICollection<PhieuThu> PhieuThu { get; set; }
        public virtual LoaiNguoiDung LoaiNguoiDung {get;set;}
    }

    public class LoaiNguoiDung
    {
        [Key]
        public int Id { get; set; }
        public string TenLoaiNguoiDung { get; set; }
        public virtual ICollection<NguoiTaoPhieu> NguoiTaoPhieu { get; set; }
    }
    public class LoaiPhieu
    {
        [Key]
        public string Id { get; set; }
        public string TenPhieu { get; set; }
        public virtual ICollection<PhieuChi> PhieuChi { get; set; }
        public virtual ICollection<PhieuThu> PhieuThu { get; set; }
    }
    public class ThuChiDbContext : DbContext
    {

        public ThuChiDbContext() : base("ThuChiDbContext") { }

        public DbSet<PhieuThu> PhieuThus { get; set; }
        public DbSet<PhieuChi> PhieuChis { get; set; }
        public DbSet<NguoiTaoPhieu> NguoiTaoPhieus { get; set; }
        public DbSet<LoaiPhieu> LoaiPhieus { get; set; }
        public DbSet<LoaiNguoiDung> LoaiNguoiDungs { get; set; }

    }
}
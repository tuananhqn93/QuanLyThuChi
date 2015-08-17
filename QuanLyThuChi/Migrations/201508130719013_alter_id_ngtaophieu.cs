namespace QuanLyThuChi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alter_id_ngtaophieu : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.NguoiTaoPhieux", "MaKhachHang");
            DropColumn("dbo.NguoiTaoPhieux", "MaKhac");
            DropColumn("dbo.NguoiTaoPhieux", "MaNhaCungCap");
            DropColumn("dbo.NguoiTaoPhieux", "MaNhanVien");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NguoiTaoPhieux", "MaNhanVien", c => c.Int());
            AddColumn("dbo.NguoiTaoPhieux", "MaNhaCungCap", c => c.Int());
            AddColumn("dbo.NguoiTaoPhieux", "MaKhac", c => c.Int());
            AddColumn("dbo.NguoiTaoPhieux", "MaKhachHang", c => c.Int());
        }
    }
}

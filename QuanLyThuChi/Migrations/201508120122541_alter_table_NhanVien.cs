namespace QuanLyThuChi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alter_table_NhanVien : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NguoiTaoPhieux", "Email", c => c.String());
            AddColumn("dbo.NguoiTaoPhieux", "DiaChi", c => c.String());
            AddColumn("dbo.NguoiTaoPhieux", "MaKhac", c => c.String());
            AddColumn("dbo.NguoiTaoPhieux", "MaKhachHang", c => c.String());
            AddColumn("dbo.NguoiTaoPhieux", "MaNhaCungCap", c => c.String());
            AddColumn("dbo.NguoiTaoPhieux", "MaNhanVien", c => c.String());
            AddColumn("dbo.NguoiTaoPhieux", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.NguoiTaoPhieux", "Discriminator");
            DropColumn("dbo.NguoiTaoPhieux", "MaNhanVien");
            DropColumn("dbo.NguoiTaoPhieux", "MaNhaCungCap");
            DropColumn("dbo.NguoiTaoPhieux", "MaKhachHang");
            DropColumn("dbo.NguoiTaoPhieux", "MaKhac");
            DropColumn("dbo.NguoiTaoPhieux", "DiaChi");
            DropColumn("dbo.NguoiTaoPhieux", "Email");
        }
    }
}

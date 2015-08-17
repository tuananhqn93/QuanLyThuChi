namespace QuanLyThuChi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alter_ThuChiLoai : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhieuChis", "LoaiNguoiTaoPhieuId", c => c.Int(nullable: false));
            AddColumn("dbo.PhieuThus", "LoaiNguoiTaoPhieuId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhieuThus", "LoaiNguoiTaoPhieuId");
            DropColumn("dbo.PhieuChis", "LoaiNguoiTaoPhieuId");
        }
    }
}

namespace QuanLyThuChi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alter_table_MaNguoiDung : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PhieuChis", "IdNguoiTaoPhieu", "dbo.NguoiTaoPhieux");
            DropForeignKey("dbo.PhieuThus", "IdNguoiTaoPhieu", "dbo.NguoiTaoPhieux");
            DropIndex("dbo.PhieuChis", new[] { "IdNguoiTaoPhieu" });
            DropIndex("dbo.PhieuThus", new[] { "IdNguoiTaoPhieu" });
            DropPrimaryKey("dbo.NguoiTaoPhieux");
            AlterColumn("dbo.NguoiTaoPhieux", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.NguoiTaoPhieux", "MaKhachHang", c => c.Int());
            AlterColumn("dbo.NguoiTaoPhieux", "MaKhac", c => c.Int());
            AlterColumn("dbo.NguoiTaoPhieux", "MaNhaCungCap", c => c.Int());
            AlterColumn("dbo.NguoiTaoPhieux", "MaNhanVien", c => c.Int());
            AlterColumn("dbo.PhieuChis", "IdNguoiTaoPhieu", c => c.Int(nullable: false));
            AlterColumn("dbo.PhieuThus", "IdNguoiTaoPhieu", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.NguoiTaoPhieux", "Id");
            CreateIndex("dbo.PhieuChis", "IdNguoiTaoPhieu");
            CreateIndex("dbo.PhieuThus", "IdNguoiTaoPhieu");
            AddForeignKey("dbo.PhieuChis", "IdNguoiTaoPhieu", "dbo.NguoiTaoPhieux", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PhieuThus", "IdNguoiTaoPhieu", "dbo.NguoiTaoPhieux", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhieuThus", "IdNguoiTaoPhieu", "dbo.NguoiTaoPhieux");
            DropForeignKey("dbo.PhieuChis", "IdNguoiTaoPhieu", "dbo.NguoiTaoPhieux");
            DropIndex("dbo.PhieuThus", new[] { "IdNguoiTaoPhieu" });
            DropIndex("dbo.PhieuChis", new[] { "IdNguoiTaoPhieu" });
            DropPrimaryKey("dbo.NguoiTaoPhieux");
            AlterColumn("dbo.PhieuThus", "IdNguoiTaoPhieu", c => c.String(maxLength: 128));
            AlterColumn("dbo.PhieuChis", "IdNguoiTaoPhieu", c => c.String(maxLength: 128));
            AlterColumn("dbo.NguoiTaoPhieux", "MaNhanVien", c => c.String());
            AlterColumn("dbo.NguoiTaoPhieux", "MaNhaCungCap", c => c.String());
            AlterColumn("dbo.NguoiTaoPhieux", "MaKhac", c => c.String());
            AlterColumn("dbo.NguoiTaoPhieux", "MaKhachHang", c => c.String());
            AlterColumn("dbo.NguoiTaoPhieux", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.NguoiTaoPhieux", "Id");
            CreateIndex("dbo.PhieuThus", "IdNguoiTaoPhieu");
            CreateIndex("dbo.PhieuChis", "IdNguoiTaoPhieu");
            AddForeignKey("dbo.PhieuThus", "IdNguoiTaoPhieu", "dbo.NguoiTaoPhieux", "Id");
            AddForeignKey("dbo.PhieuChis", "IdNguoiTaoPhieu", "dbo.NguoiTaoPhieux", "Id");
        }
    }
}

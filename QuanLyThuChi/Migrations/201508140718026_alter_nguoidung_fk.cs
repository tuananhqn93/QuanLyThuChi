namespace QuanLyThuChi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alter_nguoidung_fk : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PhieuChis", "IdLoaiNguoiDung", "dbo.LoaiNguoiDungs");
            DropForeignKey("dbo.PhieuThus", "IdLoaiNguoiDung", "dbo.LoaiNguoiDungs");
            DropForeignKey("dbo.PhieuChis", "NguoiTaoPhieu_Id", "dbo.NguoiTaoPhieux");
            DropForeignKey("dbo.PhieuThus", "NguoiTaoPhieu_Id", "dbo.NguoiTaoPhieux");
            DropIndex("dbo.PhieuChis", new[] { "IdLoaiNguoiDung" });
            DropIndex("dbo.PhieuChis", new[] { "NguoiTaoPhieu_Id" });
            DropIndex("dbo.PhieuThus", new[] { "IdLoaiNguoiDung" });
            DropIndex("dbo.PhieuThus", new[] { "NguoiTaoPhieu_Id" });
            RenameColumn(table: "dbo.PhieuChis", name: "NguoiTaoPhieu_Id", newName: "NguoiTaoPhieuId");
            RenameColumn(table: "dbo.PhieuThus", name: "NguoiTaoPhieu_Id", newName: "NguoiTaoPhieuId");
            AlterColumn("dbo.PhieuChis", "NguoiTaoPhieuId", c => c.Int(nullable: false));
            AlterColumn("dbo.PhieuThus", "NguoiTaoPhieuId", c => c.Int(nullable: false));
            CreateIndex("dbo.PhieuChis", "NguoiTaoPhieuId");
            CreateIndex("dbo.PhieuThus", "NguoiTaoPhieuId");
            AddForeignKey("dbo.PhieuChis", "NguoiTaoPhieuId", "dbo.NguoiTaoPhieux", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PhieuThus", "NguoiTaoPhieuId", "dbo.NguoiTaoPhieux", "Id", cascadeDelete: true);
            DropColumn("dbo.PhieuChis", "IdLoaiNguoiDung");
            DropColumn("dbo.PhieuThus", "IdLoaiNguoiDung");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PhieuThus", "IdLoaiNguoiDung", c => c.Int(nullable: false));
            AddColumn("dbo.PhieuChis", "IdLoaiNguoiDung", c => c.Int(nullable: false));
            DropForeignKey("dbo.PhieuThus", "NguoiTaoPhieuId", "dbo.NguoiTaoPhieux");
            DropForeignKey("dbo.PhieuChis", "NguoiTaoPhieuId", "dbo.NguoiTaoPhieux");
            DropIndex("dbo.PhieuThus", new[] { "NguoiTaoPhieuId" });
            DropIndex("dbo.PhieuChis", new[] { "NguoiTaoPhieuId" });
            AlterColumn("dbo.PhieuThus", "NguoiTaoPhieuId", c => c.Int());
            AlterColumn("dbo.PhieuChis", "NguoiTaoPhieuId", c => c.Int());
            RenameColumn(table: "dbo.PhieuThus", name: "NguoiTaoPhieuId", newName: "NguoiTaoPhieu_Id");
            RenameColumn(table: "dbo.PhieuChis", name: "NguoiTaoPhieuId", newName: "NguoiTaoPhieu_Id");
            CreateIndex("dbo.PhieuThus", "NguoiTaoPhieu_Id");
            CreateIndex("dbo.PhieuThus", "IdLoaiNguoiDung");
            CreateIndex("dbo.PhieuChis", "NguoiTaoPhieu_Id");
            CreateIndex("dbo.PhieuChis", "IdLoaiNguoiDung");
            AddForeignKey("dbo.PhieuThus", "NguoiTaoPhieu_Id", "dbo.NguoiTaoPhieux", "Id");
            AddForeignKey("dbo.PhieuChis", "NguoiTaoPhieu_Id", "dbo.NguoiTaoPhieux", "Id");
            AddForeignKey("dbo.PhieuThus", "IdLoaiNguoiDung", "dbo.LoaiNguoiDungs", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PhieuChis", "IdLoaiNguoiDung", "dbo.LoaiNguoiDungs", "Id", cascadeDelete: true);
        }
    }
}

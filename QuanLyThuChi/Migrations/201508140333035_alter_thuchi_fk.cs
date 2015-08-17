namespace QuanLyThuChi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alter_thuchi_fk : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PhieuChis", "IdNguoiTaoPhieu", "dbo.NguoiTaoPhieux");
            DropForeignKey("dbo.PhieuThus", "IdNguoiTaoPhieu", "dbo.NguoiTaoPhieux");
            DropIndex("dbo.PhieuChis", new[] { "IdNguoiTaoPhieu" });
            DropIndex("dbo.PhieuThus", new[] { "IdNguoiTaoPhieu" });
            RenameColumn(table: "dbo.PhieuChis", name: "IdNguoiTaoPhieu", newName: "NguoiTaoPhieu_Id");
            RenameColumn(table: "dbo.PhieuThus", name: "IdNguoiTaoPhieu", newName: "NguoiTaoPhieu_Id");
            AddColumn("dbo.PhieuChis", "IdLoaiNguoiDung", c => c.Int(nullable: false));
            AddColumn("dbo.PhieuThus", "IdLoaiNguoiDung", c => c.Int(nullable: false));
            AlterColumn("dbo.PhieuChis", "NguoiTaoPhieu_Id", c => c.Int());
            AlterColumn("dbo.PhieuThus", "NguoiTaoPhieu_Id", c => c.Int());
            CreateIndex("dbo.PhieuChis", "IdLoaiNguoiDung");
            CreateIndex("dbo.PhieuChis", "NguoiTaoPhieu_Id");
            CreateIndex("dbo.PhieuThus", "IdLoaiNguoiDung");
            CreateIndex("dbo.PhieuThus", "NguoiTaoPhieu_Id");
            AddForeignKey("dbo.PhieuChis", "IdLoaiNguoiDung", "dbo.LoaiNguoiDungs", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PhieuThus", "IdLoaiNguoiDung", "dbo.LoaiNguoiDungs", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PhieuChis", "NguoiTaoPhieu_Id", "dbo.NguoiTaoPhieux", "Id");
            AddForeignKey("dbo.PhieuThus", "NguoiTaoPhieu_Id", "dbo.NguoiTaoPhieux", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhieuThus", "NguoiTaoPhieu_Id", "dbo.NguoiTaoPhieux");
            DropForeignKey("dbo.PhieuChis", "NguoiTaoPhieu_Id", "dbo.NguoiTaoPhieux");
            DropForeignKey("dbo.PhieuThus", "IdLoaiNguoiDung", "dbo.LoaiNguoiDungs");
            DropForeignKey("dbo.PhieuChis", "IdLoaiNguoiDung", "dbo.LoaiNguoiDungs");
            DropIndex("dbo.PhieuThus", new[] { "NguoiTaoPhieu_Id" });
            DropIndex("dbo.PhieuThus", new[] { "IdLoaiNguoiDung" });
            DropIndex("dbo.PhieuChis", new[] { "NguoiTaoPhieu_Id" });
            DropIndex("dbo.PhieuChis", new[] { "IdLoaiNguoiDung" });
            AlterColumn("dbo.PhieuThus", "NguoiTaoPhieu_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.PhieuChis", "NguoiTaoPhieu_Id", c => c.Int(nullable: false));
            DropColumn("dbo.PhieuThus", "IdLoaiNguoiDung");
            DropColumn("dbo.PhieuChis", "IdLoaiNguoiDung");
            RenameColumn(table: "dbo.PhieuThus", name: "NguoiTaoPhieu_Id", newName: "IdNguoiTaoPhieu");
            RenameColumn(table: "dbo.PhieuChis", name: "NguoiTaoPhieu_Id", newName: "IdNguoiTaoPhieu");
            CreateIndex("dbo.PhieuThus", "IdNguoiTaoPhieu");
            CreateIndex("dbo.PhieuChis", "IdNguoiTaoPhieu");
            AddForeignKey("dbo.PhieuThus", "IdNguoiTaoPhieu", "dbo.NguoiTaoPhieux", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PhieuChis", "IdNguoiTaoPhieu", "dbo.NguoiTaoPhieux", "Id", cascadeDelete: true);
        }
    }
}

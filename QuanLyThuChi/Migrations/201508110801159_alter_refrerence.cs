namespace QuanLyThuChi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alter_refrerence : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.PhieuChis", new[] { "LoaiPhieu_Id" });
            DropIndex("dbo.PhieuThus", new[] { "LoaiPhieu_Id" });
            CreateIndex("dbo.PhieuChis", "LoaiPhieu_id");
            CreateIndex("dbo.PhieuThus", "LoaiPhieu_id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.PhieuThus", new[] { "LoaiPhieu_id" });
            DropIndex("dbo.PhieuChis", new[] { "LoaiPhieu_id" });
            CreateIndex("dbo.PhieuThus", "LoaiPhieu_Id");
            CreateIndex("dbo.PhieuChis", "LoaiPhieu_Id");
        }
    }
}

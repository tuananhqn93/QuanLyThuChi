namespace QuanLyThuChi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alter_LoaiNguoiDung : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoaiNguoiDungs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenLoaiNguoiDung = c.String(),
                        NguoiTaoPhieu_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NguoiTaoPhieux", t => t.NguoiTaoPhieu_Id)
                .Index(t => t.NguoiTaoPhieu_Id);
            
            AddColumn("dbo.NguoiTaoPhieux", "IdLoaiNguoiDung", c => c.Int(nullable: false));
            DropColumn("dbo.NguoiTaoPhieux", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NguoiTaoPhieux", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.LoaiNguoiDungs", "NguoiTaoPhieu_Id", "dbo.NguoiTaoPhieux");
            DropIndex("dbo.LoaiNguoiDungs", new[] { "NguoiTaoPhieu_Id" });
            DropColumn("dbo.NguoiTaoPhieux", "IdLoaiNguoiDung");
            DropTable("dbo.LoaiNguoiDungs");
        }
    }
}

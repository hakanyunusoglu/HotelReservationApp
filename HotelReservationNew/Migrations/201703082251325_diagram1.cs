namespace HotelReservationNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class diagram1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        Mail = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Recovery_Code = c.String(),
                        LastLogin = c.DateTime(),
                        AddDate = c.DateTime(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.User");
        }
    }
}

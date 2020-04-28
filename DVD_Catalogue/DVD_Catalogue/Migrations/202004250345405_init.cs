namespace DVD_Catalogue.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dvds",
                c => new
                    {
                        DvdId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ReleaseYear = c.Short(nullable: false),
                        Director = c.String(),
                        RatingId = c.String(maxLength: 5),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.DvdId)
                .ForeignKey("dbo.Ratings", t => t.RatingId)
                .Index(t => t.RatingId);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        RatingId = c.String(nullable: false, maxLength: 5),
                        RatingDescription = c.String(),
                    })
                .PrimaryKey(t => t.RatingId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dvds", "RatingId", "dbo.Ratings");
            DropIndex("dbo.Dvds", new[] { "RatingId" });
            DropTable("dbo.Ratings");
            DropTable("dbo.Dvds");
        }
    }
}

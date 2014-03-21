namespace MvcSimpleMovieApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddToMovieTable1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "Genre", c => c.String());
            AddColumn("dbo.Movies", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Price");
            DropColumn("dbo.Movies", "Genre");
            DropColumn("dbo.Movies", "ReleaseDate");
        }
    }
}

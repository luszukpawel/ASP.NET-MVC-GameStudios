namespace GamesStudios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGameGenreConn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "DownloadLink", c => c.String());
            AddColumn("dbo.Games", "Description", c => c.String());
            AddColumn("dbo.Games", "GenreId", c => c.Int(nullable: false));
            CreateIndex("dbo.Games", "GenreId");
            AddForeignKey("dbo.Games", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "GenreId", "dbo.Genres");
            DropIndex("dbo.Games", new[] { "GenreId" });
            DropColumn("dbo.Games", "GenreId");
            DropColumn("dbo.Games", "Description");
            DropColumn("dbo.Games", "DownloadLink");
        }
    }
}

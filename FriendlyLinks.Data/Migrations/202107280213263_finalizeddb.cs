namespace FriendlyLinks.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class finalizeddb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GolfCourse", "Info", c => c.String(nullable: false));
            AddColumn("dbo.Golfer", "OwnerId", c => c.Guid(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Golfer", "OwnerId");
            DropColumn("dbo.GolfCourse", "Info");
        }
    }
}
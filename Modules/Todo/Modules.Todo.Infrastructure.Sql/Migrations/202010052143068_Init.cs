namespace Modules.Todo.Infrastructure.Sql.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Todoes",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    Description = c.String(),
                    FinishedOn = c.DateTime(),
                    IsActive = c.Boolean(nullable: false),
                    On = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsActive);

        }

        public override void Down()
        {
            DropIndex("dbo.Todoes", new[] { "IsActive" });
            DropTable("dbo.Todoes");
        }
    }
}

namespace Modules.Todo.Infrastructure.Sql.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AdjustActiveFieldsToCompleted : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Todoes", new[] { "IsActive" });
            AddColumn("dbo.Todoes", "CompletedOn", c => c.DateTime());
            AddColumn("dbo.Todoes", "IsCompleted", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Todoes", "IsCompleted");
            DropColumn("dbo.Todoes", "FinishedOn");
            DropColumn("dbo.Todoes", "IsActive");

            Sql("UPDATE dbo.Todoes SET IsCompleted = (1 ^ IsCompleted) ");
        }

        public override void Down()
        {
            AddColumn("dbo.Todoes", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Todoes", "FinishedOn", c => c.DateTime());
            DropIndex("dbo.Todoes", new[] { "IsCompleted" });
            DropColumn("dbo.Todoes", "IsCompleted");
            DropColumn("dbo.Todoes", "CompletedOn");
            CreateIndex("dbo.Todoes", "IsActive");

            Sql("UPDATE dbo.Todoes SET IsActive =(1 ^ IsActive)");

        }
    }
}

// <auto-generated />
namespace Modules.Todo.Infrastructure.Sql.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.2.0-61023")]
    public sealed partial class AdjustActiveFieldsToCompleted : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(AdjustActiveFieldsToCompleted));
        
        string IMigrationMetadata.Id
        {
            get { return "202010060101498_AdjustActiveFieldsToCompleted"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}
